dotnet aspnet-codegenerator controller -m Client -name ClientsController -outDir Controllers -dc ApplicationDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m Client -name ClientsController -outDir Api -api -dc ApplicationDbContext -udl --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name CertificatesController -actions -m  Certificate -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

# Generate db migration

~~~bash
# install or update
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

# create migration
dotnet ef migrations add Initial --project App.DAL.EF --startup-project WebApp --context AppDbContext 
dotnet ef migrations add Another --project DAL.EF.App --startup-project WebApp --context ApplicationDbContext 

dotnet ef migrations --project App.DAL.EF --startup-project WebApp add OIS2
dotnet ef database   --project DAL.EF.App --startup-project WebApp update
dotnet ef database   --project DAL.EF.App --startup-project WebApp drop


# apply migration
dotnet ef database update --project DAL.EF.App --startup-project WebApp --context ApplicationDbContext 
~~~


# generate rest controllers

Add nuget packages
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Microsoft.EntityFrameworkCore.SqlServer
-
~~~bash
# install tooling
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool update --global dotnet-aspnet-codegenerator

cd WebApp
# MVC
dotnet aspnet-codegenerator controller -m TrainingPlan -name TrainingPlansController -outDir Controllers -dc ApplicationDbContext  -udl --referenceScriptLibraries -f
# Rest API
dotnet aspnet-codegenerator controller -m Owner -name OwnersController -outDir Api -api -dc ApplicationDbContext  -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -m Pet   -name PetsController   -outDir Api -api -dc ApplicationDbContext  -udl --referenceScriptLibraries -f
~~~


Generate Identity UI

~~~bash
cd WebApp
dotnet aspnet-codegenerator identity -dc DAL.EF.App.ApplicationDbContext --userClass AppUser -f 
~~~



docker run --name webapp_docker --rm -it -p 8000:80 webapp -p 8000:80 --name webapp_docker -it --rm
docker build -t webapp .