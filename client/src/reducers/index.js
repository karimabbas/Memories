import { combineReducers } from "redux";
import postsStore from "./postsStore";
import authStore from "./authStore";
import ErrorStore from "./ErrorStore";
import DeptStore from "./DeptStore";
import ActivityStore from "./ActivityStore";
import EmpStore from "./EmpStore";
export const reducers = combineReducers({ postsStore,authStore,ErrorStore,DeptStore,ActivityStore,EmpStore});