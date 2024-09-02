#Beetle Café Order System
Overview
The Beetle Café Order System is a Windows Forms application designed for managing orders in a café. The application allows users to view and select items from a menu, add them to a cart, and place an order. It connects to a SQL Server database to retrieve menu items and handle user interactions.

Features
View Menu Items: Displays a menu of pastries, sandwiches, and hot drinks from a SQL Server database.
Search Menu: Allows users to search for items by name.
Add to Cart: Users can add selected items to a shopping cart.
Remove from Cart: Users can remove items from the cart.
Place Order: Users can review their order, confirm it, and receive a summary.
Setup
Database Configuration:

Ensure that you have a SQL Server instance running.
The application uses a local database located at C:\Users\nkulu\source\repos\BeelteCaf _assignment1_40966402_43706355\BeelteCaf _assignment1_40966402_43706355\Database1.mdf. Update the connection string in the OrderForm class if the database location or name changes.
Dependencies:

.NET Framework
System.Data.SqlClient
System.Globalization
How to Use
Run the Application:

Open the project in Visual Studio.
Build and run the project.
Viewing and Searching Menu Items:

The application loads the menu items into a DataGridView when the form loads.
Use the search box to filter menu items by name.
Adding Items to Cart:

Click on items in the DataGridView to add them to the cart.
The selected item will appear in the cart list box with its price.
Removing Items from Cart:

Select an item in the cart list box and click the "Remove" button to remove it.
Placing an Order:

Enter your name in the customer name field.
Review the items in the cart.
Click the "Place Order" button.
Confirm the order in the confirmation dialog.
A summary of the order will be displayed.
Error Handling
The application uses an ErrorProvider to validate user input, such as ensuring a customer name is provided before placing an order.
Exceptions related to SQL operations are caught and displayed using MessageBox.
Code Overview
Key Components
OrderForm Class:

Manages the main form and user interactions.
Establishes database connections and queries.
Updates the cart and order summary.
UpdateSum() Method:

Calculates and displays the total cost of items in the cart.
OrderForm_Load Method:

Loads menu data into the DataGridView from the database.
txtSearchMenu_TextChanged Method:

Searches for menu items based on user input.
dataGridView1_CellContentClick Method:

Handles the event when a user clicks on a menu item in the DataGridView.
btnRemoveFromCart_Click Method:

Removes selected items from the cart.
btnPlaceOrder_Click Method:

Validates input and handles the order placement process.
Troubleshooting
Database Connection Issues:

Ensure the database file path is correct and accessible.
Verify SQL Server is running and configured properly.
Invalid Input Handling:

Make sure that the input fields are correctly validated.
License
This project is licensed under the MIT License - see the LICENSE file for details.

Contact
For issues or contributions, please contact nkululekongwenya123@gmail.com
