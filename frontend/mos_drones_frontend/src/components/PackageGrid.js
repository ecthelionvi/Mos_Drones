import React, { useState, useEffect } from 'react';
import { AgGridReact } from 'ag-grid-react';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';
import '../styles/PackageGrid.css'

const PackageGrid = () => {
  const [rowData, setRowData] = useState([]);

  useEffect(() => {
    // Simulating fetching data from an API or any other data source
    const data = [
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
    setRowData(data);
  }, []);

  const columnDefs = [
    {
      headerName: 'Tracking Number',
      field: 'id',
      // lockPosition: 'left',
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: 'left' }, // Align cell text to the left
    },
    {
      headerName: 'Delivery Date',
      field: 'deliveryDate',
      valueFormatter: (params) => {
        return new Date(params.value).toLocaleDateString();
      },
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: 'left' }, // Align cell text to the left
    },
    {
      headerName: 'Status',
      field: 'status',
      suppressMovable: true,
      suppressSizeToFit: true,
      cellStyle: { textAlign: 'left' }, // Align cell text to the left
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
