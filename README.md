# GuessingGame.CleanArchitecture
My first clean architecture application

Sample plugin architecture: database and gui are plugins to the business rules

The application gets a number from the user, checks it against a randomly generated number (between 0 and 100) and delivers the appropriate message back to the user.
If the user guesses the number, he has the possibility to view his previous attempts. The user should be able to play again.

The number can retrieved via a file (%temp%\guessinggame\number.in), via stdin (keyboard) or through a web api controller.

The message can be delivered via file (idem\number.out), stdout (console), sms, email or web.

The logging (for showing the previous attempts) can be done via a log file (idem\number.log), in-memory (using stringbuilder), SQL (sqllite and sqlserver through EF Core) and NoSql (mongodb, litedb).

The GUI can be one of the followings: Console, Blazor, Angular or React

All the different implementations can be configured inside the GameController (for the console app) or in the StartUp of each GUI project.
