import { yupResolver } from '@hookform/resolvers/yup';
import React, {useState } from 'react'
import { Button, Col, Container, Modal, Row, Form, Nav } from 'react-bootstrap';

import { useAppDispatch } from '../../hooks/reduxHooks';
import { NavLink, useNavigate } from 'react-router-dom';
import { SubmitHandler, useForm } from 'react-hook-form'
import { CreateCategoryType } from '../../types/category';
import { CategorySchema } from '../../formValidation/categorySchema';
import { createCategory } from '../../redux/method/categoryMethod';

const CreateCategory = () => {
    const [show, setShow] = useState(true);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const dispatch = useAppDispatch();
    const navigate = useNavigate();
    const { handleSubmit, register, formState: { errors } } = useForm<CreateCategoryType>({
        resolver: yupResolver(CategorySchema)
    })
    const onSubmit: SubmitHandler<CreateCategoryType> = data => {
        dispatch(createCategory(data))
        navigate('/categories');
        console.log(data)
    }
    
    return (
      <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title style={{ color: '#e03a3c' }} className='text-xl'>
                Create Category
                </Modal.Title>
            </Modal.Header>
            <Modal.Body>
            <Container>
                <Row>
                    <Col>
                        <Form  onSubmit={handleSubmit(onSubmit)} onClick={handleShow}>
                            <Form.Group>
                            <Form.Label>Category name</Form.Label>
                            <Form.Control
                                type='text'
                                      placeholder='category name'
                                      {...register('name')}
                                    className={errors.name?.message}
                            />
                            <p className='invalid-feedback'>{errors.name?.message}</p>
                            </Form.Group>
                            <Form.Group>
                            <Form.Label>Image</Form.Label>
                            <Form.Control
                                type='file'
                                placeholder='Gtx 1660 super'
                                {...register('image')}
                                className={errors.image?.message}
                            />
                            </Form.Group>
                            <Button
                            style={{ backgroundColor: '#e03a3c', color: '#fff' }}
                            variant='outline-none'
                            type='submit'
                            className='mt-3 w-full text-white'
                            >
                            Add category
                            </Button>
                        </Form>
                    </Col> 
                </Row>
            </Container>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                   <Nav.Item as={NavLink} className='nav-link' to='/categories'>
                        <span>Close</span>
                    </Nav.Item> 
                </Button> 
            </Modal.Footer>
        </Modal>
    )
}

export default CreateCategory