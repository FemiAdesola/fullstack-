import React from 'react'
import { Navbar, Nav, NavDropdown } from 'react-bootstrap';
import { Link, NavLink, useNavigate} from 'react-router-dom';
import Form from 'react-bootstrap/Form';

import HeaderTop from '../features/HeaderTop';
import { useAppDispatch, useAppSelector } from '../hooks/reduxHooks';
import { userLogout } from '../redux/reducers/userReducer';
import { reset } from '../redux/reducers/orderItemReducer';

const Header = () => {
    const dispatch = useAppDispatch();
    const navigate = useNavigate();
    const userInfo = useAppSelector((state) => state.userReducer.currentUser);
    const { orderItems } = useAppSelector((state) => state.orderItemReducer);
    const onLogout = () => { 
        dispatch(userLogout())
        dispatch(reset());
        navigate('/login');
    }
    const ToggleSwitch = () => {
        return (
          <>
            <Form>
            <Form.Check 
              type="switch"
                id="custom-switch"
                className='mt-5'
              />
            </Form>
            </>
        );
    };
  return (
    <>
    <HeaderTop/>
        <Navbar
            collapseOnSelect
            expand='lg'
            sticky='top'
            bg='white'
            className='shadow px-0 py-3'
            >
            <div className='container-xl'>
                <Navbar.Brand as={NavLink} to='/'>
                    <img
                    src='https://source.unsplash.com/gsUwEUr61NQ'
                    className='avatar rounded me-lg-10'
                    alt='...'
                    />
                </Navbar.Brand>
                <Navbar.Toggle aria-controls='responsive-navbar-nav' />
                
                <Navbar.Collapse id='responsive-navbar-nav'>
                
                    <div className='navbar-nav me-lg-auto'>
                    <Nav.Item
                    as={NavLink}
                    className=' nav-link active'
                    to='/'
                    aria-current='page'
                    >
                    <span>Home</span>
                </Nav.Item>
                <Nav.Item as={NavLink} className=' nav-link' to='/products'>
                    <span>Product</span>
                </Nav.Item>

                <Nav.Item as={NavLink} className=' nav-link' to='/createcategory'>
                    <span>CreateCategory</span>
                </Nav.Item>

                <Nav.Item as={NavLink} className=' nav-link' to='/contact'>
                    <span>Contact</span>
                </Nav.Item>
                    {userInfo ? (   
                <Nav.Item as={NavLink} className=' nav-link' to='/productList'>
                    <span>ListProduct</span>
                </Nav.Item>
                    ) : (  
                        null
                    )} 
                <Nav.Item>
                    <span><ToggleSwitch /></span>
                </Nav.Item>
            </div>
            <div className='d-flex align-items-center'>
                <div className='d-flex align-items-center'>
                    <Link className='nav-link' to={'/products'}>
                        <i className='fa fa-fw fa-search text-dark me-2'></i>
                    </Link>
                    <Link
                    className='nav-icon position-relative text-decoration-none' to={'/cart'}                 
                    >
                        <i className='fa fa-fw fa-cart-arrow-down text-dark me-2 '></i>
                        <span
                            style={{ backgroundColor: '#e03a3c' }}
                            className='position-absolute top-0 left-100 translate-middle badge rounded-pill  text-white'
                                  >
                    {orderItems.length}
                    </span>
                    </Link>
                          </div>
                {!userInfo ? (
                <>
                    <div className='d-flex align-items-lg-center mt-3  mt-lg-0'>
                        <Nav.Link
                            as={NavLink}
                            to='/login'
                            style={{ width:'100px' }}
                            className='btn btn-secondary btn-sm text-white me-5 ms-5 p-2'
                            >
                            Login
                        </Nav.Link>
                    </div>
                    <div className='d-flex align-items-lg-center mt-3 mt-lg-0'>
                        <Nav.Link
                            as={NavLink}
                            to='/signup'
                            style={{ backgroundColor: '#e03a3c', width:'100px' }}
                            className='btn btn-sm text-white  ms-xs-3 p-2'
                            >
                            Register
                        </Nav.Link>
                    </div>
                </>
                ):(
                    <NavDropdown
                        title={<i className='fa fa-fw fa-user text-dark mr-5 me-5 ms-5'></i>}
                        id='basic-nav-dropdown'
                        >
                    <NavDropdown.Item as={NavLink} to='/products'>
                        Products
                    </NavDropdown.Item>
                    <NavDropdown.Item
                        as={NavLink}
                        to={"/profile"}
                        >
                        Profile
                    </NavDropdown.Item>
                    <NavDropdown.Divider />
                        <NavDropdown.Item onClick={onLogout}>Logout</NavDropdown.Item>
                    </NavDropdown>
                )}
            </div>
            </Navbar.Collapse>
        </div>
        </Navbar>
    </>
  )
}

export default Header