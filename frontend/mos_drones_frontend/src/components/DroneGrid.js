import React, { useState, useEffect } from 'react';
import { AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';
import '../styles/DroneGrid.css';
import { Link } from 'react-router-dom';

const DroneGrid = () => {
  const [rowData, setRowData] = useState([]);

  useEffect(() => {
    const mockData = {
      "drones": [
        {
          "droneId": 1,
          "transit_status": "In Transit",
          "orderId": 101,
          "depotId": 201
        },
        {
          "droneId": 2,
          "transit_status": "Delivered",
          "orderId": 102,
          "depotId": 202
        },
        {
          "droneId": 3,
          "transit_status": "Awaiting Dispatch",
          "orderId": null,
          "depotId": 201
        },
        {
          "droneId": 4,
          "transit_status": "In Maintenance",
          "orderId": null,
          "depotId": 203
        }
      ]
    };

    setRowData(mockData.drones);
  }, []);

  const columnDefs = [
    {
      headerName: 'Drone ID',
      field: 'droneId',
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: 'left' },
      cellRenderer: (params) => {
        return (
          <Link to={`/drone/${params.value}`} className="drone-link">
            {params.value}
          </Link>
        );
      },
    },
    {
      headerName: 'Transit Status',
      field: 'transit_status',
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: 'left' },
    },
    {
      headerName: 'Order ID',
      field: 'orderId',
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: 'left' },
    },
    {
      headerName: 'Depot ID',
      field: 'depotId',
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: 'left' },
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
