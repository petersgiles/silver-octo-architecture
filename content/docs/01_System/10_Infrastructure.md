# Briefing System

![Data structure](https://g.gravizo.com/svg?
@startuml;
component businessengagement as "Business Engagement Team";
component taskmanagement as "Requirements Management";
component developmentteam as "Development Team";
component sourcecontrol as "Source Control";
component build as "Application Build Server";
component deployment as "Application Deployment";
component iis as "IIS"; 
component eventbus as "Event Bus";
component sharepoint as "SharePoint";
component notifications as "Notifications";
component archive as "Archive";
component search as "Search";
component logging as "SEQ logging";
component sqlserver as "SQL Server"; 
component webapps as "Web Apps";
component webapis as "Web APIs";
component adfs as "ADFS Auth";
component fedauth as "Vangard";
component identity as "Identity";
component msofficeonline as "MS Office Online";
component msoffice as "MS Office";
component browser as "Browser";
component email as "Email";
component print as "Print and Offline";
businessengagement . taskmanagement;
taskmanagement .. developmentteam;
developmentteam . sourcecontrol;
sourcecontrol .. build;
build .. deployment;
deployment ... iis;
deployment ... sharepoint;
deployment ... sqlserver;
deployment ... eventbus;
iis .. webapps;
iis ..webapis;
identity .. webapps;
sharepoint .. msoffice;
sharepoint .. msofficeonline ;
msofficeonline .. msoffice;
eventbus .. sharepoint;
eventbus .. sqlserver;
eventbus .. archive;
eventbus .. notifications;
eventbus .. email;
eventbus ... logging;
sqlserver .. identity;
sqlserver .. webapis;
sqlserver .. notifications;
search .. archive;
search .. sqlserver;
search .. sharepoint;
logging .. webapps;
logging .. webapis;
browser .. webapps;
webapps .. webapis;
archive .. webapis;
print .. eventbus;
print .. sqlserver;
adfs . fedauth;
adfs ... webapps;
adfs ... webapis;
adfs ... sharepoint;
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
