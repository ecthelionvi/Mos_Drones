# Package Tracker for Mo's Drones

Mo's Drones offers a cutting-edge courier service utilizing small unmanned aerial systems (SUAS) to efficiently deliver packages within the Lincoln and Omaha, Nebraska, areas. This GitHub repository hosts the software solution designed to manage and track the entire delivery process.
![Package Tracker Logo](frontend/mos_drones_frontend/src/images/logo.png)
## Overview

When a customer requires a package delivery, Mo's Drones dispatches a SUAS from the nearest depot to pick up the package. To ensure comprehensive coverage, depots are strategically located every ten miles along I-80 between Seward and the Missouri River. Additional depots are situated at key intersections in Lincoln, including O Street and 27th Street, O Street and 84th Street, and 84th Street and Nebraska Highway 2.

Upon reaching a depot, the package is transferred to another SUAS for onward delivery to the next depot or directly to the destination, provided it is within range. Throughout the delivery journey, customers can track the status of their packages, from dispatch to delivery, ensuring transparency and peace of mind.

## Features

### For Customers

- **Package Tracking**: Customers can monitor the status of their deliveries, including the origin and destination points, dispatch times, pickup times, depot handoffs, and delivery times.
  
- **Delivery Requests**: Customers can effortlessly generate delivery requests, prompting automatic dispatch of a SUAS to collect the package.

### For Mo's Drones Staff

- **Real-time Monitoring**: Staff members have access to a comprehensive dashboard displaying the current locations of all SUAS, whether at depots, in transit between depots, en route to or from customers, or at customer locations.

- **Package Management**: Staff can easily track which packages are aboard each SUAS, facilitating efficient routing and delivery coordination.

- **Dispatch Control**: While SUAS dispatch for package pickups is automated, staff retain the ability to manually dispatch empty SUAS between depots as needed.

- **Resilient Data**: Crucial information regarding SUAS and package locations, destinations, and statuses is resilient to power outages, ensuring continuity of service even in adverse conditions.

## Installation

To set up the Package Tracker system locally, follow these steps:

1. Clone the repository to your local machine.
2. Install the required dependencies as outlined in the documentation.
3. Configure the system settings and database connections.
4. Run the application locally or deploy it to your preferred hosting environment.

For detailed installation instructions, refer to the documentation provided in the repository.

## Contributions

All contributions are the result of collaborative teamwork. Meet the awesome team behind this project:
- [Angie Zheng](https://github.com/angzheng22)
- [Jonathan Skelton](https://github.com/Jonny-Skelton)
- [Parker Allen](https://github.com/pallen44)
- [Robert Sear](https://github.com/ecthelionvi)
- [Sabrina Benford](https://github.com/SabrinaB286)

Feel free to connect with each team member via their GitHub profiles!
## License

This software is distributed under the [MIT License](LICENSE), granting you the freedom to use, modify, and distribute the software for any purpose, subject to the terms outlined in the license agreement.
