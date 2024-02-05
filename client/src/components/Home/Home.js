import {Container, Grid, Grow,  } from "@mui/material";
import React, { useEffect,  } from "react";
import Form from "../Form/Form";
import { useDispatch,  } from "react-redux";
import { getPosts } from "../../actions/posts";
import Posts from "../Posts/Posts";
import Buttons from "../../Buttons/Buttons";


const Home = () => {

    const dispatch = useDispatch();
 
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