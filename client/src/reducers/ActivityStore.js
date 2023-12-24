
const ActivityStore = (activities = [], action) => {

    switch (action.type) {
        case 'Create_Activity':
            return [...activities, action.data];

            case 'Fetch_All_Activities':
                return action.data;
        default:
            return activities
    }

}

export default ActivityStore