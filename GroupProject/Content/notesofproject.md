MODEL                            Relationships

- Trip				      has Ids, many routes, DateTime StartDate, DateTime EndDate, Duration?
- User				      has personalInfo(Age,Gender,Email,Password,UserType[single,poweruser,admin]),many Interest
- Map				      [like Google Maps()] 						     FROM GOOGLE
- Route				      has Id,many places, StartPoint, EndPoint, List <BetweenPoints>         FROM GOOGLE
- Place				      has Id, many Categories,City,PointedInMap,Rating,Comments?, OpenHours? FROM GOOGLE
- Interest			      (is landmark,cafes,restaurant, shopping, beach,museum,historical points etc) \*checkbox on TripPlannerIndex

\-

\-

Views

- HomeIndex->

Header Contintional Rendering [if visitor is authenticated user/ADMIN, show MyTrips,MyProfile,otherwise Login,Register]

HomeSlider with some pictures

Description of using this app

Plan subscription

Button Start Planning         ------> TripPlannerIndex

`				      `Map | Filters| (PlaceRange?)

`				      `(input)StartPoint (From)| (input)EndPoint (To)| (input) StartDate? | (input) EndDate? | Duration?

`				      `Button Start the Plan

`				      `px. Already Loaded Map, the user click the points(limit 5) on the map

`						  	      `we bring all the available(low cost,faster,expert) routes of the points of user

`							      `we represent user the places of interest(etc museum,shops,cafes)

`							      `User select his liked places, and we add them to a list (User Places),[only until user\* issue role requirements]

`							      `the updated map with User Places is shown and the user finally saves the Trip[only for power users].

Footer Team Mates




- UserController--->ProfileIndex -> Personal Information of user,User(CRUD)
- MyTripsView ----->A table of userTrips(CRUD)
- Admin(Area)------>Datatable users(CRUD),User Analytics(Diagrams)

\-

\-

Controller
