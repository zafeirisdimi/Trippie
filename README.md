<i align="center"> Status Readme: 40% (in process)</i>

---------------------------------------------------------------------------------------------------------------------------------------------------

<p align="center"><img src="https://github.com/zafeirisdimi/GroupProjectBootcamp/blob/466fc2cad1276cb49dae8d22c95c3c8484b7e9c0/GroupProject/Content/images/tRIPPIE.png" width="450" alt="Trippie logo">
</p>


<h1 align="center"> Trippie </h1>

<p align="center"><strong>| <a href="#features">🎲Features</a> | <a href="#cities-autocomplete">🌇Cities-Autocomplete</a> | <a href="#tech-stack">💻Tech Stack</a> | <a href="#screenshots">📸Screenshots</a> | <a href="#our-team">🧑‍🤝‍🧑Our team</a> </strong>|

----------------------------------------------------------------------------------


# 📋Table of contents #


---------------------------------------------------------------------------------------


  * [🎬Getting Started](#getting-started)
  * [🎲Features](#features)
  * [🌇Cities-Autocomplete](#cities-autocomplete)
  * [🏃How to run](#how-to-run)
  * [💻Tech Stack](#tech-stack)
    + [Front End](#front-end)
    + [Database](#database)
    + [Back End](#back-end)
    + [🧰Other important tools](#other-important-tools)
  * [📸Screenshots](#screenshots)
  * [🎁Presentation](#presentation)
  * [🧑‍🤝‍🧑Our Team](#our-team)
  

---------------------------------------------------------------------------------------


## 🎬Getting Started ##

-------------------------------------------------------------------------------------
<section>
<details>
  <summary><h3>💡 What is Trippie?</h4></summary>
  
- <strong>A full-stack web application that simplifies and automates 
some of the aspects of planning a road trip. </strong>

</details>
<details>
  <summary><h3>🎯 Target group</h4></summary>
  
- People organizing a road trip
- Any car traveler that would like to enrich his journey with additional interesting places.

</details>

<details>
  <summary><h3>📜 Project requirements</h4></summary>
  <h4>Definition)</h4>
  <p>You need to form teams of 3-5people. You will need to define one member as the <strong>Team Coordinator</strong> and the rest of  the  members as:  <br/><strong>Front End Developer</strong> and /or <strong>Back End Developer </strong>and /or <strong>Database Developer</strong>.</p>
  
  
  <details>
  <summary><h4>The requirements are as follows:</h4></summary>
  <hr/>
  <p>
    <ol>
   <li><strong>The application you need to build is a web app that gives the ability to users to register and login</strong> <i>[10 marks]</i></li>
   <li><strong>Your web application needs to be able to connect with a database either locally or remotely </strong><i>[10 marks]</i></li>
   <li><strong>Your application must implement at least two roles</strong><i>[20 marks]</i></li>
   <li><strong>Each rolemust have different tasks and views within the application </strong><i>[10 marks]</i></li>
   <li><strong>The  application  must have the option  to  produce  reporting views with (custom)filters </strong><i>[10 marks]</i></li>
   <li><strong>The   application must have a module that permits internal communication    between internal entities which could be (implement at least one of the following):</strong> <i>[20 marks]</i><br/>a.Real time communication and/or<br/>b.REST API</li>
   <li><strong>The  application  must  support  an  e-payment process  that:</strong><i>[20 marks]</i><br/>a.Gives access to read some restricted material e.g. e-book or <br/>b.Buy some goods, e.g. purchase a digital object</li>
  </ol>
  
  </p>
  
  <h6>You will submit your projectvia the MS Teams application.All the members of your team need to submit the same projectand the maximum number of members per teamis five (5).</h6>
  <hr/>
  </details>
</details>
</section>

[🔝Back](#table-of-contents)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------


## 🎲Features ##

----------------------------------------------------------------------------------------------------------------------------------------------------------------------

✔️ **Google Maps** integration

✔️ Fast **Search Engine** of start-destination cities of trip ( just in milliseconds ). <br/><i>Almost all the cities in the world are included at this search engine.</i>


✔️ A variety of available **categories** of **places**.
<br/>
<i>Short information about each wished place of chosen trip route.</i>


✔️ Real-time communication <br/><i>user and website support team through chat room</i>.

✔️ **Trips management panel**.

✔️ Pay method with **Paypal** account.

✔️ **Multi-role user scenarios** <br/><i>( unregistered user | registered user| administrator )</i>.


✔️ **User registration and login**<br/><i>with classic way( email and password)</i>

✔️ Sign in with **Facebook** and **Google** account.

✔️ Simple **contact form**.

✔️  **Admin Dashboard** <br/><i>with simplified tables of important data and statistics of our application</i>

[🔝Back](#table-of-contents)

----------------------------------------------------------------------------------------------------------------------------------------------------


## 🌇Cities-Autocomplete ##

----------------------------------------------------------------------------------------------------------------------------------------------------

For more specific details and documentation about the service of autocomplete , you should go [there](https://github.com/ioannis-thyris/city-autocomplete) 

<strong>Extra useful resources about this service:</strong>
- Elasticsearch [(youtube.link)](https://www.youtube.com/watch?v=ZP0NmfyfsoM&list=LL&index=81&t=5s)
- Kibana [(official website)](https://www.elastic.co/what-is/kibana)
- Docker [(dev.to)](https://dev.to/nimatrazmjo/how-to-dockerize-your-application-4mj7)

-----------------------------------------------------------------------------------------------------------------------------------------------------


## 🏃How to run

-------------------------------------------------------------------------------------------------------------------------------------------------------
<h4>Follow the below steps to run the application:</h4> 

<strong> 1) Firstly, clone the repository.</strong>

<strong> 2) In the `Web.config` change the *connection string* so that the "Data Source" matches your SQL Server.</strong>

<strong> 3) Run [City-Autcomplete service](https://github.com/ioannis-thyris/city-autocomplete) with Docker. </strong><i>(Please check the instructions in its repository on how to achieve this)</i>

<strong> 4) In the `CreateTrip` view replace the Google Maps API Key with your own </strong><i>(the existing key is now invalidated)</i>.

<strong> 5) In the `PlacesController` replace your OpenTripMaps API Key with your own.</strong>

<strong> 6) Finally,you are ready to run the application</strong>

[🔝Back](#table-of-contents)

-------------------------------------------------------------------------------------------------------------------------------------------------


## 💻Tech Stack ##
-------------------------------------------------------------------------------------------------------------------------------------------------

<i>Here are all the , used in project , programming languages and tools with their official recourses.</i>


### Front End ###
----------------------------------------------------------------------------------------------

| Name               | Website | 
| :---:                  |  :---:  | 
| HTML5                 |  [w3schools](https://www.w3schools.com/html/default.asp)  | 
| CSS3                  |  [w3schools](https://www.w3schools.com/css/)  | 
| Javascript  Vanilla        |  [mozilla.docs](https://developer.mozilla.org/en-US/docs/Web/JavaScript)  | 
| Bootstrap   |  [official site](https://getbootstrap.com/)  | 
| Font Awesome    |  [official site](https://fontawesome.com/)  | 


### Database ###
------------------------------------------------------------------------------------------

| Name               | Website | 
| :---:              |  :---:  |
| SQL    |  [w3schools](https://www.w3schools.com/sql/)  |
| Microsoft Sql Server 2019    |  [Official website](https://www.microsoft.com/en-us/sql-server/sql-server-2019)  |
| Microsoft Sql Server Management(SSMS)    |  [Official website](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)  |


### Back End ###
------------------------------------------------------------------------------------------
<h4>Programming language C#</h4>

- [ASP .NET MVC](https://dotnet.microsoft.com/en-us/apps/aspnet/mvc)
- [ASP .NET CORE WebApi](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio)
- [Entiny Framework (Code First)](https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application)
- [Repository Pattern](https://dotnettutorials.net/lesson/repository-design-pattern-csharp/#:~:text=The%20Repository%20Design%20Pattern%20in%20C%23%20Mediates%20between%20the%20domain,and%20the%20data%20access%20logic.)
- [Data Trasfer Objects(DTOs)](https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5)
- [Asynchronous programming with async and await](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)
- [SignalR](https://dotnet.microsoft.com/en-us/apps/aspnet/signalr)
- [SMTP Email](https://blog.elmah.io/how-to-send-emails-from-csharp-net-the-definitive-tutorial/)


### 🧰Other important tools ###
---------------------------------------------------------------------------------------------

| Name               | Official Website | 
| :---:                  |  :---:  | 
| Microsoft Visual Studio 2022   |  [🔗](https://visualstudio.microsoft.com/vs/)  | 
| Microsoft Visual Studio Code   |  [🔗](https://code.visualstudio.com/)  | 
| Microsoft Teams    |  [🔗](https://www.microsoft.com/en/microsoft-teams/group-chat-software)  | 
| Docker       |  [🔗](https://www.docker.com/)  | 
| Postman   |  [🔗](https://www.postman.com/)  | 
| Github    |  [🔗](https://github.com/)  | 
| Canva    |  [🔗](https://www.canva.com/)  | 

[🔝Back](#table-of-contents)




## 📸Screenshots ##

---------------------------------------------------------------------------------------------------------------------------------------------------------

- Core functionality 


<div>
<img src="https://github.com/zafeirisdimi/GroupProjectBootcamp/blob/59ab5e2ece316d0213b5ff17611cc6f8cc6bcfba/GroupProject/Content/images/corefunctionality.jpg" width="1000"/>
</div>


[🔝Back](#table-of-contents)

------------------------------------------------------------------------------------

- Data transfer 

<div>
<img src="https://github.com/zafeirisdimi/GroupProjectBootcamp/blob/59ab5e2ece316d0213b5ff17611cc6f8cc6bcfba/GroupProject/Content/images/datatransafer.jpg" width="1000"/>
</div>


- Diagram ER 
![Diagram ER](https://github.com/zafeirisdimi/GroupProjectBootcamp/blob/9c0fa3f0d935fd380106d9f6df1e1732e2ce12bb/GroupProject/Content/images/diagram.png)

[🔝Back](#table-of-contents)



## 🎁Presentation ##
--------------------------------------------------------------------------------------------------------------------------------

Our presentation of project is online available [here](https://www.canva.com/design/DAFM5Lf0TJo/3HrrhrGxsN5ljFWrRx4Qgg/edit?utm_content=DAFM5Lf0TJo&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton) or [🔝Back](#table-of-contents)


## 🧑‍🤝‍🧑Our Team ##
----------------------------------------------------------------------------------------------------------------------------------------
<div align="center">

 [🧑 Ioannis Thyris](https://github.com/ioannis-thyris) | [👨 Dimitris Zafeiris](https://github.com/zafeirisdimi) | [👱 Dimitris Baltounas]() | [👴 Leonidas Mourikis](https://github.com/MourikisLeonidas) | [🧔 Stavros Gouleas](https://github.com/StaurosGouleas)
 
</div>


[🔝Back](#table-of-contents)



