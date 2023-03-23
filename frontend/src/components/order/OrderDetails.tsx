import { useEffect, useState } from 'react';
import { Card, Col, Container, Image, ListGroup, Row } from 'react-bootstrap';
import { useNavigate, useParams } from 'react-router-dom';
import Stripe from 'react-stripe-checkout';

import { useAppDispatch, useAppSelector } from '../../hooks/reduxHooks';

import toast from 'react-hot-toast';

import Loader from '../Loader/Loader';
import axiosInstance from '../../common/axiosIntsance';
import { getOrderById } from '../../redux/method/orderMethod';

const OrderDetails = () => {
    const navigate = useNavigate();
    const dispatch = useAppDispatch();
     const { id } = useParams();
    const order = useAppSelector((state) => state.orderReducer);
    const [isLoading, setIsLoading] = useState(true)
    // const orderItems = useAppSelector((state) => state.orderItemReducer);
    const itemsPrice: number | undefined = order?.orderItems.reduce(
        (acc, item) => acc + item.quantity * item.price,
        0
    );
    const taxPrice = itemsPrice ? itemsPrice * 0.1 : 0;
    const shippingPrice = itemsPrice ? (itemsPrice >= 200 ? 0 : 30) : 0;
    const totalPrice = itemsPrice && itemsPrice + taxPrice + shippingPrice;
    const handlePayment = (token: any) => {
        axiosInstance
        .post('/orders/stripe', {
            token: token.id,
            quantity: order?.totalPrice,
        })
        .then((res) => {
            axiosInstance.put(`/orders/${id}`).then((res) => {
            toast.success('you have been paid successfully🙂');
            navigate('/');
            });
        })
        .catch((error) => toast.error((error)));
    };
    useEffect(() => {
         dispatch(getOrderById())
         setIsLoading(false)
     }, [])
    const tokenHandler = (token: any) => {
    handlePayment(token);
    };
    return (
    <Container style={{marginBottom:'300px'}}>
        <h2 className='mb-5'>Payment</h2>
        {isLoading ? (
          <Loader />
        ) : (
          <Row>
            <Col md={8} className='mb-sm-3 mb-2'>
              <Card>
                <Card.Body>
                  <h4>Order Details</h4>
                  <ListGroup variant='flush'>
                    {order?.orderItems.map((item) => (
                      <ListGroup.Item key={item.id}>
                        <Row>
                          <Col md={2}>
                            <Image
                              src={item.images[0]}
                              roundedCircle
                              className='h-16 w-16'
                            />
                          </Col>
                          <Col md={6} className='d-none d-lg-block'>
                            {item.title}
                          </Col>
                          <Col>{item?.quantity}</Col>

                          <Col>{(item.price * item.quantity).toLocaleString()}</Col>
                        </Row>
                      </ListGroup.Item>
                    ))}
                  </ListGroup>
                </Card.Body>
              </Card>
            </Col>
            <Col md={4}>
              <Card>
                <Card.Body>
                  <h2 className='text-center'>Payment</h2>
                  <ListGroup variant='flush'>
                    <ListGroup.Item as='h2'>
                      SubTotal (
                      {order?.orderItems.reduce(
                        (acc, item) => acc + item.quantity,
                        0
                      )}
                      ) item
                    </ListGroup.Item>
                    <ListGroup.Item className=' d-flex justify-content-between align-items-center'>
                      <span>Total Price :</span>
                      <span>
                        {(
                          order?.orderItems.reduce(
                            (acc, item) => acc + item.price * item.quantity,0).toLocaleString()
                        )}
                      </span>
                    </ListGroup.Item>
                    <ListGroup.Item className=' d-flex justify-content-between align-items-center'>
                      <span>Tax Price</span>
                      <span>{taxPrice.toLocaleString()}</span>
                    </ListGroup.Item>
                    <ListGroup.Item className=' d-flex justify-content-between align-items-center'>
                      <span>Shipping Price</span>
                      <span>{shippingPrice.toLocaleString()}</span>
                    </ListGroup.Item>
                    <ListGroup.Item>
                      <h5 className=' d-flex justify-content-between align-items-center'>
                        <span>Total Price</span>
                        <span>{totalPrice.toLocaleString()}</span>
                      </h5>
                    </ListGroup.Item>
                    {!order?.totalPrice && (
                      <ListGroup.Item className='stripe__container'>
                        <Stripe
                          currency='€'
                          description={`Total Price ${(
                            order?.totalPrice
                          ).toLocaleString()}`}
                            name='Moysem venture'
                            image='https://source.unsplash.com/gsUwEUr61NQ'
                          stripeKey={"ok"}
                          token={tokenHandler}
                        />
                      </ListGroup.Item>
                    )}
                  </ListGroup>
                </Card.Body>
              </Card>
            </Col>
          </Row>
        )}
    </Container>
  )
}

export default OrderDetails