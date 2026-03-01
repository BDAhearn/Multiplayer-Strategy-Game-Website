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
The strategy multiplayer game website will allow players to create lobbies to play other players in various games. While the primary focus is being able to play games, it will also have other features that facilitate this. These include account creation, lobby creation, and stat tracking. Lobbies will be able to be either open to everyone online, private to only people with the password, or completely local. Players will be able to create new lobbies or join existing ones of the game type they would like. The initial games will be simple games like tic-tac-toe or connect four but will be able to support more complext games like checkers or chess. The games will be played in real time and the gameboard will be updated for both players after one makes a move. The stats will be shown on each players page with the games they most played along with their win/loss/draw/forfiet ratios.

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
