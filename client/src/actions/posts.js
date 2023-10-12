import * as api from "../api/index";

export const getPosts = () => {
  return async dispatch => {
    const response = await api.fetchPosts();
    const data = response.data;
    // console.log(data)
    dispatch({
      type: "FETCH_ALL",
      data
    });
  }
}
//   try {
//     const response = await api.fetchPosts();
//     const data = response.data
//     dispatch({
//       type: "FETCH_ALL",
//       paylod:data
//     });
//   } catch (error) {
//     console.log(error.message);
//   }
// };


export const createPost = (post) => async (dispatch) => {

  try {
    const response = await api.createPost(post);
    const data = response.data
    // console.log(data)
    dispatch({
      type: "CREATE",
      data
    });
    console.log('done')
  } catch (error) {
    const data = error.response.data.errors
    dispatch({
      type: "Not_CREATE",
      payload: data
    });
    console.log("fail")

    // error.Title = error.response.data.errors.Title[0];
    // console.log(error.Title);
    // console.log(error.response.data.errors.Message[0]);
    // console.log(error.response.data.errors.formFile);
  }
};

export const EditPost = (id) => {
  return async dispatch => {
    const response = await api.EditPost(id);
    const editPost = response.data;
    // console.log(editPost);
    dispatch({
      type: "Edit",
      editPost
    })
  }
}

export const UpdatePost = (id, post) => async (dispatch) => {
  // return async dispatch => {
  //   const response = await api.UpdatePost(id,post);
  //   const updatedData = response.data;
  //   console.log(updatedData);
  //   dispatch({
  //     type: "UPDATE",
  //     updatedData
  //   })
  // }

  try {
    const response = await api.UpdatePost(id, post);
    const updatedData = response.data
    console.log(updatedData)
    dispatch({
      type: "UPDATE",
      updatedData,
    });
    console.log('done')
  } catch (error) {
    const data = error.response.data.errors
    dispatch({
      type: "Not_CREATE",
      payload: data
    });
    console.log("fail")
  }
}



// return async dispatch => {
//   const response = await api.fetchPosts();
//   const data = response.data;
//   // console.log(data)
//   dispatch({
//     type: "FETCH_ALL",
//      data
//   });
// }
// }

export const deletePost = (id) => {
  console.log(id)
  return async dispatch => {
    const response = await api.deletePost(id);
    console.log(response.data)
    dispatch({
      type: "DELETE",
      id
    })
  }

}

export const PostReactions = (id, type) => {
  return async dispatch => {
    const response = await api.postreacts(id, type);
    const updatedData = response.data.message;
    console.log(updatedData);
    dispatch({
      type: "Post_Reactions",
      updatedData
    });
  }
};
