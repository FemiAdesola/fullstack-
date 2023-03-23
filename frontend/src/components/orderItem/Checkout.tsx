import React from 'react'
import { Button, Card, Col, Container, Image, ListGroup, Row } from 'react-bootstrap';
import toast from 'react-hot-toast';
import { useNavigate } from 'react-router-dom';

import axiosInstance from '../../common/axiosIntsance';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHooks';
import { reset } from '../../redux/reducers/orderItemReducer';


const Checkout = () => {
    const dispatch = useAppDispatch();
    const { orderItems, shippingAddress } = useAppSelector((state) => state.orderItemReducer);
    const navigate = useNavigate();
    const itemsPrice = orderItems.reduce(
        (acc, item) => acc + item.quantity * item.price,
        0
    );
    const taxPrice = itemsPrice * 0.24;
    const shippingPrice = itemsPrice <= 200 ? 0 : 30;
    const totalPrice = itemsPrice + taxPrice + shippingPrice;
     const onSubmit = () => {
    const order = {
      totalPrice,
      orderItems,
      shippingAddress,
    };
    axiosInstance
      .post('/orders', order)
      .then((res) => {
        toast.success('your order has been created');
        dispatch(reset());
        navigate(`/orders/${res.data.id}`);
        navigate(`/order`);
      })
      .catch((err) => toast.error((err)));
  };
  return (
    <Container className='mt-5' style={{ marginBottom: '300px' }}>
       <h2 className='mb-5'>Checkout</h2>
        <Row>
          <Col md={8} className='mb-2'>
            <Card>
              <Card.Body>
                <ListGroup variant='flush'>
                  <ListGroup.Item>
                    <h4 className=' justify-content-between d-flex align-items-center'>
                      <span> Address: </span>
                      <span>
                            {shippingAddress?.address}
                            {shippingAddress?.city}{' '}
                            {shippingAddress?.postalCode}
                      </span>
                    </h4>
                  </ListGroup.Item>
                  <h3 className='my-3'>Items</h3>
                  {orderItems.map((orderItem) => (
                    <ListGroup.Item key={orderItem.id} className=' mb-2'>
                      <Row className='d-flex align-items-center'>
                        <Col md={2}>
                          <Image
                            src={orderItem.images}
                            roundedCircle
                            className='avatar'
                          />
                        </Col>
                        <Col md={6}>{orderItem.title}</Col>
                        <Col>{orderItem?.quantity}</Col>

                        <Col>{(orderItem.price * orderItem.quantity).toLocaleString()} €</Col>
                        <Col></Col>
                      </Row>
                    </ListGroup.Item>
                  ))}
                </ListGroup>
              </Card.Body>
            </Card>
          </Col>
          <Col md={4}>
            <Card className='shadow '>
              <Card.Body>
                <ListGroup variant='flush'>
                    <ListGroup.Item as='h2'>
                        SubTotal (
                        {orderItems.reduce((acc, orderItem) => acc + orderItem.quantity, 0)}) item
                    </ListGroup.Item>
                    <ListGroup.Item className=' d-flex justify-content-between align-items-center'>
                        <span>Total Price :</span>
                        <span>
                            {orderItems.reduce((acc, orderItem) =>
                                acc + orderItem.price * orderItem.quantity, 0)
                                .toLocaleString()} €
                        </span>
                    </ListGroup.Item>
                    <ListGroup.Item className=' d-flex justify-content-between align-items-center'>
                        <span>Tax Price</span>
                        <span>{(taxPrice).toLocaleString()} €</span>
                    </ListGroup.Item>
                    <ListGroup.Item className=' d-flex justify-content-between align-items-center'>
                        <span>Shipping Price</span>
                        <span>{shippingPrice.toLocaleString()} €</span>
                    </ListGroup.Item>
                    <ListGroup.Item className=' d-flex justify-content-between align-items-center'>
                        <span>Total Price</span>
                        <span>{totalPrice.toLocaleString()} €</span>
                    </ListGroup.Item>
                    <ListGroup.Item className=' d-flex justify-content-between align-items-center'>
                    <Button
                        style={{ backgroundColor: '#e03a3c', color: '#fff' }}
                        onClick={onSubmit}
                    // onClick={() => navigate('/order')}
                        disabled={orderItems.length === 0}
                        className='w-full'
                        >
                        Place order
                        </Button>
                    </ListGroup.Item>
                    <ListGroup.Item className=' d-flex justify-content-between align-items-center'>
                    <Button
                        style={{ backgroundColor: '#e03a3c', color: '#fff' }}
                        onClick={() => navigate('/products')}
                        disabled={orderItems.length === 0}
                        className='w-full'
                        >
                       Get more product
                        </Button>
                    </ListGroup.Item>
                </ListGroup>
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
  )
}

export default Checkout