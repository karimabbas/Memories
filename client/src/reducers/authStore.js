
const authStore = (state = { authData: null }, action) => {
    switch (action.type) {
        case "AUTH":
            if (action?.data.id != null) {
                localStorage.setItem('UserProfile', JSON.stringify({ ...action?.data }))
                localStorage.setItem('UserToken', action?.token)
                localStorage.setItem('RefreshToken', action?.refreshToken) 
            }
            return { ...state, authData: action?.data }
        case "LOGOUT":
            localStorage.clear();
            return { ...state, authData: null }

        case "FETCH_ALL_Users":
            console.log(action?.data)
            return { ...state, authData: action?.data }

        case "Current_User":
            console.log(action?.data)
            return {...state,authData:action?.data}    
        default:
            return state;
    }
}

export default authStore