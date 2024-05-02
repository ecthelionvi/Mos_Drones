import "../styles/DroneGrid.css";
import { Link } from "react-router-dom";
import { AgGridReact } from "ag-grid-react";
import "ag-grid-community/styles/ag-grid.css";
import React, { useState, useEffect } from "react";
import "ag-grid-community/styles/ag-theme-alpine.css";

const DroneGrid = () => {
  const [rowData, setRowData] = useState([]);

  useEffect(() => {
    fetchDroneData();
  }, []);

  const fetchDroneData = async () => {
    try {
      const response = await fetch("http://localhost:3000/api/Drone/GetDrones");
      if (response.ok) {
        const data = await response.json();
        setRowData(data);
      } else {
        console.error("Error fetching drone data:", response.status);
      }
    } catch (error) {
      console.error("Error fetching drone data:", error);
    }
  };

  const columnDefs = [
    {
      headerName: "Drone ID",
      field: "droneId",
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: "left" },
      cellRenderer: (params) => {
        return (
          <Link to={`/drone/${params.value}`} className="drone-link">
            {params.value}
          </Link>
        );
      },
    },
    {
      headerName: "Transit Status",
      field: "transit_status",
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: "left" },
    },
    {
      headerName: "Order ID",
      field: "orderId",
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: "left" },
    },
    {
      headerName: "Depot ID",
      field: "depotId",
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: "left" },
    },
  ];

  return (
    <div className="drone-grid-container">
      <div className="ag-theme-alpine" style={{ height: 400, width: 800 }}>
        <AgGridReact
          rowData={rowData}
          columnDefs={columnDefs}
          pagination={true}
          paginationPageSize={10}
          suppressHorizontalScroll={true}
          onGridReady={(params) => {
            params.api.sizeColumnsToFit();
          }}
        />
      </div>
    </div>
  );
};

export default DroneGrid;
