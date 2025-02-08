#Create a New Folder with Solution Name
#Open the Solution Folder from xCode
#Open CLI and run
        dotnet new sln
        this will create a solution with same name as the Folder
#Now Run
        dotnet new webapi -controllers -n API  #API can be replaced by any Name you prefer
        dotnet sln add API #This will bind the API to the solution

#Run the command to set HTTPS certificate for localserver
dotnet dev-certs https --trust
dotnet dev-certs https --clean #to try again


#Now Run
        ng new MyAngularApp #MyAngularApp can be replaced by any Name you Prefer

#GoBack to Solution Folder
        npm install -g @angular/cli #install nmp package


#GoBack to MyAngularApp
           ng serve

webAPI     commands dotnet build / dotnet run
classlib   commands ng serve


# In the appsettings.Development.json add the following
,
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=devpulse.db"

# Install dotnet ef from nuget.org
#The Entity Framework Core tools help with design-time development tasks. They're #primarily used to manage Migrations and to scaffold a DbContext and entity types by #reverse engineering the schema of a database.
#This package, dotnet-ef is for cross-platform command line tooling that can be used #anywhere.
dotnet tool install --global dotnet-ef --version 9.0.1
# Must match major version of our project
# Commands:
#  database    Commands to manage the database.
#  dbcontext   Commands to manage DbContext types.
#  migrations  Commands to manage migrations.
type dotnet ef migrations -h for the commands
#Commands:
#  add                        Adds a new migration.
#  bundle                     Creates an executable to update the database.
#  has-pending-model-changes  Checks if any changes have been made to the model since the #last migration.
#  list                       Lists available migrations.
#  remove                     Removes the last migration.
#  script (Important for us)                     Generates a SQL script from migrations.

# Intial setup is to add migration and the command will be
# dotnet ef migrations add "Name for migration" "output location" "Location"
dotnet ef migrations add IntialCreate -o Data/Migrations
# Now our database Migration is created in Data folder and under Migrations we have 3 #files and we are interested in Initial Create. THis is where all the datacreating #code is written.
# Next command to run
dotnet ef databse -h
#Commands:
#  drop    Drops the database.
#  update  Updates the database to a specified migration.
# This command will create a databse (devpulse.db) see line 31-32
dotnet ef database update
# Although the database is created we still cannot open it
# we can use any database viewer like dbweaver/sqllite we will use sqlite
# make sure you have the extension installed for sqlite then go shift + command + P (MAC) and type sqlite select is and further it will show the database to select you will now have SQLLITE EXPLORER as part of your project

