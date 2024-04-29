import React, { useState, useEffect } from "react";
import "../styles/PackageDetails.css";
import pkg from "../images/open-pkg.png";
import pkg_not_found from "../images/package-not-found.png";
import { useParams, NavLink } from "react-router-dom";
import axios from "axios";

const PackageDetails = () => {
  const { packageId } = useParams();
  const [packageDetails, setPackageDetails] = useState(null);

  useEffect(() => {
    const fetchPackageDetails = async () => {
      try {
        const response = await axios.post("http://localhost:5000/api/Home/FindOrder", {
          orderId: parseInt(packageId),
        });
        setPackageDetails(response.data);
      } catch (error) {
        console.error("Error fetching package details:", error);
      }
    };

    fetchPackageDetails();
  }, [packageId]);

  if (!packageDetails) {
    return (
      <div className="pd-details-container">
        <div className="pd-details-header">
          <h2 className="pd-details-title">Oops...</h2>
          <div className="pd-details__underline-not-found"></div>
          <NavLink to="/" className="pd-close-button">
            <span>×</span>
          </NavLink>
        </div>
        <div className="pd-image-container">
          <img className="pd-image-bottom-not-found" src={pkg_not_found} alt="Baby Mo" />
          <div className="pd-speech-bubble">
            <p className="pd-speech-bubble-paragraph">Sorry, I can't find your package</p>
          </div>
        </div>
      </div>
    );
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
        <p className="pd-detail">
          <span className="pd-detail-label">Package ID:</span> {packageDetails.packageId}
        </p>
        <p className="pd-detail">
          <span className="pd-detail-label">Delivery Date:</span>{" "}
          {new Date(packageDetails.deliveryDate).toLocaleDateString()}
        </p>
        <p className="pd-detail">
          <span className="pd-detail-label">Status:</span> {packageDetails.status}
        </p>
      </div>
      <img className="pd-image-bottom" src={pkg} alt="Package" />
    </div>
  );
};

export default PackageDetails;
