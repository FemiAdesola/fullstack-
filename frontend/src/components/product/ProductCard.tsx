import { Card } from 'react-bootstrap';
import { Link } from 'react-router-dom';

import { ProductType } from '../../types/product';

const ProductCard = ({ id, title, price, images, category }: ProductType) => {

  return (
    <Card className='my-2 p-1 rounded' style={{ height: '22rem' }}>
      <Link to={`/products/${id}`}>
        <Card.Img
          src={images}
          variant='top'
          style={{ height: '250px', width: '100%', objectFit: 'cover' }}
        />
        <Card.Body>
          <Card.Title className='d-flex justify-content-between align-items-baseline mb-4'>
            <span className='fs-2'>{title}</span>
            <span className='ms-2 text-muted'>{category.name}</span>
             <span className='ms-2 text-muted'>{price}€</span>
          </Card.Title>
        </Card.Body>
      </Link>
    </Card>
  )
}

export default ProductCard