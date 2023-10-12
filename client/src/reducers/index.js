import { combineReducers } from "redux";
import postsStore from "./postsStore";
import authStore from "./authStore";
import ErrorStore from "./ErrorStore";
export const reducers = combineReducers({ postsStore,authStore,ErrorStore});