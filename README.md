# DataEntry

This is simple piece of software that can be used for data entry. It is build using ASPNET Core framework.
The UI is built using Blazor Server App and communicates with the database using through an API. 
The API is built using ASPNET Core and uses Microsoft SQL Server. The Software comes with JWT Authentication and Authorisation.

The API endpoints are as follows:
Categories
GET request for all categories Url: https://localhost:7045/api/categories
Response:
[
  {
    "name": "Groceries",
    "description": "For food",
    "products": null,
    "id": 9,
    "userId": "48e3511b-ee15-442c-a64f-62effcac949b",
    "user": null
  }
]

POST request for adding a new category Url: https://localhost:7045/api/categories
Request:
{
  "name": "string",
  "description": "string"
}

Customers
GET request for all customers Url: https://localhost:7045/api/customers
Response:
[
  {
    "id": 0,
    "userId": "string"
    "name": "string",
    "phone": "string",
    "email": "string"
  }
]

POST
request for adding a new customer Url: https://localhost:7045/api/customers
Request:

  {
    "userId": "string"
    "name": "string",
    "phone": "string",
    "email": "string"
  }


Products
GET request for all products Url: https://localhost:7045/api/products
Request:
[
  {
    "name": "Harvest Rice",
    "description": null,
    "price": 178,
    "categoryId": 9,
    "category": null,
    "id": 4,
    "userId": "48e3511b-ee15-442c-a64f-62effcac949b",
  }
]

POST request for adding a new product Url: https://localhost:7045/api/products

  {
    "name": "Harvest Rice",
    "description": null,
    "price": 178,
    "categoryId": 9,
    "userId": "48e3511b-ee15-442c-a64f-62effcac949b",
  }

Sales
GET request for all sales Url: https://localhost:7045/api/sales
[
  {
    "invoiceNumber": 3623151,
    "totalSale": 958,
    "amountPaid": 958,
    "customerId": 6,
    "date": "2022-07-06T22:54:39.8420386",
    "id": 4,
    "userId": "48e3511b-ee15-442c-a64f-62effcac949b",
  }
]

POST request for adding a new sale Url: https://localhost:7045/api/sales

  {
	"invoiceNumber": 3623151,
	"totalSale": 958,
	"amountPaid": 958,
	"customerId": 6,
	"date": "2022-07-06T22:54:39.8420386",
	"userId": "48e3511b-ee15-442c-a64f-62effcac949b",
  }


SaleItems
GET request for all sale items Url: https://localhost:7045/api/saleitems
[
  {
    "id": 6,
    "saleId": 4,
    "productId": 6,
    "quantity": 3,
    "unitPrice": 200,
    "totalPrice": 600
  }
]

POST request for adding a new sale item Url: https://localhost:7045/api/saleitems
  {
	"saleId": 4,
	"productId": 4,
	"quantity": 1,
	"price": 178,
  }


To use the software, you will have to create an acount. It is a multi-user system. All data you enter will be acredited
to only you. This includes the products, customers, sales, categories.
Follow these simple steps to create an account:
1. Create an account if you are new or login to start a session
2. Add a new category by navigating to the Categories page
3. Add a new customer by navigating to the Customers page
4. Add a new product by navigating to the Products page
5. Add a new sale by navigating to the Sales page

    To add a sale do the following:
	1. One the sale page, you can enter the Sale master details:
        The customer buying the goods
		The amount that was paid
    2. Use the product drop down to select a product.
	3. Enter the quantity of the product.
	4. Click on the Add to Sale button.
	5. You can use the up and down arrows on the Quantity field to adjust the quantity.
	6. The system auomatically calutalates the total price of the sale.
	7. Once you are satisfied, hit the Save buttin.
	
