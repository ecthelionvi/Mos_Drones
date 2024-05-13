import "../styles/DroneGrid.css";
import { Link } from "react-router-dom";
import { AgGridReact } from "ag-grid-react";
import "ag-grid-community/styles/ag-grid.css";
import React, { useState, useEffect } from "react";
import "ag-grid-community/styles/ag-theme-alpine.css";

const DroneGrid = () => {
  const [rowData, setRowData] = useState([]);
  const [useMockData, setMockData] = useState(false);

  useEffect(() => {
    const mockData = {
      drones: [
        {
          droneId: 1,
          transitStatus: "In Transit",
          order: {
            orderId: 101,
          },
          currentDepot: {
            depotId: 201,
          },
        },
        {
          droneId: 2,
          transitStatus: "Delivered",
          order: {
            orderId: 102,
          },
          currentDepot: {
            depotId: 202,
          },
        },
        {
          droneId: 3,
          transitStatus: "Awaiting Dispatch",
          order: null,
          currentDepot: {
            depotId: 201,
          },
        },
        {
          droneId: 4,
          transitStatus: "In Maintenance",
          order: null,
          currentDepot: {
            depotId: 203,
          },
        },
      ],
    };

    const fetchDroneData = async () => {
      if (useMockData) {
        setRowData(mockData.drones);
        return;
      }

      try {
        const response = await fetch("http://localhost:3001/api/Admin/GetDrones");
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

    fetchDroneData();
  }, [useMockData]);

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
      field: "transitStatus",
      suppressMovable: true,
      cellStyle: { textAlign: "left", flex: 1 },
    },
    {
      headerName: "Order ID",
      valueGetter: (params) => {
        return params.data.order ? params.data.order.orderId : null;
      },
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: "left" },
    },
    {
      headerName: "Depot ID",
      valueGetter: (params) => {
        return params.data.currentDepot ? params.data.currentDepot.depotId : null;
      },
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: "left" },
    },
  ];

  return (
    <div className="drone-grid-container">
      <div className="ag-theme-alpine" style={{ height: 400, width: 1200}}>
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
