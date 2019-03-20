# Pack Navigation

## Terms

### Jurisdiction

  - Department or Business Entity e.g PM &amp; C, Queensland State Goverment or any Workplace with a Reporting Structure 
  - A jurisdiction has one or more bundles

### Bundle

  - A discrete set of Packs relating to a topic e.g. Parlimentary, Reports, Travel
  - A bundle has one or more packs

### Pack

  - A particular topic  
  - A pack has zero to many folders

### Folder

  - A folder has zero to many folders
  - A folder has zero to many briefings

### Brief

  - A brief may have zero to one brief
  - A brief may have zero to three discussions  
  - A brief may have zero to many attachment  

### Primary Document (Brief)

  - A document managed by sharepoint  

### Ancillary Documents {Attachment)

  - A document managed by sharepoint  

### Discussion

  - A discussion may have zero to many messages  

### Comment

  - Like a Post on a social media site  

## Logical Relationship diagram

```plantuml
@startuml

object "Jurisdiction" as jurisdiction
object "Bundle" as bundle
object "Pack" as pack
object "Folder" as folder
object "Briefing" as briefing
object "Brief" as brief
object "Attachment" as attachment
object "Discussion" as discussion
object "Comment" as comment
object "Status" as status
object "Recommended Direction" as recommed
object "Recommendation" as recommendation
object "Recommendation Options" as options
object "Recommendation Response" as action


' relationships
jurisdiction "1" --> "*" bundle 
bundle "1" --> "*" pack 
pack "1" --> "*" folder 
folder "1" --> "0..*" folder 
folder "1" --> "0..*" briefing  
briefing "1" --> "1" brief 
briefing "1" --> "0..3" discussion  
briefing "1" --> "0..*" attachment 
briefing "1" --> "0..*" status 
briefing "1" --> "0..*" recommed 
recommed "1" --> "1..*" options 
recommed "1" --> "0..1" recommendation 
recommed "1" --> "0..*" action 
options "1" --> "0..*" action 

discussion "1" --> "0..*" comment  

@enduml
```