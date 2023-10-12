import * as api from "../api/index";

export const signup = (form) => async (dispatch) => {
    // console.log(formData);
    try {
        const response = await api.signUp(form);
        console.log(response);
        const data = response.data.message
        console.log(data)
        dispatch({
            type: "AUTH",
            data
        });

    } catch (error) {
        for (let index = 0; index < 6; index++) {
            const data = error.response.data.message[index].description
            console.log(data)

            dispatch({
                type: "Not_CREATE",
                payload: data
            });
            console.log("fail")
        }

    }

};



export const signin = (formData) => async (dispatch) => {
    try {
        const response = await api.signIn(formData);
        const data = response.data.message
        const token = response.data.token
        console.log(data)
        dispatch({
            type: "AUTH",
            data,
            token
        });
    } catch (error) {
        for (let index = 0; index < 6; index++) {
            const data = error
            console.log(data)

            dispatch({
                type: "Not_CREATE",
                payload: data
            });
            console.log("fail")
        }
    }
};

export const getUsers = () => {
    return async dispatch => {
      const response = await api.users();
      const data = response.data.message;
      console.log(data)
      dispatch({
        type: "FETCH_ALL_Users",
        data
      });
    }
  }