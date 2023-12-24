import React from 'react';
import style from '../Dept/style';
import { Card, Label } from 'reactstrap';

const SingleActivity = ({act}) => {

    const classes = style();
    return (
        <>
      <br></br>
            <Card className={classes.buttonSubmit}>
                <Label color='yellow' > Activity </Label>{act.activity_name}
            </Card>
        </>
    );
};

export default SingleActivity;