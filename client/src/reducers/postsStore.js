const postsStore = (posts = [], action) => {
    switch (action.type) {
        case 'FETCH_ALL':
            return action.data;
        case 'CREATE':
            // console.log(posts)
            return [...posts, action.data];
        case 'Edit_Post':
            localStorage.setItem('PostId', JSON.stringify(action.editPost.id))
            return posts.map((post) => (post.id === action.editPost.id) ? action.editPost : post);
        case 'UPDATE':
            return posts.map((post) => (post.id === action.updatedData.id) ? action.updatedData : post);
        // return action.updatedData;
        case 'DELETE':
            console.log(posts.filter((post) => (post.id !== action.id)));
            return posts.filter((post) => (post.id !== action.id));
        case 'Post_Reactions':
            return posts.map((post) => (post.id === action.updatedData.id) ? action.updatedData : post);

        default:
            return posts
    }
}
export default postsStore;