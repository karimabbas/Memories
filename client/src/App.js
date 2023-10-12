import { React, useState } from "react";
import { Container } from "@mui/material"
import Home from "./components/Home/Home";
import Navbar from "./components/Navbar/Navbar";
import { BrowserRouter, Route, Routes, useNavigate } from "react-router-dom";
import Auth from "./components/Auth/Auth";
import { useEffect } from "react";
import Posts from "./components/Posts/Posts";
import AllUsers from "./components/Users/AllUsers";
import { useDispatch } from "react-redux";

function App() {


  return (
    <BrowserRouter>
      <Container maxWidth="lg">
        <Navbar />
        <Routes>
          <Route path="/" exact element={<Home />} />

          <Route path="/posts/:id" exact element={<Posts/>} />

          <Route path="/auth" exact element={<Auth />} />

          <Route path="/allUsers" exact element={<AllUsers/>} />

        </Routes>
      </Container>
    </BrowserRouter>

  );
}

export default App;
