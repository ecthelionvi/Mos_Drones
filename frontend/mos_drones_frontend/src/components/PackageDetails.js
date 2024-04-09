import React from 'react';
import { useParams, NavLink } from 'react-router-dom';
import '../styles/PackageDetails.css';
import pkg from '../images/open-pkg.png'
const PackageDetails = () => {
  const { packageId } = useParams();

  const mockData = [
    {
      id: '1',
      deliveryDate: '2024-04-10',
      status: 'In Transit',
    },
    {
      id: '2',
      deliveryDate: '2024-03-30',
      status: 'Delivered',
    },
  ];

  const packageDetails = mockData.find((pkg) => pkg.id === packageId);

  if (!packageDetails) {
    return <div className="pd-package-not-found">Package not found</div>;
  }

  return (
    <div className="pd-details-container">
      <div className="pd-details-header">
        <h2 className="pd-details-title">Package Details</h2>
        <div className="pd-details__underline"></div>
        <NavLink to="/" className="pd-close-button">
          <span>×</span>
        </NavLink>
      </div>
      <div className="pd-details-content">
        <p className="pd-detail"><span className="pd-detail-label">Package ID:</span> {packageDetails.id}</p>
        <p className="pd-detail"><span className="pd-detail-label">Delivery Date:</span> {packageDetails.deliveryDate}</p>
        <p className="pd-detail"><span className="pd-detail-label">Status:</span> {packageDetails.status}</p>
      </div>
      <img className="pd-image-bottom" src={pkg} alt="Package" />
    </div>
  );
};

export default PackageDetails;
