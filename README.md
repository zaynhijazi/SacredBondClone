# SacredBond Setup

## First Step Nuget Packages Setup
After cloning this repository, make sure to go to the SacredBond.App.sln. For the next steps, the aim is to install the required NuGet packages for each project in the solution. You should run the `dotnet restore` command in the respective directories of the projects to download the necessary packages defined in their `.csproj` files.

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

### Configuring Connection Strings in Projects

To configure connection strings in your projects:

- **SacredBond.App**:
   - Open the `appsettings.Development.json` file in the "SacredBond.App" project.
   - Update the connection string to match the one you used to connect to your local SQL Server instance. Replace `[YourConnectionString]` with the actual connection string.

- **SacredBondFaker**:
   - Open the `appsettings.json` file in the "SacredBondFaker" project.
   - Update the connection string to match the one you used to connect to your local SQL Server instance. Replace `[YourConnectionString]` with the actual connection string.

## Third Step SQL Server Set up for Mac Users
This tutorial applies to all regardless of the processor they have: Intel/M1 and above. This text assumes that you have .NETCore installed because dotnet cli comes packaged with it. Moreover, before reading the rest of the text, make sure to download Docker and Azure Data Studio. 

### Docker (SQL Server Setup)
SQL Server Management Studio is a windows application and it cannot be downloaded on Mac. To deal with that, MSFT, has created a docker image, that has MSSQL Server integrated into it. To set up Docker, lets follow these steps:
#### First time setting up SQL Server using Docker
1. Open up Docker
   1. Make to go Settings -> Resources
   2. Make sure to change the memory to atleast 4GB.
2. Open a terminal
3. Now cd into the directory that contians your solution.
4. <pre><code>
    $ docker pull mcr.microsoft.com/mssql/server:2019-latest
    $ docker run -d --name [NameOfContainer] -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=[YourPassword]' -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
    $ mssql -u sa -p [YourPassword]</code></pre>
5. Once you are done with Docker, then make sure to terminate the container through Docker's UI or through the command line like this:
   1. <pre><code>$ docker kill [NameOfContainer]</code></pre>
### Using Docker Again
1. To turn our SQL Server, we need to turn on the Docker Container that we previously created. You can do that either through Docker's UI by pressing on the play button or you can do it in the terminal like this:
   1.  <pre><code>$ docker start [NameOfContainer]</code></pre>

### Azure Data Studio (Connecting to our SQL Server)
1. Make sure to download Azure Data Studio based of the specs that you have.
2. Go to New -> New Connection
3. Set the Input Type to Parameters
4. Set the Authentication Type to SQL Login
5. The username is sa (this should be for everyone who is following the tutorial, only the password will be different).
6. For the password, put the password the used when you created your Docker SQL Server Container.
7. Leave the other options in their default status, and then connect.


## Fourth Step EFCore (Connecting to our SQL Server)
1. Since we are using a localhost db, make sure to update the connection string that is in your appSettings.Development.json file and set it to this:
   1. <pre><code>"Server=localhost;Database=[NameOfDatabase];User=sa;Password=[YourPasswordFromDocker];MultipleActiveResultSets=true;Encrypt=false"</code></pre>
2. Now to add a Migration, we need to make sure we enter the Target Project (the project that contains your DBContext class, which is SacredBond.Core):
   <pre><code> $ cd ./project_with_migrations_folder
    $ dotnet ef --startup-project ../my_startup_project_path/ migrations add myMigration01</code></pre>
