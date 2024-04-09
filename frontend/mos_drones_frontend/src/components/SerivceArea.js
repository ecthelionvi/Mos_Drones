import '../styles/ServiceArea.css';
import warehouseIcon from '../images/warehouse.png';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';
import React, { useEffect, useRef } from 'react';

const Map = () => {
  const position = [40.9867827, -96.5746042];
  const zoom = 10;
  const mapRef = useRef(null);

  const depots = [
    { name: "Depot 1 - Seward", lat: 40.911152, lng: -97.101418 },
    { name: "Depot 2 - Seward + 10 miles", lat: 40.8864233, lng: -96.9189836 },
    { name: "Depot 3 - Seward + 20 miles", lat: 40.8743983, lng: -96.7304361 },
    { name: "Depot 4 - 27th St & 0 St", lat: 40.813800, lng: -96.758890 },
    { name: "Depot 5 - 84th St & HWY 2", lat: 40.735820, lng: -96.606360 },
    { name: "Depot 6 - O St & 84th St", lat: 40.813500, lng: -96.605940 },
    { name: "Depot 7 - Seward + 30 miles", lat: 40.897247, lng: -96.5727986 },
    { name: "Depot 8 - Seward + 40 miles", lat: 40.9575287, lng: -96.4078043 },
    { name: "Depot 9 - Seward + 50 miles", lat: 41.0570905, lng: -96.2939217 },
    { name: "Depot 10 - Seward + 60 miles", lat: 41.1520287, lng: -96.1537872 },
    { name: "Depot 11 - Seward + 70 miles (Omaha)", lat: 41.224722, lng: -96.01937 },
  ];

  const customIcon = L.icon({
    iconUrl: warehouseIcon,
    iconSize: [32, 32],
    iconAnchor: [16, 32],
    popupAnchor: [0, -32],
  });

  useEffect(() => {
    const map = mapRef.current;
    if (map) {
      map.invalidateSize();
    }
  }, []);

  return (
    <div>
      <MapContainer center={position} zoom={zoom} className="service-area" ref={mapRef}>
        <TileLayer
          url="https://{s}.basemaps.cartocdn.com/light_all/{z}/{x}/{y}{r}.png"
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>'
          subdomains='abcd'
          maxZoom={19}
        />
        {depots.map((depot, index) => (
          <Marker key={index} position={[depot.lat, depot.lng]} icon={customIcon}>
            <Popup>{depot.name}</Popup>
          </Marker>
        ))}
      </MapContainer>
    </div>
  );
};

export default Map;
