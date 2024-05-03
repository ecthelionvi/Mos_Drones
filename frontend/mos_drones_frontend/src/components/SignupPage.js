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
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [city, setCity] = useState("");
  const [state, setState] = useState("");
  const [zipCode, setZipCode] = useState("");
  const [addressLine, setAddressLine] = useState("");

  const navigate = useNavigate();

  const addrAutocompleteRef = useRef(null);

  const { isLoaded } = useJsApiLoader({
    id: "google-map-script",
    googleMapsApiKey: "AIzaSyD9EOVlGpDT2Tj7c6b2xDU8CzYEto-ofN8",
    libraries: ["places"],
  });

  const onPlaceChanged = (autocompleteRef) => {
    if (autocompleteRef.current) {
      const place = autocompleteRef.current.getPlace();
      const addressComponents = place.address_components;

      const streetNumber = addressComponents.find((component) =>
        component.types.includes("street_number"),
      )?.long_name;
      const route = addressComponents.find((component) =>
        component.types.includes("route"),
      )?.long_name;
      const locality = addressComponents.find((component) =>
        component.types.includes("locality"),
      )?.long_name;
      const administrativeAreaLevel1 = addressComponents.find((component) =>
        component.types.includes("administrative_area_level_1"),
      )?.short_name;
      const postalCode = addressComponents.find((component) =>
        component.types.includes("postal_code"),
      )?.long_name;

      setCity(locality || "");
      setState(administrativeAreaLevel1 || "");
      setZipCode(postalCode || "");
      setAddressLine(`${streetNumber} ${route}` || "");
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (
      !firstName ||
      !lastName ||
      !email ||
      !password ||
      !city ||
      !state ||
      !zipCode ||
      !addressLine
    ) {
      setMessage("Please fill in all fields.");
      return;
    }

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      setMessage("Please enter a valid email address.");
      return;
    }

    if (password.length < 6) {
      setMessage("Password must be at least 6 characters long.");
      return;
    }

    try {
      await axios.post("http://localhost:3000/api/Login/CreateAccount", {
        firstName,
        lastName,
        email,
        password,
        city,
        state,
        zipCode,
        addressLine,
      });
      navigate("/");
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
              <label htmlFor="firstName" className="signup-form-label">
                First Name
              </label>
              <input
                type="text"
                id="firstName"
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
                required
                className="signup-form-input"
              />
            </div>
            <div className="signup-form-group">
              <label htmlFor="lastName" className="signup-form-label">
                Last Name
              </label>
              <input
                type="text"
                id="lastName"
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
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
