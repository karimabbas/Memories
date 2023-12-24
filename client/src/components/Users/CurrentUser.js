import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { UserProfile } from '../../actions/auth';
import { blue } from '@mui/material/colors';

const CurrentUser = () => {

    const dispatch = useDispatch();

    const [currentUser,setCurrentUser] = useState({
        email:''
    });

    useEffect(() => {
        dispatch(UserProfile())
    }, [dispatch]);

    // const authDataError = useSelector((state) => state.authStore)
    // console.log(authDataError.authData);
    // setCurrentUser({email:authDataError.authData.email});
    // console.log(currentUser);
    return (
        <>
            <div color='green'>
                {/* {currentUser} */}
                {/* <span color='yellow'> user name : </span> {currentUser} */}
                <br></br>
                {/* <span color='red'> user Email : </span> {currentUser.email} */}
            </div>
        </>
    );
};

export default CurrentUser;