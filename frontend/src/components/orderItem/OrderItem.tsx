import React from 'react'
import { Link, useNavigate} from 'react-router-dom';
import { Row, Container, Col, Card, ListGroup, Image, Button } from 'react-bootstrap';
import { FaMinus, FaPlus } from 'react-icons/fa';

import { useAppDispatch, useAppSelector } from '../../hooks/reduxHooks';
import { addToOrderItem, removeFromOrderItem } from '../../redux/reducers/orderItemReducer';


const OrderItem = () => {
    const dispatch = useAppDispatch()
    const navigate = useNavigate();
    const { orderItems } = useAppSelector((state) => state.orderItemReducer);
  return (
<Container  style={{marginBottom:'600px'}}>
        {orderItems.length === 0 ? (
          <Col className='pt-5 mb-10' >
           No item in your cart
            <Link to='/products' className='mx-3'>
              Get item from store
            </Link>
          </Col>
        ) : (
          <Row className='pt-5'>
            <Col md={8}>
              <ListGroup variant='flush'>
                {Array.isArray(orderItems)? orderItems.map((orderItem) => (
                  <ListGroup.Item
                    key={orderItem.id}
                    className='shadow rounded p-5 bg-white mb-2'
                  >
                    <Row className='d-flex align-items-center'>
                        <Col md={2}>
                            <Image
                            src={orderItem.images}
                            roundedCircle
                            className='h-16 w-16'
                            />
                        </Col>
                        <Col className='d-none d-lg-block'>Name: {orderItem.title}</Col>
                        <Col>Quantity: {orderItem.quantity}</Col>
                        <Col>Price: {orderItem.price } €</Col>
                        <Col>Total price:{(orderItem.price * orderItem.quantity).toLocaleString()}</Col>
                        <Col>
                            <FaPlus
                            onClick={() => dispatch(addToOrderItem(orderItem))}
                            size={'1.5rem'}
                            style={{ backgroundColor: '#e03a3c' }}
                            className='icons__cart  m-2 rounded-circle text-white p-1 cursor-pointer'
                            />
                        <FaMinus
                          size={'1.5rem'}
                          style={{ backgroundColor: '#e03a3c' }}
                          className={`icons__cart m-2 rounded-circle text-white p-1 cursor-pointer `}
                          onClick={() => dispatch(removeFromOrderItem(orderItem))}
                        />
                      </Col>
                    </Row>
                  </ListGroup.Item>
                )):null}
              </ListGroup>
            </Col>
            <Col md={4}>
              <Card className='shadow'>
                <Card.Body>
                  <ListGroup variant='flush'>
                    <ListGroup.Item as='h2'>
                      SubTotal: 
                      {(orderItems.reduce((acc, orderItem) => acc + orderItem.quantity, 0)) <= 1 ? 
                        `${(orderItems.reduce((acc, orderItem) => acc + orderItem.quantity, 0))} product` :
                        `${(orderItems.reduce((acc, orderItem) => acc + orderItem.quantity, 0))} products`}
                    </ListGroup.Item>
                    <ListGroup.Item className=' d-flex justify-content-between align-items-center pb-5'>
                      <span>Total Price :</span>
                      <span>
                        {orderItems.reduce((acc, orderItem)=> acc + orderItem.price * orderItem.quantity, 0).toLocaleString()} €
                      </span>
                    </ListGroup.Item>
                    <ListGroup.Item className=' d-flex justify-content-between align-items-center'>
                      <Button
                        style={{ backgroundColor: '#e03a3c' }}
                        disabled={orderItems.length === 0}
                        onClick={() => navigate('/shipping')}
                        className='w-1/2 text-white me-2'
                        variant='outline-none'
                      >
                        Checkout
                      </Button>
                      <Button
                        style={{ backgroundColor: '#e03a3c' }}
                        onClick={() => navigate('/products')}
                        className='w-1/2 text-white me-2'
                        variant='outline-none'
                      >
                        Countine
                      </Button>
                    </ListGroup.Item>
                  </ListGroup>
                </Card.Body>
              </Card>
            </Col>
          </Row>
        )}
    </Container>
  )
}

export default OrderItem