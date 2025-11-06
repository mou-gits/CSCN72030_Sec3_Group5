# GUI Frontend – C# WinForms Setup Guide

This folder is for the **Windows Forms GUI** that will display room telemetry and HVAC actuator states in real time. The app will communicate with the backend via HTTP and reflect the current state of the dorm climate system.

This guide walks you through setting up a basic **C# WinForms project** using **Visual Studio** (not VS Code), so you can get started with a working “Hello World” GUI.

---

## Prerequisites

- **Windows OS**
- **Visual Studio 2022 or later** (Community Edition is fine)
- **.NET Desktop Development workload** installed

---

## Step-by-Step Setup

### 1. Open Visual Studio

Launch **Visual Studio** (not VS Code). You should see the start screen with options to create or open a project.

---

### 2. Create a New Project

- Click **"Create a new project"**
- In the search bar, type **"Windows Forms App (.NET)"**
- Select **"Windows Forms App (.NET)"** (not .NET Framework)
- Click **Next**

---

### 3. Configure the Project

- **Project Name**: `DormClimateGUI`
- **Location**: Browse to your local clone of the repo → `gui_frontend/`
- **Solution Name**: You can keep it the same as the project name
- Click **Create**

---

### 4. Verify Project Structure

Visual Studio will generate:

```
DormClimateGUI/
├── Form1.cs
├── Program.cs
├── DormClimateGUI.csproj
```

You’ll see a design surface for `Form1` and a code editor.

---

### 5. Run the App

- Click the green **Start** button (or press `F5`)
- A blank Windows Form window should appear
- This confirms your environment is working

---

## Next Steps

Once your Hello World app is running:

- Add UI elements to display temperature, heater %, AC %
- Use `HttpClient` to call backend API endpoints (e.g., `/api/telemetry`)
- Parse JSON responses and update the UI dynamically

---

## Integration Expectations

- The backend will expose HTTP endpoints on `localhost:8000`
- Your app will poll or request telemetry data from `/api/telemetry?room_id=...`
- You’ll display the current room temperature and actuator states

---

## Folder Structure

```
gui_frontend/
├── DormClimateGUI/         # Visual Studio project folder
│   ├── Form1.cs
│   ├── Program.cs
│   └── DormClimateGUI.csproj
└── README.md
```

---

## 📚 Resources

- [WinForms Documentation](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
- [Visual Studio Download](https://visualstudio.microsoft.com/downloads/)
