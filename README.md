# Food-Delivery-WebApp
 step one: to run the project you will either download visual studio or vs code.
 
  ---------------------------------------- SHOULD YOU CHOOSE VS CODE --------------------------------------------
   
   MAKE SURE YOUR COMPUTER IS CONFIGURED TO RUN .NET CORE PROJECTS   
   
  ---------------- ----------------------------------------------------------------
 
 step two: download mssql 
 
 step three : open FDDAPI then open appsettings :- on DefaultConnetion :  change the values of *** to your own database connection values
 
 step four: you will need to create migration 
 
 ---------------------------- VISUAL STUDIO ---------------------------------------
 
 on visual studio IDE : click tools then Nuget Package Manager then Package Manager Console 

 on the package manager console window  :- on Default Project select Infrastructure
 
 copy paste code on console :- add-migration initialCreate
 
 once migration is done 
 
 copy paste code on console :- update-database 
 
 once its done 
 
 run the project 
 
 --------------------------- VS CODE --------------------------------------------
 
 on vs code Terminal copy paste code :- dotnet ef migrations initialCreate --project Infrastructure 
 
 once migration is done 
 
 copy paste code on Terminal := update-database 
 
 once its done 
 
 copy paste code:- dotnet watch run 
 
![fddhome](https://user-images.githubusercontent.com/39485154/155523850-81435383-aeef-4b95-a42f-13245619670f.PNG)
![fddbasket](https://user-images.githubusercontent.com/39485154/155523873-7e276055-fd38-4915-a55a-7f90fb8ed3a1.PNG)
