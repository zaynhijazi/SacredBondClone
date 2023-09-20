# SacredBond Setup

## First Step Nuget Packages Setup:
After cloning this repository, make sure to go to download **Visual Studio (VS)** and not **Visual Studio Code (VSC)**. After downloading, VS, open SacredBond.App.sln. For the next steps, the aim is to install the required NuGet packages for each project in the solution. You should run the `dotnet restore` command in the respective directories of the projects to download the necessary packages defined in their `.csproj` files.

1. **SacredBond.App**:
   - Navigate to the "SacredBond.App" directory in your terminal.
   - Run the following command to restore NuGet packages:
     ```
     cd SacredBond.App
     dotnet restore
     ```

2. **SacredBond.Common**:
   - Navigate to the "SacredBond.Common" directory in your terminal.
   - Run the following command to restore NuGet packages:
     ```
     cd SacredBond.Common
     dotnet restore
     ```

3. **SacredBond.Core**:
   - Navigate to the "SacredBond.Core" directory in your terminal.
   - Run the following command to restore NuGet packages:
     ```
     cd SacredBond.Core
     dotnet restore
     ```

4. **SacredBondFaker**:
   - Navigate to the "SacredBondFaker" directory in your terminal.
   - Run the following command to restore NuGet packages:
     ```
     cd SacredBondFaker
     dotnet restore
     ```
## Setting Up SQL Server and SQL Server Management Studio (SSMS) on Windows (Skip this step if you a Mac and etc)

This guide provides step-by-step instructions for setting up SQL Server, SQL Server Management Studio (SSMS), and connecting to a local database on a Windows PC.

### Installing SQL Server

1. **Download SQL Server**:
   - Download SQL Server from the official Microsoft website.

2. **Run the Installer**:
   - Run the SQL Server installer.
   - Follow the installer's instructions to configure the installation. Install the Database Engine Services and other features as needed.

3. **Configure Installation**:
   - During installation, you will be prompted to select an instance name, authentication method, and set the SA (System Administrator) password. Make note of these settings for later use.

4. **Launch SQL Server Installation Center**:
   - After installation, launch the SQL Server Installation Center from the Windows Start menu.

5. **SQL Server Configuration Manager**:
   - In the SQL Server Installation Center, click on "SQL Server Configuration Manager."
   - Ensure that the SQL Server instance you installed is running. If not, right-click on it and select "Start."

### Installing SQL Server Management Studio (SSMS)

1. **Download SSMS**:
   - Download SQL Server Management Studio (SSMS) from the official Microsoft website.

2. **Run the SSMS Installer**:
   - Run the SSMS installer.
   - Follow the installer's instructions to complete the installation.

### Connecting to a Local Database Using SSMS

1. **Launch SQL Server Management Studio (SSMS)**:
   - Open SQL Server Management Studio from the Windows Start menu.

2. **Connect to SQL Server Instance**:
   - In the "Connect to Server" window, provide the following information:
     - **Server type**: Leave this as the default, "Database Engine."
     - **Server name**: Enter the name or address of your SQL Server instance (e.g., `(local)` or `localhost` for a local instance).
     - **Authentication**: Choose the appropriate authentication type (Windows Authentication or SQL Server Authentication).
     - **Login**: Enter your Windows username or SQL Server login name.
     - **Password**: Enter the SA (System Administrator) password you set during SQL Server installation.

3. **Connect to the Database Engine**:
   - Click the "Connect" button. If the connection is successful, you will be connected to the SQL Server Database Engine.
After finishing this step go to the "Fourth Step".
## Setting Up SQL Server and SQL Server Management Studio (SSMS) on Mac (Skip this step if you have a Windows PC and go to the "Fourth Step"):
This tutorial applies to all regardless of the processor they have: Intel/M1 and above. This text assumes that you have .NET Core installed because dotnet cli comes packaged with it. SSMS is a Windows Applicaiton is not present on Mac. Microsoft has a docker image that can be used on Mac. Moreover, before reading the rest of the text, make sure to download **Docker** and **Azure Data Studio**. 

### Docker (SQL Server Setup)

Since SQL Server Management Studio is a Windows application and not available on Mac, Microsoft has created a Docker image with MSSQL Server integrated into it. Follow these steps to set up Docker:

#### First-time setup for SQL Server using Docker

1. **Open Docker**:
   - Launch Docker.

2. **Allocate Memory**:
   - Navigate to **Settings** -> **Resources** and allocate a minimum of 4GB of memory.

3. **Open a Terminal**:
   - Open a terminal.

4. **Navigate to Your Solution Directory**:
   - Use the `cd` command to navigate to the directory containing your solution.

5. **Run the following commands**:
   - Pull the SQL Server Docker image (for both Intel-based and M1-based Macs):
     ```bash
     $ docker pull mcr.microsoft.com/mssql/server:2019-latest
     ```

   - For **Intel-based Macs**:
     ```bash
     $ docker run -d --name [NameOfContainer] -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=[YourPassword]' -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
     ```

   - For **M1-based Macs**:
     ```bash
     $ docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=[YourPassword]" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
     ```

### Using Docker Again
1. To turn our SQL Server, we need to turn on the Docker Container that we previously created. You can do that either through Docker's UI by pressing on the play button or you can do it in the terminal like this:
   1.  <pre><code>$ docker start [NameOfContainer]</code></pre>

### Azure Data Studio (Connecting to our SQL Server):
While Docker is running, Azure Data Studio needs to be running simultaneously as it will serve as the GUI of our database. 
1. Make sure to download Azure Data Studio based of the specs that you have.
2. Go to New -> New Connection
3. Set the Input Type to Parameters
4. Set the Authentication Type to SQL Login
5. The username is sa (this should be for everyone who is following the tutorial, only the password will be different).
6. For the password, put the password the used when you created your Docker SQL Server Container.
7. Leave the other options in their default status, and then connect.


## Fourth Step, updating our connection strings to connect to our database:
To configure connection strings in your projects, follow based on your operating system:

- **SacredBond.App** (for Mac Users):
   - Open the `**appsettings.Development.json**` file in the **"SacredBond.App"** project.
   - Update the connection string to match this format for Mac users:
     ```
     "Server=localhost;Database=[Name_Of_Choice];User=sa;Password=[Docker_Setup_Password];MultipleActiveResultSets=true;Encrypt=false"
     ```

- **SacredBondFaker** (for Mac Users):
   - Open the `**appsettings.json`** file in the **"SacredBondFaker**" project.
   - Update the connection string to match this format for Mac users:
     ```
     "Server=localhost;Database=[Name_Of_Choice];User=sa;Password=[Docker_Setup_Password];MultipleActiveResultSets=true;Encrypt=false"
     ```

- **SacredBond.App** (for Windows Users):
   - Open the **`appsettings.Development.json`** file in the **"SacredBond.App"** project.
   - Use the connection string provided during the installation of SQL Server Management Studio (SSMS) on your Windows system.

- **SacredBondFaker** (for Windows Users):
   - Open the `**appsettings.json`** file in the **"SacredBondFaker"** project.
   - Use the connection string provided during the installation of SQL Server Management Studio (SSMS) on your Windows system.
 
## Last and Final Step. Updating the Database (for both Windows and Mac Users)

To update the database schema, follow these steps in your terminal:

1. **Open the Terminal**:
   - Open a terminal window on your computer.

2. **Navigate to the Repository Directory**:
   - Use the `cd` command to navigate to the directory where you cloned the GitHub repository. For example:
     ```bash
     cd path/to/SacredBondClone
     ```

3. **Navigate to SacredBond.Core Directory**:
   - Within the "SacredBondClone" directory, navigate to the "SacredBond.Core" directory using the `cd` command. For example:
     ```bash
     cd SacredBond.Core
     ```

4. **Run the Database Update Command**:
   - Run the following command to update the database schema (ensure you have the necessary Entity Framework Core tools installed):
     ```bash
     dotnet ef database update --startup-project ../SacredBond.App/
     ```

   This command will apply any pending migrations and update the database to match your project's schema.

Make sure to perform these steps after making any changes to your Entity Framework Core migrations or database schema.

## Running SacredBondFaker

To run the SacredBondFaker project, follow these steps in your terminal:

1. **Open Your Terminal**:
   - Open a terminal window on your computer.

2. **Navigate to the Repository Directory**:
   - Use the `cd` (Change Directory) command to navigate to the directory where you cloned the GitHub repository. For example:
     ```bash
     cd path/to/your/cloned/repo
     ```

3. **Navigate to the SacredBondFaker Directory**:
   - Within the repository directory, navigate to the "SacredBondFaker" directory using the `cd` command:
     ```bash
     cd SacredBondFaker
     ```

4. **Build the Project**:
   - To build the project and generate the necessary executable files, use the `dotnet build` command:
     ```bash
     dotnet build
     ```

5. **Run the Project**:
   - Execute the project by running the following command:
     ```bash
     dotnet run
     ```

   This will run the SacredBondFaker project, and any output or results will be displayed in the terminal.

Make sure you have the .NET SDK installed on your computer to use these commands.

## Testing Profile Picture Setup

To test the profile picture setup feature, follow these steps:

1. **Open the Solution**:
   - Double-click the "SacredBond.App.sln" file located in the repository directory (the directory of your cloned repo). This will open the solution in your preferred development environment.

2. **Run the Application**:
   - Once the solution is open, run the application by clicking on the play button or using your development environment's build and run commands.

3. **Handling "This page is not working"**:
   - If you encounter a "This page is not working" error on your screen, change the URL in the address bar to:
     ```
     https://localhost:7015/Identity/Account/Logout
     ```

4. **Log In with Fake Accounts**:
   - Log in using one of the fake accounts created by "SacredBondFaker." You will both of these fake accounts in your local database. For example:
     - Username: Colleen27@yahoo.com
     - Password: Welcome8890!
     - Alternatively, you can use the following fake account:
       - Username: Danny28@gmail.com

5. **Complete Profile**:
   - After logging in, navigate to the "Profile" section.
   - Click on the "Complete Profile" button.

6. **Profile Picture Setup**:
   - Within the profile setup, locate the "Profile Picture Setup" section.
   - Upload at least 3 pictures.

7. **Verify Picture Upload**:
   - To ensure the pictures were uploaded successfully, revisit the "Profile Picture Setup" section.

This process allows you to test the profile picture setup functionality within the SacredBond application.





