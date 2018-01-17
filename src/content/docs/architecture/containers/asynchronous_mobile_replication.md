hero: Asynchronous Mobile Replication
title: Asynchronous Mobile Replication
description: C4 Component (Asynchronous Mobile Replication).

# Asynchronous Mobile Replication

![diagram](asynchronous_mobile_replication.svg)

[PNG](asynchronous_mobile_replication.png) | [SVG](asynchronous_mobile_replication.svg)


## Background

In most cases, devices will be continuously connected to the enterprise network via a mobile device management (MDM) solution. Traditional, synchronous (‘just in time’) delivery of content is achieved as the data services are always reachable.

It is not uncommon, for mobile users to spend periods of time disconnected from the enterprise network – particularly when they are travelling. During these periods, a method of asynchronously transferring and storing content locally on the mobile device is required. Most applications that require this functionality (such as email) maintain a local database for this purpose, but no standard currently exists at PM&C for internally developed applications.

## CouchDB

In order to provide VIP access to their briefing materials while disconnected, client applications will make use of CouchDB.
The system is architected to act as a broker between a separate System of Record (SOR) and an end user on a mobile device. No information is stored on CouchDB that is not also held on this SOR. Documents are created and modified primarily on the SOR and publication to CouchDB occurs only after explicit approval.

- A lightweight service routinely queries the SOR to identify any documents that are marked as ready to share to named users. It stores this information in an Enterprise Service Bus (ESB) to ensure that no documents are lost.
- Another service regularly extracts user-level data from the ESB, transforms it and inserts it into a dedicated CouchDB database for that user. Separate databases ensure complete logical separation of user data and have no detrimental effect on the performance of the system.
- When a connection to the corporate network can be established via the Enterprise Mobile Device Management solution, the application connects to CouchDB. CouchDB authenticates the current user of the device, and then determines which documents they are authorised to access. 
- Once this process is complete, the mobile application pulls down any new or modified document information for that user, storing it locally in PouchDB. If documents have been modified locally by the user, these changes are pushed to a separate CouchDB database for integration with the SOR.

## Components

### Infrastructure

The Asynchronous Mobile Replication solution is designed to operate within the current infrastructure requirements of the Department. Except where explicitly outlined in this document, it will leverage existing compute, storage and network patterns. This includes settings which directly affect compliance with the regulatory and legal obligations of the Department.

### CouchDb

CouchDB is an open source NoSQL database that is developed by the Apache Software Foundation under version 2.0 of the Apache License. CouchDB is designed with offline use in mind, and it inherently supports asynchronous replication of data between devices that may experience periods of disconnectedness. CouchDB is extensible, scalable and resilient and forms the core of various high-profile solutions such as the JavaScript package manager npm and the BBC for its online content shareing platform.

### PouchDb

PouchDB is a JavaScript library that enables applications to store data locally while offline, then synchronize it with CouchDB and compatible servers when the application is back online, keeping the user's data in sync no matter where they next login. It is extensible and is compatible with all modern browsers. 

### Authentication

The proposed solution leverages a Web API that provides both authentication and authorisation functionality. This API acts as a broker that translates the logged-in user’s credentials into a format that is understood by CouchDB. In addition to restricting information access to those that have a need to know, this model ensures a seamless user experience by facilitating single sign-on (SSO).

### Monitoring and Audit

In addition to application-level performance monitoring, the Asynchronous Mobile Replication solution will record detailed usage, authentication and authorisation events for review by ICT support staff and cyber security analysts.

## Activity

### Share

![diagram](asynchronous_mobile_replication_001.svg)

[PNG](asynchronous_mobile_replication_001.png) | [SVG](asynchronous_mobile_replication_001.svg)

### Unshare

![diagram](asynchronous_mobile_replication_002.svg)

[PNG](asynchronous_mobile_replication_002.png) | [SVG](asynchronous_mobile_replication_002.svg)
