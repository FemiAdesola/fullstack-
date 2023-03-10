import { createBrowserRouter, RouterProvider } from 'react-router-dom'

import CategoryBoard from './components/category/CategoryBoard';
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
    ]
  }
])

function App() {
  return (
    <RouterProvider router={router}/>
  );
}

export default App