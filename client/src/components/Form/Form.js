import React, { useState, useEffect } from 'react';
import styles from "./styles";
import stylesColor from "../Navbar/styles";
import { Button, Paper, TextField, Typography } from '@mui/material';
import { useDispatch, useSelector } from 'react-redux';
import { createPost, UpdatePost } from '../../actions/posts';

const Form = () => {

    const classes = styles();
    const classcolor = stylesColor();

    const PostID = parseInt(localStorage.getItem('PostId'));
    const user = JSON.parse(localStorage.getItem("UserProfile"));
    // console.log(PostID)

    const [postData, setPostData] = useState({
        Title: '',
        Message: '',
    });
    const [file, setFile] = useState();
    const [inputerror, SetInputerror] = useState({ Title: '', Message: '', FormFile: '' });

    const dispatch = useDispatch();

    const handlepostData = (e) => {
        setPostData({ ...postData, [e.target.name]: e.target.value })
    }

    const errors = useSelector((state) => state.ErrorStore)
    // console.log(errors)
    const allpost = useSelector((state) => state.postsStore)

    const post = useSelector(() => (PostID ? allpost.find((p) => p.id === PostID) : null));

    // console.log(post)

    const saveFile = (e) => {
        setFile(e.target.files[0]);
    }

    const ResetFile = (e) => {
        setFile(e.target.value == null);
    }

    useEffect(() => {
        
        if (post) {
            setPostData({ Title: post.title, Message: post.message });
            setFile(post.postImage)
        }

    }, [post])

  

    const clear = () => {
        setPostData({
            Title: '',
            Message: '',
        });
        localStorage.removeItem("PostId");

        SetInputerror({ Title: '', Message: '', FormFile: '' });
        setFile();
        
    }


    const handleSubmit = async (e) => {
        e.preventDefault();
        const formData = new FormData();
        console.log(file);
        formData.append("FormFile", file);
        formData.append("Title", postData.Title);
        formData.append("Message", postData.Message);
        if (post) {
            dispatch(UpdatePost(post.id, formData))
            localStorage.removeItem("PostId");
        } else {
            dispatch(createPost(formData));
        }
        clear();
        ResetFile(e)
    }

    useEffect(() => {
        if (errors) {
            SetInputerror({ Title: errors.Title, Message: errors.Message, FormFile: errors.formFile });
        }
    
    }, [errors])


    if (!user) {
        return (
          <Paper className={classes.paper}>
            <Typography variant="h6" align="center">
              Please Sign In to create your own memories and like other's memories.
            </Typography>
          </Paper>
        );
      }


    return (
        <Paper className={classes.Paper}>
            <span className={classcolor.signin}>{inputerror.Title}</span>
            <br></br>
            <span className={classcolor.signin}>{inputerror.Message}</span>
            <br></br>
            <span className={classcolor.signin}>{inputerror.FormFile}</span>

            <form autoComplete='off' noValidate className={`${classes.root} ${classes.form}`} onSubmit={handleSubmit} accept="image/png, image/jpeg" encType="multipart/form-data" >
                <Typography variant="h6">Creating Memory</Typography>
                <TextField className={classes.TextField} name="Title" variant="outlined" label="Title" value={postData.Title} fullWidth onChange={handlepostData} />

                <TextField className={classes.TextField} name="Message" variant="outlined" label="Message" value={postData.Message} fullWidth onChange={handlepostData} />

                <input id="file" type="file" label="Post Image" variant="outlined"  fullWidth onChange={saveFile} />

                <Button className={classes.buttonSubmit} variant="contained" color="primary" size="large" type="submit" fullWidth>Submit</Button>
                <Button variant="contained" color="secondary" size="small" onClick={clear} fullWidth>Clear</Button>

            </form>

        </Paper>


    )
}
export default Form;
