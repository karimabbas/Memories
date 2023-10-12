import React from 'react'
import styles from './styles';
import { Card, Button, CardActions, CardContent, CardMedia, Typography } from '@mui/material'
import DeleteIcon from '@mui/icons-material/Delete';
import moment from 'moment';
import { deletePost, EditPost, PostReactions } from '../../../actions/posts';
import { useDispatch, useSelector } from 'react-redux';
import EditIcon from '@mui/icons-material/Edit';
import { useParams } from 'react-router-dom';
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'
import ThumbUpAltIcon from '@mui/icons-material/ThumbUpOffAlt';
import ThumbUpAltOutlined from '@mui/icons-material/ThumbUpAltOutlined';
import FavoriteIcon from '@mui/icons-material/Favorite';


const Post = ({ post }) => {

    const classes = styles();
    const dispatch = useDispatch();

    const MySwal = withReactContent(Swal)

    const handleDeleteConfirm = (id) => {
        return MySwal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            customClass: {
                confirmButton: 'btn btn-primary',
                cancelButton: 'btn btn-outline-danger ml-1'
            },
            buttonsStyling: false
        }).then(function (result) {
            if (result.value) {
                console.log(result.value)
                dispatch(deletePost(id))
                MySwal.fire({
                    icon: 'success',
                    title: 'Deleted!',
                    text: 'Your post has been deleted.',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    }
                })
            }
        })
    }

    const Likes = () => {
        return <><ThumbUpAltOutlined fontSize="small" />&nbsp; {post.likes}Like</>
    };

    const Loves = () => {
        return <><FavoriteIcon fontSize="small" />&nbsp;{post.loves}Love</>;
    };


    return (
        <Card className={classes.card}>
            {/* <img src={post.postImage} alt='' /> */}
            <CardMedia className={classes.media} image={`https://localhost:7010/PostFiles/${post.postImage}`} title={post.title} />
            <div className={classes.overlay}>
                <Typography color="silver" fontStyle="italic" variant="h7">{post.title}</Typography>
                <Typography fontWeight='bold' fontStyle="oblique" color="blanchedalmond" variant="body2">{moment(post.created_At).format("hh:mm")}</Typography>
            </div>

            <div className={classes.overlay2}>
                <Button style={{ color: 'gray' }} size="small"
                    onClick={() => dispatch(EditPost(post.id))}
                ><EditIcon fontSize="medium" /></Button>
            </div>

            {/* <div className={classes.details}>
          <Typography variant="body2" color="textSecondary" component="h2">{post.tags.map((tag) => `#${tag} `)}</Typography>
        </div> */}

            <Typography className={classes.title} gutterBottom variant="h5" component="h2"><strong>{post.title}</strong></Typography>

            <CardContent>
                <Typography variant="body2" color="black" component="p">{post.message}</Typography>
            </CardContent>
            <CardActions className={classes.cardActions}>

                <Button size="small" color="primary" onClick={() => dispatch(PostReactions(post.id, 'likes'))} >
                    <Likes />
                </Button>

                <Button size="small" color="error" onClick={() => dispatch(PostReactions(post.id, 'loves'))} >
                    <Loves />
                </Button>

                <Button size="small" color="warning" onClick={() => handleDeleteConfirm(post.id)} >
                    <DeleteIcon fontSize="small" /> Delete
                </Button>

            </CardActions>
        </Card>
    )
}

export default Post
