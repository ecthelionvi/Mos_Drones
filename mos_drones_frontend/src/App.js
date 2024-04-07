import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import CustomerDashboard from './components/CustomerDashboard';
import ProtectedRoute from './components/ProtectedRoute';
import StaffDashboard from './components/StaffDashboard';
import SignupPage from './components/SignupPage'
import LoginPage from './components/LoginPage'
import HomePage from './components/HomePage';


const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" component={HomePage} />
        <Route path="/login" component={LoginPage} />
        <Route path="/signin" component={SignupPage} />
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
