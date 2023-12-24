import React, { useEffect, useState } from 'react';
import * as yup from 'yup';
import { Formik, Form, Field } from "formik";
import styles from "./styles"
import { Avatar, Button, Container, Grid, Paper } from '@mui/material';
import stylesColor from "../Navbar/styles";
import { useDispatch, useSelector } from 'react-redux';
import { signup, signin } from '../../actions/auth';
import authStore from '../../reducers/authStore';
import { useNavigate } from 'react-router-dom';
import CustomInput from './CustomInput';


const Auth = () => {

    const classes = styles();
    const classcolor = stylesColor();
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const [signUp, setSignUp] = useState(false);

    const [inputfileds, SetInputFileds] = useState({
        FirstName: "",
        Email: "",
        Password: "",
        ConfirmPassword: "",
        RememberMe: false
    });

    const [inputfiledsx, SetInputFiledsx] = useState({
        Email: "",
        Password: "",
        ConfirmPassword: "",
    });

    const user = JSON.parse(localStorage.getItem("UserProfile"));

    const authDataError = useSelector((state) => state.authStore)
    const ServErrors = authDataError.authData;
    const errors = useSelector((state) => state.ErrorStore)

    const [serverErrors, setServerErrors] = useState();

    const [dberrors, SetDbErrors] = useState();

    const InputSchema = yup.object({

        FirstName: yup.string()
            .required("User Name Filed is Requierd")
            .trim()
            .matches(/^'?\p{L}+(?:[' ]\p{L}+)*'?$/u, "as")
            .strict(/^'?\p{L}+(?:[' ]\p{L}+)*'?$/u, '* This field cannot contain only blankspaces'),

        Email: yup.string()
            .required("Email Filed is Requierd")
            .email("Please Enter Valid Email Address"),

        Password: yup.string().required("Password is required").min(8, "Password must be at least 8 characters long"),

        ConfirmPassword: yup.string().oneOf([yup.ref('Password'), null], 'Passwords must match').required("Passwords must match")
    });


    const InputSignInSchema = yup.object({

        Email: yup.string()
            .required("Email Filed is Requierd")
            .email("Please Enter Valid Email Address"),
        Password: yup.string().required("Password is required"),
        ConfirmPassword: yup.string().oneOf([yup.ref('Password'), null], 'Passwords must match').required("Passwords must match")

    });

    const switchMode = () => {
        setSignUp((prevIsSignup) => !prevIsSignup)
    }

    const handleSubmit = (values) => {
        if (signUp) {
            SetInputFileds({ ...inputfileds, values })
        } else {
            SetInputFiledsx({ ...inputfiledsx, values })
        }
        if (signUp) {
            dispatch(signup(values))
        } else {
            dispatch(signin(values))
        }
    }
    // console.log(signUp)

    useEffect(() => {
        if (ServErrors) {
            setServerErrors(ServErrors)
        }
    }, [ServErrors]);


    // console.log(serverErrors)

    useEffect(() => {
        if (errors) {
            SetDbErrors(errors)
        }

    }, [errors]);

    useEffect(() => {
        if (user) {
            navigate("/")
        }
    }, [user])

    const clear = () => {
        SetInputFileds({
            FirstName: "",
            Email: "",
            Password: "",
            ConfirmPassword: "",
            RememberMe: false
        })
    }

    return (

        <Formik

            initialValues={signUp ? inputfileds : inputfiledsx}
            validationSchema={signUp ? InputSchema : InputSignInSchema}
            onSubmit={(values, { resetForm }) => {
                handleSubmit(values)
                // resetForm()
            }}
        // onReset={clear}

        >
            {({ errors, touched }) => (
                <>
                    {/* <Container component="main" maxWidth="xs"> */}
                    <Paper className={classes.paper} elevation={3}>

                        <span className={classcolor.signin}>{serverErrors}</span>
                        <br></br>

                        <span className={classcolor.signin}>{dberrors}</span>
                        <br></br>
                        <Avatar className={classes.avatar}></Avatar>
                        <Form>
                            {signUp && (
                                <>
                                    <CustomInput label="User Name:" name="FirstName" type="text" />
                                </>
                            )}
                            <CustomInput label="Email:" name="Email" type="email" />
                            <br></br>

                            <CustomInput label="Password:" name="Password" type="password" />
                            <br></br>

                            <CustomInput label="ConfirmPassword:" name="ConfirmPassword" type="password" />
                            <br></br>

                            <Button type="submit" variant="contained" color="primary" className={classes.submit}>
                                {signUp ? 'Sign Up' : 'Sign In'}
                            </Button>
                            {/* <Button type="submit" fullWidth variant="contained" onClick={resetForm} color="primary" className={classes.submit}> clear</Button> */}
                            <Grid container justify="flex-end">
                                <Grid item>
                                    <Button onClick={switchMode}>
                                        {signUp ? 'Already have an account? Sign in' : "Don't have an account? Sign Up"}
                                    </Button>
                                </Grid>
                            </Grid>
                        </Form>

                    </Paper>
                    {/* // </Container> */}
                </>
            )}

        </Formik>
    );
};

export default Auth;