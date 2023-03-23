import React, { useEffect, useState } from 'react';
import { Row, Container, Col, Card, ListGroup, Image, Button } from 'react-bootstrap';
import { useNavigate, useParams } from 'react-router-dom';

import axiosInstance from '../../common/axiosIntsance';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHooks';
import { addToOrderItem } from '../../redux/reducers/orderItemReducer';
import { OrderItemProductType } from '../../types/orderItem';
import { ProductType } from '../../types/product';
import Review from './Review';
import UpdateProduct from './UpdateProduct';

const SingleProduct = () => {
  const params = useParams();
  const navigate = useNavigate();
  const dispatch = useAppDispatch()
  const { id } = params;
  const [products, setProducts] = useState<ProductType>()
  const  userInfo = useAppSelector((state) => state.userReducer.currentUser);
    useEffect(() => {
    const singleProductDetails = async () => {
      try {
        const res = await axiosInstance.get<ProductType>(`products/${id}`);
        setProducts(res.data);
      } catch (err) {
        console.log(err);
      } 
    };
    singleProductDetails();
    }, [id]);
  
  const onAdd = () => {
    dispatch(addToOrderItem(products as OrderItemProductType));
    navigate('/orderitem');
  };
  return (
    <Container style={{marginBottom:'200px'}}>
      <Row  className='pt-4'>
        <Col md={6}>
          <Card className='shadow'>
            <Image
              className=' p-3'
              rounded
              src={products?.images}
              style={{ width: '100%', height: '450px' }}
            />
          </Card>
        </Col>
        <Col md={5}>
        <ListGroup
            variant='flush'
            className='shadow p-5 bg-white rounded'
        >
          <ListGroup.Item>
          <h2>{products?.title}</h2>
          </ListGroup.Item>
          <ListGroup.Item>
            {' '}
            <h5 className=' d-flex justify-content-between align-items-center'>
              <span>Price:</span>
              <span>{products?.price}€</span>
            </h5>
          </ListGroup.Item>
          <ListGroup.Item>
            <h5 className=' d-flex justify-content-between align-items-center'>
              <span>Category:</span>
              <span>{products?.category.name}</span>
            </h5>
          </ListGroup.Item>
          <ListGroup.Item>
            <span>Description: </span>
            {products?.description}
          </ListGroup.Item>
          <ListGroup.Item>
            <Button
              onClick={onAdd}
              style={{ backgroundColor: '#e03a3c', color: '#fff' }}
              variant='outline-none'
              className='w-full'
              >Add To OrderItem</Button>
          </ListGroup.Item> 
        </ListGroup>
        </Col>
        {userInfo ? ( 
         <Col md={30}>
          <ListGroup.Item>
            <UpdateProduct
              id={products?.id}
              previousTitle={products?.title}
              previousDescription={products?.description}
              previousPrice={products?.price}
              previousImage={products?.images} />
          </ListGroup.Item>
          </Col>
          ) : (  
          null
          )}   
      </Row>
      <Review/>
    </Container>
  )
}

export default SingleProduct