const EmpStore = (employees = [], action) => {

    switch (action.type) {
        case 'Create_Emp':
            return [...employees, action.data];

        case 'Fetch_All_Emp':
            return action.data;    

        default:
            return employees
    }
};

export default EmpStore;