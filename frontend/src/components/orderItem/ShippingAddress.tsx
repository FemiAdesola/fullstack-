import React, { useEffect, useState } from 'react';
import { Button, Card, Col, Container, Form, Row } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

import { useAppDispatch, useAppSelector } from '../../hooks/reduxHooks';
import { saveAddress } from '../../redux/reducers/orderItemReducer';
import { AddressTypes } from '../../types/orderItem';

const ShippingAddress = () => {
    const { shippingAddress } = useAppSelector((state) => state.orderItemReducer);
    const dispatch = useAppDispatch();
    const navigate = useNavigate();
    const [formData, setFormData] = useState<AddressTypes>({
        address: '',
        city: '',
        postalCode: '',
        country: '',
    });
    const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData((prevState) => ({
      ...prevState,
      [e.target.name]: e.target.value,
    }));
    };
    const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    dispatch(
      saveAddress({
        address: formData.address,
        city: formData.city,
        postalCode: formData.postalCode,
        country: formData.country,
      })
    );
    navigate('/checkout');
  };

    useEffect(() => {
    if (shippingAddress) return navigate('/checkout');
    }, [shippingAddress]);
    
  return (
    <Container style={{marginBottom:'400px'}}>
        <Row className=' justify-content-center py-6'>
          <Col md={6}>
                <Card>
                    <Card.Body>
                        <Form onSubmit={onSubmit}>
                            <Form.Group controlId='address'>
                            <Form.Label>Address</Form.Label>
                            <Form.Control
                                onChange={onChange}
                                name='address'
                                placeholder='enter your address'
                                required
                            />
                            </Form.Group>
                            <Form.Group controlId='city'>
                            <Form.Label>City</Form.Label>
                            <Form.Control
                                onChange={onChange}
                                name='city'
                                placeholder='enter your city'
                                required
                            />
                            </Form.Group>
                            <Form.Group controlId='postalCode'>
                            <Form.Label>Postal Code</Form.Label>
                            <Form.Control
                                onChange={onChange}
                                name='postalCode'
                                placeholder='enter your postal code'
                                required
                            />
                            </Form.Group>
                            <Form.Group controlId='country'>
                            <Form.Label>Country</Form.Label>
                            <Form.Control
                                onChange={onChange}
                                name='country'
                                placeholder='enter your country'
                                required
                            />
                            </Form.Group>
                            <Button
                            style={{ backgroundColor: '#e03a3c', color: '#fff' }}
                            variant='outline-none'
                            type='submit'
                            className='mt-4 w-full'
                              >
                                  Submit
                            </Button>
                        </Form>
                    </Card.Body>
                </Card>
            </Col>
        </Row>
    </Container>
  )
}

export default ShippingAddress