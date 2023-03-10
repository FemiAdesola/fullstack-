import React from 'react'
import { Col, Container, Image, Row } from 'react-bootstrap';
import toast from 'react-hot-toast';


const Footer = () => {
  return (
      <footer id='footer' >
      <div className='footer-top'>
        <Container>
          <Row>
            <Col lg={3} md={6} xs={12} className='footer-contact'>
              <h3>
                <Image width={100} src='https://source.unsplash.com/gsUwEUr61NQ' alt='' />
              </h3>
              <p>
               Kiltaveljenpolku 
                <br />
                Espoo
                <br />
                Finland
                <br />
                <br />
                <strong>Phone:</strong> +3581234567
                <br />
                <strong>Email:</strong> info@123.com
                <br />
              </p>
            </Col>
            <Col lg={2} md={6} xs={6} className='footer-links'>
              <h4>Useful Links</h4>
              <ul>
                <li>
                  <i className='bx bx-chevron-right' /> <a href='/'>Home</a>
                </li>
                <li>
                  <i className='bx bx-chevron-right' /> <a href='/products'>Our products</a>
                </li>
                <li>
                  <i className='bx bx-chevron-right' /> <a href='/'>Services</a>
                </li>
                <li>
                  <i className='bx bx-chevron-right' />{' '}
                  <a href='/'>Terms of service</a>
                </li>
                <li>
                  <i className='bx bx-chevron-right' />{' '}
                  <a href='/'>Privacy policy</a>
                </li>
              </ul>
            </Col>
            <Col lg={3} md={6} xs={6} className='footer-links'>
            <h4>Our Services</h4>
              <ul>
                <li>
                  <i className='bx bx-chevron-right' />{' '}
                  <a href='/'>Web Design</a>
                </li>
                <li>
                  <i className='bx bx-chevron-right' />{' '}
                  <a href='/'>Web Development</a>
                </li>
                <li>
                  <i className='bx bx-chevron-right' />{' '}
                  <a href='/'>Product Management</a>
                </li>
                <li>
                  <i className='bx bx-chevron-right' />{' '}
                  <a href='/'>Marketing</a>
                </li>
              </ul>
            </Col>
            <Col lg={4} md={6} className='footer-newsletter'>
              <h4>Subscribe to our newsletter</h4>
              <p>
                Lorem ipsum, dolor sit amet consectetur adipisicing elit. Error quod molestias sit sint repellat rerum id,
              </p>
              <form onSubmit={() => toast.success('Thank you for your Subscrition')}>
                <input
                  type='email'
                  required
                  placeholder='info@123.com'
                  name='email'
                />
                <input type='submit' defaultValue='Subscribe' />
              </form>
            </Col>
          </Row>
        </Container>
      </div>
    </footer>
  )
}

export default Footer