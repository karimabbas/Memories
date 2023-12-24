import React, { useEffect, useState } from 'react';
import style from "../Dept/style";
import { CircularProgress, Grid, Paper, Stack, TextField } from '@mui/material';
import { Button } from 'reactstrap';
import { useDispatch, useSelector } from 'react-redux';
import { Create_ACtivity, getAllActivities } from '../../actions/Activity';
import SingleActivity from './SingleActivity';
const ACtivity = () => {

    const user = JSON.parse(localStorage.getItem("UserProfile"));
    const dispatch = useDispatch();
    const classes = style();

    const [activityData, setActivityData] = useState({
        Activity_name: ""
    });

    const handleData = (e) => {
        setActivityData({ ...activityData, [e.target.name]: e.target.value })
    }

    const Clear = () => {
        setActivityData({
            Activity_name: ""
        });
    }

    useEffect(() => {
        dispatch(getAllActivities());
    }, [dispatch]);

    const AllActivities = useSelector((state) => state.ActivityStore);
    // console.log(AllActivities)

    const handleSubmit = async (e) => {
        e.preventDefault();
        dispatch(Create_ACtivity(activityData))
        Clear();
    }

    return (

        <>
            {user ?
                <Paper className={classes.Paper} >

                    <form onSubmit={handleSubmit}>
                        <Stack spacing={2} direction="row" sx={{ marginBottom: 4 }}>
                            <TextField
                                type="text"
                                name='Activity_name'
                                value={activityData.Activity_name}
                                variant='outlined'
                                color='secondary'
                                label="Activity Name"
                                fullWidth
                                required
                                onChange={handleData}

                            />
                        </Stack>
                        <Button className={classes.buttonSubmit} variant="contained" color="warning" size="large" type="submit">Create</Button>

                    </form>
                    <br></br>
                </Paper>
                : <p>You are not authorized..No Data To show</p>}

            {AllActivities ?
                <Grid className={classes.mainContainer} container alignItems="stretch" spacing={3}>
                    {AllActivities.map((act) => (
                        <Grid key={act.id} item xs={8} md={6}>
                            <SingleActivity act={act} />
                        </Grid>
                    ))}

                </Grid> : <CircularProgress />
            }
        </>
    );
}
export default ACtivity;