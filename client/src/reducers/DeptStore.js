const DeptStore = (departments = [], action) => {

    switch (action.type) {
        case 'Create_Dept':
            return [...departments, action.data];

        case 'FETCH_ALL_DEPT':
            return action.data;

        default:
            return departments
    }

}

export default DeptStore