import { React, useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { getUsers } from '../../actions/auth';
// import { Card } from '@mui/material';
import DataTable from 'react-data-table-component'
import ReactPaginate from 'react-paginate'
import {Card, CardHeader, CardTitle, CardBody, Input, Row, Col,CustomInput, Label, Button } from 'reactstrap'


function AllUsers() {

    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(getUsers())
    }, [dispatch]);

  const [searchTerm, setSearchTerm] = useState('')
  const [currentPage, setCurrentPage] = useState(1)
  const [rowsPerPage, setRowsPerPage] = useState(10)
  const [currentRole, setCurrentRole] = useState({ value: '', label: 'Select Role' })
  const [currentPlan, setCurrentPlan] = useState({ value: '', label: 'Select Plan' })
  const [currentStatus, setCurrentStatus] = useState({ value: '', label: 'Select Status', number: 0 })

    const authDataError = useSelector((state) => state.authStore)
    const AllUsers = authDataError.authData;

    const columns = [
        {
            name: "User Name",
            minWidth: '320px',
            sortable: true,
            selector: 'userName',
            cell: row => row.userName
        }, {
            name: "User Email",
            minWidth: '320px',
            sortable: true,
            selector: 'email',
            cell: row => row.email
        }

    ]

    

    const CustomPagination = () => {
        const count = Number(Math.ceil(AllUsers.total / rowsPerPage))
    
        return (
          <ReactPaginate
            previousLabel={''}
            nextLabel={''}
            pageCount={count || 1}
            activeClassName='active'
            forcePage={currentPage !== 0 ? currentPage - 1 : 0}
            // onPageChange={page => handlePagination(page)}
            pageClassName={'page-item'}
            nextLinkClassName={'page-link'}
            nextClassName={'page-item next'}
            previousClassName={'page-item prev'}
            previousLinkClassName={'page-link'}
            pageLinkClassName={'page-link'}
            containerClassName={'pagination react-paginate justify-content-end my-2 pr-1'}
          />
        )
      }

      const dataToRender = () => {
        const filters = {
          role: currentRole.value,
          currentPlan: currentPlan.value,
          status: currentStatus.value,
          q: searchTerm
        }
    
        const isFiltered = Object.keys(filters).some(function (k) {
          return filters[k].length > 0
        })
    
        if (AllUsers) {
          return AllUsers
        } else if (AllUsers === 0 && isFiltered) {
          return []
        } 
      }

      const CustomHeader = ({ toggleSidebar, handlePerPage, rowsPerPage, handleFilter, searchTerm }) => {
        return (
          <div className='invoice-list-table-header w-100 mr-1 ml-50 mt-2 mb-75'>
            <Row>
              <Col xl='6' className='d-flex align-items-center p-0'>
                <div className='d-flex align-items-center w-100'>
                  <Label for='rows-per-page'>Show</Label>
                  <Input
                    className='form-control mx-50'
                    type='select'
                    id='rows-per-page'
                    value={rowsPerPage}
                    onChange={handlePerPage}
                    style={{
                      width: '5rem',
                      padding: '0 0.8rem',
                      backgroundPosition: 'calc(100% - 3px) 11px, calc(100% - 20px) 13px, 100% 0'
                    }}
                  >
                    <option value='10'>10</option>
                    <option value='25'>25</option>
                    <option value='50'>50</option>
                  </Input>
                  <Label for='rows-per-page'>Entries</Label>
                </div>
              </Col>
              <Col
                xl='6'
                className='d-flex align-items-sm-center justify-content-lg-end justify-content-start flex-lg-nowrap flex-wrap flex-sm-row flex-column pr-lg-1 p-0 mt-lg-0 mt-1'
              >
                <div className='d-flex align-items-center mb-sm-0 mb-1 mr-1'>
                  <Label className='mb-0' for='search-invoice'>
                    Search:
                  </Label>
                  <Input
                    id='search-invoice'
                    className='ml-50 w-100'
                    type='text'
                    value={searchTerm}
                    onChange={e => handleFilter(e.target.value)}
                  />
                </div>
              
              </Col>
            </Row>
          </div>
        )
      }

    return (
        <>
            <Card>
                <DataTable
                    noHeader
                    pagination
                    subHeader
                    responsive
                    paginationServer
                    columns={columns}
                    className='react-dataTable'
                    paginationComponent={CustomPagination}
                    data={dataToRender()}
                    subHeaderComponent={
                        <CustomHeader
                          rowsPerPage={rowsPerPage}
                          searchTerm={searchTerm}
                        />
                      }

                />
            </Card>
        </>
    )
}

export default AllUsers