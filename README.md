<i align="center"> Status Readme: 40% (in process)</i>

---------------------------------------------------------------------------------------------------------------------------------------------------
<p align="center"><img src="https://github.com/zafeirisdimi/GroupProjectBootcamp/blob/466fc2cad1276cb49dae8d22c95c3c8484b7e9c0/GroupProject/Content/images/tRIPPIE.png" width="450" alt="Trippie logo">
</p>


<h1 align="center"> Trippie </h1>

<p align="center"><strong>| <a href="#features">Features</a> | <a href="#cities-autocomplete">Cities-Autocomplete</a> | <a href="#tech-stack">Tech Stack</a> | <a href="#screenshots">Screenshots</a> | <a href="#our-team">Our team</a> </strong>|

---------------------------------------------------------------------------------------------------------------------------------------------------



# 📋Table of contents #
------------------------------------------------------------------------------------
* [Getting Started](#getting-started)
  * [Features](#features)
  * [Cities-Autocomplete](#cities-autocomplete)
  * [Models](#models)
    + [Data Transfer Objects](#data-transfer-objects)
      - [SearchAlongPathDto](#searchalongpathdto)
      - [SendEmailDto](#sendemaildto)
  * [Tech Stack](#tech-stack)
    + [Front End](#front-end)
    + [Database](#database)
    + [Back End](#back-end)
    + [Other important tools](#other-important-tools)
  * [Our Team](#our-team)
  * [Screenshots](#screenshots)
  * [Presentation](#presentation)

------------------------------------------------------------------------------------


## 🎬Getting Started ##

<section>
<details>more
  <summary><h4>What is Trippie?</h4></summary>
  
A full-stack web application that simplifies and automates 
some of the aspects of planning a road trip.

</details>
<details>
  <summary><h4>Target group</h4></summary>
  
- People organizing a road trip
- Any car traveler that would like to enrich his journey with additional interesting places.

</details>

<details>
  <summary><h4>Requirements of project</h4></summary>
  
- People organizing a road trip
- Any car traveler that would like to enrich his journey with additional interesting places.

</details>
</section>

## 🕹️Features ##

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

## 🗺️Cities-Autocomplete ##

For more specific details and documentation about the service of autocomplete you should go [there](https://github.com/ioannis-thyris/city-autocomplete) 

## 🏃How to run

Follow the below steps to run the application: 
1) Firstly, clone the repository.
2) In the `Web.config` change the *connection string* so that the "Data Source" matches your SQL Server.
3) Run [city-autocomplete](https://github.com/ioannis-thyris/city-autocomplete) service with Docker. (Please check the instructions in its repository on how to achieve this)
4) In the `CreateTrip` view replace the Google Maps API Key with your own (the existing key is now invalidated).
5) In the `PlacesController` replace your OpenTripMaps API Key with your own.
6) Run the application.

## 🧱Models ##

### Data Transfer Objects ###

<details><summary><h5>CityDto</h5></summary>

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| int             | GeonameID      | get, set  |
| string         | Name       | get, set    |
| string         | Country       | get, set    |
| double         | Latitude       | get, set    |
| double         | Longitude        | get, set    |

</details>

<details>
<summary><h5>PlaceDtoForCreate</h5></summary>

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| string             | Xid      | get, set  |
| string         | Name       | get, set    |
| string         | Rate       | get, set    |
| string         | ImageUrl        | get, set    |
| string         | Info         | get, set    |
| double         | Latitude       | get, set    |
| double         | Longitude        | get, set    |

</details>

#### SearchAlongPathDto ###

| Type           | Properties       | Methods |
| :---:          |     :---:        |  :---:  |
| List of Coordinates            | PathOverview      | get, set  |
| int?         | Radius       | get, set    |
| int?         | PointsAlongPath       | get, set    |
| PlaceTypeEnum[]         | PlaceTypes       | get, set    |
| double         | Longitude        | get, set    |


#### SendEmailDto ###

| Type           | Properties       | Methods | Decorator |
| :---:          |     :---:        |  :---:  | :---:  |
| string           | Name      | get, set  | Required |
| string         | Subject        | get, set    | Required |
| string        | Email        | get, set    | go there | 
| PlaceTypeEnum[]         | PlaceTypes       | get, set    |
| double         | Longitude        | get, set    |


 ``` 
 ``` 
 
 [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
                            
 ```
 ``` 
 

## 🛠️Tech Stack ##

<i>Here are all the , used in project , programming languages and tools with their official recourses.</i>


### Front End ###



| Name           | Logo       | Website | 
| :---:          |     :---:        |  :---:  | 
| HTML5          |     :---:        |  [w3schools](https://www.w3schools.com/html/default.asp)  | 
| CSS3          |     :---:        |  [w3schools](https://www.w3schools.com/css/)  | 
| Javascript  Vanilla        |     :---:        |  [mozilla.docs](https://developer.mozilla.org/en-US/docs/Web/JavaScript)  | 
| Bootstrap        |     :---:        |  [official site](https://getbootstrap.com/)  | 
| Font Awesome        |     :---:        |  [official site](https://fontawesome.com/)  | 



### Database ###

- [Microsoft Sql Server 2019](https://www.microsoft.com/en-us/sql-server/sql-server-2019)
- [Microsoft Sql Server Management(SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)

### Back End ###

- [ASP .NET MVC](https://dotnet.microsoft.com/en-us/apps/aspnet/mvc)
- [ASP .NET CORE WebApi](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio)
- [Entiny Framework (Code First)](https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application)
- [Repository Pattern](https://dotnettutorials.net/lesson/repository-design-pattern-csharp/#:~:text=The%20Repository%20Design%20Pattern%20in%20C%23%20Mediates%20between%20the%20domain,and%20the%20data%20access%20logic.)
- [Data Trasfer Objects(DTOs)](https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5)
- [Asynchronous programming with async and await](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)
- [SignalR](https://dotnet.microsoft.com/en-us/apps/aspnet/signalr)
- [SMTP Email](https://blog.elmah.io/how-to-send-emails-from-csharp-net-the-definitive-tutorial/)


### 🧰Other important tools ###

- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [Microsoft Teams](https://www.microsoft.com/en/microsoft-teams/group-chat-software)
- [Docker](https://www.docker.com/)
- [Postman](https://www.postman.com/)
- [Github](https://github.com/)
- [Canva](https://www.canva.com/)



## 🧑‍🤝‍🧑Our Team ##

- [Ioannis Thyris](https://github.com/ioannis-thyris)
- [Dimitris Zafeiris](https://github.com/zafeirisdimi)
- [Dimitris Baltounas]()
- [Leonidas Mourikis](https://github.com/MourikisLeonidas)
- [Stavros Gouleas](https://github.com/StaurosGouleas)


## 📸Screenshots ##

- Core functionality 


<div>
<img src="https://github.com/zafeirisdimi/GroupProjectBootcamp/blob/59ab5e2ece316d0213b5ff17611cc6f8cc6bcfba/GroupProject/Content/images/corefunctionality.jpg" width="1000"/>
</div>


------------------------------------------------------------------------------------

- Data transfer 

<div>
<img src="https://github.com/zafeirisdimi/GroupProjectBootcamp/blob/59ab5e2ece316d0213b5ff17611cc6f8cc6bcfba/GroupProject/Content/images/datatransafer.jpg" width="1000"/>
</div>


- Diagram ER 
![Diagram ER](https://github.com/zafeirisdimi/GroupProjectBootcamp/blob/9c0fa3f0d935fd380106d9f6df1e1732e2ce12bb/GroupProject/Content/images/diagram.png)


------------------------------------------------------------------------------------

## 🎁Presentation ##

Our presentation of project is online available [here](https://www.canva.com/design/DAFM5Lf0TJo/3HrrhrGxsN5ljFWrRx4Qgg/edit?utm_content=DAFM5Lf0TJo&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)



