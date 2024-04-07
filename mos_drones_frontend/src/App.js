import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import LoginForm from './components/LoginPage';
import CustomerDashboard from './components/CustomerDashboard';
import StaffDashboard from './components/StaffDashboard';
import ProtectedRoute from './components/ProtectedRoute';
import MainPage from './components/HomePage';
import SignupForm from './components/SignupPage';

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/login" element={<LoginForm />} />
        <Route path="/signup" element={<SignupForm />} />
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
