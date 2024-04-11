import "../styles/PackageGrid.css";
import { Link } from "react-router-dom";
import { AgGridReact } from "ag-grid-react";
import "ag-grid-community/styles/ag-grid.css";
import React, { useState, useEffect } from "react";
import "ag-grid-community/styles/ag-theme-alpine.css";

const PackageGrid = () => {
  const [rowData, setRowData] = useState([]);

  useEffect(() => {
    const mockData = [
      {
        id: "1",
        deliveryDate: "2024-04-10",
        status: "In Transit",
      },
      {
        id: "2",
        deliveryDate: "2024-03-30",
        status: "Delivered",
      },
    ];
    setRowData(mockData);
  }, []);

  const columnDefs = [
    {
      headerName: "Tracking Number",
      field: "id",
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: "left" },
      cellRenderer: (params) => {
        return (
          <Link to={`/package/${params.value}`} className="package-link">
            {params.value}
          </Link>
        );
      },
    },
    {
      headerName: "Delivery Date",
      field: "deliveryDate",
      valueFormatter: (params) => {
        return new Date(params.value).toLocaleDateString();
      },
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: "left" },
    },
    {
      headerName: "Status",
      field: "status",
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: "left" },
    },
  ];

  return (
    <div className="package-grid-container">
      <div className="ag-theme-alpine" style={{ height: 400, width: 600 }}>
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

export default PackageGrid;
