# SacredBond.App

## EFCore and SQL Server Set up for Mac Users
This tutorial applies to all regardless of the processor they have: Intel/M1 and above. This text assumes that you have .NETCore installed because dotnet cli comes packaged with it. Moreover, before reading the rest of the text, make sure to download Docker and Azure Data Studio. 

## Docker (SQL Server Setup)
SQL Server Management Studio is a windows application and it cannot be downloaded on Mac. To deal with that, MSFT, has created a docker image, that has MSSQL Server integrated into it. To set up Docker, lets follow these steps:
### First time setting up SQL Server using Docker
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

## Azure Data Studio (Connecting to our SQL Server)
1. Make sure to download Azure Data Studio based of the specs that you have.
2. Go to New -> New Connection
3. Set the Input Type to Parameters
4. Set the Authentication Type to SQL Login
5. The username is sa (this should be for everyone who is following the tutorial, only the password will be different).
6. For the password, put the password the used when you created your Docker SQL Server Container.
7. Leave the other options in their default status, and then connect.


## EFCore (Connecting to our SQL Server)
1. Since we are using a localhost db, make sure to update the connection string that is in your appSettings.Development.json file and set it to this:
   1. <pre><code>"Server=localhost;Database=[NameOfDatabase];User=sa;Password=[YourPasswordFromDocker];MultipleActiveResultSets=true;Encrypt=false"</code></pre>
2. Now to add a Migration, we need to make sure we enter the Target Project (the project that contains your DBContext class, which is SacredBond.Core):
   <pre><code> $ cd ./project_with_migrations_folder
    $ dotnet ef --startup-project ../my_startup_project_path/ migrations add myMigration01</code></pre>
