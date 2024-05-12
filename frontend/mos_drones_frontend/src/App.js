import React, { useState, useEffect } from "react";
import { BrowserRouter as Router, Route, Routes, Navigate } from "react-router-dom";
import LoginPage from "./components/LoginPage";
import PackageDetails from "./components/PackageDetails";
import HomePage from "./components/HomePage";
import SignupPage from "./components/SignupPage";
import PackageGrid from "./components/PackageGrid";
import DronePage from "./components/DronePage";
import axios from 'axios';

const App = () => {
  const [user, setUser] = useState(null);

  useEffect(() => {
    const storedUser = {
      accountId: localStorage.getItem("accountId"),
      firstName: localStorage.getItem("firstName"),
      lastName: localStorage.getItem("lastName"),
      email: localStorage.getItem("email"),
      isAdmin: localStorage.getItem("isAdmin") === "true",
    };

    if (storedUser.accountId) {
      setUser(storedUser);
    }
  }, []);

  const handleLogin = () => {
    const loggedInUser = {
      accountId: localStorage.getItem("accountId"),
      firstName: localStorage.getItem("firstName"),
      lastName: localStorage.getItem("lastName"),
      email: localStorage.getItem("email"),
      isAdmin: localStorage.getItem("isAdmin") === "true",
    };

    setUser(loggedInUser);
  };

  const handleLogout = async () => {
    try{
      const response = await axios.post("http://localhost:3001/api/Login/Logout");
      if (response.status === 200) {
        localStorage.removeItem("accountId");
        localStorage.removeItem("firstName");
        localStorage.removeItem("lastName");
        localStorage.removeItem("email");
        localStorage.removeItem("isAdmin");
        setUser(null);
        Navigate("/login");
      } else {
        console.error("Error logging out");
      }
    }catch (error) {  
      console.error("Error logging out:", error);
    }
};

  /* 
  Original code
  Update to incorporate the depot list for selection
  Maybe validation to ensure that they are an admin or that the depot exists
  const handleDroneRelocation = (drone, newDepotId) => {
      
  }
  */

  return (
    <Router>
      <Routes>
        <Route
          path="/"
          element={
            <HomePage
              loggedIn={!!user}
              onLogout={handleLogout}
              user={user}
              role={user?.isAdmin ? "True" : "False"}
              component={PackageGrid}
            />
          }
        />
        <Route path="/login" element={<LoginPage onLogin={handleLogin} />} />
        <Route path="/signup" element={<SignupPage />} />
        <Route path="/package/:packageId" element={<PackageDetails />} />
        <Route path="/drone/:droneId" element={<DronePage />} />
      </Routes>
    </Router>
  );
};

export default App;
