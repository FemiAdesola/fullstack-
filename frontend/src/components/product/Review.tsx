import React, { useEffect, useState } from 'react';
import { Row, Container, Col, Card, Form, ListGroup, Button, Image, Alert } from 'react-bootstrap';
import toast, { Renderable, Toast, ValueFunction } from 'react-hot-toast';
import { Link, useNavigate, useParams } from 'react-router-dom';
import axiosInstance from '../../common/axiosIntsance';


import Rating from '../../features/Rating';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHooks';
import { getProductById } from '../../redux/method/productMethod';
import {  ProductType } from '../../types/product';

const Review = () => {
    const params = useParams();
    const navigate = useNavigate();
    const dispatch = useAppDispatch()
    const { id } = params;
    const [rating, setRating] = useState<number>(0);
    const [comment, setComment] = useState<string>('');
    const [refresh, setRefresh] = useState<boolean>(false);
    const  userInfo  = useAppSelector((state) => state.userReducer.currentUser);
   let products = useAppSelector(state => state.productReducer)

    const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const review = {
      comment,
      rating,
    };
    axiosInstance
      .post(`/products/${id}/reviews`, review)
      .then((res) => {
        toast.success('thank you for the comment 🙂');
        setRefresh((prev) => (prev = !prev));
      })
      .catch((err: Renderable | ValueFunction<Renderable, Toast>) => toast.error((err)));
    };
    
    useEffect(() => {
    dispatch(getProductById(id));
    window.scrollTo(0, 0);
  }, [id, dispatch, refresh]);

  return (
      <Container>
          <Row className='mt-2'>
            <Col md={6}>
              <Card>
                <Card.Body>
                  <h3 style={{ color: '#e03a3c' }}>Review from customers</h3>
                  {/* <ListGroup variant='flush'>
                    {products.reviews.map((review) => (
                      <ListGroup.Item key={review._id}>
                        <div className='d-flex'>
                          <strong>{review.name}</strong>
                          <Rating value={review.rating} />
                          <p>{getDate(review.createdAt)}</p>
                        </div>
                        <p>{review.comment}</p>
                      </ListGroup.Item>
                    ))}
                  </ListGroup> */}
                </Card.Body>
              </Card>
            </Col>
            <Col md={5}>
              <ListGroup className='bg-white p-3'>
                <ListGroup.Item>
                  <h3 style={{ color: '#e03a3c' }}>Comment</h3>
                 {userInfo ? (
                    <Form onSubmit={onSubmit}>
                      <Form.Group controlId='rating'>
                        <Form.Label>Rating</Form.Label>
                        <Form.Control
                          required
                          onChange={(e: any) => setRating(e.target.value)}
                          as='select'
                        >
                          <option value={1}>❤️</option>
                          <option value={2}>❤️❤️</option>
                          <option value={3}>❤️❤️❤️</option>
                          <option value={4}>❤️❤️❤️❤️</option>
                          <option value={5}>❤️❤️❤️❤️❤️</option>
                        </Form.Control>
                      </Form.Group>
                      <Form.Group controlId='comment'>
                        <Form.Label>Comment</Form.Label>
                        <Form.Control
                          required
                          onChange={(e) => setComment(e.target.value)}
                          as={'textarea'}
                          rows={3}
                        />
                      </Form.Group>
                      <Button
                        style={{ backgroundColor: '#e03a3c', color: '#fff' }}
                        className='mt-2 w-full'
                        variant='outline-none'
                        type='submit'
                      >
                        Submit
                      </Button>
                      </Form>
                ) : (
                   <Alert  variant='danger'>
                      You must login first to feedback{' '}
                      <Link to='/login' className='ms-2'>
                        Login Now
                      </Link>
                  </Alert>
                )}
                </ListGroup.Item>
              </ListGroup>
            </Col>
          </Row>
    </Container>
  )
}

export default Review