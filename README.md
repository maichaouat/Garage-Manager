
Garage Manager is a robust console application meticulously crafted to streamline garage management tasks. The user interface presents an extensive menu with diverse capabilities to ensure efficient garage operations. The system seamlessly handles different vehicle types, such as Cars, Motorcycles, and Trucks, and it offers the flexibility to specify whether a vehicle is powered by an Electric or Combustible engine. Moreover, the application is designed with scalability in mind, making it effortless to accommodate additional vehicle types when required.

Project Overview
The project follows a clear separation between the logic layer (GarageLogic solution) and the user interface (Console.UI solution). This design ensures that the interaction with the user is handled through the UIGarageManager class, which, in turn, manages the logic layer.

Design Separation
The separation between the logic layer and the user interface is crucial for maintaining a clean and organized architecture. The User Interface layer is responsible for interacting with the user through console input and output. It triggers the logic layer and receives the necessary parameters from it for a seamless user experience.

In contrast, the logic layer (GarageLogic Solution) consists of objects and their methods, focused solely on business logic. It does not directly interact with the user. For each object (e.g., Car, Motorcycle, Truck) within the Vehicle class, common requirements are defined in the logic layer. Additionally, each object has individual requirements specific to its type. The modular design of the code allows for the effortless addition of new vehicle types (child classes of Vehicle) with minimal code changes. This approach ensures the program's maintainability and encourages reusability.

Class Diagram
For a more detailed insight into the project's design and relationships between classes, please refer to the class diagram file.
![diagram](https://github.com/maichaouat/Garage-Manager/blob/abd75974824123126ffa33f3a4f3e1967a22337d/%D7%AA%D7%9E%D7%95%D7%A0%D7%941.png)
The Garage Manager project embraces best practices in software architecture, making it a scalable and easy-to-maintain solution. With the clear separation of concerns and modular design, the application can be expanded to accommodate new vehicle types without compromising the overall structure.

The system is designed to provide a user-friendly experience for managing a garage efficiently.

