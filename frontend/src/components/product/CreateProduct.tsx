import { yupResolver } from '@hookform/resolvers/yup';
import React, { useEffect, useState } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Col, Container, Modal, Row, Form, Nav } from 'react-bootstrap';

import { useAppDispatch } from '../../hooks/reduxHooks';
import { NavLink, useNavigate } from 'react-router-dom';
import { CreateProductType } from '../../types/product';
import { createProduct } from '../../redux/method/productMethod';
import axiosInstance from '../../common/axiosIntsance';
import { productSchema } from '../../formValidation/productSchema';

const CreateProduct = () => {
    const [show, setShow] = useState(true);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const dispatch = useAppDispatch();
    const navigate = useNavigate();
    const [productTitle, setProductTitle] = useState("")
    const [productDescription, setProductDescription]= useState("")
    const [productPrice, setProductPrice]= useState<number>(0)
    const [productCategoryId, setProductCategoryId] = useState<number>(0)
    const [productImages, setProductImages] = useState<string>("")
    const [getUrlImages, setGetUrlImages]= useState<FileList | null>(null);
    const [message, setMessage] = useState("")
    const createProductHandler = (e:React.FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     dispatch(createProduct(
      {   title: productTitle,    
          price: productPrice,
          description: productDescription,
          categoryId: productCategoryId,
          images:  [productImages]
     })).then((data) => {
      if ("error" in data) {
        setMessage("Failed to create  new Product data (Invalid Data)");
      } else {
        navigate('/productList');
      }
    });
  };
  useEffect(() => {
    if (getUrlImages) {
      axiosInstance.post("files/upload", {
        file: getUrlImages[0]
      }, { headers: { "Content-Type": "multipart/form-data" } })
        .then(response => setProductImages(response.data.location))} 
  }, [getUrlImages])
    const {  formState: { errors } } = useForm<CreateProductType>({
        resolver: yupResolver(productSchema)
    })
    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title style={{ color: '#e03a3c' }} className='text-xl'>
                Create product
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
            <Container>
                <Row>
                    <Col>
                        <Form  onSubmit={createProductHandler} onClick={handleShow}>
                            <Form.Group>
                            <Form.Label>Product title</Form.Label>
                            <Form.Control
                                type='text'
                                placeholder='product title'
                                value={productTitle}
                                onChange={(e: { target: { value: React.SetStateAction<string>; }; }) => setProductTitle(e.target.value)}
                                    
                                className={errors.title?.message && 'is-invalid'}
                            />
                            <p className='invalid-feedback'>{errors.title?.message}</p>
                            </Form.Group>
                            <Form.Group>
                            <Form.Label>Price</Form.Label>
                            <Form.Control
                                type='number'
                                placeholder='price'
                                value={productPrice }
                                onChange={(e: { target: { value: string; }; }) => setProductPrice(parseInt(e.target.value))}// {...register("productCreate.price")}
                                
                                className={errors.price?.message && 'is-invalid'}
                            />
                            <p className='invalid-feedback'>{errors.price?.message}</p>
                            </Form.Group>
                            <Form.Group>
                            <Form.Label>Description</Form.Label>
                            <Form.Control
                                as={'textarea'}
                                rows={3}
                                placeholder='description'
                                value={productDescription}
                                onChange={(e: { target: { value: React.SetStateAction<string>; }; }) => setProductDescription(e.target.value)} //  {...register("productCreate.description")}
                                
                                className={errors.description?.message && 'is-invalid'}
                            />
                            <p className='invalid-feedback'>{errors.description?.message}</p>
                                </Form.Group>
                                <Form.Group>
                            <Form.Label>CategoryID</Form.Label>
                            <Form.Control
                                type='number'
                                placeholder='category'
                                value={productCategoryId | 0}
                                onChange={(e: { target: { value: string; }; }) => setProductCategoryId(parseInt(e.target.value))}  
                                
                                className={errors.categoryId?.message && 'is-invalid'}
                            />
                            <p className='invalid-feedback'>{errors.categoryId?.message}</p>
                                </Form.Group>

                            <Form.Group>
                            <Form.Label>Image</Form.Label>
                            <Form.Control
                                type='file'
                                placeholder='Gtx 1660 super'
                                name='image'
                            onChange={(e: React. ChangeEvent<HTMLInputElement>)=>setGetUrlImages(e.currentTarget.files)}
                            />
                            </Form.Group>
                            <Button
                            style={{ backgroundColor: '#e03a3c', color: '#fff' }}
                            variant='outline-none'
                            type='submit'
                            className='mt-3 w-full text-white'
                            >
                            Add product
                            </Button>
                            {message}
                        </Form>
                    </Col> 
                </Row>
            </Container>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    <Nav.Item as={NavLink} className='nav-link' to='/productlist'>
                        <span>Close</span>
                    </Nav.Item> 
                </Button> 
            </Modal.Footer>
        </Modal>
    )   
}

export default CreateProduct