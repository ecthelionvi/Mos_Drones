import "../styles/PackageGrid.css";
import { Link } from "react-router-dom";
import { AgGridReact } from "ag-grid-react";
import "ag-grid-community/styles/ag-grid.css";
import React, { useEffect, useState } from "react";
import "ag-grid-community/styles/ag-theme-alpine.css";

const PackageGrid = ({ packageData, fetchPackages }) => {
  const [rowData, setRowData] = useState([]);
  const [useMockData, setUseMockData] = useState(false);

  useEffect(() => {
    const mockData = [
      {
        packageId: "1",
        deliveryDate: "2024-04-10",
        status: "In Transit",
      },
      {
        packageId: "2",
        deliveryDate: "2024-03-30",
        status: "Delivered",
      },
    ];

    if (useMockData) {
      setRowData(mockData);
    } else {
      setRowData(packageData);
    }
  }, [packageData, useMockData]);

  const columnDefs = [
    {
      headerName: "Tracking Number",
      field: "packageId",
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
      cellStyle: { textAlign: "left" },
    },
  ];

  return (
    <div className="package-grid-container">
      <div className="ag-theme-alpine" style={{ height: 400, width: 900 }}>
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