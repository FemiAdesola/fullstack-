import { useEffect, useState } from 'react';
import { Button, Container, Image, Nav, Row} from 'react-bootstrap';
import { FaEdit, FaTrash } from 'react-icons/fa';
import { Link, NavLink,  useParams } from 'react-router-dom';


import { useAppDispatch, useAppSelector } from '../../hooks/reduxHooks';
import BoardWrapper from '../../features/BoardWrapper';
import toast from 'react-hot-toast';
import axiosInstance from '../../common/axiosIntsance';
import { getAllProducts } from '../../redux/method/productMethod';

const ProductBoard = () => {
    const dispatch = useAppDispatch();
    let { id } = useParams()
    let products = useAppSelector(state => state.productReducer);
    const [refresh, setRefresh] = useState<boolean>(true);
    const [show, setShow] = useState<boolean>(false);
    const onOpen = () => setShow(true);
    const onClose = () => setShow(false);
    const cols = [
        'image',
        'title',
        'description',
        'category',
        'price',
        'options',
    ];
    const onDelete = (id: string | number) => {
        if (window.confirm('Check, are you sure you want to delete this?')) {
        axiosInstance
            .delete(`/products/${id}`)
            .then((res) => {
                toast.success('Product has beend deleted');
            setRefresh((prev) => (prev = !prev));
            })
            .catch((e) => toast.error((e)));
        }
    };
    useEffect(() => {
    dispatch(getAllProducts())
    }, [refresh])
  return (
      <Container fluid>
          <Row className='py-3'>
            <h3 className='d-flex justify-content-between align-items-center'>
                <span>Product List</span>
                <Button
                style={{ backgroundColor: '#e03a34', color: '#fff' }}
                variant='outline-none'
                onClick={onOpen}
                size='sm'
                >
                <Nav.Item as={NavLink} className='nav-link' to='/create'>
                        <span>CreateProduct</span>
                    </Nav.Item>    
                  </Button>
                <Button
                style={{ backgroundColor: '#e03a34', color: '#fff' }}
                variant='outline-none'
                onClick={onOpen}
                size='sm'
                >
                    <Nav.Item as={NavLink} className='nav-link' to='/categories'>
                        <span>Check Categories</span>
                    </Nav.Item>    
                </Button>
            </h3>
            <BoardWrapper cols={cols} >
            {Array.isArray(products)? products.map((product) => (
              <tr key={product?.id}>
                <td>
                  <Image className='avatar' roundedCircle src={product?.images} />
                </td>
                <td>{product?.title}</td>
                <td>{product?.description}</td>
                {/* <td>{product?.category.name}</td> */}
                <td>{(product?.price)}</td>
                <td>
                <Link
                    className='btn btn-sm btn-success me-2'
                    to={`/productList/${product?.id}`}
                >
                    <FaEdit />
                </Link>
                <Button
                    onClick={() => onDelete(product?.id)} 
                    variant='danger'
                    size='sm'
                >
                    <FaTrash />
                </Button>
                </td>
              </tr>
            )): null}                
          </BoardWrapper>
          </Row>
    </Container>
  )
}

export default ProductBoard