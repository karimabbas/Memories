import * as api from "../api/index"

export const CreateEmployee = (emp) => async (dispatch) => {
    try {
        const response = await api.CreateEmp(emp);
        const data = response.data
        console.log(data);
        dispatch({
            type: "Create_Emp",
            data
        })

    } catch (error) {
        const data = error?.response?.data?.errors
        // console.log(error.response)
        dispatch({
            type: "Not_CREATE",
            payload: data
        });
    }
}

export const getAllEmps = () => {
    return async dispatch => {
        const response = await api.AllEmps();
        const data = response.data;
        dispatch({
            type: "Fetch_All_Emp",
            data
        })

    }
}