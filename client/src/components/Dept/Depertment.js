import React, { useState, useEffect } from 'react'
import { Paper, Stack, TextField, Button, Grid, CircularProgress } from '@mui/material'
import styles from "../Form/styles";
import { useDispatch, useSelector } from 'react-redux';
import { createDept, getAllDepts } from '../../actions/Dept';
import SingleDept from './SingleDept';

const Depertment = () => {

    const classes = styles();
    const dispatch = useDispatch();

    const [deptdata, setDeptData] = useState({
        Dept_name: "", YearOfCreation: ""
    });

    const handlepostData = (e) => {
        setDeptData({ ...deptdata, [e.target.name]: e.target.value })
    }

    const [handleError, SetHandleError] = useState({

    })

    const clear = () => {
        setDeptData({
            Dept_name: " ",
            YearOfCreation: " ",
        });

    }
    const user = JSON.parse(localStorage.getItem("UserProfile"));


    useEffect(() => {
        dispatch(getAllDepts());
    }, [dispatch]);

    const allDepts = useSelector((state) => state.DeptStore);

    console.log(allDepts)

    const handleSubmit = async (e) => {
        e.preventDefault();
        // console.log(deptdata)
        dispatch(createDept(deptdata))
        clear();

    }


    return (
        <>
            {user ?


                <Paper className={classes.Paper} >

                    <form onSubmit={handleSubmit}>
                        <Stack spacing={2} direction="row" sx={{ marginBottom: 4 }}>
                            <TextField
                                type="text"
                                name='Dept_name'
                                value={deptdata.Dept_name}
                                variant='outlined'
                                color='secondary'
                                label="Depatment Name"
                                fullWidth
                                required
                                onChange={handlepostData}

                            />

                            <TextField
                                type="date"
                                name='YearOfCreation'
                                value={deptdata.YearOfCreation}
                                variant='outlined'
                                color='secondary'
                                label="Year of Creation"
                                fullWidth
                                required
                                onChange={handlepostData}
                                sx={{ mb: 4 }}
                            />
                        </Stack>
                        <Button className={classes.buttonSubmit} variant="contained" color="warning" size="large" type="submit">Create</Button>


                    </form>

                </Paper>
                : <p>You are not authorized..No Data To show</p>}

            {allDepts ?
                <Grid className={classes.mainContainer} container alignItems="stretch" spacing={3}>

                    {allDepts.map((dept) => (
                        <Grid key={dept.id} item xs={12} sm={6} md={6}>
                            <SingleDept dept={dept} />
                        </Grid>
                    ))}
                </Grid>
                : <CircularProgress />
            }

        </>

    )
}

export default Depertment
