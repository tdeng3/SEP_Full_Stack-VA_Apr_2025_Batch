USE Northwind
GO

-- All scenarios are based on Database NORTHWIND.

-- 1.      List all cities that have both Employees and Customers.

            SELECT DISTINCT e.City
            FROM Employees e JOIN Customers c ON e.City = c.City
             
-- 2.      List all cities that have Customers but no Employee.
            -- a.      Use sub-query

            SELECT DISTINCT c.City
            FROM Customers c 
            WHERE c.City NOT IN (
                SELECT e.City
                FROM Employees e
            )

            -- b.      Do not use sub-query

            SELECT DISTINCT c.City
            FROM Customers c LEFT JOIN Employees e ON c.City = e.City
            WHERE e.City IS NULL

-- 3.      List all products and their total order quantities throughout all orders.

            SELECT p.ProductName, SUM(od.Quantity) AS [Total order quantities]
            FROM [Order Details] od JOIN Products p ON od.ProductID = p.ProductID
            GROUP BY p.ProductName

-- 4.      List all Customer Cities and total products ordered by that city.
            -- ON c.City = o.ShipCity might miss a few cases like customer places an order and ships to other city.

            SELECT c.City, SUM(od.Quantity) AS [Total order quantities]
            FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
                             JOIN [Order Details] od ON od.OrderID = o.OrderID
            GROUP BY c.City

-- 5.      List all Customer Cities that have at least two customers.

            SELECT c.City, COUNT(c.CustomerID) AS [Total number of customers in this city]
            FROM Customers c 
            GROUP BY c.City
            HAVING COUNT(c.CustomerID) >= 2
            ORDER BY 2 DESC

            SELECT c.City, COUNT(c.CustomerID) AS [Total number of customers in this city]
            FROM Customers c
            WHERE c.City NOT IN (
                SELECT c1.City
                FROM Customers c1
                GROUP BY c1.City
                HAVING COUNT(c1.CustomerID) = 1
            )
            GROUP BY c.City
            ORDER BY 2 DESC

-- 6.      List all Customer Cities that have ordered at least two different kinds of products.

            SELECT c.City, COUNT(DISTINCT od.ProductID) AS [Total kinds of products]
            FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
                             JOIN [Order Details] od ON o.OrderID = od.OrderID
            GROUP BY c.City
            HAVING COUNT(DISTINCT od.ProductID) >= 2
            ORDER BY 2 DESC

-- 7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
            -- o.OrderID IS NOT NULL is not necessory because if the customer never place an order, his/her ID won't be here.
            
            SELECT DISTINCT c.ContactName
            FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
            WHERE o.ShipCity != c.City

-- 8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

            SELECT TOP 5 p.ProductName, SUM(od.Quantity) AS [Total Quantity Sold], AVG(od.UnitPrice * (1-od.Discount) * od.Quantity) AS [Avg Price]
            FROM [Order Details] od JOIN Products p ON od.ProductID = p.ProductID
                                    JOIN Orders o ON od.OrderID = o.OrderID
                                    JOIN Customers c ON c.CustomerID = o.CustomerID
            GROUP BY p.ProductName
            ORDER BY 2 DESC

            -- SELECT od.ProductID, c.City, SUM(od.Quantity) AS TotalQuantity, ROW_NUMBER() OVER (PARTITION BY od.ProductID ORDER BY SUM(od.Quantity) DESC) AS RNK
            -- FROM [Order Details] od JOIN Orders o ON od.OrderID = o.OrderID
            --                         JOIN Customers c ON o.CustomerID = c.CustomerID
            -- GROUP BY od.ProductID, c.City

            -- SELECT TOP 5 dt.ProductID, dt.City, dt.TotalQuantity, dt.[Avg Price], dt.RNK
            -- FROM (
            --     SELECT od.ProductID, c.City, SUM(od.Quantity) AS TotalQuantity, AVG(od.UnitPrice * (1-od.Discount) * od.Quantity) AS [Avg Price], ROW_NUMBER() OVER (PARTITION BY od.ProductID ORDER BY SUM(od.Quantity) DESC) AS RNK
            --     FROM [Order Details] od JOIN Orders o ON od.OrderID = o.OrderID
            --                             JOIN Customers c ON o.CustomerID = c.CustomerID
            --                             JOIN Products p ON od.ProductID = p.ProductID
            -- GROUP BY od.ProductID, c.City
            -- ) dt
            -- WHERE dt.RNK <= 5

            



            -- SELECT TOP 5 c.City, SUM(od.Quantity) AS [Popular products], AVG(od.UnitPrice * (1-od.Discount) * od.Quantity) AS AvgRevenue
            -- FROM [Order Details] od JOIN Products p ON od.ProductID = p.ProductID
            --                         JOIN Orders o ON od.OrderID = o.OrderID
            --                         JOIN Customers c ON c.CustomerID = o.CustomerID
            -- GROUP BY c.City
            -- ORDER BY 2 DESC
            
            -- SELECT DISTINCT TOP 5 p.ProductName, c.ContactName, c.City, AVG(od.UnitPrice * (1-od.Discount) * od.Quantity) AS AvgRevenue
            -- FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
            --                 JOIN Orders o ON od.OrderID = o.OrderID
            --                 JOIN Customers c ON c.CustomerID = o.CustomerID
            -- GROUP BY p.ProductName, c.ContactName, c.City
            -- ORDER BY 4 DESC
            

-- 9.      List all cities that have never ordered something but we have employees there.
            -- a.      Use sub-query

            SELECT DISTINCT dt.City
            FROM (
                SELECT c1.City, o.OrderID
                FROM Customers c1 LEFT JOIN Orders o ON c1.CustomerID = o.CustomerID
                                    JOIN Employees e ON e.City = c1.City
                ) dt
            WHERE dt.OrderID IS NULL

            -- b.      Do not use sub-query
            
            SELECT DISTINCT c.City
            FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
                            JOIN Employees e ON e.City = c.City
            WHERE o.OrderID IS NULL

-- 10.      List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

            -- employee sold most orders
                -- we can count the total numbers of order per city
                -- Top 1
            
            -- the city of most total quantity of products ordered
                -- we can sum the total quantity per city
                -- Top 1

            -- We inner join them on City
            SELECT soldMostEmployeesCity.City
            FROM (
                    SELECT TOP 1 e.City, COUNT(o.OrderID) AS [Totoal orders]
                    FROM Orders o JOIN Employees e ON o.EmployeeID = e.EmployeeID
                    GROUP BY e.City
                    ORDER BY COUNT(o.OrderID) DESC
            ) AS soldMostEmployeesCity
            INNER JOIN
                (
                    SELECT TOP 1 o.ShipCity AS City, SUM(od.Quantity) AS [Total number of Quantities]
                    FROM Orders o
                    JOIN [Order Details] od
                    ON o.OrderID = od.OrderID
                    GROUP BY o.ShipCity
                    ORDER BY SUM(od.Quantity) DESC
                ) AS topOrdersCustomersCity
            ON soldMostEmployeesCity.City = topOrdersCustomersCity.City
            


-- 11.      How do you remove the duplicates record of a table?

            WITH CTE AS (
                            SELECT *, ROW_NUMBER() OVER (PARTITION BY column1, column2 ORDER BY column1) AS rn
                            FROM table
                        )
            DELETE FROM table
            WHERE EXISTS (
                            SELECT 1
                            FROM CTE
                            WHERE CTE.rn > 1
                            AND CTE.primary_key_column = table.primary_key_column
                        )
