import { useEffect, useMemo, useState } from 'react';
import { Row, Container, Col, Card, Form, ListGroup, FormSelect } from 'react-bootstrap';
import debouce from "lodash.debounce";

import ProductCard from './ProductCard';
import { useAppSelector, useAppDispatch } from '../../hooks/reduxHooks';
import Loader from '../Loader/Loader';
import { getAllProducts } from '../../redux/method/productMethod';
import { getAllCategories } from '../../redux/method/categoryMethod';
import { sortByName, sortByPrice } from '../../redux/reducers/productReducer';

const Products = () => {
  const [search, setSearch] = useState("")
  const [filteredValue, setFilteredValue] = useState("");
  const [isLoading, setIsLoading] = useState(true)
  let products = useAppSelector(state => state.productReducer)
  const dispatch = useAppDispatch()  
  const categories = useAppSelector(state => state.categoryReducer)
  const handleChange = (e: { target: { value: React.SetStateAction<string>; }; }) => {
  setSearch(e.target.value);
  };
  const reset = () => {
    setFilteredValue('');
    setSearch('');
    };
    if (search !== "") {
        products = products.filter(item => {
        return item.title.toLowerCase().includes(search.toLowerCase())
        })
    }
    const debouncedResults = useMemo(() => {
      return debouce(handleChange, 1000);
  }, []);
  useEffect(() => {
      return () => {
        debouncedResults.cancel();
      };
  });
  useEffect(() => {
    dispatch(getAllProducts())
    dispatch(getAllCategories())
    setIsLoading(false)
  }, [])
  if (filteredValue) {
    products = products.filter((item) => {
      return item.category.name.toLowerCase().includes(filteredValue)
    })
  } 
  const sortByNameA = () => {
    dispatch(sortByName("asc"))
  }
  const sortByNameD = () => {
    dispatch(sortByName("desc"))
  }
  const sortByProductPriceA = () => {
    dispatch(sortByPrice("asc"))
  }
   const sortByProductPriceD = () => {
    dispatch(sortByPrice("desc"))
  }
  return (
    <>
      { isLoading && !products ? (
        <Loader />
        ) : (
      <Container>
        <Row className='pt-4'>
          <Col lg={3}>
            <h2 className='py-4'>Filter</h2>
            <Card className='shadow p-3'>
              <ListGroup variant='flush'>
                <ListGroup.Item>
                  <h4 className='mb-2'>Category</h4>
                  <FormSelect
                    defaultValue={'All'}
                    onChange={(e: any) => {
                      if (e.target.value === "All") {
                        reset();
                      } else {
                        setFilteredValue(e.target.value);
                      }
                    }}
                  >
                    <option value='All'>All</option>
                    All
                    { categories.map((category) => (
                      <option value={category.name.toLowerCase()} key={category.id}>
                        {category.name.toLowerCase()}
                      </option>
                    ))}
                  </FormSelect>
                    </ListGroup.Item>
                <ListGroup.Item>
                  <h4 className='mb-2'>Price</h4>
                  <FormSelect
                    defaultValue={'All'}
                        onChange={(e: any) =>
                        {
                          if (e.target.value === "All") {
                           dispatch(sortByPrice("asc"));
                          } else if(e.target.value === "asc") {
                            sortByProductPriceA();
                          } else if(e.target.value === "desc"){
                            sortByProductPriceD()
                          }
                        }
                    }    
                  >
                    <option value='All'>All</option>
                    All
                      <option value='asc'>
                        A-Z
                        </option>
                        <option value='desc'>
                        Z-A
                      </option>
                    
                  </FormSelect>
                </ListGroup.Item>
                <ListGroup.Item>
                      <h4 className='mb-2'>Get by Title</h4>
                       <FormSelect
                    defaultValue={'All'}
                        onChange={(e: any) =>
                        {
                          if (e.target.value === "All") {
                            dispatch(sortByName("asc"));
                          } else if(e.target.value === "asc") {
                            sortByNameA();
                          } else if(e.target.value === "desc"){
                            sortByNameD()
                          }
                        }
                    }    
                  >
                  <option value='All'>All</option>
                    All
                      <option value='asc'>
                        A-Z
                        </option>
                        <option value='desc'>
                        Z-A
                  </option>
                  </FormSelect>
                </ListGroup.Item>
              </ListGroup>
            </Card>
          </Col>
          <Col lg={9}>
            <Row>
              <div className='col-md-6 pb-4'>
                <div className='d-flex'>
                  <Form.Control
                    onChange={debouncedResults}
                    className='me-2'
                    placeholder='Search...'
                  />
                </div>
              </div>
            </Row>
            <Row style={{ minHeight: '80vh' }}>
              {Array.isArray(products)? products.map((product) => (
                <Col lg={4} md={6} xs={12} key={product.id}>
                      <ProductCard 
                          images={product.images}
                            title={product.title}
                            price={product.price}
                            category={product.category}
                            description={product.description}
                            id={product.id}
                      />
                </Col>
              )):null}
            </Row>
          </Col>
          </Row>
      </Container>
      )}
    </>
  )
}

export default Products