# Example Briefing Pack 

![Data structure](https://g.gravizo.com/svg?
@startuml;
object "Jurisdiction" as jurisdiction;
object "Bundle" as bundle;
object "Pack" as pack;
object "Folder" as folder;
object "Brief" as briefing;
object "Document" as brief;
object "Attachment" as attachment;
object "Discussion" as discussion;
object "Status" as status;
object "Recommended Direction" as recommed;
object "Recommendation" as recommendation;
object "Recommendation Options" as options;
object "Recommendation Response" as action;
jurisdiction "1" -> "*" bundle ;
bundle "1" -> "*" pack ;
pack "1" --> "*" folder ;
folder "1" -> "0..*" folder ;
folder "1" -> "0..*" briefing  ;
briefing "1" --> "1" brief ;
briefing "1" --> "0..3" discussion ;
briefing "1" --> "0..*" attachment ;
briefing "1" --> "0..*" status ;
briefing "1" --> "0..*" recommed ;
recommed "1" --> "1..*" options ;
recommed "1" --> "0..1" recommendation ;
recommed "1" --> "0..*" action ;
options "1" --> "0..*" action ;
note "See Discussion Service" as N1;
discussion .. N1;
note "See Document Service" as N2;
brief .. N2;
attachment .. N2;
@enduml;
)

