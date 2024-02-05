const Empstate = {
    employees: [],
    editEmp: null
}

const EmpStore = (state = [], action) => {

    switch (action.type) {
        case 'Fetch_All_Emp':
            return action.data;
        case 'Create_Emp':
            return [...state, action.data];
        case 'Edit_Emp':
            var editEmp = action.emp;

            var emps = state.filter(function (employee) {
                return employee.id !== editEmp.id
            });
            localStorage.setItem('editEmp', JSON.stringify(editEmp))
            return emps;

        case 'UPDATE_Employee':
            console.log(action.updatedData)
            return  [...state,action.updatedData];

        case 'DELETE_Emp':
            return state.filter((emp) => (emp.id !== action.id));

        default:
            return state
    }
};

export default EmpStore;