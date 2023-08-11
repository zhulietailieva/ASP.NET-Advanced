# Trail Ventures
ASP.NET Core MVC web application developed during SoftUni ASP.NET Advanced-May2023 course
## Project Overview
![landing_page](https://github.com/zhulietailieva/ASP.NET-Advanced/assets/91086964/3f19856a-5249-4193-a738-20e0d680fbdb)

## Table of Contents

- [Introduction](#introduction)
- [Technologies Used](#technologies-used)
- [Architecture](#architecture)
- [Database Design](#database-design)
- [Setup](#setup)
- [Features](#features)
- [APIs and External Integrations](#apis-and-external-integrations)
- [License](#license)

## Introduction
TrailVentures is a a web application for people who want to participate in an organised hike in the mountain. 
It is designed for people to create or sign up for trips. You register as a user, who can join trips and leave them. You can aslo become a guide and organise and create trips that are one or more days. Guides can also register huts and edit existing ones. Only administrator can register mountains in the web application.
## Technologies Used

- **ASP.NET Core 6 MVC**
- **ASP.NET Core Areas**
- **Entity Framework Core**
- **ASP.NET Identity**
- **Bootstrap**
- **Razor ViewEngine**
- **Toatstr**
- **NUnit**
- **Swagger**
- **ReCaptcha**

## Architecture
![363859055_1771958426596871_4643915147751044916_n](https://github.com/zhulietailieva/ASP.NET-Advanced/assets/91086964/273e5692-5e14-4d25-baed-6b180d1ec9b6)

## Database Design
![database_diagram](https://github.com/zhulietailieva/ASP.NET-Advanced/assets/91086964/aeede285-c4e8-4cbd-8963-71b0ef75c047)

Databas has admin:
- admin@trailventures.bg    password:123456 - admin 

## Setup
Configure both these project as startup project to enable statistics on Index page:
![startup_projects](https://github.com/zhulietailieva/ASP.NET-Advanced/assets/91086964/abd7e1ce-14db-43b1-a682-b822460aff1d)

*if "Update-Database" fails, please delete Migrations folder and then run Add-Migration Initial and then then run Update-Database
## Features

## APIs and External Integrations

Integration with swagger API for statistics on Index page

## License
MIT licence
