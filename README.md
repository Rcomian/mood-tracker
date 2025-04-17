Mood Tracker
============

## Overview

This application is a very basic mood tracker, keeping a record of moods over time.

## Technical

This is a simple service that can serve as a skeleton application.

It includes the following:

* Self-hosted backend API in C# .net
* Angular front-end with bootstrap
* JWT based authentication
* SQL Server data storage

## System requirements

* Dotnet v9+
* Node v22+
* SQL Server + sqlcmd

## Setup

Ensure that the backend has the correct connection string for your sql server instance, by modifying the file:

`mood-tracker/backend/MoodTracker.API/appsettings.json`

You can set up the database with some simple sample data by running the following from the "scripts" directory:

`sqlcmd -S localhost -U sa -P 'Your_password123' -i ../sql/full-init.sql`

## Running

To run the backend, from the "backend" directory, run:

`dotnet run --urls="http://localhost:5000" --project MoodTracker.API`

To run the frontend (development mode), in the frontend directory, run:

`npx ng serve`

## Login

You can sign in with the test user:

* username: testuser
* password: secret123

