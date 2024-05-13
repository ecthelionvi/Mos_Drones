import React, { useState, useEffect } from 'react';
import "../styles/DronePage.css";
import axios from 'axios';

const DronePage = ({ droneId, onRelocate }) => {
    const [droneData, setDroneData] = useState([]);
    const depotList = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
    const [drone, setDrone] = useState({});
     
    useEffect(() => {
        const fetchDroneData = async () => {
            try {
                const response = await axios.get("http://localhost:3001/api/Admin/GetDrones");
                if (response.status === 200) {
                    setDroneData(response.data);
                } else {
                    console.error("Error fetching drone data:", response.status);
                }
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        }
        fetchDroneData();
    }, []);

    useEffect(() => {
        if (droneData.length > 0) {
            const drone = droneData.find(drone => drone.droneId === droneId);
            setDrone(drone);
        }
    }, [droneData, droneId]);

    const DroneStatus = () => {
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

    const OrderStatus = () => {
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

    const RelocationButton = ({ droneId, depotList, onRelocate }) => {

        const [depotId, setDepotId] = useState('');
        const [message, setMessage] = useState('');

        const handleInputChange = (event) => {
            setDepotId(event.target.value);
        };

        const handleClick = async () => {
            if (!depotId) {
                setMessage('Please elect a depot');
                return;
            }

            const newDepotId = parseInt(depotId);

            if ((!isNaN(newDepotId)) && (depotList.includes(newDepotId))) {
                try {
                    await axios.post("http://localhost:3001/api/Drone/ChangeDepot", {
                        droneId,
                        depotId: newDepotId
                    });
                    onRelocate(newDepotId);
                    setMessage('Drone relocated successfully')
                } catch (error) {
                    console.error("Depot Selection Error:", error);
                    setMessage("Drone Relocation failed");
                }
            }
        };

        return (
            <div>
                <select value={depotId} onChange={handleInputChange}>
                    <option value="">Select Depot</option>
                    {depotList.map((depot, index) => (
                        <option key={index} value={depot}>
                            {depot}
                        </option>
                    ))}
                </select>
                <button disabled={drone.transit_status === 'In Transit'} onClick={handleClick}>Relocate</button>
                {message && <p>{message}</p>}
            </div>
        )
    };

    return (
        <div className="dronepage-body">
            <div className="body-container">
                <h1>Drone {droneId} Dashboard</h1>
                <div className="drone-card">
                    <DroneStatus drone={drone} />
                    <p>Transit Status: {drone.transit_status}</p>
                    <OrderStatus drone={drone} />
                    <p>Deployed From Depot # {drone.depotId}</p>
                </div>
                <h2>Drone {drone.id} Status</h2>
            </div>
            <RelocationButton droneId={drone.id} depotList={depotList} />
        </div>
    );
}

export default DronePage;
