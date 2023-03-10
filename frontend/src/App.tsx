import { createBrowserRouter, RouterProvider } from 'react-router-dom'

import CategoryBoard from './components/category/CategoryBoard';


const router = createBrowserRouter([
  {
    path: '/',
    
    children: [
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