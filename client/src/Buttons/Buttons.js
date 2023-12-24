import React from 'react'
import { useNavigate } from 'react-router-dom';
import { Button } from 'reactstrap';


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

    return (
        <div>
            <Button onClick={Depertment} color="warning">Depertments</Button>
            <span>  </span>
            <Button onClick={Users} color="error">Users</Button>
            <span>  </span>

            <Button onClick={Employees} color="error">Employees</Button>
            <span>  </span>

            <Button onClick={ACtivities} color="error">Activities</Button>
            <span>  </span>

            <Button onClick={UserProfile} color="error">UserProfile</Button>
            <span>  </span>

        </div>

    )
}

export default Buttons
