# 🐾 Animal Rescue Management App

This application is designed to help rescue centers manage their animals more effectively. Built in C#, it supports both Console and UWP interfaces, with functionality for adding, removing, sorting, and archiving animals, as well as calculating adoption fees.

---

## 🎯 Features

- Add new animals with ID, name, species, and check-in date
- Search for animals by ID
- Remove or "check out" adopted animals
- Automatically calculate adoption fees based on age
- Archive adopted pets
- Save and load data from a local file
- Use either Console or UWP interface

---

## 🧑‍💻 How to Use the Application

### 🔹 Console Application

1. **Run the Console app**
   - Open the solution in Visual Studio.
   - Set the Console project (e.g., `AnimalRescue.ConsoleApp`) as the startup project.
   - Press `Ctrl + F5` to run without debugging.

2. **Main Menu Options**
   - Press a key to select:
     - `1` → Add Animal
     - `2` → List All Animals
     - `3` → Search Animal by ID
     - `4` → Sort Animals
     - `5` → Remove (Checkout) Animal
     - `6` → Archive Adopted Animals
     - `7` → Exit

3. **Follow Prompts**
   - Enter animal name, species, etc., when prompted.
   - Animal ID is generated automatically.
   - Confirmation messages will guide you.

---

### 🔸 UWP Application

1. **Run the UWP app**
   - Set the UWP project (e.g., `PetUWP`) as the startup project.
   - Build and deploy on local machine.

2. **Add a Pet**
   - Enter name and species in the text boxes.
   - Click `Add Pet` to save.

3. **Remove a Pet**
   - Enter the Pet ID in the "Remove Pet" text box.
   - Click `Remove` to delete it.

4. **Check Out a Pet**
   - Enter the Pet ID in the "Checkout Pet" section.
   - Click `Check Out`.

5. **See Animal List**
   - The ListView on the main page shows all animals currently in the system.

---

## 📂 Data Storage

- File: `pets.txt`
- Location:
  - Console: Root directory of the project
  - UWP: Application’s local folder (`ApplicationData.Current.LocalFolder`)
- Format: CSV (`ID,Name,Species,CheckInTime,isCheckedOut`)

---

## 📌 Notes

- IDs are auto-generated and unique.
- Once an animal is checked out, it's marked but not deleted unless archived.
- Archived animals can be saved separately (if implemented).
- Always ensure `pets.txt` is not open elsewhere to avoid access issues.

---

## 📷 Screenshots

*Add screenshots here if required.*

---

## 👨‍💻 Author

**Simeon Oyinlola Olawore**  
Computer Programming and Analysis | Niagara College  
2025 Skills Ontario Coding Challenge

---

## ✅ Requirements

- .NET Core / .NET 8 SDK
- Visual Studio 2022 or later
- Windows 10/11 for UWP deployment

