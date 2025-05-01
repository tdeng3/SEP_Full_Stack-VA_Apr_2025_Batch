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

            SELECT c.City, COUNT(*) AS [Total number of customers in this city]
            FROM Customers c 
            GROUP BY c.City
            HAVING COUNT(*) >= 2
            ORDER BY 2 DESC

            SELECT c.City, COUNT(*) AS [Total number of customers in this city]
            FROM Customers c
            WHERE c.City NOT IN (
                SELECT c1.City
                FROM Customers c1
                GROUP BY c1.City
                HAVING COUNT(*) = 1
            )
            GROUP BY c.City
            ORDER BY 2 DESC

-- 6.      List all Customer Cities that have ordered at least two different kinds of products.

-- 7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

-- 8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

-- 9.      List all cities that have never ordered something but we have employees there.

-- a.      Use sub-query

-- b.      Do not use sub-query

-- 10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

-- 11. How do you remove the duplicates record of a table?
