import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import LoginPage from './components/LoginPage';
import CustomerDashboard from './components/CustomerDashboard';
import StaffDashboard from './components/StaffDashboard';
import ProtectedRoute from './components/ProtectedRoute';
import HomePage from './components/HomePage';
import SignupPage from './components/SignupPage';
import PackageGrid from './components/PackageGrid';

const App = () => {
  const [loggedIn, setLoggedIn] = useState(() => {
    const sessionLoggedIn = sessionStorage.getItem('loggedIn');
    return sessionLoggedIn === 'true';
  });

  useEffect(() => {
    sessionStorage.setItem('loggedIn', loggedIn);
  }, [loggedIn]);

  const handleLogin = () => {
    setLoggedIn(true);
  };

  const handleLogout = () => {
    setLoggedIn(false);
  };
  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage loggedIn={loggedIn} setLoggedIn={setLoggedIn} onLogout={handleLogout} component={PackageGrid} />} />
        <Route path="/login" element={<LoginPage loggedIn={loggedIn} onLogin={handleLogin} />} />
        <Route path="/signup" element={<SignupPage />} />
        <Route
          path="/customer"
          element={<ProtectedRoute component={CustomerDashboard} role="customer" />}
        />
        <Route
          path="/staff"
          element={<ProtectedRoute component={StaffDashboard} role="staff" />}
        />
      </Routes>
    </Router>
  );
};

export default App;
