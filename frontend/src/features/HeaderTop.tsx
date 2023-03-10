import React from 'react'

const HeaderTop = () => {
  return (
    <>
        <nav
            className='navbar navbar-expand-lg bg-dark navbar-light h-12 d-none d-lg-block'
            id='templatemo_nav_top'
        >
            <div className='container text-light'>
                <div className='w-full d-flex justify-content-between align-items-center'>
                    <div>
                        <i className='fa text-sm  fa-envelope mx-2'></i>
                        <a
                            className='navbar-sm-brand text-light text-sm text-decoration-none'
                            href='mailto:info@123.com'
                        >
                            info@123.com
                        </a>
                        <i className='fa text-sm  fa-phone mx-2'></i>
                        <a
                            className='navbar-sm-brand text-sm  text-light text-decoration-none'
                            href='tel:010-020-0340'
                        >
                            +358231791094
                        </a>
                    </div>
                    <div>
                        <a
                            className='text-light'
                            href="https://github.com/FemiAdesola"
                            target='_blank'
                            rel="noreferrer"
                        >
                            <i className='fab text-md  fa-github fa-sm fa-fw me-5'></i>
                        </a>
                        <a
                            className='text-light'
                            href="https://www.linkedin.com/in/femi-adesola-oyinloye-106454145/"
                            target='_blank'
                            rel="noreferrer"
                        >
                            <i className='fab text-md fa-linkedin fa-sm fa-fw me-5'></i>
                        </a>
                        <a
                            className='text-light'
                            href='/'
                            target='_blank'
                            rel="noreferrer"
                        >
                            <i className='fab text-md  fa-facebook-f fa-sm fa-fw me-2'></i>
                        </a>
                    </div>
                </div>
            </div>
        </nav>
    </>
  )
}

export default HeaderTop