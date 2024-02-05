import { React, useState } from "react";
import { Container } from "@mui/material"
import Home from "./components/Home/Home";
import Navbar from "./components/Navbar/Navbar";
import { BrowserRouter, Navigate, Route, Routes, useNavigate } from "react-router-dom";
import Auth from "./components/Auth/Auth";
import { useEffect } from "react";
import Posts from "./components/Posts/Posts";
import AllUsers from "./components/Users/AllUsers";
import { useDispatch } from "react-redux";
import Depertment from "./components/Dept/Depertment";
import ACtivity from "./components/Activity/Activity";
import Employee from "./components/Employee/Employee";
import CurrentUser from "./components/Users/CurrentUser";
import UploadFiles from "./components/UploadFiles/UploadFiles";

function App() {
  const user = JSON.parse(localStorage.getItem("UserProfile"));


  return (
    <BrowserRouter>
      <Navbar />
      <Container maxWidth="lg">
        <Routes>
          <Route path="/" exact element={<Home />} />

          <Route path="/posts/:id" exact element={<Posts />} />

          <Route path="/auth" exact element={<Auth />} />

          <Route path="/allUsers" exact element={<AllUsers />} />

          <Route path="/depertment" exact element={<Depertment />} />

          <Route path="/employees" exact element={<Employee />} />

          <Route path="/activities" exact element={<ACtivity />} />

          <Route path="/userProfile" exact element={<CurrentUser />} />

          <Route path="/files" exact element={<UploadFiles />} />


        </Routes>
      </Container>
    </BrowserRouter>

  );
}

export default App;
