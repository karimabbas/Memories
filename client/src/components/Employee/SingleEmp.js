import React from 'react';
import styles from '../Dept/style.js';
import { Card, CardTitle, Label } from 'reactstrap';

const SingleEmp = ({ emp }) => {

    const classes = styles();
    return (
        <>
            <pre></pre>

            <Card className={classes.buttonSubmit}>
                <Label color='blue'>name</Label> :{emp.name}
                <p> <span color='blue'> Email : </span> {emp.email}</p>
                <p> <span color='blue'> Age : </span> {emp.age} years</p>
                <p> <span color='blue'> Salary : </span> {emp.salary} $</p>
                <CardTitle> <span color='red' >Department:</span> {emp?.department?.dept_name}</CardTitle>

            </Card>

        </>
    );
};

export default SingleEmp;