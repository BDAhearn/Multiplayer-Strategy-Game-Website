# Senior-Project---Multiplayer-Strategy-Game-Website
Senior Project for W26 CIS4891.0M1. Strategy game website that allows users to create public, private, and local lobbies and track stats.

|Table of Contents|
|--------------------|
| [Description](#description) | 
| [Solution Architecture Diagram](#solution-architecture-diagram) | 
| [Wireframe](#wireframe) | 
| [User Stories](#user-stories) | 
| [Use Cases](#use-cases) | 
| [Use-Case Diagram](#use-case-diagram) | 
| [Requirements](#requirements)
| [ERD Diagram](#erd-diagram)
| [UML Class Diagram](#uml-class-diagram)


## Description
  The project I am going with is the multiplayer strategy game idea. The purpose of it is to allow players to play online or local multiplayer turned based strategy games. The main goal is to create a multiplayer lobby-based platform. While the games are indeed important to this project, they are secondary to the creation of the main platform. This will require players to create a lobby for the game of their choosing and let them keep it local (in person), invite friends, or have it open to everyone. It will primarily be a web-based application although it will be built to allow alternative clients to access it, such as a standalone app.
  
  To begin, the project overview should be discussed. The project can be broken down into 3 major parts. Player registration, gameplay, and lobby creation and running. Players registration will allow players to choose their name and save their game statistics otherwise they will be lost whenever they end their connection to the server. This will need just a standard password style login. The next is gameplay. Game assets, requirements, and the program to run them will be needed. At the beginning only a few simple games will be offered, but more can be added later. The game assets will initially be simple art that can be updated at any time. The requirements will consist of minimum and maximum players, and any other constraints that particular game may have. Each game will additionally need its own code to be able to run and determine the flow of gameplay. Finally, lobby creation and running one will be needed. Players will be able to select the game they want to play, if the lobby will be local players only and how many, private and only available via invite, or open to anyone. Once a game starts, it will be needed to determine which players turn it is and when a game is completed and the lobby should be closed. This will happen when there is a clear winner, a player leaves, the lobby timer runs out, or a player forfeits. Overall, all three parts interact with each other deeply but can be designed fairly separately. The user registration and games design are fairly standard and have been taught throughout the degree program. Player registration will use a username and password style login where the password is encrypted. The game design will involve at first simple games like Tic-tac-toe and Connect Four but can be scaled up to any other inventoryless (where all information is available to all players) strategy games like Chess, Othello, Checkers, Dots and boxes . The creating and running a lobby proposes much more of a challenge since it will need players to be updated when another player makes a move. This can be handled with various libraries like SignalR. The main language for this project will be C#, HTML, and Javascript using the ASP.Net framework. This will primarily allow web based interactions but can be modified to allow phone apps to connect to it too.
  
  An important question that needs to be addressed is what data will be stored. Considering the application will consist of games, players, and lobbies, data on all three of those will be needed. To begin, the games that are available will need their logic and rules, visuals, and requirements stored. All of these are essential for the game to be able to run but will be fairly static unless the game itself is updated. The database table for the games would consist of the game ID number as the primary key, the name, the location of the visuals, the location of the logic, players needed to start the game, and how long the lobby can be open before it is closed by the server. The next information that will need to be stored is player information. This will help avoid issues with multiple people trying to control the same side in a game and lobbies being pure chaos. This project will allow both registered users and temporary users. The player table will store information such as the user's ID number for the primary key, username, if they are temporary or registered, and an encrypted password if they are registered. Finally information on game lobbies will need to be stored. This will allow games to be played smoothly and track stats. The data needed to be stored will be the lobby ID number as the primary key, the game played, if it is concluded, the winner’s player ID if it concluded, player ID if a player forfeited, game state of the game board, date played, time opened, and if the lobby is local, private, or open to anyone. A secondary table of the players in the game will be needed. This will allow for more than 2 player games to easily be added as well. This table will consist of a generic numbered primary key, lobby ID number, and player ID number. Game state will be serialized info of which pieces are where, player turn, and any other in game constraints.
  
  The primary source of all of this data will be from user uploads. The exception to this is the game data which will solely be uploaded by the application owner (in this case, me). This is to limit the issues of malicious code being uploaded. Player info and lobby info will be uploaded by players using the interface. The information they can upload will be limited to username, password, and lobby info. Lobby info will be based upon drop downs of information pulled from the server. This should help limit the possibility of any malicious behavior and other issues the players can experience. The username will need to be filtered to avoid profanity, and the passwords will need to conform to standard best practices for registered users. Temporary users will get a premade name to use and can only change it if they become a registered user.
  
  There are a few ways the data can be used. The primary way would be to create lobbies and play games as this is the primary intention of the project. The next would be to show statistics. This can be player statistics, game statistics, and lobby statistics. For players statistics, their wins, losses, forfeits, and abandons will be able to be shown, along with their most played games, and recent game states they have. This could be used either as a badge of honor or a way to discourage players from abandoning a game. Game statistics will be such as which are the most played games, which games have the most forfeits/abandons and completions. This could help with quality assurance since if a game has a lot of abandons or forfeits that can show an issue. It could also help with deciding what type of games are popular and should be added. Finally lobby statistics will allow people to see what lobbies are open for them to join, and past games played. 
  
  Similar sites to this project in terms of function include Lichess, jstris, any of the boardgame websites of yore, and weirdly enough instant messaging services. All of these include player registration, lobby creation, and sending information between players in real time. While this project is focussing on turn based games, the game state will still need to be updated in real time as a player may move at any random time instead of at set intervals. The main literature that has been used in research thus far has been primarily stack overview and blog posts of similar projects recommending various libraries to use and techniques that they have employed.
  
  The plan for this project is to break things down into chunks of when they make sense to implement. The first iteration of the site will include a couple locally playable games chosen from a drop down menu. The next iteration will include player registration and basic local only lobby creation. After that invite only online multiplayer will be added. Finally open lobby online multiplayer will be added. After the main site functionality has been completed, the aesthetics of the site and games will be updated and auxiliary parts such as player statistics will be added. This should allow for a project to be much more easily achieved instead of trying to design all of it at once.
  
  In conclusion, this project certainly has a lot more moving parts to it than what was initially assumed. All in all though it should help demonstrate a solid understanding of what has been learned throughout this degree program while still offering new ways to learn while working on it. 

## Solution Architecture Diagram
![alt text](https://github.com/BDAhearn/Senior-Project---Multiplayer-Strategy-Game-Website/blob/main/Wireframs%20and%20diagrams/Solution%20Architecture%20Diagram.png?raw=true "Solution Architecture Diagram")

## Wireframe
**Welcome Page**
![alt text](https://github.com/BDAhearn/Senior-Project---Multiplayer-Strategy-Game-Website/blob/main/Wireframs%20and%20diagrams/Welcome%20Splash%20Page%20Wireframe.png?raw=true "Welcome Page")

**Lobby Search and Creation**
![alt text](https://github.com/BDAhearn/Senior-Project---Multiplayer-Strategy-Game-Website/blob/main/Wireframs%20and%20diagrams/Player%20Profile%20Screen%20Wireframe.png?raw=true "Lobby Search and Creation")

**Game Play Page**
![alt text](https://github.com/BDAhearn/Senior-Project---Multiplayer-Strategy-Game-Website/blob/main/Wireframs%20and%20diagrams/Game%20Interface%20Wireframe.png?raw=true "Game Play Page")

**Player Stats**
![alt text](https://github.com/BDAhearn/Senior-Project---Multiplayer-Strategy-Game-Website/blob/main/Wireframs%20and%20diagrams/Player%20Profile%20Screen%20Wireframe.png?raw=true "Player Stats")

## User Stories
**User Story 1**

As an unregistered user 

I need to be able to register an account 

So that I can create game lobbies and my game stats 
 
 
**User Story 2**

As a registered user

I want private lobbies

So that I can play games with specific friends
 
 
**User Story 3**

As a registered user

I want to open lobbies

So that I can play games whwnever my friends can't
  
  
**User Story 4**

As an unregistered user

I want a temporary account

So that I can play with games with friends and join open lobbies without the hassle of logging in or creating an account
 

**User Story 5**

As a registered user

I want local lobbies

So that I can play games in person with friends
 
 
## Use Cases
**Use Case 1**

*Description*: A new user wants to register an account to create a lobby and track their stats

*The System*: User Registration System

*The Actors*: A New User

*Scenario*: A new user has found the site and would like to register an account to be able to access additional functionality. On any page they can click the "Create Account" button on the top right of the page or on the Welcome Page they click the links in the text body to creat an account. They proceed to enter their username, email, password, and an optional brief discription of themselves. Once registered, they are able to log in and use additional site functionality

*Expected Result*: The user creates a new result and is able to login and use additional site functionality


**Use Case 2**

*Description*: A registered user wants to create a private lobby so they can play with specific friends

*The System*: Lobby Creation

*The Actors*: The User, Their Friends

*Scenario*: A user who has already registered an account and wants to play an online game with their friends. They go to the Games page on the site. On the left there is a lobby Creation panel. They Choose the game they want from a drop down menu and how many players they would like in their lobby (depending on the game's limits). They then choose the private lobby option and give the lobby a password. Once in the game, they copy the url and send it to their friends with the password so they can join. The friends click the link and enter the password when prompted.

*Expected Result*: The User creates a private password protected lobby and their friends join by following a link and entering a password. They then are able to play the game.


**Use Case 3**

*Description*: A registered user wants to create an open lobby so they can play anyone

*The System*: Lobby Creation

*The Actors*: The User, Other Users

*Scenario*: A user who has already registered an account and wants to play an online game with anyone. They go to the Games page on the site. On the left there is a lobby Creation panel. They Choose the game they want from a drop down menu and how many players they would like in their lobby (depending on the game's limits). They then choose the open lobby option. Once in the game, they wait for other users to join. Once the desired number joins they play the game.

*Expected Result*: The User creates an open lobby for anyone to join. After other players join it, they play the game.


**Use Case 4**

*Description*: An unregistered user does not wish to register an account and would only like to join friends and open lobbies

*The System*: User Registration System

*The Actors*: The Unregistered User 

*Scenario*: The Unregistered User wants to game without setting up an account. They would do this by joining a lobby. Once they join a lobby when they aren't logged in, the system will generate a temporary account with a generic username for them to use for this session.

*Expected Result*: The Unregistered User joins a lobby and is given a temporary account with a generic username, they then can play the game.


**Use Case 5**

*Description*: A registered user wants to play a game with friends who are in the meatspace with them but lack the physical games.

*The System*: Lobby Creation

*The Actors*: The User, Their Friends in Meatspace

*Scenario*: The User would like to play a game hosted by the site with friends who are physically near them but lack the physical resources to play the games. They go to the Games page on the site. On the left there is a lobby Creation panel. They Choose the game they want from a drop down menu and how many players they would like in their lobby (depending on the game's limits). They then choose the local lobby option. Once in the game, they take turns on the same device making their moves.

*Expected Result*: The User and their friends in meatspace are able to create a local lobby and play the game.
## Use-Case Diagram
![alt text](https://github.com/BDAhearn/Senior-Project---Multiplayer-Strategy-Game-Website/blob/main/Wireframs%20and%20diagrams/Use%20Case%20Diagram%20UML.png?raw=true "Use-Case Diagram UML")

## Requirements
|**ID**|**Requirements**|
|--|-----|
|R-1|The software shall allow users to play games of their choice that is offered either locally, with a private lobby online, or an open lobby as they choose.|
|R-2|The software should allow private lobbies to be password protected.|
|R-3|The software shall allow users to play the game real time without having to refresh their webpage.|
|R-4|The software shall allow users to use either temporary accounts or accounts that they create.|
|R-5|The software shall allow only the user who created the account to access their account.|
|R-6|The software shall allow the user to track which games they play the most and how often they win and lose.|
|R-7|The database should keep track of all of the games played with the final board, the users who played, and the winner.|
|R-8|The software shall allow the games to run without users cheating.|
|R-9|The software shall notifiy users when a game is complete.|

## ERD Diagram
![alt text](https://github.com/BDAhearn/Senior-Project---Multiplayer-Strategy-Game-Website/blob/main/Wireframs%20and%20diagrams/ERD%20Diagram.png?raw=true "ERD Diagram")

## UML Class Diagram 
![alt text](https://github.com/BDAhearn/Senior-Project---Multiplayer-Strategy-Game-Website/blob/main/Wireframs%20and%20diagrams/UML%20Class%20Diagram%20.png?raw=true "UML Class Diagram")
