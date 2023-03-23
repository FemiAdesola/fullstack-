import React, { useEffect, useState } from 'react'
import { Row, Container, Col, Card, Button, Image} from 'react-bootstrap';
import { FaTrash } from 'react-icons/fa';
import { Link, useNavigate, useParams } from 'react-router-dom';
import toast from 'react-hot-toast';

import { useAppDispatch } from '../../hooks/reduxHooks';
import { CategoryType } from '../../types/category';
import axiosInstance from '../../common/axiosIntsance';
import { deleteCategory } from '../../redux/method/categoryMethod';
import UpdateCategory from './UpdateCategory';

const SingleCategory = () => {
    const params = useParams();
    const navigate = useNavigate();
    const dispatch = useAppDispatch()
    const { id } = params;
    const [category, setCategory] = useState<CategoryType>()
    const [refresh, setRefresh] = useState<boolean>(true);  
    useEffect(() => {
    const singleProductDetails = async () => {
      try {
        const res = await axiosInstance.get<CategoryType>(`categories/${id}`);
        setCategory(res.data);
      } catch (err) {
        console.log(err);
      } 
    };
    singleProductDetails();
    }, [refresh,id]);
    const deleteCategoryHandler = () => {
        if (window.confirm('Check, are you sure you want to delete this?'))
            dispatch(deleteCategory(id))
            toast.success('Product has beend deleted');
            navigate("/categories")
            setRefresh((prev) => (prev = !prev));
    }
    return (
    <Container style={{marginBottom:'300px'}}>
        <Row  className='pt-4'>
            <Col md={5}>
                <Card className='shadow'>
                    <Image
                        className=' p-1'
                        rounded
                        src={category?.image}
                        style={{ width: '100%', height: '100%' }}
                    />
                    <Card.Body>
                        <Card.Title className='d-flex justify-content-between align-items-baseline mb-4'>
                            <span className='fs-2 align-items-baseline'>{category?.name}</span>
                        </Card.Title>
                    </Card.Body>
                    <Button
                        onClick={deleteCategoryHandler}
                        variant='danger'
                        size='lg'
                    >
                        DELETE <FaTrash />
                        </Button> 
                    <Col className='pt-5 mb-10' >
                        <Link to='/categories' className='mx-3'>
                            Get back to category list
                        </Link>
                    </Col>    
                </Card> 
            </Col>
            <Col md={7}>
                    <UpdateCategory
                        previousName={category?.name}
                        previousImage={category?.image}
                        id={category?.id}                            
                />         
            </Col> 
        </Row> 
    </Container>
  )
}

export default SingleCategory

