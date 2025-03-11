# RSGymPT

A learning project developed in C# using .NET 8.0 for managing personal trainer sessions. The application focuses on object-oriented programming principles and implements key functionalities such as:

- User authentication.
- Personal trainer management.
- Handling and tracking user requests.

This project is designed as a personal learning exercise and incorporates SOLID principles for improved code structure and maintainability.

## Features

- **Login Module:** Secure user authentication.
- **Request Module:** Manage personal trainer requests (create, update, delete, and finalize sessions).
- **Personal Trainer Module:** Search and view trainer information.
- **User Module:** View user profiles (excluding sensitive data like passwords).

## Technologies

- **C#** (with .NET 8.0)
- **JSON Files** for data persistence

## Project Structure

The project follows an organized structure to separate concerns and ensure maintainability:

- RSGymPT/
  - Data/
    - JsonFiles/
      - Users.json
      - PersonalTrainers.json
      - Requests.json
    - DataStorage.cs
    - SeedData.cs
  - Models/
    - User.cs
    - PersonalTrainer.cs
    - Request.cs
  - Services/
    - AuthService.cs
    - RequestService.cs
    - PersonalTrainerService.cs
  - UI/
    - LoginMenu.cs
    - MainMenu.cs
    - RequestMenu.cs
    - PersonalTrainerMenu.cs
    - UserMenu.cs
  - Utils/
    - Constants.cs
    - Helpers.cs
  - Program.cs
  - RSGymPT.sln

---

This project is part of a learning exercise and is not intended for production use.
