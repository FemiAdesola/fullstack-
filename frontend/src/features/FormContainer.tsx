import React from 'react'
import { Container, Row, Col, Card, Image } from 'react-bootstrap';

import { FormTypes } from '../types/user';

const FormContainer = (props:FormTypes) => {
  return (
    <Container>
        <Row className=' justify-content-center py-6'>
          <Col md={6}>
            <Card>
              <h1 style={{ color: '#e03a3c' }} className='text-center my-3'>
                {props.title}
              </h1>
              {props.src && (
                <Image src={props.src} style={{ height: '250px' }} />
              )}
              <Card.Body>{props.children}</Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
  )
}

export default FormContainer