import React from 'react'
import { Card } from 'react-bootstrap';
import { Link } from 'react-router-dom';

import { CategoryType } from '../../types/category';

const CategoryCard = ({ name, image}: CategoryType) => {
  return (
    <Card className='my-3 p-2 rounded' style={{ height: '20rem', width:'100%' }}>
      <Link to={`/products`}>
        <Card.Img
          src={image}
          variant='top'
          style={{ height: '250px', width: '100%', objectFit: 'cover' }}
        />
        <Card.Body>
          <Card.Title className='d-flex justify-content-between align-items-baseline mb-4'>
            <span className='fs-2 align-items-baseline'>{name}</span>
          </Card.Title>
        </Card.Body>
      </Link>
    </Card>
  )
}

export default CategoryCard