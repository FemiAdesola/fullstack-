import { createBrowserRouter, RouterProvider } from 'react-router-dom'

import CategoryBoard from './components/category/CategoryBoard';
import CreateCategory from './components/category/CreateCategory';
import Contact from './components/Contact';
import CreateProduct from './components/product/CreateProduct';
import Products from './components/product/Products';
import SingleProduct from './components/product/SingleProduct';
import Home from './pages/Home';
import Layout from './pages/Layout';
import OrderItem from './components/orderItem/OrderItem';
import Checkout from './components/orderItem/Checkout';
import ShippingAddress from './components/orderItem/ShippingAddress';
import OrderDetails from './components/order/OrderDetails';
import SignUp from './components/user/SignUp';
import Login from './components/user/Login';
import Profile from './components/user/Profile';

const router = createBrowserRouter([
  {
    path: '/',
    element: <Layout />,

    children: [
      {
        path: '/',
        element: <Home children={undefined}/>
      },
      {
        path: 'categories',
        element: <CategoryBoard/>
      },
      {
        path: '/products',
        element: <Products />
      },
       {
        path: 'products/:id',
        element: <SingleProduct />
      },
      {
        path: 'createcategory',
        element: <CreateCategory />
      },
      {
        path: 'create',
        element: <CreateProduct />
      },
      {
        path: 'contact',
        element: <Contact />
      },
       {
        path: 'orderitem',
        element: <OrderItem />
      },
       {
        path: 'checkout',
        element: <Checkout/>
      },
      {
        path: 'shipping',
        element: <ShippingAddress />
      },
      {
        path: 'orders/:id',
        // path: 'order',
        element: <OrderDetails/>
      },
      {
        path: 'signup',
        element: <SignUp />
      },
      {
        path: 'login',
        element: <Login />
      },
      {
        path: 'profile',
        element: <Profile/>
      },
    ]
  }
])

function App() {
  return (
    <RouterProvider router={router}/>
  );
}

export default App