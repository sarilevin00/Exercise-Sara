CREATE PROCEDURE GetMonthlyInquiryReport
    @Year INT,
    @Month INT
AS
BEGIN
    SET NOCOUNT ON;

    -- חשב תאריכים רלוונטיים
    DECLARE @CurrentMonthStart DATE = DATEFROMPARTS(@Year, @Month, 1);
    DECLARE @NextMonthStart DATE = DATEADD(MONTH, 1, @CurrentMonthStart);

    DECLARE @PrevMonthStart DATE = DATEADD(MONTH, -1, @CurrentMonthStart);
    DECLARE @PrevMonthEnd DATE = @CurrentMonthStart;

    DECLARE @LastYearMonthStart DATE = DATEADD(YEAR, -1, @CurrentMonthStart);
    DECLARE @LastYearNextMonthStart DATE = DATEADD(MONTH, 1, @LastYearMonthStart);

    -- טבלת סיכום חודשי נוכחי
    CREATE TABLE #CurrentMonth (
        DepartmentId INT PRIMARY KEY,
        CurrentCount INT
    );

    INSERT INTO #CurrentMonth (DepartmentId, CurrentCount)
    SELECT DepartmentId, COUNT(*)
    FROM Inquiries
    WHERE InquiryDate >= @CurrentMonthStart AND InquiryDate < @NextMonthStart
    GROUP BY DepartmentId;

    -- טבלת סיכום חודש קודם
    CREATE TABLE #PrevMonth (
        DepartmentId INT PRIMARY KEY,
        PrevCount INT
    );

    INSERT INTO #PrevMonth (DepartmentId, PrevCount)
    SELECT DepartmentId, COUNT(*)
    FROM Inquiries
    WHERE InquiryDate >= @PrevMonthStart AND InquiryDate < @PrevMonthEnd
    GROUP BY DepartmentId;

    -- טבלת סיכום אותו חודש בשנה שעברה
    CREATE TABLE #LastYear (
        DepartmentId INT PRIMARY KEY,
        LastYearCount INT
    );

    INSERT INTO #LastYear (DepartmentId, LastYearCount)
    SELECT DepartmentId, COUNT(*)
    FROM Inquiries
    WHERE InquiryDate >= @LastYearMonthStart AND InquiryDate < @LastYearNextMonthStart
    GROUP BY DepartmentId;

    -- שליפת הדוח עם חיבורים בין הטבלאות
    SELECT 
        d.DepartmentId,
        d.DepartmentName,
        ISNULL(c.CurrentCount, 0) AS CurrentMonthInquiries,
        ISNULL(p.PrevCount, 0) AS PreviousMonthInquiries,
        ISNULL(l.LastYearCount, 0) AS LastYearSameMonthInquiries,
        CASE 
            WHEN ISNULL(p.PrevCount, 0) = 0 THEN NULL
            ELSE CAST(((CAST(ISNULL(c.CurrentCount, 0) - p.PrevCount AS FLOAT)) / p.PrevCount) * 100 AS DECIMAL(5,2))
        END AS ChangeVsPreviousMonthPercent,
        CASE
            WHEN ISNULL(l.LastYearCount, 0) = 0 THEN NULL
            ELSE CAST(((CAST(ISNULL(c.CurrentCount, 0) - l.LastYearCount AS FLOAT)) / l.LastYearCount) * 100 AS DECIMAL(5,2))
        END AS ChangeVsLastYearPercent
    FROM Departments d
    LEFT JOIN #CurrentMonth c ON d.DepartmentId = c.DepartmentId
    LEFT JOIN #PrevMonth p ON d.DepartmentId = p.DepartmentId
    LEFT JOIN #LastYear l ON d.DepartmentId = l.DepartmentId
    ORDER BY d.DepartmentName;

    -- ניקוי טבלאות זמניות
    DROP TABLE #CurrentMonth;
    DROP TABLE #PrevMonth;
    DROP TABLE #LastYear;
END;
