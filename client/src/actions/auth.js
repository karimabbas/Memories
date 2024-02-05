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
        const token = response.data.accessToken
        const refreshToken = response.data.refreshToken
        const expirtDate = response.data.expirtDate
        const UserId = response.data.UserId
        console.log(response)
        dispatch({
            type: "AUTH",
            data,
            token,
            refreshToken
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

export const UserProfile = () => {
    return async dispatch => {
        const response = await api.CurrentUser();
        const data = response.data;
        // console.log(data)
        dispatch({
            type: "Current_User",
            data
        });
    }
}

export const LOGOUT = () => {
    return async dispatch => {
        const response = await api.logOut();
        const data = response.data.message;
        console.log(data);
        dispatch({
            type: "LOGOUT",
            data
        });
    }
}