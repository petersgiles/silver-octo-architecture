# Commitments

![Data structure](https://g.gravizo.com/svg?
@startuml;
!define Lookup(name,desc) class name as "desc" << (L,#AAFFAA) >>;
!define CoreEntity(name,desc) class name as "desc" << (E,#AAAAFF) >>;
CoreEntity(brief, "Brief");
brief .. brief;
brief .. comment;
comment .. comment;
@enduml;
)
