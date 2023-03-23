import { yupResolver } from '@hookform/resolvers/yup';
import React, { useEffect, useState } from 'react'
import { SubmitHandler, useForm } from 'react-hook-form';
import { useNavigate, useParams } from 'react-router-dom';
import { Container, Row, Col, Button, Form, Card } from 'react-bootstrap';
import { FaCheck, FaTimes, FaTrash } from 'react-icons/fa';


import { SignUpSchema } from '../../formValidation/signUpSchema';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHooks';

import { UserForm } from '../../types/user';
import Loader from '../Loader/Loader';
import axiosInstance from '../../common/axiosIntsance';
import { getUserBydId } from '../../redux/method/userMethod';

const Profile = () => {
    const dispatch = useAppDispatch()
    const navigate = useNavigate();
    const { id } = useParams();
    const [refresh, setRefresh] = useState<boolean>(false);
    const  users = useAppSelector((state) => state.userReducer.currentUser);
    const { handleSubmit, register, formState: { errors } } = useForm<UserForm>({
        resolver: yupResolver(SignUpSchema)
    })
    const onsubmit: SubmitHandler<UserForm> = data => {
        const update = {
        name: data.name,
        email: data.email,
        password: data.password === '' ? null : data.password,
        avatar : data.avatar
        };
        axiosInstance
        .put(`/users/${users?.id}`, update)
        .then((res) => {
            setRefresh((prev) => (prev = !prev));
        })
        .catch((err) => (console.log(err)));
        navigate(`/users`);
    }
  
   useEffect(() => {
     dispatch(getUserBydId(id));
     navigate(`/profile/`);
   }, [dispatch, users, refresh])
  return (
    <Container className='mt-5' style={{marginBottom:'200px'}}>
        { !users ? (
          <Loader />
        ) : (
          <Row>
            
            <Col lg={4} md={5} xs={12}>
              <h2>User Profile</h2>
              <Card>
                <Card.Body>
                  <Form onSubmit={handleSubmit(onsubmit)}>
                    <Form.Group controlId='name'>
                      <Form.Label>Username</Form.Label>
                      <Form.Control
                        {...register('name', {
                          value: users?.name,
                        })}
                        placeholder='Enter name'
                        className={errors.name?.message && 'is-invalid'}
                      />
                      <p className='invalid-feedback'>{errors.name?.message}</p>
                    </Form.Group>

                    <Form.Group controlId='email'>
                      <Form.Label>Email Address</Form.Label>
                      <Form.Control
                        {...register('email', {
                          value: users?.email,
                        })}
                        placeholder='Enter email'
                        className={errors.email?.message && 'is-invalid'}
                      />
                      <p className='invalid-feedback'>
                        {errors.email?.message}
                      </p>
                    </Form.Group>

                    <Form.Group controlId='password'>
                      <Form.Label>Password</Form.Label>
                      <Form.Control
                                              {...register('password', {
                            value: users?.password
                        })}
                        type='password'
                        placeholder='********'
                        className={errors.password?.message && 'is-invalid'}
                      />
                      <p className='invalid-feedback'>
                        {errors.password?.message}
                      </p>
                    </Form.Group>             
                    <Form.Group controlId='avatar'>
                        <Form.Label>Upload image </Form.Label>
                            <Form.Control
                                type='file'
                                placeholder='avatar'
                                {...register('avatar', {
                                    value: users?.avatar,
                                })}
                                className={errors.avatar?.message}
                        />
                    </Form.Group>
                    <p className='invalid-feedback'>{errors.avatar?.message}</p>
                    <Button
                      style={{ backgroundColor: '#e03a3c', color: '#fff' }}
                      variant='outline-none'
                      type='submit'
                      className='mt-3 w-full'
                    >
                      Update
                    </Button>
                  </Form>
                </Card.Body>
              </Card>
            </Col>
            <Col md={7} lg={8}>
              {/* <TableContainer cols={cols}>
                {orders.map((order) => (
                  <tr key={order._id}>
                    <td>{order._id}</td>

                    <td>{formatCurrencry(order?.totalPrice)}</td>
                    <td>{order?.shippingAddress?.address}</td>
                    <td>
                      {order.isPaid ? (
                        <FaCheck color='green' />
                      ) : (
                        <FaTimes color='red' />
                      )}
                    </td>
                    <td>{getDate(order?.createdAt)}</td>
                    <td>
                      <Link
                        to={`/orders/${order._id}`}
                        className='btn btn-sm btn-secondary  me-2'
                      >
                        <GrView />
                      </Link>
                      <Button
                        onClick={() => onDelete(order._id)}
                        variant='danger'
                        size='sm'
                      >
                        <FaTrash />
                      </Button>
                    </td>
                  </tr>
                ))}
              </TableContainer> */}
            </Col>
          </Row>
        )}
      </Container>
  )
}

export default Profile