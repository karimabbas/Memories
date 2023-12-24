import { Card, TextField } from '@mui/material'
import React, { useEffect } from 'react'
import styles from './style';
import moment from 'moment';
import { useDispatch } from 'react-redux';
import { getAllDepts } from '../../actions/Dept';
import { Label } from 'reactstrap';

const SingleDept = ({ dept }) => {

  const classes = styles();
  const dispatch = useDispatch();

  return (
    <>
      <br></br>
      <Card className={classes.buttonSubmit}>
        <Label color='blue'> dept name</Label> :{dept.dept_name}
      </Card>
      <Card>
        <Label color='purple'> Year of Creation</Label>
        :{moment(dept.yearOfCreation).format("DD-MMMM-YYYY")}

      </Card>
    </>


  )
}

export default SingleDept
