import { Card, CircularProgress, FormControl, Grid, InputLabel, LinearProgress, MenuItem, Paper, Select, Typography } from '@mui/material';
import { Form, Formik } from 'formik';
import React, { useEffect, useState } from 'react';
import Button from '@mui/material/Button';
import * as yup from 'yup';
import CustomInput from '../Auth/CustomInput';
import styles from "../Auth/styles"
import stylesColor from "../Navbar/styles";
import { useDispatch, useSelector } from 'react-redux';
import { getAllDepts } from '../../actions/Dept';
import { CreateEmp } from '../../api';
import { CreateEmployee, getAllEmps } from '../../actions/Emp';
import { CardTitle } from 'reactstrap';
import SingleEmp from './SingleEmp';


const Employee = () => {

    const classes = styles();
    const classcolor = stylesColor();
    const dispatch = useDispatch();
    const [allDepts, setAllDepts] = useState();

    const [inputfileds, SetInputFileds] = useState({
        Name: '',
        Salary: '',
        Age: '',
        Email: ''
    });

    const [department, setDepartment] = useState({
    });

    useEffect(() => {
        dispatch(getAllDepts())
        dispatch(getAllEmps())
    }, [dispatch]);

    const all_Depts = useSelector((state) => state.DeptStore);
    const all_Emps = useSelector((state) => state.EmpStore);
    console.log(all_Emps)

    const InputSchema = yup.object({
        Name: yup.string().required("Please Enter your name"),
        Salary: yup.number().required("Please Enter your salary"),
        Email: yup.string().required("Please Enter your email").email("Pleas Enter valid Email"),
        Age: yup.number().required("Please Enter your Age"),
        Department: yup.string()
    })

    const handleDept = (e) => {
        setDepartment({ ...department, [e.target.name]: e.target.value })
    }

    const handleSubmit = (values) => {

        dispatch(CreateEmployee({ ...department, ...values }))
        
    }

    return (
        <>
            <Formik
                initialValues={inputfileds}
                validationSchema={InputSchema}
                onSubmit={(values) => {
                    handleSubmit(values)
                }}
                onReset={()=> {
                
                }}
            >
                {
                    () => (
                        <>
                            {
                                <Paper>
                                    <Form>
                                        <CustomInput label="Name : " name="Name" type="text" />
                                        <pre></pre>

                                        <CustomInput label="Salary : " name="Salary" type="text" />
                                        <pre></pre>

                                        <CustomInput label="Email : " name="Email" type="text" />
                                        <pre></pre>

                                        <CustomInput label="Age : " name="Age" type="text" />
                                        <pre></pre>

                                        <InputLabel id="demo-simple-select-label">Department :</InputLabel>
                                        <Select margin='none' sx={{ minWidth: 240 }} labelId='demo-simple-select-label'
                                            id="demo-simple-select"
                                            name='Department'
                                            onChange={handleDept}
                                        >
                                            {all_Depts.map((x) => (
                                                <MenuItem value={x.id} >{x.dept_name}</MenuItem>
                                            ))}

                                        </Select>
                                        <pre></pre>
                                        <Button className={classes.empButton} type="submit" variant="contained" color="success" >
                                            Save
                                        </Button>
                                    </Form>
                                </Paper>
                            }


                        </>

                    )
                }

            </Formik >

            <pre></pre>
            <Paper>
                {
                    all_Emps ?
                        <Grid className={classes.mainContainer} container alignItems="stretch" spacing={4}>

                            {all_Emps.map((e) => (
                                <Grid key={e.id} item xs={12} sm={6} md={6}>
                                    <SingleEmp emp={e} />
                                </Grid>
                            ))}
                        </Grid>

                        : <CircularProgress />
                }
            </Paper>
        </>
    );
}

export default Employee