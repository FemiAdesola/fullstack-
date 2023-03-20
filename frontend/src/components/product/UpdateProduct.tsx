import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { Button, Col, Row, Form, Card } from 'react-bootstrap';

import { useAppDispatch } from '../../hooks/reduxHooks';
import { UpdateProductProps, UpdateValueType } from '../../types/product';
import { yupResolver } from '@hookform/resolvers/yup';
import { useForm } from 'react-hook-form';
import { productSchema } from '../../formValidation/productSchema';
import axiosInstance from '../../common/axiosIntsance';
import { updateProduct } from '../../redux/method/productMethod';

const UpdateProduct = ({id, previousTitle, previousDescription, previousImage, previousPrice}:UpdateProductProps) => {
    const dispatch = useAppDispatch();
  const navigate = useNavigate();
  const [productTitle, setProductTitle] = useState(previousTitle)
  const [productDescription, setProductDescription]= useState(previousDescription)
  const [productPrice, setProductPrice] = useState<number>(previousPrice)
  const [previousValue, setPreviousValue] = useState(false)
  const [productImages, setProductImages] = useState<string>(previousImage)
  const [getUrlImages, setGetUrlImages]= useState<FileList | null>(null);
  const [message, setMessage] = useState("")
  const handleChange = () => {
    setPreviousValue(!previousValue)
    if (previousValue === false) {
      setProductTitle(previousTitle)
      setProductDescription(previousDescription)
      setProductPrice(Number(previousPrice))
    }
  }
  const editProduct = () => {
    if (productPrice <= 0 || isNaN(productPrice)) {
      setMessage("Re-enter the product price");
    }
    const newProductUpdate: UpdateValueType = {
      id: id,
      title: productTitle,
      description: productDescription,
      price: productPrice,
      images: [productImages]
    }
    dispatch(updateProduct(newProductUpdate)).then((data) => {
        if ("error" in data) {
          setMessage("Failed to create  new Product data (Invalid Data");
        } else {
          navigate("/products");
        }
    });
    navigate(`/products`)
    }
    useEffect(() => {
        if (getUrlImages) {
        axiosInstance.post("files/upload", {
            file: getUrlImages[0]
        }, { headers: { "Content-Type": "multipart/form-data" } })
            .then(response => setProductImages(response.data.location))} 
    }, [getUrlImages])
        const {  formState: { errors } } = useForm<UpdateValueType>({
            resolver: yupResolver(productSchema)
    })
  
  return (
      <div>
          <Row className=' justify-content-center py-6'>
        <Col lg={5} md={6}>
          <Card>
            <h1 className='text-center text-primary my-3'>Update Product</h1>
            <Card.Body>
              <Form onSubmit={handleChange}>
                <Form.Group>
                  <Form.Label>Product title</Form.Label>
                  <Form.Control
                    type='text'
                    // placeholder='product title'
                    value={productTitle? productTitle : previousTitle}
                    onChange={(e: { target: { value: React.SetStateAction<string>; }; }) => setProductTitle(e.target.value)}
                    className={errors.title?.message}
                  />
                  <p className='invalid-feedback'>{errors.title?.message}</p>
                </Form.Group>
                <Form.Group>
                  <Form.Label>Price</Form.Label>
                  <Form.Control
                    type='number'
                    placeholder='price'
                    value={productPrice?productPrice:previousPrice}
                    onChange={(e: { target: { value: string; }; }) => setProductPrice(parseInt(e.target.value))}
                    className={errors.price?.message}
                  />
                  <p className='invalid-feedback'>{errors.price?.message}</p>
                </Form.Group>
                <Form.Group>
                  <Form.Label>Product Description</Form.Label>
                  <Form.Control
                    as={'textarea'}
                    rows={3}
                    placeholder='description'
                    value={productDescription?productDescription:previousDescription}
                    onChange={(e: { target: { value: React.SetStateAction<string>; }; }) => setProductDescription(e.target.value)} 
                    className={errors.description?.message}
                  />
                  <p className='invalid-feedback'>
                    {errors.description?.message}
                  </p>
                </Form.Group>
                <Form.Group>
                  <Form.Label>Image</Form.Label>
                  <Form.Control
                    type='file'
                    placeholder='image url'
                    onChange={(e: React. ChangeEvent<HTMLInputElement>)=>setGetUrlImages(e.currentTarget.files)}
                    className={errors.images?.message && 'is-invalid'}
                  />
                  <p className='invalid-feedback'>{errors.images?.message}</p>
                </Form.Group>
                <Button type='submit' className='mt-3 w-full text-white' onClick={editProduct}>
                  Update product
                </Button>
              </Form>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </div>
  )
}

export default UpdateProduct