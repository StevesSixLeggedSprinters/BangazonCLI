# BangazonCLI

## The Command Line Ordering System

BangazonCLI application allows a user to interact with a basic product ordering database via a command line interface.



```bash
*********************************************************
**  Welcome to Bangazon! Command Line Ordering System  **
*********************************************************
1. Create a customer account
2. Choose active customer
3. Create a payment option
4. Add product to sell
5. Add product to shopping cart
6. Complete an order
7. Remove customer product
8. Update product information
9. Show stale products
10. Show customer revenue report
11. Show overall product popularity
12. Leave Bangazon!
>
```


### Installing Core Technologies
* SQLite
* For OSX Users `brew install sqlite`

### For Windows Users
Visit the SQLite downloads and download the 64-bit DLL (x64) for SQLite version, unzip and install it.

### SQL Browser
The DB browser for SQLite will let you view, query and manage your databases during the course.

### Visual Studio Code
Visual Studio Code is Microsoft's cross-platform editor that we'll be using during orientation for writing C# and building .NET applications. Make sure you add the C# extension immediately after installation completes.

### Windows
[Install .NET Core](https://www.microsoft.com/net/core#windows)
Click the link to download the .NET Core SDK for Windows (https://go.microsoft.com/fwlink/?LinkID=827524)
Once installed open a command line app to initialize some code.
Make a directory for your app: `mkdir HelloWorld`
Move to the newly created directory. : `cd HelloWorld`
Create a new app: `dotnet new`
Build the app and restore any get any missing libraries (packages) : `dotnet restore`
Run the app: `dotnet run`
You should see the test "Hello World".
Navigate to the folder where the app was created and https://docs.asp.net/en/latest/getting-started.html

### OSX
[Install .NET Core] (https://www.microsoft.com/net/core#macos)
Create and run an ASP.NET application using .NET Core
(https://docs.asp.net/en/latest/getting-started.html)
Review .NET Core Documentation
(https://docs.microsoft.com/en-us/dotnet/)


### Setting Up Your Environment Variable
Create an environment variable in your .zschrc or .bashrc file with the following syntax: 

```
Example:
	export BangazonCLI_db="/Users/KyleKellums/workspace/csharp/bangazon/BangazonCLI/bangazoncli.db".
```

Clone from github using git clone https://github.com/StevesSixLeggedSprinters/BangazonCLI.git 
cd into the directory you created.


### How to Run
After cloning the repo and setting your environment variable, restore dependencies and apply the migration.
```dotnet restore```
```dotnet ef database update```




## Collaboraters
* Krissy
* Kyle
* Kevin
* Jordan


Program Functionality: 


### Creating a Customer
As a user of the program, you are able to create a customer account via the CLI we created. This is the first option in the BangazonCLI. 
