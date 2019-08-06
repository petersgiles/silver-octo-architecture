# Example Commitment Pack

![Data structure](https://g.gravizo.com/svg?
@startuml;
!define Lookup(name,desc) object "desc" as name;
!define CoreEntity(name,desc) object "desc" as name;
CoreEntity(jurisdiction, "Jurisdiction");
CoreEntity(bundle, "Bundle");
CoreEntity(pack, "Pack");
CoreEntity(commitment, "Commitment");
CoreEntity(comments, "Discussions");
CoreEntity(contact, "Contact");
CoreEntity(electorate, "Electorate");
CoreEntity(costing, "Costing");
Lookup(mappoint, "MapPoint");
Lookup(package, "Package");
Lookup(portfolio, "Portfolio");
Lookup(theme, "Theme");
Lookup(politicalparty, "Political Party");
jurisdiction "1" -> "*" bundle ;
bundle "1" -> "*" pack : "Political Party" ;
pack "0" --> "*" commitment;
commitment "0" -> "*" commitment;
commitment "0" --> "*" comments;
commitment "0" --> "*" contact;
commitment "0" --> "*" electorate;
commitment "0" --> "*" costing;
commitment "0" --> "*" mappoint;
commitment "0" --> "*" package;
commitment "1" --> "*" portfolio;
commitment "0" --> "*" theme;
commitment "1" --> "1" politicalparty;
note "See Discussion Service" as N1;
comments .. N1;
@enduml;
)

