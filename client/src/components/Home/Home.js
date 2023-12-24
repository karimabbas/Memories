import { Card, CardHeader, Container, Grid, Grow, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import Form from "../Form/Form";
import { useDispatch, useSelector } from "react-redux";
import { getPosts } from "../../actions/posts";
import Posts from "../Posts/Posts";
import { getAllDepts } from "../../actions/Dept";
import { Button } from "reactstrap";
import AllUsers from "../Users/AllUsers";
import { Link, Route, useNavigate } from "react-router-dom";
import Depertment from "../Dept/Depertment";
import styles from "../Navbar/styles";
import Buttons from "../../Buttons/Buttons";


const Home = () => {

    const dispatch = useDispatch();
    const navigate = useNavigate();
    const classes = styles();
    const user = JSON.parse(localStorage.getItem("UserProfile"));

    useEffect(() => {
        if (user != null) {
            dispatch(getPosts());
        }

    }, [user, dispatch]);


    return (

        <Grow in>

            <Container>

                <Grid container justify="space-between" alignItems="stretch" spacing={3}>
                    <Grid item xs={12} sm={7}>
                        <Posts />
                    </Grid>
                    <Grid item xs={12} sm={4}>
                        <Buttons />
                        <Form />
                    </Grid>
                </Grid>
            </Container>
        </Grow>
    )
};

export default Home;