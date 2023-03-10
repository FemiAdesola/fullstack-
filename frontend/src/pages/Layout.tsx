import React from 'react'
import { Outlet, useLocation } from "react-router-dom"
import { ThemeProvider } from "react-bootstrap"
import Header from '../components/Header'
import Footer from '../components/Footer'
import FooterBottom from '../features/FooterBottom'


const Root = () => {
   const location = useLocation();
    const isHome = location.pathname === '/';
    
    return (
        <ThemeProvider >
            <Header />
            <Outlet />
            <Footer />
             <div id='footer'>
                {isHome && <FooterBottom />}
            </div>
        </ThemeProvider>
    )
}

export default Root