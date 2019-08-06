### Example Electorate Pack

![Data structure](https://g.gravizo.com/svg?
@startuml;
!define Lookup(name,desc) object "desc" as name;
!define CoreEntity(name,desc) object "desc" as name;
CoreEntity(jurisdiction, "Jurisdiction");
CoreEntity(bundle, "Bundle");
CoreEntity(pack, "Pack");
CoreEntity(comments, "Discussions");
CoreEntity(electorate, "Electorate");
Lookup(mappoint, "MapPoint");
Lookup(briefs, "Briefs");
Lookup(commitments, "Commitments");
Lookup(reports, "Reports");
Lookup(statistics, "Statistics");
jurisdiction "1" -> "*" bundle ;
bundle "1" -> "*" pack;
pack "0" --> "*" electorate;
electorate "0" --> "*" comments;
electorate "0" --> "*" mappoint;
electorate "0" --> "*" briefs;
electorate "0" --> "*" commitments;
electorate "0" --> "*" reports;
electorate "0" --> "*" statistics;
note "See Discussion Service" as N1;
comments .. N1;
note "See Commitments Service" as N2;
commitments .. N2;
note "See Briefs Service" as N3;
briefs .. N3;
@enduml;
)