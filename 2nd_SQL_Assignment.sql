USE AdventureWorks2019
GO

-- AGGREGATION FIELD 
    -- COUNT *
--SELECT fields, aggregation(field)
--FROM table JOIN table2 on..
--WHERE Criteria -- optional
--GROUP BY fields -- use when have both aggregated and non-aggregated fields
--HAVING criteia --Optional
--ORDER BY fields DESC --optional

--EXCUTE ORDER
--FROM-->WHERE-->GROUP BY-->HAVING-->SELECT-->DISTINCE-->ORDER BY


-- Write queries for following scenarios
    -- 1. How many products can you find in the Production.Product table?
        
        SELECT COUNT(pp.ProductID) as SumOfTotal
        FROM Production.Product pp

        SELECT COUNT(DISTINCT pp.ProductNumber) as SumOfTotal
        FROM Production.Product pp

    -- 2. Write a query that retrieves the number of products in the Production.
        -- Product table that are included in a subcategory. 
        -- The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

        SELECT *
        FROM Production.Product pp

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

        SELECT *
        FROM Production.ProductInventory ppi

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

        SELECT *
        FROM Production.ProductInventory ppi

        SELECT ppi.Shelf, ppi.ProductID, SUM(ppi.Quantity) AS TheSum
        FROM Production.ProductInventory ppi
        WHERE ppi.LocationID = 40
        GROUP BY ppi.Shelf, ppi.ProductID
        HAVING SUM(ppi.Quantity) < 100

    -- 8. Write the query to list the average quantity for products 
        -- where column LocationID has the value of 10 from the table Production.ProductInventory table.

        SELECT *
        FROM Production.ProductInventory ppi

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
        FROM Person.CountryRegion pcr JOIN Person.StateProvince psp ON pcr.CountryRegionCode = psp.CountryRegionCode 
        WHERE pcr.Name IN ('Germany','Canada')

        -- Using Northwnd Database: (Use aliases for all the Joins)

    -- 14. List all Products that has been sold at least once in last 27 years.

    -- 15. List top 5 locations (Zip Code) where the products sold most.

    -- 16. List top 5 locations (Zip Code) where the products sold most in last 27 years.

    -- 17. List all city names and number of customers in that city.     

    -- 18. List city names which have more than 2 customers, and number of customers in that city

    -- 19. List the names of customers who placed orders after 1/1/98 with order date.

    -- 20. List the names of all customers with most recent order dates

    -- 21. Display the names of all customers  along with the  count of products they bought

    -- 22. Display the customer ids who bought more than 100 Products with count of products.

    -- 23. List all of the possible ways that suppliers can ship their products. Display the results as below

        -- Supplier Company Name                Shipping Company Name

        ---------------------------------            ----------------------------------

    -- 24. Display the products order each day. Show Order date and Product Name.

    -- 25. Displays pairs of employees who have the same job title.

    -- 26. Display all the Managers who have more than 2 employees reporting to them.

    -- 27. Display the customers and suppliers by city. The results should have the following columns

        -- City

        -- Name

        -- Contact Name,

        -- Type (Customer or Supplier)
