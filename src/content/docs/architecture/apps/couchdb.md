# Couch DB



## System

![diagram](couchdb.svg)

[PNG](couchdb.png) | [SVG](couchdb.svg)

---

### 1.	Background

An increasing number of government users consume online services via mobile devices. In most cases, these devices will be continuously connected to the enterprise network via a mobile device management (MDM) solution. Traditional, synchronous (‘just in time’) delivery of content is suitable in these cases as the server is always reachable.
It is not uncommon, however, for mobile users to spend periods of time in a disconnected state – particularly when they are travelling. During these periods, a method of asynchronously transferring and storing content locally on the mobile device is required. Most applications that require this functionality (such as email) maintain a local database for this purpose, but no standard currently exists at PM&C for internally developed applications.

## 2.	Solution Architecture

### 2.1.	Overview

In order to provide this asynchronous delivery of information to mobile users, the solution will leverage a combination of CouchDB and PouchDB in a server-client configuration. This section outlines this configuration. Specific product information about CouchDB and PouchDB is available in the Components section of this document.
The system is architected to act as a broker between a separate System of Record (SOR) and an end user on a mobile device. No information is stored on CouchDB that is not also held on this SOR. Documents are created and modified primarily on the SOR and publication to CouchDB occurs only after explicit approval.

### 2.2.	Process

1.	A lightweight service routinely queries the SOR to identify any documents that are marked as ready to share to named users. It stores this information in an Enterprise Service Bus (ESB) to ensure that no documents are lost.
2.	Another service regularly extracts user-level data from the ESB, transforms it and inserts it into a dedicated CouchDB database for that user. Separate databases ensure complete logical separation of user data and have no detrimental effect on the performance of the system.
3.	When a connection to the corporate network can be established via the Enterprise Mobile Device Management solution, the application connects to CouchDB. CouchDB authenticates the current user of the device, and then determines which documents they are authorised to access. 
4.	Once this process is complete, the mobile application pulls down any new or modified document information for that user, storing it locally in PouchDB. If documents have been modified locally by the user, these changes are pushed to a separate CouchDB database for integration with the SOR.

### 2.3.	Components

#### INFRASTRUCTURE

The Asynchronous Mobile Replication solution is designed to operate within the current infrastructure requirements of the Department. Except where explicitly outlined in this document, it will leverage existing compute, storage and network patterns. This includes settings which directly affect compliance with the regulatory and legal obligations of the Department.

#### COUCHDB

CouchDB is an open source NoSQL database that is developed by the Apache Software Foundation under version 2.0 of the Apache License. CouchDB is designed with offline use in mind, and it inherently supports asynchronous replication of data between devices that may experience periods of disconnectedness. CouchDB is extensible, scalable and resilient and forms the core of various high-profile solutions such as the JavaScript package manager npm and the BBC for its online content shareing platform.

#### POUCHDB

PouchDB is a JavaScript library that enables applications to store data locally while offline, then synchronize it with CouchDB and compatible servers when the application is back online, keeping the user's data in sync no matter where they next login. It is extensible and is compatible with all modern browsers. 

#### AUTHENTICATION

The proposed solution leverages a Web API that provides both authentication and authorisation functionality. This API acts as a broker that translates the logged-in user’s credentials into a format that is understood by CouchDB. In addition to restricting information access to those that have a need to know, this model ensures a seamless user experience by facilitating single sign-on (SSO).

#### MONITORING AND AUDIT

In addition to application-level performance monitoring, the Asynchronous Mobile Replication solution will record detailed usage, authentication and authorisation events for review by ICT support staff and cyber security analysts.Requirements

PUC1	Create Document	Document is created on SOR
Information/formatting added to document
PUC2	Share Document with User(s)	Author identifies that document is ready to be shared 
Author shares document with user(s), ACL set
Document marked as shared in SOR
AMR service extracts information from SOR and stores it in ESB
AMR service grooms information from ESB into CouchDB format (JSON) per ACL
AMR service inserts data via CouchDB API 
Document(s) available to user(s) on next refresh
PUC3	Share Document with Additional User(s)	Author identifies that document should be shared with additional user(s)
Author shares document with user, ACL updated
Document marked as shared in SOR
AMR service extracts information from SOR and stores it in ESB
AMR service grooms information from ESB into CouchDB format (JSON) per ACL
AMR service inserts data via CouchDB API
Document(s) available to user(s) on next refresh
PUC4	Unshare Document with Users	Author identifies that document should be unshared with additional users 
Author unshares document with user(s), ACL updated
Document already marked as shared in SOR
AMR service extracts information from SOR and stores it in ESB
AMR service grooms information from ESB into CouchDB format (JSON) per ACL
AMR service inserts data via CouchDB API for authorised users and deletes it for unauthorised users
Document(s) removed from unshared user(s) on next refresh
PUC5	Update Document (SOR)	Author or contributor makes a change to document in SOR
Document already marked as shared in SOR
AMR identifies that document has changed and service extracts information from SOR and stores it in ESB
AMR service grooms information from ESB into CouchDB format (JSON) per ACL
AMR service inserts data via CouchDB API for authorised users
Document update(s) available to user(s) on next refresh
PUC6	Update Document (Mobile)	Author or contributor makes a change to document on mobile application
Mobile application connects to CouchDB
Document update(s) pushed to CouchDB
AMR service identifies document update(s), extracts it from CouchDB and inserts into ESB
AMR service extracts information from ESB and inserts it into SOR
AMR service confirms that update(s) are successfully written to SOR
AMR service deletes information from CouchDB via API
PUC7	Delete Document	Author marks document for deletion in SOR
AMR identifies that document has been marked for deletion in SOR
If document marked as shared in SOR, remove all ACLs and follow PUC4 workflow
PUC8	Unshare Document	Author unshares document in SOR
AMR identifies that document has been marked for deletion in SOR
If document marked as shared in SOR, remove all ACLs and follow PUC4 workflow
PUC9	Monitor Document Access	Authors view access metrics on documents
Administrators view detailed audit information for specific documents



