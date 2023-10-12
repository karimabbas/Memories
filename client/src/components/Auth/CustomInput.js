import { useField } from 'formik'
import React from 'react'
import Error from './Error';
import { Input } from '@mui/material';

export default function CustomInput({ label, ...props }) {

    const [filed, meta] = useField(props);

    return (
        <>
            <label htmlFor={props.id || props.name}>{label}</label>
            <Input {...filed} {...props} />
            <Error showIf={meta.error && meta.touched}>{meta.error}</Error>

        </>
    )
}
