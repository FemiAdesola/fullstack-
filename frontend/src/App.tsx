import { createBrowserRouter, RouterProvider } from 'react-router-dom'

import CategoryBoard from './components/category/CategoryBoard';
import Products from './components/product/Products';
import SingleProduct from './components/product/SingleProduct';
import Home from './pages/Home';
import Layout from './pages/Layout';

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
      }
    ]
  }
])

function App() {
  return (
    <RouterProvider router={router}/>
  );
}

export default App