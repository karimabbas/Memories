import { CircularProgress, Grid, InputLabel, MenuItem, Paper, Select} from '@mui/material';
import { Form, Formik } from 'formik';
import React, { useEffect, useState } from 'react';
import Button from '@mui/material/Button';
import * as yup from 'yup';
import CustomInput from '../Auth/CustomInput';
import styles from "../Auth/styles";
import { useDispatch, useSelector } from 'react-redux';
import { getAllDepts } from '../../actions/Dept';
import { CreateEmployee, UpdateEmployee, getAllEmps } from '../../actions/Emp';
import SingleEmp from './SingleEmp';
import { useTranslation } from 'react-i18next';


const Employee = () => {

    const classes = styles();
    const dispatch = useDispatch();
    const { t } = useTranslation();


    const [inputfileds, SetInputFileds] = useState({
        Name: '',
        Salary: '',
        Age: '',
        Email: ''
    });

    const [department, setDepartment] = useState('');

    const EditEmp = JSON.parse(localStorage.getItem("editEmp"));

    useEffect(() => {
        dispatch(getAllDepts())
        dispatch(getAllEmps())
    }, [dispatch]);

    const all_Depts = useSelector((state) => state.DeptStore);
    const employeesStore = useSelector((state) => state.EmpStore);

    const InputSchema = yup.object({
        Name: yup.string().required("Please Enter your name"),
        Salary: yup.number().required("Please Enter your salary"),
        Email: yup.string().required("Please Enter your email").email("Pleas Enter valid Email"),
        Age: yup.number().required("Please Enter your Age"),
        department: yup.string()
    })

    const handleDept = (e) => {
        setDepartment({ [e.target.name]: e.target.value })
    }

    // useEffect(() => {
    //     if (EditEmp != null) {
    //         SetInputFileds({ Name: EditEmp.name, Salary: EditEmp.salary, Age: EditEmp.age, Email: EditEmp.email });
    //         var id = EditEmp.department.id;
    //         console.log(id)
    //         setDepartment(id)
    //     }
    //     localStorage.removeItem("editEmp");
    // }, [EditEmp]);


    const handleSubmit = (values) => {

        if (EditEmp) {
            console.log(values);
            console.log(department);
            dispatch(UpdateEmployee(EditEmp.id,{...department,...values}))
            localStorage.removeItem("editEmp");
        }else{
            dispatch(CreateEmployee({ ...department, ...values }))
        }
    }

    return (
        <>
            <Formik
                initialValues={inputfileds}
                validationSchema={InputSchema}
                onReset={() => { }}
                onSubmit={(values, { resetForm }) => {
                    handleSubmit(values)
                    resetForm();
                }}
            >

                {({ handleChange, values }) => {

                    // console.log("props", props);
                    // const { values } = props
                    if (EditEmp != null) {
                        values.Name = EditEmp.name
                    }

                    // const handelEmp = (e) => {
                    //     SetInputFileds([e.target.name], e.target.value)
                    // }

                    return (
                        <>
                            <Paper>
                                <Form>
                                    <CustomInput label={t("Name")} onChange={handleChange} value={values.Name} name="Name" type="text" />
                                    <pre></pre>

                                    <CustomInput label={t("Salary")} name="Salary" type="text" />
                                    <pre></pre>

                                    <CustomInput label="Email :" name="Email" type="text" />
                                    <pre></pre>

                                    <CustomInput label="Age :" name="Age" type="text" />
                                    <pre></pre>

                                    <InputLabel id="demo-simple-select-label" key={44}>Department :</InputLabel>
                                    <Select margin='none' sx={{ minWidth: 240 }} labelId="demo-simple-select-label" id="demo-simple-select"
                                        name="department"
                                        value={department}
                                        onChange={handleDept}
                                    >
                                        {all_Depts.map((x) => (
                                            <MenuItem value={x.id} >{x.dept_name}</MenuItem>
                                        ))}

                                    </Select>
                                    <pre></pre>
                                    {
                                        inputfileds.Name ? <Button className={classes.empButton} type="submit" variant="contained" color="warning" >
                                            Update
                                        </Button>
                                            :
                                            <Button className={classes.empButton} type="submit" variant="contained" color="success" >
                                                Save
                                            </Button>
                                    }
                                </Form>
                            </Paper>
                        </>
                    )

                }
                }

            </Formik >

            <pre></pre>
            <Paper>
                {
                    employeesStore ?
                        <Grid className={classes.mainContainer} container alignItems="stretch" spacing={4}>

                            {employeesStore.map((e) => (
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