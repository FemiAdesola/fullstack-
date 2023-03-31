import { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import { Row, Container, Col} from 'react-bootstrap';

import { HomeLayout } from '../types/homeLayout';
import HomeCarousel from '../features/HomeCarousel';
import HomeMeta from '../features/HomeMeta';
import { useAppDispatch, useAppSelector } from '../hooks/reduxHooks';
import CategoryCard from '../components/category/CategoryCard';
import Loader from '../components/Loader/Loader';
import { getAllCategories } from '../redux/method/categoryMethod';

const Home = ({ title, description, children, }: HomeLayout) => {
  const location = useLocation();
  const isHome = location.pathname === '/';
  const [isLoading, setIsLoading] = useState(true)
  const categories = useAppSelector(state => state.categoryReducer)
  const dispatch = useAppDispatch()
  useEffect (() => {
    dispatch(getAllCategories())
    setIsLoading(false) 
  }, [])
  
  return (
    <>
      <HomeMeta webHeading={title} comment={description} />
      {isHome && <HomeCarousel />}
      <main id='main' className='py-2'>
        {children}
        <Container>
          <h2 style={{ color: '#e03a3c' }} className='mt-5'>
            Categories of our products
          </h2>
          { isLoading || !categories ? (
            <Loader />
              ) : (
            <Col lg={12} className='ml-5'>
              <Row md={3} xs={1} lg={3} style={{ minHeight: '60vh' }}>
                {Array.isArray(categories)? categories.map((category) => (
                  <Col lg={4} md={6} xs={12} key={category.id} gap={5}>
                      <CategoryCard 
                        image={category.image}
                        name={category.name}
                        id={category.id}  
                      />
                  </Col>
                )):null}
              </Row>
            </Col>
        )}
        </Container>
      </main>
    </>
  )
}

export default Home