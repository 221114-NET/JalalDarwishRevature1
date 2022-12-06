-- List all customers (full name, customer id, and country) who are not in the USA
	SELECT FirstName, LastName, CustomerId, Country FROM dbo.Customer WHERE Country != 'USA';

-- List all customers from Brazil
	SELECT * FROM dbo.Customer WHERE Country = 'Brazil';

-- List all sales agents
	SELECT * FROM dbo.Employee WHERE Title = 'Sales Support Agent';

-- Retrieve a list of all countries in billing addresses on invoices
	SELECT DISTINCT BillingCountry FROM dbo.Invoice;

-- Retrieve how many invoices there were in 2009, and what was the sales total for that year?
    -- (challenge: find the invoice count sales total for every year using one query)
	SELECT COUNT(InvoiceDate) FROM dbo.Invoice WHERE YEAR(InvoiceDate) = 2009;
		--Come back to challenge

-- how many line items were there for invoice #37
	SELECT COUNT(Quantity) FROM dbo.InvoiceLine WHERE InvoiceId = 37;

-- how many invoices per country?
	SELECT COUNT(*) AS 'Number of Invoices', BillingCountry FROM dbo.Invoice GROUP BY BillingCountry;

-- Retrieve the total sales per country, ordered by the highest total sales first.
	SELECT SUM(Total) AS 'Total Sales', BillingCountry FROM dbo.Invoice GROUP BY BillingCountry ORDER BY SUM(Total) DESC;

    -- JOINS CHALLENGES
-- Show all invoices of customers from brazil (mailing address not billing)
	SELECT * FROM dbo.Customer INNER JOIN dbo.Invoice ON dbo.Customer.CustomerId = dbo.Invoice.CustomerId WHERE Country = 'Brazil';
    
-- Show all invoices together with the name of the sales agent for each one
    SELECT dbo.Invoice.*, dbo.Employee.FirstName FROM dbo.Invoice INNER JOIN dbo.Customer ON dbo.Invoice.CustomerId = dbo.Customer.CustomerId INNER JOIN dbo.Employee ON dbo.Customer.SupportRepId = dbo.Employee.EmployeeId ORDER BY dbo.Employee.FirstName DESC;

-- Show all playlists ordered by the total number of tracks they have
    SELECT COUNT(dbo.PlaylistTrack.PlaylistId) AS 'Number of Tracks', dbo.Playlist.Name FROM dbo.PlaylistTrack INNER JOIN dbo.Playlist ON dbo.PlaylistTrack.PlaylistId = dbo.Playlist.PlaylistId GROUP BY dbo.Playlist.Name ORDER BY 'Number of Tracks' DESC;

-- Which sales agent made the most sales in 2009?
	/*still need to display name*/SELECT MAX(counts) FROM (SELECT FirstName, LastName, COUNT(*) counts FROM (SELECT dbo.Employee.FirstName, dbo.Employee.LastName FROM dbo.Invoice INNER JOIN dbo.Customer ON dbo.Invoice.CustomerId = dbo.Customer.CustomerId INNER JOIN dbo.Employee ON dbo.Customer.SupportRepId = dbo.Employee.EmployeeId) as sales GROUP BY FirstName, LastName) AS x;

-- How many customers are assigned to each sales agent?

-- Which track was purchased the most ing 20010?

-- Show the top three best selling artists.

-- Which customers have the same initials as at least one other customer?



-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?

-- 2. which artists did not record any tracks of the Latin genre?

-- 3. which video track has the longest length? (use media type table)

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)

-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.


-- DML exercises

-- 1. insert two new records into the employee table.

-- 2. insert two new records into the tracks table.

-- 3. update customer Aaron Mitchell's name to Robert Walter

-- 4. delete one of the employees you inserted.

-- 5. delete customer Robert Walter.