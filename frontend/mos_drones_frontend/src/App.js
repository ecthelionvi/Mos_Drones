import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import LoginPage from './components/LoginPage';
import CustomerDashboard from './components/CustomerDashboard';
import StaffDashboard from './components/StaffDashboard';
import ProtectedRoute from './components/ProtectedRoute';
import HomePage from './components/HomePage';
import SignupPage from './components/SignupPage';

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage key="home" />} />
        <Route path="/login" element={<LoginPage />} />
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
