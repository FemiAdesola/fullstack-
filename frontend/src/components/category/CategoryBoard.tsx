import React, { useEffect, useState } from 'react'
import { Button, Container, Image, Nav, Row } from 'react-bootstrap';
import { NavLink} from 'react-router-dom';


import BoardWrapper from '../../features/BoardWrapper';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHooks'
import { getAllCategories } from '../../redux/method/categoryMethod';


const CategoryBoard = () => {
    const categories = useAppSelector(state => state.categoryReducer)
    const dispatch = useAppDispatch();
    const [show, setShow] = useState<boolean>(false);
    const onOpen = () => setShow(true);
    const onClose = () => setShow(false);
    const cols = [
        'image',
        'name',
        'options',
    ];
    useEffect(() => {
    dispatch(getAllCategories())
    }, [])
    return (
        <Container fluid>
            <Row className='py-3'>
                <h3 className='d-flex justify-content-between align-items-center'>
                    <span>List of Category </span>
                    <Button
                    style={{ backgroundColor: '#e03a34', color: '#fff' }}
                    variant='outline-none'
                    onClick={onOpen}
                    size='sm'
                    >
                        <Nav.Item as={NavLink} className='nav-link' to='/createcategory'>
                            <span>Create Category</span>
                        </Nav.Item>    
                    </Button>
                </h3>
                <BoardWrapper cols={cols} >
                {Array.isArray(categories)? categories.map((category) => (
                <tr key={category?.id}>
                    <td>
                    <Image className='avatar' roundedCircle src={category?.image} />
                    </td>
                    <td>{category?.name}</td>
                    <td>
                    <Button
                        variant='danger'
                        size='sm'
                        >
                        <Nav.Item as={NavLink} className='nav-link' to={`${category?.id}`}>
                            <span>Check Details</span>
                        </Nav.Item>  
                    </Button>
                    </td>
                </tr>
                )): null}                
            </BoardWrapper>
            </Row>
        </Container>
    )
}

export default CategoryBoard