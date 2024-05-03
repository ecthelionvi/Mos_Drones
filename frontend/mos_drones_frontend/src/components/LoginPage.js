import axios from "axios";
import "../styles/LoginPage.css";
import logo from "../images/logo.png";
import React, { useState } from "react";
import { useNavigate, NavLink } from "react-router-dom";

const LoginPage = ({ onLogin }) => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [message, setMessage] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Check if the entered credentials match the test user
    if (username === "robert.scott.sears@gmail.com" && password === "password") {
      // Test user credentials
      const testUser = {
        accountId: 1,
        firstName: "Robert",
        lastName: "Sears",
        email: "robert.scott.sears@gmail.com",
        isAdmin: true,
      };

      localStorage.setItem("accountId", testUser.accountId);
      localStorage.setItem("firstName", testUser.firstName);
      localStorage.setItem("lastName", testUser.lastName);
      localStorage.setItem("email", testUser.email);
      localStorage.setItem("isAdmin", testUser.isAdmin);

      onLogin();
      navigate("/");
    } else if (username === "robert.scott.sears@icloud.com" && password === "password") {
      const testUser = {
        accountId: 1,
        firstName: "Robert",
        lastName: "Sears",
        email: "robert.scott.sears@icloud.com",
        isAdmin: false,
      };

      localStorage.setItem("accountId", testUser.accountId);
      localStorage.setItem("firstName", testUser.firstName);
      localStorage.setItem("lastName", testUser.lastName);
      localStorage.setItem("email", testUser.email);
      localStorage.setItem("isAdmin", testUser.isAdmin);

      onLogin();
      navigate("/");
    } else {
      try {
        const response = await axios.post("http://localhost:3000/api/Login/auth", {
          email: username,
          password: password,
        });

        const { accountId, firstName, lastName, email, isAdmin } = response.data;

        localStorage.setItem("accountId", accountId);
        localStorage.setItem("firstName", firstName);
        localStorage.setItem("lastName", lastName);
        localStorage.setItem("email", email);
        localStorage.setItem("isAdmin", isAdmin);

        onLogin();
        navigate("/login");
      } catch (error) {
        console.error("Login error:", error);
        setMessage("Login failed. Please check your credentials.");
      }
    }
  };
  return (
    <div className="login-form-container">
      <div className="close-button-container">
        <NavLink to="/" className="close-button">
          <span>×</span>
        </NavLink>
      </div>
      <div className="login-form-wrapper">
        <div className="login-form-content">
          <img src={logo} alt="Mo's Drones Logo" className="login-form-logo" />
          <h2 className="login-form-title">Sign In</h2>
          <form onSubmit={handleSubmit} className="login-form">
            <div className="login-form-group">
              <label htmlFor="username" className="login-form-label">
                Username
              </label>
              <input
                type="text"
                id="username"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
                className="login-form-input"
              />
            </div>
            <div className="login-form-group">
              <label htmlFor="password" className="login-form-label">
                Password
              </label>
              <input
                type="password"
                id="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
                className="login-form-input"
              />
            </div>
            <button type="submit" className="login-form-button">
              Sign In
            </button>
          </form>
          <p className="login-form-message">{message}</p>
        </div>
        <div className="login-form-signup-section">
          <p className="login-form-signup-text">New to Mo's Drones?</p>
          <NavLink to="/signup" className="login-form-signup-button">
            Sign Up
          </NavLink>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
