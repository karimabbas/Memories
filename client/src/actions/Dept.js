import * as api from "../api/index";

export const createDept = (dept) => async (dispatch) => {
    try {
        const response = await api.CreateDept(dept);
        const data = response.data
        // console.log(data)

        dispatch({
            type: "Create_Dept",
            data
        });
        // console.log("done");

    } catch (error) {
        const data = error?.response?.data?.errors
        // console.log(error.response)
        dispatch({
            type: "Not_CREATE",
            payload: data
        });
        // console.log("fail")
    }
}

export const getAllDepts = () => {
    return async dispatch => {
        const response = await api.AllDepts();
        const data = response.data;
        console.log(data)
        dispatch({
            type: "FETCH_ALL_DEPT",
            data
        });
    }
}