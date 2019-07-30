# Commitments

![Data structure](https://g.gravizo.com/svg?
@startuml;
!define Lookup(name,desc) class name as "desc" << (L,#AAFFAA) >>;
!define CoreEntity(name,desc) class name as "desc" << (E,#AAAAFF) >>;
CoreEntity(commitment, "Commitment");
CoreEntity(comment, "Comment");
CoreEntity(contact, "Contact");
CoreEntity(electorate, "Electorate");
CoreEntity(costing, "Costing");
Lookup(mappoint, "MapPoint");
Lookup(package, "Package");
Lookup(portfolio, "Portfolio");
Lookup(theme, "Theme");
Lookup(politicalparty, "Political Party");
commitment .. commitment;
commitment .. comment;
commitment .. contact;
commitment .. electorate;
commitment .. costing;
commitment .. mappoint;
commitment .. package;
commitment .. portfolio;
commitment .. theme;
commitment .. politicalparty;
comment .. comment;
@enduml;
)
