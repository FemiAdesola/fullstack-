import React, { useEffect, useState } from 'react';
import { Row, Container, Col, Card, ListGroup, Image } from 'react-bootstrap';
import { useParams } from 'react-router-dom';

import axiosInstance from '../../common/axiosIntsance';
import { ProductType } from '../../types/product';
import Review from './Review';
import UpdateProduct from './UpdateProduct';

const SingleProduct = () => {
  const params = useParams();
  const { id } = params;
  const [products, setProducts] = useState<ProductType>()
 
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
  return (
    <Container style={{marginBottom:'200px'}}>
      <Row  className='pt-4'>
        <Col md={7}>
          <Card className='shadow'>
            <Image
              className=' p-3'
              rounded
              src={products?.images}
              style={{ width: '100%', height: '100%' }}
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
          </ListGroup>
        </Col>
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
      </Row>
      <Review/>
    </Container>
  )
}

export default SingleProduct