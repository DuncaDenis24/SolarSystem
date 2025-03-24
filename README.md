# Solar System Simulation

## Overview
This project is a **Solar System Simulation** that includes planetary data, rocket simulations, and a Windows Forms application for visualization. It is built using **ASP.NET Core** for the backend and **Windows Forms** for the frontend.

## Features
- Display planetary data (diameter, mass, orbital period, etc.).
- Simulate rocket launches based on acceleration and engine data.
- Windows Forms interface for user interaction.
- Backend API to process planetary and rocket data.

## Technologies Used
- **Backend:** ConsoleApp(.NET Framework)
- **Frontend:** Windows Forms (C#)
- **Other:** JSON, Text-based data processing

## Installation & Setup
### Prerequisites
- Visual Studio (with .NET and Windows Forms support)
- Git (optional for version control)

### Steps
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/SolarSystemSimulation.git
   ```
2. Open `SolarSystem.sln` in Visual Studio.
3. Start the **Windows Forms** application (`SolarSystemForm.csproj`).

## Project Structure
```
SolarSystem
│-- SolarSystemApp
│   │-- solar/
│   │-- SolarSystem/
│   └-- SolarSystem.sln
│
└-- SolarSystemForm (Frontend - Windows Forms)
    │-- Form1.cs (Main Form UI)
    │-- SolarForm.cs (Additional UI)
    │-- App.config (Configuration)
    └-- SolarSystemForm.csproj
```

## Data Sources
The project uses text files for initial planetary and rocket data:
- `Planetary_Data.txt` – Contains diameter and mass of planets.
- `Rocket_Data.txt` – Specifies rocket engine and acceleration details.
- `Solar_System_Data.txt` – Includes orbital periods and distances.

## Contribution
Feel free to contribute by submitting pull requests or opening issues.

## License
This project is licensed under the MIT License.

---
**Author:** Your Name  
GitHub: [DuncaDenis24](https://github.com/DuncaDenis24)

