import { useNavigate } from 'react-router-dom';
import React, { useState } from 'react';
import { jwtDecode } from 'jwt-decode';
import '../styles/LoginPage.css';
import logo from '../images/logo.png';
import axios from 'axios';

const LoginForm = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [message, setMessage] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post('http://localhost:5159/api/auth/login', {
        email,
        password,
      });

      const token = response.data.token;
      const decodedToken = jwtDecode(token);
      const roleUri = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
      const role = decodedToken[roleUri];

      localStorage.setItem('token', token);
      localStorage.setItem('role', role);

      if (role === 'staff') {
        navigate('/staff');
      } else if (role === 'customer') {
        navigate('/customer');
      } else {
        console.log(decodedToken);
        setMessage('Unknown user role.');
      }
    } catch (error) {
      console.error('Login error:', error);
      setMessage('Login failed. Please check your credentials.');
    }
  };

  return (
    <div className="login-form-container">
      <div className="login-form-wrapper">
        <div className="login-form-content">
          <img src={logo} alt="Mo's Drones Logo" className="login-form-logo" />
          <h2 className="login-form-title">Sign In</h2>
          <form onSubmit={handleSubmit} className="login-form">
            <div className="login-form-group">
              <label htmlFor="email" className="login-form-label">Email</label>
              <input
                type="email"
                id="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
                className="login-form-input"
              />
            </div>
            <div className="login-form-group">
              <label htmlFor="password" className="login-form-label">Password</label>
              <input
                type="password"
                id="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
                className="login-form-input"
              />
            </div>
            <button type="submit" className="login-form-button">Sign In</button>
          </form>
          <p className="login-form-message">{message}</p>
        </div>
        <div className="login-form-signup-section">
          <p className="login-form-signup-text">New to Mo's Drones?</p>
          <a href="/signup" className="login-form-signup-button">Sign Up</a>
        </div>
      </div>
    </div>
  );
};

export default LoginForm;
