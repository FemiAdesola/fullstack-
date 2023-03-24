import React from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { SubmitHandler, useForm } from 'react-hook-form'
import { yupResolver } from "@hookform/resolvers/yup"
import { Button, Form} from 'react-bootstrap';

import { UserForm } from '../../types/user';
import { useAppDispatch } from '../../hooks/reduxHooks';
import { SignUpSchema } from '../../formValidation/signUpSchema';
import FormContainer from '../../features/FormContainer';
import { createUserWithSignUp } from '../../redux/method/userMethod';

const SignUp = () => {
  const dispatch = useAppDispatch()
  const navigate = useNavigate();
  const { handleSubmit, register, formState: { errors } } = useForm<UserForm>({
    resolver: yupResolver(SignUpSchema)
  })
  const onSubmit: SubmitHandler<UserForm> = data => {
    dispatch(createUserWithSignUp(data))
    navigate('/login');
  }
  const redirectInUrl = new URLSearchParams().get("redirect");
  const redirect = redirectInUrl ? redirectInUrl : "/login";  
  return (
    <FormContainer
        meta='Register to have access to the store'
        src='https://source.unsplash.com/AvqpdLRjABs'
        title='Register to have access to the store'
    >
      <Form onSubmit={handleSubmit(onSubmit)}>
        <Form.Group controlId='name'>
          <Form.Label>Username</Form.Label>
          <Form.Control
            placeholder='Enter name'
            {...register('name')}
            className={errors.name?.message}
          />
          <p className='invalid-feedback'>{errors.name?.message}</p>
        </Form.Group>
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
          <Form.Label>Enter your password  </Form.Label>
          <Form.Control
            type='password'
            placeholder='*******'
            {...register('password')}
            className={errors.password?.message && 'is-invalid'}
          />
          <p className='invalid-feedback'>{errors.password?.message}</p>
        </Form.Group>
        <Form.Group controlId='avatar'>
          <Form.Label>Upload image </Form.Label>
        <Form.Control
            type='file'
            placeholder='avatar'
            {...register('avatar')}
            className={errors.avatar?.message}
           />
        </Form.Group>
          <p className='invalid-feedback'>{errors.avatar?.message}</p>
          <Link to={`/login?redirect=${redirect}`} className='float-end me-2 mt-1'>
            Already have an Account ? Login
          </Link>
        <Button
          style={{ backgroundColor: '#e03a3c', color: '#fff' }}
          variant='outline-none'
          type='submit'
          className='mt-4 w-full'
        >
          Register
        </Button>
      </Form>
    </FormContainer>
  )
}

export default SignUp