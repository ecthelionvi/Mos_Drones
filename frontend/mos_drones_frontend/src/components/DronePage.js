import React, { useState } from 'react';
import "../styles/DronePage.css";

const DronePage = ({ drone, onDepotIdChange }) => {

    const DroneStatus = ({ drone }) => {
        const hasOrder = (drone.orderId != null);

        let statusMessage = '';
        if ((drone.transit_status === 'In Transit') && (hasOrder === true)) {
            statusMessage = "Drone is in transit with Order";
        } else if ((drone.transit_status === 'At Depot') && (hasOrder === true)) {
            statusMessage = `Drone is at Depot number ${drone.depotId} with Order`;
        } else {
            statusMessage = `Drone is ready to be deployed from Depot ${drone.depotId}`;
        }

        return (
            <p>{statusMessage}</p>
        );
    };

    const OrderStatus = ({ drone }) => {
        let orderStatusMessage = '';
        if (drone.orderId === null) {
            orderStatusMessage = 'Current Order Number: N/A';
        } else {
            orderStatusMessage = `Current Order Number: ${drone.orderId}`;
        }

        return (
            <p>{orderStatusMessage}</p>
        );
    };

    const RelocationButton = ({ drone }) => {

        const [depotId, setDepotId] = useState(drone.depotId);
        const handleInputChange = (event) => {
            setDepotId(event.target.value);
        };

        const handleClick = () => {
            const newDepotId = parseInt(depotId, 10);

            if (!isNaN(newDepotId)) {
                onDepotIdChange(newDepotId);
                setDepotId(newDepotId);
            } else {
                alert('Please enter a value Depot Number');
            }
        };

        return (
            <div>
                <input
                    type="number"
                    value={depotId}
                    onChange={handleInputChange}
                    placeholder="Enter Depot Id"
                />
                <button
                    disabled={drone.transit_status === 'In Transit'}
                    onClick={handleClick}>
                    Relocate
                </button>
            </div>
        )
    };

    return (
        <div className="dronepage-body">
            <div className="body-container">
                <h1>Drone {drone.id} Dashboard</h1>
                <div className="drone-card">
                    <DroneStatus drone={drone} />
                    <p>Transit Status: {drone.transit_status}</p>
                    <OrderStatus drone={drone} />
                    <p>Deployed From Depot # {drone.depotId}</p>
                </div>
                <h2>Drone {drone.id} Status</h2>
            </div>
            <RelocationButton drone={drone} />
        </div>
    );
}

export default DronePage;