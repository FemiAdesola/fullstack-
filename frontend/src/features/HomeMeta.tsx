import React from 'react'
import { Helmet } from 'react-helmet';

import { Props } from '../types/homeLayout';

const HomeMeta = ({
  webHeading= 'eCommerce App',
  comment= 'eCommerce store',
  keywords,
}:Props) => { 
  return (
    <Helmet>
      <title>{webHeading}</title>
      <meta name='description' content={comment} />
      <meta name='keyword' content={keywords} />
    </Helmet>
  )
}

export default HomeMeta