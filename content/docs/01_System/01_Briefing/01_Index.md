# Briefing

## Briefs, Commitments and Electorates are containers

They can hold multiple documents, links, conversations and other supporting information that constitutes a complete rendering of information exchange.

![Data structure](https://g.gravizo.com/svg?
@startuml;
package "Briefing" {;
together {;
class Portfolio;
Container ()- Portfolio ;
class Bundle;
Container ()- Bundle ;
Portfolio *-- Bundle ;
class Pack;
Container ()- Pack ;
Bundle *-- Pack ;
class Folder;
Container ()- Folder ;
Pack *-- Folder ;
};
together {;
class Brief;
Container ()-- Brief ;
Folder o-- Brief ;
class Recommendation;
Brief *-- Recommendation ;
class RecommendedDirection;
Brief *--  RecommendedDirection ;
class RecommendedAction;
RecommendedDirection *-- RecommendedAction ;
};
together {;
class Commitment;
Container ()- Commitment ;
Folder o-- Commitment ;
};
together {;
class Electorate;
Container ()- Electorate ;
Folder o-- Electorate ;
};
together {;
class Discussion;
Container ()- Discussion ;
Brief *-- Discussion ;
Commitment *-- Discussion ;
Electorate *-- Discussion ;
note "See Discussion Service" as N1;
Discussion .. N1;
};
Brief .. Commitment;
Brief .. Electorate;
Electorate .. Commitment;
};
@enduml;
)


# Pack Navigation

## Terms

### Jurisdiction

  - Department or Business Entity e.g PM &amp; C, Queensland State Goverment or any Workplace with a Reporting Structure 
  - A jurisdiction has one or more bundles

### Bundle

  - A discrete set of Packs relating to several topics e.g. Parlimentary, Reports, Travel
  - A bundle has one or more packs

### Pack

  - A heirachy of briefing material often for a specific topic like Travel or Questions on Notice
  - A pack has zero to many folders

### Folder

  - A way to group items within packs and other folders
  - A folder has zero to many folders
  - A folder has zero to many briefings

### Brief

  - A container of prepared information on a specific subject
  - A brief may have zero to one brief
  - A brief may have zero to many discussions  
  - A brief may have zero to many attachments  

### Commitment

  - A container of prepared information in response to a Commitment given to the Australian People
  - It may have one Commitment
  - It may belong to one political party
  - It may be related to other commitments
  - It may have zero to many discussions  
  - It may be related to other briefs  

### Electorate

  - A container prepared to inform a minister on the circumstances in an Electorate
  - It may belong to one political party
  - It may be related to zero to many Commitments
  - It may have zero to many Discussions  
  - It may be related to zero to many Briefs  

### Primary Document (Brief)

  - A document managed by SharePoint 
  - A document is often prepared using Microsoft Word  

### Ancillary Documents (Attachment)

  - A document managed by SharePoint 
  - A document is often prepared using Microsoft Word 

## SharePoint Document to Brief

![Data structure](https://g.gravizo.com/svg?
@startuml;
!define Table(name,desc) class name as "desc" <<(T,#FFAAAA) >>;
!define primary_key(x) <b>x</b>;
!define unique(x) <color:green>x</color>;
!define not_null(x) <u>x</u>;
Table(document, "Document") {;
    primary_key(id) GUID;
    renderedDocumentUrl GUID;
};
Table(container, "Brief") {;
    primary_key(id) GUID;
    parentid GUID; 
    createdutc datetime;
    modifiedutc datetime;
    type string;
};
Table(documentcontainer, "DocumentToContainer") {;
    primary_key(documentid) GUID;
    primary_key(containerid) GUID;
};
Table(ext_key_sp, "Sharepoint Key Mapping") {;
    primary_key(id) GUID;
    primary_key(web_url) VARCHAR[32];
    primary_key(list_id) GUID;
    primary_key(item_id) INTEGER;
};
container "0" --> "1" container; 
documentcontainer "0" --> "*" container ;
documentcontainer "0" --> "*" document; 
document  "1" ..> "0..1" ext_key_sp;
@enduml;
)
