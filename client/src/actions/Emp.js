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

export const deleteEmp = (id) => {
    console.log(id)
    return async dispatch => {
        const response = await api.deleteEmployee(id);
        console.log(response.data)
        dispatch({
            type: "DELETE_Emp",
            id
        })
    }
}

export const GetEmp = (id) => {
    return async dispatch => {
        const response = await api.GetEmployee(id);
        const emp = response.data;
        // console.log(emp);
        dispatch({
            type: "Edit_Emp",
            emp
        })
    }
}


export const UpdateEmployee = (id, emp) => async (dispatch) => {
    try {
      const response = await api.UpdateEmployee(id, emp);
      const updatedData = response.data
      console.log(updatedData)
      dispatch({
        type: "UPDATE_Employee",
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