import React from 'react';
import useStyles from './styles';
import { useSelector } from 'react-redux';
import { CircularProgress, Grid } from '@mui/material';
import Post from './Post/Post';

const Posts = () => {

    const classes = useStyles();

    const posts = useSelector((state) => state.postsStore)

    return (
        posts ?
            <Grid className={classes.mainContainer} container alignItems="stretch" spacing={3}>

                {posts.map((post) => (
                    <Grid key={post.id} item xs={12} sm={6} md={6}>
                        {/* <Route path="/post/:id={post.id}" exact element={<Post />} /> */}

                        <Post post={post} />
                    </Grid>
                ))}
            </Grid>
            : <CircularProgress />

    );
};

export default Posts;
