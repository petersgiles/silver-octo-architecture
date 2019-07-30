# Briefing System

![Data structure](https://g.gravizo.com/svg?
@startuml;
node "Authentication and Identity" {;
component adfs as "ADFS Auth";
component fedauth as "Vangard";
component identity as "Identity";
};
node "Desktop and Mobile" {;
component browser as "Browser";
component msoffice as "MS Office";
component msofficeonline as "MS Office Online";
component email as "Email";
component print as "Print and Offline";
};
node "Platforms and Infrastructure" {;
component sharepoint as "SharePoint";
component iis as "IIS"; 
component logging as "SEQ logging";
component sqlserver as "SQL Server"; 
};
node "Digital First" {;
component webapps as "Web Apps";
component webapis as "Web APIs";
component notifications as "Notifications";
component eventbus as "Event Bus";
};
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
eventbus .. notifications;
eventbus .. email;
eventbus .. print;
sqlserver .. print;
sqlserver .. identity;
sqlserver .. webapis;
sqlserver .. notifications;
adfs .. webapps;
adfs .. webapis;
adfs .. sharepoint;
adfs ..fedauth;
logging .. eventbus;
logging .. webapps;
logging .. webapis;
@enduml;
)

## Authentication

Provided via ADFS 4 federated to Vangard.

## Identity

Provided with [Identity Server.](http://docs.identityserver.io/en/latest/index.html)

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

[TODO](.\todo.md)

[Generic Data Structures](.\generic-data-structures.md)
