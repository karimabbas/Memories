import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import { Provider } from 'react-redux';
import { legacy_createStore, applyMiddleware, compose } from 'redux';
import thunk from 'redux-thunk';
import { reducers } from './reducers';
import "./index.css";
import './i18n/config';
const store = legacy_createStore(reducers, compose(applyMiddleware(thunk)))

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <Provider store={store}>
      <App />

    </Provider>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
