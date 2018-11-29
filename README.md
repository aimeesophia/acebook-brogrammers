# Acebook #

## Description ##
Acebook is a C# application developed by team Brogrammers. It is a social media application allowing users to register accounts and create, comment on, and like posts.

## Technologies Used ##
* ASP.NET Core 2.2
* ASP.NET MVC 5
* C#
* .NET Framework 4.7.2
* .NET Standard 2
* NUnit
* Selenium
* SQL Express
* HTML
* JavaScript
* jQuery
* CSS
* Bootstrap
* TeamCity
* Octopus
* Osprey

## Process ##
Our [wiki](https://github.com/aimeecraig/acebook-brogrammers/wiki/Acebook-Wiki) discusses our production process for this challenge.

## How to Install and Use ##
1. Clone the repository

```
git clone https://github.com/aimeecraig/acebook-brogrammers.git
```

2. Navigate into the project directory
```
cd acebook-brogrammers
```

## How to Set Up Databases ##

To install PostgreSQL:
```
brew install postgresql
```
```
ln -sfv /usr/local/opt/postgresql/*.plist ~/Library/LaunchAgents
launchctl load ~/Library/LaunchAgents/homebrew.mxcl.postgresql.plist
```
Once you have PostgreSQL installed, follow these instructions to set up databases for this project:

1. Connect to psql
```
psql
```
2. Create the acebook database
```
CREATE DATABASE acebook;
```
3. Connect to the acebook database
```
\c acebook
```
4. Create the posts table
```
CREATE TABLE posts(id SERIAL PRIMARY KEY, content VARCHAR(200));
```
5. Create the users table
```
CREATE TABLE users(id SERIAL PRIMARY KEY, username VARCHAR(20), password VARCHAR(200));
```
6. Ensure that the DefaultConnection in appsettings.json refers to your connection (you may have to update the Username). e.g.:
```
"Host=localhost;Port=5432;Username=YOUR_USERNAME_HERE;Database=acebook;"
```

## Learning Objectives ##
1. I can TDD fizzbuzz in C#
2. I can explain what the .NET platform is
```
This is outlined in the Core Concepts section of our [wiki](https://github.com/aimeecraig/acebook-brogrammers/wiki/Acebook-Wiki)
```
3. I can add create, update and delete endpoints to the demo app (and test them using postman)
4. I can manage dependencies
5. I can TDD a .NET app that shows 'hello, world' at localhost:5001/
```
This is the application in the helloWorld folder.
```

## Contributors ##
* [Aimee Craig](https://github.com/aimeecraig)
* [John Littler](https://github.com/JSLittler)
* [Melissa Sedgwick](https://github.com/melissasedgwick)
* [Terry Mace](https://github.com/Tolvic)
