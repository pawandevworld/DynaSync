# Create a New Folder with Solution Name
# Open the Solution Folder from xCode
# Open CLI and run
        dotnet new sln
#        this will create a solution with same name as the Folder
# Now Run
        dotnet new webapi -controllers -n API  #API can be replaced by any Name you prefer
        dotnet sln add API #This will bind the API to the solution

# Run the command to set HTTPS certificate for localserver
dotnet dev-certs https --trust
dotnet dev-certs https --clean #to try again

# Now Run
        ng new MyAngularApp #MyAngularApp can be replaced by any Name you Prefer

# GoBack to Solution Folder
        npm install -g @angular/cli #install nmp package


# GoBack to MyAngularApp
           ng serve

# webAPI     commands dotnet build / dotnet run
# classlib   commands ng serve


# In the appsettings.Development.json add the following

  "ConnectionStrings": {
    "DefaultConnection": "Data Source=devpulse.db"

# Install dotnet ef from nuget.org
# The Entity Framework Core tools help with design-time development tasks. They're #primarily used to manage Migrations and to scaffold a DbContext and entity types by #reverse engineering the schema of a database.
# This package, dotnet-ef is for cross-platform command line tooling that can be used #anywhere.
dotnet tool install --global dotnet-ef --version 9.0.1
# Must match major version of our project
# Commands:
#  database    Commands to manage the database.
#  dbcontext   Commands to manage DbContext types.
#  migrations  Commands to manage migrations.
type dotnet ef migrations -h for the commands
# Commands:
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

# Now goto the Client side Angular setup https://angular.dev/reference/versions
# 1 Install Node (brew install node for mac) or check if it is already installed 
node --version
# 2 Install npm (npm install -g @angular/cli@19 version 19) or check if it is 
already installed npm --version
# 3 Create the Client project by using ng new TaskHandler 
# <TaskHandler> is the name used
# 4 Goto the TaskHandler folder and use ng serve to run the application

# Install Angular Language Service from marketplace
# Go to Code Settings Settings and search for Breackets and set to always

# Set communication between the client and api using cors
# Now we will need the ngx-bootstrp libarary for bootstrap functionality in # angular way
# NOTE: SHOULD BE INSTALLED IN CLIENT DIRECTORY NOT IN THE API
# here is the command to install check angular version compatibility
# installed version 19
npm install ngx-bootstrap@19 bootstrap font-awesome

#  Also add the following in the angular.json not in the test section
#  and before the existing stylesheets in "styles" section

              "node_modules/bootstrap/dist/css/bootstrap.min.css",
              "node_modules/font-awesome/css/font-awesome.min.css",

# Setting up https for client site
# make sure you have homebrew installed. While in the client folder sptop the server
# and run the following command homebrew for mac
brew install mkcert
#                Or use chocolatey for windows
#                brew install mkcert
# not in the client folder 
run mkcert -install
# you should get the following message
# The local CA is now installed in the system trust store!
# Now create a ssl folder and goto the ssl folder and run mkcert command
# this will create your key in the ssl folder.
# Now goto angular.json file and under the serve section on verytop add the following
          "options":{
            "ssl": true,
            "sslCert":"./ssl/localhost.pem",
            "sslKey":"./ssl/localhost-key.pem"
          },
# Now on ng serve you will see the certificate is applied

# Adding the salt password and hash password
# dotnet ef migrations add "UserEntityUpdated" no need to specify location as it is already set make sure you are in the API folder
# to verify the dotnet-ef use the following command to verify the installed
dotnet tool list -g
# if no version is installed install dotnet-ef from nuget-org and search for dotnet-ef
dotnet ef migrations add UserEntityUpdated
# once that works do the following to update the database table
dotnet ef database update
# For JWT need nuget package for system.identitymodel.token.jwt and must be inserted in
# DevPulse.csproj 
        <PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="8.4.0" />
# for getting the token following nuget package is needed
        Microsoft.AspNetCore.Authentication.JwtBearer

# creating an angular component
# ng g c where c is for component
# where nav is the name of the component
# dry run first to see what will be created and then to --skip-test to create all but the test files
ng g c nav --dry-run 
ng g c nav --skip-tests

# creating an angular _services folder with account.service ts file
# ng g s where s is for services
ng g s _services/account --skip-tests
# use localStorage to save token information in the local client storage (like registery in lagacy code)

# NOTE when creating a new component in the ts file under the @Components, under imports must include FormModule

# For validations on the app use njx toastr goto (https://www.npmjs.com/package/ngx-toastr)   Check under install and use the provided cli command to install toastrservice "npm install ngx-toastr" and add the css to angular.json "node_modules/ngx-toastr/toastr.css" under the styles and include the provide parameter in the app.config.ts 

# Now what if a user can sneak in to the url directly like "https://localhost:4200/members" so we need to create a route gaurd for now great a _gaurds foulder to have all the authrizations for all routes      ng g g _guards/auth --dry-run

# use for free theames https://bootswatch.com/ and to use the theames simply install using the "npm i bootswatch" command and add "node_modules/bootswatch/dist/darkly/bootstrap.min.css" in the angular.json file after the existing bootstrap files. 

# ErrorHandling / API middleware / Angular Interceptor / Troubleshooting exceptions

# API side error handling#
# Create a buggyController to test all possible error like "Authorization error, not-found, Server error, Bad-Request (http 400 to 499 errors) typically these are user side errors", Validation error (can be tested by using the "register new user")

# Create a APIException class to handle the error like statuscode, message or any details such as stack to populate it to the client. Client can use this information to notify the user of the error and what action the user need to take to resolve it

# creat an exception middleware pipeline (also varies on prod/dev mode) returns json request
# in order to use the middleware we need to add it in the program.cs and must be at the top of the pipeline


# CLIENT side error handling#
# Create a component for testing all possible errors using the buggyController.

# Intercepts http requests either way out or way back from API server. On the way back we can intercept the request to see if there is any error with http request. Interceptor can catch it and we can do somthing in the user interface to show these errors

# In the app.config.ts for the http client provider pass the withInterceptors([errorInterceptor])

# Validating errors test in the test-errors-component for the 400validationerror store the error array in a string array and in the 400validationerror method. This can be used to dhow a detailed error information. In this example use it just under the error testing buttons in the test-errors.component.html

# Handling Not-Found. Just create simple pages with the error a routerlink to go back to the home page. Finally set then in the routes.

# Handling Server-Error. This is a classical example of using constructor in a component class since this is the only place we can accessing the "navigationextras"

# Now that we have added Jobs entity and created a extension to calculate age of the job in day we can not do the migration and update the database with new tables and fields by usign the following command in the API
# "dotnet ef migrations add UpdateUserJobEntity" if any error then type dotnet build to see errors or simply use "dotnet ef migrations remove" to undo the action

# Not that we have seed data available we have to first delete our old database if any There are two # ways to delete the data. 1 Delete amnualy the .db file or use the command Line in the API folder "dotnet ef database drop"