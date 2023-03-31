import React, { useEffect, useState } from 'react'
import { Col, Container, Row } from 'react-bootstrap'

import { useAppDispatch, useAppSelector } from '../../hooks/reduxHooks'
import { getAllCategories } from '../../redux/method/categoryMethod'
import Loader from '../Loader/Loader'
import CategoryCard from './CategoryCard'

const Categories = () => {
    const [isLoading, setIsLoading] = useState(true)
    const categories = useAppSelector(state => state.categoryReducer)
    const dispatch = useAppDispatch()
    useEffect (() => {
        dispatch(getAllCategories())
        setIsLoading(false) 
    }, [])
  return (
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
                )): null}
              </Row>
            </Col>
        )}
        </Container>
  )
}

export default Categories