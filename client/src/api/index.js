import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'
import React, { useEffect, useState } from 'react';


const MySwal = withReactContent(Swal)

const API = axios.create({ baseURL: 'https://localhost:7010' });

// console.log(localStorageItem);

API.interceptors.request.use((req) => {
    if (localStorage.getItem('UserProfile')) {
        req.headers.authorization = `Bearer ${localStorage.getItem('UserToken')}`;
    }
    return req;
},
    error => Promise.reject(error)
)

API.interceptors.response.use(res => res, error => {

    if (error?.response?.status === 401) {
        console.log("lol")
        MySwal.fire({
            title: 'Are you sure?',
            text: "You Not Authorized to this action!",
            icon: 'warning',
            confirmButtonText: 'okay!',

            customClass: {
                confirmButton: 'btn btn-warning',
            }
        });


        return Promise.reject({ status: 403, errors: ['Unauthorized'] })

    }
})


// api.interceptors.response.use(response => response, error => {


//     if (error?.response?.status === 401) {
//         if (!nonApiRoute) logOut()
//         return Promise.reject({ status: 401, errors: ['Unauthorized'] })
//     }

//     if (error?.response?.status === 403) {
//         toast.error(
//             <ErrorToast
//                 title={<h3>تحذير !</h3>}
//                 result={<h3>أنت غير مصرح لك !</h3>}
//             />, { hideProgressBar: false })

//         return Promise.reject({ status: 403, errors: ['Unauthorized'] })
//     }

//     if (error?.response?.status === 422) {
//         const errors = Object.values(error?.response?.data || {})
//         return Promise.reject({ status: 422, errorsRaw: errors, errors: errors.reduce(error => error) })
//     }

//     console.error(error)

//     return Promise.reject({ status: error?.response?.status, errors: ['Oops!'] })
// })

export const signUp = (data) => API.post('/Account/SginUp', data);
export const signIn = (data) => API.post('/Account/Sginin', data);
export const users = () => API.get('/AllUsers');

export const fetchPosts = () => API.get('/GetAllPosts');
export const createPost = (newPost) => API.post('/CreatePost', newPost);

export const EditPost = (id) => API.get(`/EditPost/${id}`);

export const UpdatePost = (id, post) => API.put(`/UpdatePost/${id}`, post);

export const deletePost = (id) => API.delete(`/DeletePost/${id}`);  
export const postreacts = (id, type) => API.put(`/postreacts/${id}/${type}`);







