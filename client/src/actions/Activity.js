import * as api from "../api/index";

export const Create_ACtivity = (activity) => async (dispatch) => {
    try {
        const res = await api.CreateActivity(activity);
        const data = res.data
        console.log(data)

        dispatch({
            typee: "Create_Activity",
            data
        });
    } catch (error) {

        const data = error.response.data.errors
        console.log(error.response)
        dispatch({
            type: "Not_CREATE",
            payload: data
        });
    }
}

export const getAllActivities = () => {
    return async dispatch => {
        const response = await api.AllActivities();
        const data = response.data;
        console.log(data)
        dispatch({
            type: "Fetch_All_Activities",
            data
        });
    }
}