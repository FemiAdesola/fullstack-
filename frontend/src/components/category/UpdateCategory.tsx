import React, { useEffect, useState } from 'react'
import { Button, Col, Row, Form, Card } from 'react-bootstrap';

import { UpdateCategoryProps, UpdateCategoryType } from '../../types/category';
import { useAppDispatch } from '../../hooks/reduxHooks';
import { useNavigate } from 'react-router-dom';
import { updateCategory } from '../../redux/method/categoryMethod';
import axiosInstance from '../../common/axiosIntsance';



const UpdateCategory = ({id, previousName, previousImage }:UpdateCategoryProps) => {
    const [categoryName, setCategoryName] = useState(previousName)
    const [categoryImage, setCategoryImage] = useState(previousImage)
    const [getUrlImages, setGetUrlImages]= useState<FileList | null>(null);
    const [previousValue, setPreviousValue] = useState(false)
    const [message, setMessage] = useState("")
    const dispatch = useAppDispatch();
    const navigate = useNavigate();

    const handleChange = () => {
        setPreviousValue(!previousValue)
        if (previousValue === false) {
            setCategoryName(categoryName)
        }
    }
    const editProduct = () => {
        const newUpdate: UpdateCategoryType = {
            id: id,
            name: categoryName,
            image: categoryImage
        }
        dispatch(updateCategory(newUpdate)).then((data) => {
        if ("error" in data) {
          setMessage("Failed to create  new Product data (Invalid Data");
        } else {
          navigate("/categories");
        }
        });
        navigate(`/categories`) 
    } 
    useEffect(() => {
        if (getUrlImages) {
        axiosInstance.post("files/upload", {
            file: getUrlImages[2]
        }, { headers: { "Content-Type": "multipart/form-data" } })
            .then(response => setCategoryImage(response.data.location))} 
    }, [getUrlImages])
    
    return (
   <div>
        {/* <Container> */}
            <Row className=' justify-content-center py-6'>
                <Col lg={11} md={6}>
                    <Card>
                        <h1 className='text-center text-primary my-3'>Update Product</h1>
                        <Card.Body>
                            <Row>
                                <Col>
                                    <Form onSubmit={handleChange}>
                                        <Form.Group>
                                        <Form.Label>Category name</Form.Label>
                                        <Form.Control
                                            type='text'
                                            value={categoryName? categoryName : previousName}
                                            onChange={(e: { target: { value: React.SetStateAction<string>; }; }) => setCategoryName(e.target.value)}
                                        />
                                        </Form.Group>
                                        <Form.Group>
                                        <Form.Label>Image</Form.Label>
                                        <Form.Control
                                            type='file'
                                            onChange={(e: React. ChangeEvent<HTMLInputElement>)=>setGetUrlImages(e.currentTarget.files)}
                                        />
                                        </Form.Group>
                                        <Button
                                            style={{ backgroundColor: '#e03a3c', color: '#fff' }}
                                            variant='outline-none'
                                            type='submit'
                                            className='mt-3 w-full text-white'
                                            onClick={editProduct}
                                        >
                                            Update category
                                        </Button>
                                    </Form>
                                </Col> 
                            </Row>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        {/* </Container> */}
    </div>
  )
}

export default UpdateCategory