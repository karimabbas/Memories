const ErrorStore = (state = [], action) => {
    switch (action.type) {
        case 'Not_CREATE':
            // console.log([action.payload])
            return action.payload;

        default:
            return state
    }
}
export default ErrorStore;