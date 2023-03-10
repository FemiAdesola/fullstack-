import React from 'react'
import { Outlet, useLocation } from "react-router-dom"
import { ThemeProvider } from "react-bootstrap"
import Header from '../components/Header'


const Root = () => {
   const location = useLocation();
    const isHome = location.pathname === '/';
    
    return (
        <ThemeProvider >
            <Header />
            <Outlet />
        </ThemeProvider>
    )
}

export default Root