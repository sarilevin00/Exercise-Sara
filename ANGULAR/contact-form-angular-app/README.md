# Contact Form Angular App

This project is an Angular application that communicates with a .NET Web API for managing contact form submissions. It allows users to submit contact forms and view a monthly report of submissions.

## Features

- **Contact Form**: Users can fill out a contact form with fields for Name, Phone, Email, Departments, and Description.
- **Monthly Report**: Displays a report of contact form submissions retrieved from the API.

## Project Structure

- **src/app**: Contains the main application code.
  - **components**: Contains reusable components.
    - **contact-form**: Component for submitting contact forms.
    - **monthly-report**: Component for displaying the monthly report.
  - **services**: Contains services for API communication.
  - **models**: Contains data models for the application.
  - **app.module.ts**: Main module of the application.
  - **app.component.ts**: Root component of the application.

## Setup Instructions

1. Clone the repository.
2. Navigate to the project directory.
3. Install dependencies using `npm install`.
4. Update the `src/environments/environment.ts` file with the API base URL.
5. Run the application using `ng serve`.

## Usage

- Access the application in your browser at `http://localhost:4200`.
- Fill out the contact form and submit it.
- Navigate to the monthly report page to view the submissions.

## Dependencies

This project may use Angular Material, Kendo, or PrimeNg for UI components to enhance the user interface.

## License

This project is licensed under the MIT License.

## הערות נוספות
# Contact Form Angular App

אפליקציה זו נבנתה ב-Angular
 ומאפשרת שליחת פניות דרך טופס, צפייה בדוח פניות חודשי, וממשק מותאם לניידים. האפליקציה מתקשרת ל-API שנבנה 
 ב-.NET.

## תכולת הפרויקט

- **טופס פניות**: מאפשר למשתמש להזין שם, טלפון, אימייל, מחלקות (ריבוי בחירה), תיאור הפנייה ולשלוח.
- **דוח חודשי**: דף המציג דוח פניות חודשי המתקבל מ-API (Stored Procedure).
- **Responsive Design**: הממשק מותאם לכל סוגי המסכים, כולל מובייל.
- **Material Design**: השתמשתי ב-Angular Material
 לשיפור חווית המשתמש והנראות.

## אתגרים והתמודדות

- **קישור ל-API**: טיפול ב-CORS,
 ניהול שגיאות, והצגת הודעות מתאימות למשתמש.
- **עיצוב רספונסיבי**: שימוש ב-Flex Layout ו-Material
 להתאמה מלאה לכל מכשיר.
- **ניהול טפסים**: ולידציה מתקדמת, טיפול בשדות חובה, ותמיכה בריבוי מחלקות.
- **דוח חודשי**: עיבוד נתונים מה-API 
והצגה גרפית/טבלאית ברורה.

## שיקולים בבחירת גרסה

- השתמשתי ב-Angular 17 
(הגרסה האחרונה בעת בניית הפרויקט) כדי ליהנות מביצועים טובים, תמיכה ארוכה, ותכונות חדשות.
- Angular Material
 נבחר בזכות אינטגרציה קלה, תיעוד רחב, ותמיכה מובנית ב-Responsive Design.

## הוראות התקנה ופריסה

1. **התקנת תלותיות**
npm install
2. **הרצה בסביבת פיתוח**
ng serve
האפליקציה תעלה בכתובת: `http://localhost:4200`

3. **הגדרת כתובת ה-API**
- יש לעדכן את הקובץ `src/environments/environment.ts`
 בהתאם לכתובת ה-API שלך.

4. **פריסה לשרת**
ng build --prod
את תיקיית `dist/` יש להעלות לשרת סטטי 
(כגון IIS, Apache, Nginx).


