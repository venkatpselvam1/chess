# OVerview
It is a chess game written using .Net API, HTML and JS. Two players can play the game. The game will show the hint when user click on a piece. The user can move the piece by choosing the hint. If the opponent King is taken, then the player wins.



# Demo
![](https://raw.githubusercontent.com/venkatpselvam1/chess/master/Demo/ChessDemo.gif)

# Architecture
It is 3 tier application. The game's core logic will be written as business logic. Using the HTTP API's we can move the pieces. We have an refresh API, which fetch the state of the board after each event and print the board again. Printin the board is written in the HTML using the current state fetched by the API.

Along with API interface, we have CLI interface through which also we can play the game. But it is not user-friendly.

![](https://raw.githubusercontent.com/venkatpselvam1/chess/master/Demo/Architecture.jpg)
