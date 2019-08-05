# Briefing System

![Data structure](https://g.gravizo.com/svg?
@startuml;
component adfs as "ADFS Auth";
component fedauth as "Vangard";
component identity as "Identity";
component browser as "Browser";
component msoffice as "MS Office";
component msofficeonline as "MS Office Online";
component email as "Email";
component print as "Print and Offline";
component sharepoint as "SharePoint";
component iis as "IIS"; 
component logging as "SEQ logging";
component sqlserver as "SQL Server"; 
component archive as "Archive";
component search as "Search";
component webapps as "Web Apps";
component webapis as "Web APIs";
component notifications as "Notifications";
component eventbus as "Event Bus";
component adfs as "ADFS Auth";
component developmentteam as "Development Team";
component businessengagement as "Business Engagement Team";
component sourcecontrol as "Source Control";
component taskmanagement as "Requirements Management";
component build as "Application Build Server";
component deployment as "Application Deployment";
browser .. webapps;
webapps .. webapis;
iis .. webapps;
iis ..webapis;
webapps .. identity;
msoffice .. sharepoint;
msofficeonline .. sharepoint;
msoffice .. msofficeonline;
eventbus .. sharepoint;
eventbus .. sqlserver;
eventbus .. archive;
eventbus .. notifications;
eventbus .. email;
eventbus .. print;
sqlserver .. print;
sqlserver .. identity;
sqlserver .. webapis;
sqlserver .. notifications;
archive .. webapis;
search .. archive;
search .. sqlserver;
search .. sharepoint;
adfs . fedauth;
adfs ... webapps;
adfs ... webapis;
adfs ... sharepoint;
logging ... eventbus;
logging .. webapps;
logging .. webapis;
businessengagement . taskmanagement;
taskmanagement .. developmentteam;
developmentteam . sourcecontrol;
sourcecontrol .. build;
build .. deployment;
deployment ... iis;
deployment ... sharepoint;
deployment ... sqlserver;
deployment ... eventbus;
@enduml;
)

## Authentication

Provided via ADFS 4 federated to Vangard.

## Identity

What the user is permitted to do

## Profile

User presentation, config, and preferences.

## MS Office & SharePoint

Provides clients and services that support co-authoring.

## Mobile Iron

Provides management and access to Web Apps on mobile devices

## SharePoint Events

Provide SharePoint platform activity data to the distributed system.

## Notifications

A Service for managing subscriptions for notification of significant system events.

## Web Apps

Applications that allows users to manage information.

## Web API

Data Services