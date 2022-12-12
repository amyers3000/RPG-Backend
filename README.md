**RPG Player .NET Backend**

Inspired by classic RPG video games, this API allows users to create characters, assign skills and weapons, view all characters that belong to them, initate fights and view the current highscore. This backend was built to simulate a professional web service API. The applicaiton uses techniques and best practices such as Service Response Objects, DTOs, Dependency Injections, Services, Seeding Data and follows an MVC archtecture. This API was constructed to help solidfy my .NET/C# knowledge and help draw comparisons between other backend languages/framewords such as Node.js.

Please note: Due to learning purposes, the second branch includes notes taken from both the web and the [ASP.NET/C#](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio) docs.

***Languages and Tools:***
Entity Frameworks | C# | ASP.NET 7 | SQL Lite | AutoMapper | JWT

***How to Run API***

1. Fork and clone repo
2. Make sure proper .NET SDK is installed
3. In terminal run dotnet watch run

*** Attributes ***

Only 30 attribute points can be assigned to a character. There are 3 attributes:

1. Intelligence - Increases odds that a higher damage value will be generated for a weapon upon being assigned to character. Intelligence will increase the odds of a critical strike(more damage) when attacking an opponent with a skill.
2. Strength - Strength will increase the odds of a critical strike (more damage) when attacking an opponent with a weapon.
3. Defense - Defense will decrease the odds of a critical strike (more damage) from an opponent.

***Skills***

Mages are more susceptible to Archer attacks - increased odds of a critical strike

Warriors are more susceptible to Mage attacks - increased odds of a critical strike

Archers are more susceptible to Warrior attacks - increased odds of a critical strike

| Id | Skill | Damage | Type |
| - | -------| -------| ---- |
| 1 | Fireball | 30 | Mage |
| 2 | Frenzy | 32 | Mage |
| 3 | Blizzard | 28 | Mage |
| 4 | Thunder | 30 | Mage |
| 5 | Side-Swipe | 20 | Warrior |
| 6 | Slasher | 18 | Warrior |
| 7 | Precision Shot | 30 | Archer |

***Weapons***

Weapons can be given any name and assigned a type however the damage attribute is randomly assigned. A user can increase there odds of getting a higher damage attribute for there weapon by:
1. Having the type of weapon match the class of the character
2. Having high intelligence

***Routes***

| Method | Route | Description |
|--------|-------|-------------|
| Post | /api/Character | Allows user to create a character and assign attributes. Only 30 attribute points are available. (requires authorization) |
| Put | /api/Character | Allows user to update a specific user they created (requires authorization) |
| Get | /api/Character/GetAll | Allows user to view all characters that they created (requires authorization) |
| Get | /api/Character/{id} | Allows user view a single character that they created (requires authorization) |
| Delete | /api/Character/{id} | Allows user to delete a user that they created (requires authorization) |
| Post | /api/Character/Skill | Allows user to assign predefined skills to a character they made (requires authorizaiton) |

| Method | Route | Description |
|--------|-------|-------------|
| Post | /Fight/Weapon | A character attacks an opponent with their weapon causing damage and reducing opponent HP |
| Post | /Fight/Skills | A character attacks an opponent with one of their skills causing damage and reducting opponent HP |
| Post | /Fight | Allows user to choose multiple characters to battle to the death returning a log of events. After fight all HP is restored |
| Get | /Fight | Shows highscore |

| Method | Route | Description |
|--------|-------|-------------|
| Post | /Weapon | Allows user to assign a weapon to their character (requires authorization) |




