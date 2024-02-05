import React from 'react'
import { useNavigate } from 'react-router-dom';
import Button from '@mui/material/Button';


const Buttons = () => {

    const navigate = useNavigate();

    const Depertment = () => {
        navigate("/depertment")
    }

    const Users = () => {
        navigate("/allUsers")
    }

    const Employees = () => {
        navigate("/employees")
    }

    const ACtivities = () => {
        navigate("/activities")
    }

    const UserProfile = () => {
        navigate("/userProfile")
    }

    const FilesUpload = ()=>{
        navigate("/files")
    }
    return (
        <div>
            <Button onClick={Depertment} variant="contained" color="warning">Depertments</Button>
            <Button onClick={Users} color="error" variant="contained">Users</Button>
            <Button onClick={Employees} color="success" variant="contained">Employees</Button>
            <Button onClick={ACtivities} color="inherit" variant="contained">Activities</Button>
            <Button onClick={UserProfile} color="info" variant="contained">UserProfile</Button>
            <Button onClick={FilesUpload} color="secondary" variant="contained">Files</Button>
            

        </div>

    )
}

export default Buttons
