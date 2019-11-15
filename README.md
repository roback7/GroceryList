# GroceryList

API to retrieve and update customer grocery lists.

Customers have a unique Customer ID and a name.
The List pairs the Customer ID with an item.

# To Run

To run GroceryList:

IIS Express must be installed. Can be downloaded from "https://www.microsoft.com/en-us/download/details.aspx?id=48264"

Next, open cmd, and navigate to the directory containing IIS Express. (Ex "C:\Program Files (x86)\IIS Express")

Run command: > iisexpress /path:PATH_TO_PUBLISH /port:9090

Where PATH_TO_PUBLISH is the path to the publish folder in GroceryList (Ex "C:\Users\ksrob\Desktop\PUBLISH\")

Next to access API, open an internet browser and navigate to "http://localhost:9090/"

This will open the swagger documentation for the API.
