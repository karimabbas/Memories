import React from 'react';
import styles from '../Dept/style.js';
import { Card, CardTitle, Label } from 'reactstrap';
import Button from '@mui/material/Button';
import { useDispatch, useSelector } from 'react-redux';
import { GetEmp, deleteEmp } from '../../actions/Emp.js';
import DeleteIcon from '@mui/icons-material/Delete';
import withReactContent from 'sweetalert2-react-content'
import Swal from 'sweetalert2'

const SingleEmp = ({ emp }) => {

    const classes = styles();
    const MySwal = withReactContent(Swal)
    const dispatch = useDispatch()

    const handleDeleteConfirm = (id) => {
        return MySwal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            customClass: {
                confirmButton: 'btn btn-primary',
                cancelButton: 'btn btn-outline-danger ml-1'
            },
            buttonsStyling: false
        }).then(function (result) {
            if (result.value) {
                console.log(result.value)
                dispatch(deleteEmp(id))
                MySwal.fire({
                    icon: 'success',
                    title: 'Deleted!',
                    text: 'Your post has been deleted.',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    }
                })
            }
        })
    }

    const handleEdit = (id) => {
        dispatch(GetEmp(id))
    }
    
    return (
        <>
            <pre></pre>
            <Card className={classes.buttonSubmit}>
                <Label color='#99886f'>name</Label> :{emp.name}
                <p> <span color='#7f9175'> Email : </span> {emp.email}</p>
                <p> <span color='#99886f'> Age : </span> {emp.age} years</p>
                <p> <span color='#99886f'> Salary : </span> {emp.salary} $</p>
                <CardTitle> <span color='yellow' >Department:</span> {emp?.department?.dept_name}</CardTitle>
            </Card>
            <pre></pre>
            <Button className={classes.empButton} onClick={() => { handleDeleteConfirm(emp.id) }} type="submit" variant="contained" color="error" >
                Delete
            </Button>
            <Button className={classes.empButton} onClick={() => { handleEdit(emp.id) }} type="submit" variant="contained" color="warning" >
                Edit
            </Button>


        </>
    );
};

export default SingleEmp;