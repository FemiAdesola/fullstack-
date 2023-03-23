import React, { useEffect } from 'react'
import {  useForm } from 'react-hook-form'
import { yupResolver } from "@hookform/resolvers/yup"
import { Link, useNavigate } from 'react-router-dom';
import { Button, Form} from 'react-bootstrap';


import { useAppDispatch, useAppSelector } from '../../hooks/reduxHooks';
import { Authentications } from '../../types/user';
import { userAuthentication } from '../../redux/method/userMethod';
import FormContainer from '../../features/FormContainer';
import { SignInSchema } from '../../formValidation/signUpSchema';

const Login = () => {
    const { handleSubmit, register, formState: { errors } } = useForm<Authentications>({
    resolver: yupResolver(SignInSchema)
  })
  const  userInfo  = useAppSelector((state) => state.userReducer.currentUser);
  const navigate = useNavigate();
  const dispatch = useAppDispatch();
  const onSubmit=(data:Authentications)=> {
    dispatch(userAuthentication(data))
  }
  useEffect(() => {
    if (userInfo)
    {
      return navigate('/')
    }
  }, [navigate, userInfo]);
  const redirectInUrl = new URLSearchParams().get("redirect");
    const redirect = redirectInUrl ? redirectInUrl : "/signup";
    
  return (
   <FormContainer
        meta='Login your account'
        src='https://source.unsplash.com/gsUwEUr61NQ'
        title='Login Your Account'
    >
      <Form onSubmit={handleSubmit(onSubmit)} style={{marginBottom:'80px'}}>
        <Form.Group controlId='email'>
          <Form.Label>Email</Form.Label>

          <Form.Control
            type='email'
            placeholder='Enter email'
            {...register('email')}
            className={errors.email?.message}
          />
          <p className='invalid-feedback'>{errors.email?.message}</p>
        </Form.Group>

        <Form.Group controlId='password'>
          <Form.Label>Enter your password </Form.Label>
          <Form.Control
            type='password'
            placeholder='*******'
            {...register('password')}
            className={errors.password?.message}
          />
          <p className='invalid-feedback'>{errors.password?.message}</p>
          <Link to={`/signup?redirect=${redirect}`} className='float-end me-2 mt-1'>
           Not yet register?{" "}
          </Link>
        </Form.Group>

        <Button
          type='submit'
          className='mt-4 w-full'
          style={{ backgroundColor: '#e03a3c', color: '#fff' }}
          variant='outline-none'
        >
          Submit
        </Button>
      </Form>
    </FormContainer>
  )
}

export default Login