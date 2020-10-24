# WZ-IV-API
WZ - Interview Exercise

Technologies: ASP.NET Core 2.x or higher, Entity Framework Code First, AutoMapper, SQL Server and AngularJS/Angular 2+.
Separate the solution in layers: Web (UI), Model (Entities, DTOs), Data (repositories), and Services.
Include scripts to create the tables and indexes of the database. Don’t use Entity Framework Migrations.
Use bundles.

Functional Requirements:
•	Products management: 
  o	Products list page: 
    	List of products with filters by category, sub category and description.
    	Grid with sorting and the following columns: Code, Description, Category, Sub Category, Price, Status (active or inactive). Make the status editable inside the grid by using a checkbox.
  o	Product Editor page:
    	Edit all the properties of a product.
•	Order page:
  o	Show a button for each product and when clicked, add it to a grid.
  o	Let the user remove products from the grid.
  o	If the same product is added more than once, group it (show the product and its quantity instead of showing the product more than once).
  o	Button to complete the order
•	Orders history page:
  o	Filters: date range and price range.
  o	Grid with sorting
•	Product: code, description, category, sub category, price, status (active/inactive)
•	All the data has to be saved in the database
