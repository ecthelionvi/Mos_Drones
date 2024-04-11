import axios from "axios";
import "../styles/SignupPage.css";
import React, { useState, useRef } from "react";
import { useNavigate, NavLink } from "react-router-dom";
import { useJsApiLoader, Autocomplete } from "@react-google-maps/api";

const SignupPage = () => {
  const [password, setPassword] = useState("");
  const [address, setAddress] = useState("");
  const [message, setMessage] = useState("");
  const [email, setEmail] = useState("");
  const [name, setName] = useState("");

  const navigate = useNavigate();

  const addrAutocompleteRef = useRef(null);

  const { isLoaded } = useJsApiLoader({
    id: "google-map-script",
    googleMapsApiKey: "AIzaSyCfTn6UID_1mfAbHLjaFNsgAww13JewQzE",
    libraries: ["places"],
  });

  const onPlaceChanged = (autocompleteRef) => {
    if (autocompleteRef.current) {
      const place = autocompleteRef.current.getPlace();
      console.log("Selected place:", place);
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Basic validation
    if (!name || !email || !password || !address) {
      setMessage("Please fill in all fields.");
      return;
    }

    // Email validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      setMessage("Please enter a valid email address.");
      return;
    }

    // Password validation
    if (password.length < 6) {
      setMessage("Password must be at least 6 characters long.");
      return;
    }

    try {
      await axios.post("http://localhost:5159/api/auth/signup", {
        name,
        email,
        password,
        address,
      });
      navigate("/login");
    } catch (error) {
      console.error("Signup error:", error);
      setMessage("Signup failed. Please try again.");
    }
  };

  return (
    <div className="signup-form-container">
      <div className="close-button-container">
        <NavLink to="/" className="close-button">
          <span>×</span>
        </NavLink>
      </div>
      <div className="signup-form-wrapper">
        <div className="signup-form-content">
          <h2 className="signup-form-title">Create Account</h2>
          <form onSubmit={handleSubmit} className="signup-form">
            <div className="signup-form-group">
              <label htmlFor="name" className="signup-form-label">
                Name
              </label>
              <input
                type="text"
                id="name"
                value={name}
                onChange={(e) => setName(e.target.value)}
                required
                className="signup-form-input"
              />
            </div>
            <div className="signup-form-group">
              <label htmlFor="email" className="signup-form-label">
                Email
              </label>
              <input
                type="email"
                id="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
                className="signup-form-input"
              />
            </div>
            <div className="signup-form-group">
              <label htmlFor="password" className="signup-form-label">
                Password
              </label>
              <input
                type="password"
                id="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                placeholder="At least 6 characters"
                required
                className="signup-form-input"
              />
            </div>
            <div className="signup-form-group">
              <label htmlFor="address" className="signup-form-label">
                Address
              </label>
              {isLoaded && (
                <Autocomplete
                  onLoad={(autocomplete) => {
                    addrAutocompleteRef.current = autocomplete;
                  }}
                  onPlaceChanged={() => onPlaceChanged(addrAutocompleteRef)}
                >
                  <input
                    type="text"
                    id="address"
                    value={address}
                    onChange={(e) => setAddress(e.target.value)}
                    required
                    className="signup-form-input"
                  />
                </Autocomplete>
              )}
            </div>
            <button type="submit" className="signup-form-button">
              Sign Up
            </button>
          </form>
          <p className="signup-form-message">{message}</p>
        </div>
        <div className="signup-form-login-section">
          <p className="signup-form-terms">
            By creating an account, you agree to Mo's Drones' Conditions of Use and Privacy Notice.
          </p>
          <p className="signup-form-login-text">Already have an account?</p>
          <NavLink to="/login" className="signup-form-login-link">
            Sign In
          </NavLink>
        </div>
      </div>
    </div>
  );
};

export default SignupPage;
