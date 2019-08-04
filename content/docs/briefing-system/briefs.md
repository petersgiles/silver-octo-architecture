# Briefs

## Briefs are containers

They can hold multiple documents, links, converations and other supporting information that constitutes a complete brief

![Data structure](https://g.gravizo.com/svg?
@startuml;
class Container{;
  id GUID;
  parentid GUID;
};
class Brief extends Container {;
  type string;
};
@enduml;
)

## Document Container relationship

![Data structure](https://g.gravizo.com/svg?
@startuml;
!define Table(name,desc) class name as "desc" <<(T,#FFAAAA) >>;
!define primary_key(x) <b>x</b>;
!define unique(x) <color:green>x</color>;
!define not_null(x) <u>x</u>;
Table(document, "Document") {;
    primary_key(id) GUID;
    inlineData boolean;
};
Table(container, "Container") {;
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

