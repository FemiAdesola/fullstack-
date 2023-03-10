import React from 'react'
import { Card, Table } from 'react-bootstrap';

import { BoardWrapperType } from '../types/boardWrapper';


const BoardWrapper = ({children, cols}: BoardWrapperType ) => {
  return (
      <Card className=' shadow border-0 mt-5 '>
      <Table responsive hover className='table-nowrap'>
        <thead
          style={{ backgroundColor: '#000000' }}
          className='thead-light text-white'
        >
          <tr>
            {cols.map((col: any) => (
              <th key={col} scope='col'>
                {col}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>{children}</tbody>
      </Table>
    </Card>
  )
}

export default BoardWrapper