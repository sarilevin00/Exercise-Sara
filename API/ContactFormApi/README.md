# Contact Form API

This project is a Web API built with .NET that allows users to submit contact forms and manage their submissions through CRUD operations. It also provides a monthly report of submissions via a stored procedure.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete contact form submissions.
- **Monthly Report**: Retrieve a monthly report of contact form submissions using a stored procedure.
- **Data Model**: The contact form includes fields for Name, Phone, Email, Departments, Description, and Submission Date.

## Project Structure

- **Controllers**: Contains the `ContactFormController` which handles HTTP requests.
- **Models**: Contains the `ContactForm` model representing the data structure.
- **Services**: Contains the `ContactFormService` which encapsulates business logic.
- **Data**: Contains the `ContactFormDbContext` for database context.
- **StoredProcedures**: Contains the logic for generating a monthly report.
- **Tests**: Contains unit tests for the controller.
- **Program.cs**: Entry point of the application.
- **Startup.cs**: Configures services and the request pipeline.
- **appsettings.json**: Configuration settings for the application.

## Setup Instructions

1. Clone the repository.
2. Navigate to the project directory.
3. Restore the dependencies using `dotnet restore`.
4. Update the `appsettings.json` file with your database connection string.
5. Run the application using `dotnet run`.

## Usage

- Use a tool like Postman or curl to interact with the API endpoints.
- The base URL for the API is `http://localhost:5000/api/contactform`.

## Endpoints

- `POST /api/contactform`: Create a new contact form submission.
- `GET /api/contactform/{id}`: Retrieve a specific contact form submission.
- `PUT /api/contactform/{id}`: Update a specific contact form submission.
- `DELETE /api/contactform/{id}`: Delete a specific contact form submission.
- `GET /api/contactform/monthlyreport`: Get the monthly report of contact form submissions.

## Unit Tests

Unit tests are included in the `Tests` directory to ensure the functionality of the API.

## License

This project is licensed under the MIT License.

**הסברים נוספים לפי השאלות**

## תיאור הפרויקט
ContactFormApi הוא שירות Web API ב-.NET Core 
המאפשר ניהול טופס פניות עם פעולות CRUD, 
כולל שליחת פניות, צפייה, עדכון ומחיקה. בנוסף, השירות כולל Endpoint להצגת דוח פניות חודשי באמצעות Stored Procedure.

## רכיבי הפרויקט
- **Controllers**: ניהול ה-Endpoints של ה-API.
- **Models**: הגדרת מבנה הנתונים של טופס הפנייה.
- **Services**: לוגיקת עסקים, טיפול בפניות ובדוחות.
- **Data**: ניהול הגישה למסד הנתונים באמצעות Entity Framework Core.
- **StoredProcedures**: קריאה ל-Stored Procedure לדוח חודשי.
- **Unit Tests**: בדיקות יחידה לפעולות הבסיסיות של ה-API.

## שיטת הבנייה
- שימוש ב-.NET Core Web API.
- Entity Framework Core לניהול ORM.
- Dependency Injection לכל רכיבי השירות.
- שימוש ב-async/await לביצועים טובים יותר.

## יתרונות
- **מודולריות**: הפרדה ברורה בין שכבות (מודל, שירות, בקר).
- **Scalability**: מתאים להרחבה עתידית.
- **בדיקות**: כולל בדיקות יחידה בסיסיות.
- **ביצועים**: שימוש ב-async/await.
- **אבטחה**: ניתן להוסיף בקלות מנגנוני Authentication/Authorization.

## חסרונות
- דורש ידע ב-.NET Core ו-Entity Framework.
- תלות במסד נתונים SQL Server.
- לא כולל ממשק משתמש (Frontend).

## אבטחה
- שימוש ב-Connection Strings מאובטח בקובץ הגדרות.
- אפשרות להוספת JWT Authentication.
- טיפול ב-CORS להגבלת גישה מדומיינים מורשים בלבד.
- טיפול בשגיאות באמצעות Exception Handling והחזרת קודי סטטוס מתאימים.

## טיפול בשגיאות
- שימוש ב-try/catch בכל פעולות הגישה למסד הנתונים.
- החזרת הודעות שגיאה מפורטות ללקוח.
- רישום שגיאות בלוגים (ניתן להרחיב ל-Serilog/NLog).

## מנגנוני קישור
- Entity Framework Core לגישה למסד הנתונים.
- Stored Procedure לדוח חודשי.
- אפשרות להרחבה ל-Swagger לתיעוד ה-API.

## קרוס דומיין (CORS)
- מוגדר ב-Startup.cs, ניתן להגדיר דומיינים מורשים בלבד.
- מאפשר אינטגרציה עם אפליקציות Frontend שונות.

## הוראות התקנה והפעלה

1. **התקנת .NET Core SDK**  
   יש להוריד ולהתקין את [NET Core SDK](https://dotnet.microsoft.com/download).

2. **הגדרת מסד נתונים**  
   יש להגדיר Connection String בקובץ `appsettings.json` תחת `DefaultConnection`.

3. **הרצת הפרויקט**
dotnet restore dotnet build dotnet run
dotnet test

5. **גישה ל-API**
- כתובת ברירת מחדל: `https://localhost:5001/api/contactform`
- Endpoint לדוח חודשי: `GET /api/contactform/monthlyreport`

## הערות
- יש להגדיר את ה-Stored Procedure `sp_GetMonthlyReport` במסד הנתונים.
- מומלץ להפעיל HTTPS בלבד.
- ניתן להרחיב את המערכת לאימות משתמשים ולניהול הרשאות.


