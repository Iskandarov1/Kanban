# Ilmhub Spaces - Lead Management System

Ilmhub Spaces is a modern web application built with **Blazor** for effectively managing educational institutions. Designed with user-friendly features and powered by **MudBlazor**, it provides a seamless experience .

---

## **Features Kanban**

### **Lead Management**
- **Track Leads**: Monitor leads through various stages of the sales funnel.
- **Drag-and-Drop Interface**: Manage leads with an intuitive kanban board.
- **Lead Status Tracking**: Organize leads into statuses like **New**, **Contacted**, **Registered**, and more.
- **Detailed Lead Information**:
  - Contact details (e.g., phone numbers).
  - Notes for each lead.
- **Multiple Lead Sources**:
  - Telegram
  - Instagram
  - Referrals

### **Course Management**
- **Comprehensive Course Catalog**: Maintain detailed information about all courses.
- **Course Details**:
  - Pricing and duration.
  - Assign instructors to courses.
- **Active/Inactive Course Status**: Toggle course availability with ease.

### **User Interface**
- **Modern Material Design**: Built with **MudBlazor** for a professional look and feel.
- **Responsive Layout**: Works flawlessly on both desktop and mobile devices.
- **Search and Filtering**:
  - Search through leads and courses effortlessly.
  - Filter data by date range, course, or source.

---

## **Screenshots**

https://github.com/user-attachments/assets/4079e615-24ee-4b8f-845a-1c4baa1cea45



Uploading Screen Recording 2025-01-17 at 8.07.33 PM.mov…



https://github.com/user-attachments/assets/503c2ab3-9396-42f6-9024-5a4fe9ac3b6f





---

## **Tech Stack**

- **Frontend**: Blazor (WebAssembly)
- **UI Framework**: MudBlazor (Material Design components for Blazor)
- **Backend**: ASP.NET Core
- **Database**: SQL Server / Entity Framework Core
- **Hosting**: Azure / Local IIS (configurable)

---

## **Getting Started**

### **Prerequisites**
- [.NET SDK](https://dotnet.microsoft.com/download) (6.0 or higher)
- SQL Server (or compatible database)
- A text editor or IDE (e.g., [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/))

### **Installation**

1. Clone the repository:
   ```bash
   git clone https://github.com/Iskandarov1/Kanban.git
   cd ilmhub-spaces
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Set up the database:
   - Update the connection string in `appsettings.json`.
   - Apply migrations:
     ```bash
     dotnet ef database update
     ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Open your browser and navigate to:
   ```
   http://localhost:5000
   ```

---

## **Contributing**

Contributions are welcome! If you'd like to contribute:

1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add new feature"
   ```
4. Push to the branch:
   ```bash
   git push origin feature-name
   ```
5. Open a Pull Request.

---

## **License**

This project is licensed under the [MIT License](LICENSE).

---

## **Contact**

For inquiries, support, or feedback, please contact:

- **Email**: Iskandarovsanjarbek1327@gmail.com
- **GitHub**: [your-username](https://github.com/Iskandarov1)
