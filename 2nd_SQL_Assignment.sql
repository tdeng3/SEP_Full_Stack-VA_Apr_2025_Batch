USE AdventureWorks2019
GO

--SELECT fields, aggregation(field)
--FROM table JOIN table2 on..
--WHERE Criteria -- optional
--GROUP BY fields -- use when have both aggregated and non-aggregated fields
--HAVING criteia --Optional
--ORDER BY fields DESC --optional

--EXCUTION ORDER
--FROM-->WHERE-->GROUP BY-->HAVING-->SELECT-->DISTINCE-->ORDER BY


-- Write queries for following scenarios
    -- 1. How many products can you find in the Production.Product table?
        
        SELECT COUNT(pp.ProductID) as SumOfTotal
        FROM Production.Product pp

         --  SELECT COUNT(DISTINCT pp.ProductNumber) as SumOfTotal
         --  FROM Production.Product pp

    -- 2. Write a query that retrieves the number of products in the Production.
        -- Product table that are included in a subcategory. 
        -- The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

         --  SELECT *
         --  FROM Production.Product pp

        SELECT pp.ProductNumber, pp.ProductSubcategoryID
        FROM Production.Product pp
        WHERE pp.ProductSubcategoryID IS NOT NULL

    -- 3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.

            -- ProductSubcategoryID CountedProducts

                -------------------- ---------------

        SELECT pp.ProductSubcategoryID, COUNT(pp.ProductNumber) AS CountedProducts
        FROM Production.Product pp
        WHERE pp.ProductSubcategoryID IS NOT NULL
        GROUP BY pp.ProductSubcategoryID
        ORDER BY CountedProducts DESC

    -- 4. How many products that do not have a product subcategory.

        SELECT COUNT(pp.ProductSubcategoryID) AS ProductWithoutSubcategory
        FROM Production.Product pp
        WHERE pp.ProductSubcategoryID IS NOT NULL
        
    -- 5. Write a query to list the sum of products quantity in the Production.ProductInventory table.

        SELECT COUNT(ppi.Quantity) as SumOfTotal
        FROM Production.ProductInventory ppi

    -- 6. Write a query to list the sum of products in the Production.ProductInventory table 
        -- and LocationID set to 40 
        -- and limit the result to include just summarized quantities less than 100.

        --  ProductID    TheSum

            -----------        ----------

         --  SELECT *
         --  FROM Production.ProductInventory ppi

        SELECT ppi.ProductID, SUM(ppi.Quantity) AS TheSum
        FROM Production.ProductInventory ppi
        WHERE ppi.LocationID = 40
        GROUP BY ppi.ProductID
        HAVING SUM(ppi.Quantity) < 100

    -- 7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table 
        -- and LocationID set to 40 
        -- and limit the result to include just summarized quantities less than 100

        -- Shelf      ProductID    TheSum

        ----------   -----------        -----------

         --  SELECT *
         --  FROM Production.ProductInventory ppi

        SELECT ppi.Shelf, ppi.ProductID, SUM(ppi.Quantity) AS TheSum
        FROM Production.ProductInventory ppi
        WHERE ppi.LocationID = 40
        GROUP BY ppi.Shelf, ppi.ProductID
        HAVING SUM(ppi.Quantity) < 100

    -- 8. Write the query to list the average quantity for products 
        -- where column LocationID has the value of 10 from the table Production.ProductInventory table.

         --  SELECT *
         --  FROM Production.ProductInventory ppi

        SELECT ppi.ProductID, AVG(ppi.Quantity) AS TheAVG
        FROM Production.ProductInventory ppi
        WHERE ppi.LocationID = 10
        GROUP BY ppi.ProductID

    -- 9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

        -- ProductID   Shelf      TheAvg

    ----------- ---------- -----------

        SELECT ppi.ProductID, ppi.Shelf, AVG(ppi.Quantity) as TheAvg
        FROM Production.ProductInventory ppi
        GROUP BY ppi.ProductID, ppi.Shelf
        

    -- 10. Write query  to see the average quantity  of  products by shelf 
        -- excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

        -- ProductID   Shelf      TheAvg

    ----------- ---------- -----------

        SELECT ppi.ProductID, ppi.Shelf, AVG(ppi.Quantity) AS TheAvg
        FROM Production.ProductInventory ppi
        WHERE ppi.Shelf != 'N/A'
        GROUP BY ppi.ProductID, ppi.Shelf

    -- 11. List the members (rows) and average list price in the Production.Product table. 
        -- This should be grouped independently over the Color and the Class column. 
        -- Exclude the rows where Color or Class are null.

        -- Color                        Class              TheCount          AvgPrice

        -------------- - -----    -----------            ---------------------

    -- Joins:

        SELECT pp.Color, pp.Class, COUNT(*) AS TheCount, AVG(pp.ListPrice) AS AvgPrice
        FROM Production.Product pp
        WHERE pp.Color IS NOT NULL AND pp.Class IS NOT NULL
        GROUP BY pp.Color, pp.Class

    -- 12. Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables. 
            -- Join them and produce a result set similar to the following.

        -- Country                        Province

     ---------                          ----------------------

        SELECT pcr.Name AS Country, psp.Name AS Province 
        FROM Person.CountryRegion pcr JOIN Person.StateProvince psp ON pcr.CountryRegionCode = psp.CountryRegionCode 

    -- 13. Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables 
        --  and list the countries filter them by Germany and Canada. 
        --  Join them and produce a result set similar to the following.
        
        -- Country                        Province

        ---------                          ----------------------

        SELECT pcr.Name AS Country, psp.Name AS Province 
        FROM Person.CountryRegion AS pcr JOIN Person.StateProvince AS psp ON pcr.CountryRegionCode = psp.CountryRegionCode 
        WHERE pcr.Name IN ('Germany','Canada')

--  Using Northwnd Database: (Use aliases for all the Joins)

USE Northwind
GO

    -- 14. List all Products that has been sold at least once in last 27 years.

         --  SELECT *
         --  FROM Orders o

         --  SELECT *
         --  FROM [Order Details] od

        SELECT DISTINCT p.ProductName, od.UnitPrice, o.OrderDate
        FROM Products p JOIN [Order Details] od ON P.ProductID = od.ProductID 
                        JOIN Orders o ON od.OrderID = o.OrderID
        WHERE o.OrderDate >= DATEADD(YEAR, -27, GETDATE())

    -- 15. List top 5 locations (Zip Code) where the products sold most.

         --  SELECT * 
         --  FROM Products p JOIN [Order Details] od ON P.ProductID = od.ProductID 
                        J --  OIN Orders o ON od.OrderID = o.OrderID

        SELECT Top 5 o.ShipPostalCode, SUM(od.Quantity) AS [Total Sold]
        FROM Products p JOIN [Order Details] od ON P.ProductID = od.ProductID 
                        JOIN Orders o ON od.OrderID = o.OrderID
        WHERE o.ShipPostalCode IS NOT NULL
        GROUP BY o.ShipPostalCode
        ORDER BY [Total Sold] DESC

    -- 16. List top 5 locations (Zip Code) where the products sold most in last 27 years.

        SELECT Top 5 o.ShipPostalCode, SUM(od.Quantity) AS [Total Sold]
        FROM Products p JOIN [Order Details] od ON P.ProductID = od.ProductID 
                        JOIN Orders o ON od.OrderID = o.OrderID
        WHERE o.ShipPostalCode IS NOT NULL AND o.OrderDate >= DATEADD(YEAR, -27, GETDATE())
        GROUP BY o.ShipPostalCode
        ORDER BY 2 DESC

    -- 17. List all city names and number of customers in that city.     

        SELECT c.City, COUNT(c.CustomerID) AS [Total Customers]
        FROM Customers c
        GROUP BY c.City
        ORDER BY 2 DESC

    -- 18. List city names which have more than 2 customers, and number of customers in that city

        SELECT c.City, COUNT(c.CustomerID) AS [Total Customers]
        FROM Customers c
        GROUP BY c.City
        HAVING COUNT(c.CustomerID) > 2
        ORDER BY 2 DESC

    -- 19. List the names of customers who placed orders after 1/1/98 with order date.

         --  SELECT o.OrderDate
         --  FROM Orders o

        SELECT c.ContactName, o.OrderDate
        FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
        WHERE o.OrderDate > '1998-01-01 00:00:00.000'

    -- 20. List the names of all customers with most recent order dates

        SELECT c.ContactName, o.OrderDate
        FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
        WHERE o.OrderDate = (
            SELECT MAX(o.OrderDate)
            FROM Orders o
            WHERE o.CustomerID = c.CustomerID
        )
        ORDER BY c.ContactName

    -- 21. Display the names of all customers  along with the  count of products they bought

         --  SELECT c.ContactName
         --  FROM Customers c

        SELECT c.ContactName, COUNT(p.ProductName) AS [Products they bought]
        FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID 
                        JOIN Orders o ON od.OrderID = o.OrderID 
                        JOIN Customers c ON c.CustomerID = o.CustomerID
        GROUP BY c.ContactName
        ORDER BY 2 DESC
        
    -- 22. Display the customer ids who bought more than 100 Products with count of products.

        --FROM-->WHERE-->GROUP BY-->HAVING-->SELECT-->DISTINCE-->ORDER BY

        SELECT o.CustomerID, COUNT(p.ProductName) AS [Products they bought]
        FROM Products p JOIN [Order Details] od ON P.ProductID = od.ProductID 
                        JOIN Orders o ON od.OrderID = o.OrderID 
        GROUP BY o.CustomerID
        HAVING COUNT(p.ProductName) > 100
        ORDER BY 2 DESC

    -- 23. List all of the possible ways that suppliers can ship their products. Display the results as below

        -- Supplier Company Name                Shipping Company Name

        ---------------------------------            ----------------------------------

        SELECT DISTINCT s1.CompanyName AS [Supplier Company Name], s2.CompanyName AS [Shipping Company Name]
        FROM Shippers s2 JOIN Orders o ON o.ShipVia = s2.ShipperID 
                         JOIN [Order Details] od ON o.OrderID = od.OrderID
                         JOIN Products p ON p.ProductID = od.ProductID 
                         JOIN Suppliers s1 ON s1.SupplierID = p.SupplierID
        ORDER BY [Supplier Company Name]
        

    -- 24. Display the products order each day. Show Order date and Product Name.

         --  SELECT *
         --  FROM Products

         --  SELECT *
         --  FROM Orders

        SELECT o.OrderDate, p.ProductName
        FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID
                      JOIN Products p ON od.ProductID = p.ProductID
        ORDER BY o.OrderDate


    -- 25. Displays pairs of employees who have the same job title.

        SELECT e1.Title, e1.FirstName + ' ' + e1.LastName AS Employee1, e2.FirstName + ' ' + e2.LastName AS Employee2
        FROM Employees e1 JOIN Employees e2 ON e1.Title = e2.Title
        WHERE e1.EmployeeID != e2.EmployeeID
        ORDER BY e1.Title

    -- 26. Display all the Managers who have more than 2 employees reporting to them.

         --  SELECT *
         --  FROM Employees

         --  WITH EmpHierarchyCTE
         --  AS(
             --  SELECT e.EmployeeID, e.FirstName, e.ReportsTo, 1 lvl
             --  FROM Employees e
             --  WHERE ReportsTo IS NULL
             --  UNION ALL
             --  SELECT e1.EmployeeID, e1.FirstName,e1.ReportsTo, cte.lvl + 1
             --  FROM Employees e1 JOIN EmpHierarchyCTE cte ON e1.ReportsTo = cte.EmployeeID
         --  )
         --  Select * FROM EmpHierarchyCTE

        SELECT manager.FirstName + ' ' + manager.LastName AS Manager, COUNT(e.ReportsTo) AS [Num of employee reporting to this person]
        FROM Employees manager JOIN Employees e ON manager.EmployeeID = e.ReportsTo
        GROUP BY manager.FirstName, manager.LastName

    -- 27. Display the customers and suppliers by city. The results should have the following columns

        -- City

        -- Name

        -- Contact Name,

        -- Type (Customer or Supplier)

        --  SELECT *
        --  FROM Customers

        SELECT c.City, c.CompanyName AS Name, c.ContactName,'Customer' AS Type
        FROM Customers c
        UNION
        SELECT s.City, s.CompanyName AS Name, s.ContactName, 'Supplier' AS Type
        FROM Suppliers s
