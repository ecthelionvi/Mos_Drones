import { useNavigate } from 'react-router-dom';
import React, { useState } from 'react';
import '../styles/SignupPage.css';
import axios from 'axios';

const SignupForm = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [address, setAddress] = useState('');
  const [message, setMessage] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Basic validation
    if (!name || !email || !password || !address) {
      setMessage('Please fill in all fields.');
      return;
    }

    // Email validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
      setMessage('Please enter a valid email address.');
      return;
    }

    // Password validation
    if (password.length < 6) {
      setMessage('Password must be at least 6 characters long.');
      return;
    }

    try {
      await axios.post('http://localhost:5159/api/auth/signup', {
        name,
        email,
        password,
        address,
      });
      navigate('/login');
    } catch (error) {
      console.error('Signup error:', error);
      setMessage('Signup failed. Please try again.');
    }
  };

  return (
    <div className="signup-form-container">
      <div className="signup-form-wrapper">
        <div className="signup-form-content">
          <h2 className="signup-form-title">Create Account</h2>
          <form onSubmit={handleSubmit} className="signup-form">
            <div className="signup-form-group">
              <label htmlFor="name" className="signup-form-label">Name</label>
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
              <label htmlFor="email" className="signup-form-label">Email</label>
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
              <label htmlFor="password" className="signup-form-label">Password</label>
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
              <label htmlFor="address" className="signup-form-label">Address</label>
              <input
                type="text"
                id="address"
                value={address}
                onChange={(e) => setAddress(e.target.value)}
                required
                className="signup-form-input"
              />
            </div>
            <button type="submit" className="signup-form-button">Sign Up</button>
          </form>
          <p className="signup-form-message">{message}</p>
        </div>
        <div className="signup-form-login-section">
          <p className="signup-form-terms">
            By creating an account, you agree to Mo's Drones' Conditions of Use
            and Privacy Notice.
          </p>
          <p className="signup-form-login-text">Already have an account?</p>
          <a href="/login" className="signup-form-login-link">
            Sign In
          </a>
        </div>
      </div>
    </div>
  );
};

export default SignupForm;
