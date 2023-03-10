import { useState } from 'react';
import { Carousel } from 'react-bootstrap';

const HomeCarousel = () => {
    const [index, setIndex] = useState(0);

    const handleSelect = (selectedIndex: number) => {
    setIndex(selectedIndex);
  };
  return (
      <Carousel activeIndex={index} onSelect={handleSelect}>
        <Carousel.Item className='carsouel__item' interval={1000}>
          <img
            className='d-block w-full '
            src='https://source.unsplash.com/164_6wVEHfI'
            alt='First slide'
          />
          <Carousel.Caption>
            <h3>Shoe</h3>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item className='carsouel__item'>
          <img
            className='d-block w-full '
          src='https://source.unsplash.com/TS--uNw-JqE'
            alt='Second slide'
          />
          <Carousel.Caption>
            <h3>Cloth</h3>
            </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item className='carsouel__item'>
          <img
            className='d-block w-full '
            src='https://source.unsplash.com/FV3GConVSss'
            alt='Third slide'
          />
          <Carousel.Caption>
            <h3>Furniture</h3>
          </Carousel.Caption>
        </Carousel.Item>
        <Carousel.Item className='carsouel__item'>
          <img
            className='d-block w-full '
            src='https://source.unsplash.com/qhnutBbnzOc'
            alt='Third slide'
          />
          <Carousel.Caption>
            <h3>Electronics</h3>
          </Carousel.Caption>
        </Carousel.Item>
    </Carousel>
  )
}

export default HomeCarousel