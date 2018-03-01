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

### Briefing
  - A briefing may have zero to one brief
  - A briefing may have zero to three discussions  
  - A briefing may have zero to many attachment  

### Brief
  - A document managed by sharepoint  

### Attachment
  - A document managed by sharepoint  

### Discussion
  - A discussion may have zero to many messages  

### Message
  - A message is just text  


## Logical Relationship diagram

```plantuml format="svg" classes="uml myDiagram"
@startuml
!include /docs/includes/theme.iuml


object "Jurisdiction" as jurisdiction
object "Bundle" as bundle
object "Pack" as pack
object "Folder" as folder
object "Briefing" as briefing
object "Brief" as brief
object "Attachment" as attachment
object "Discussion" as discussion
object "Message" as message

' relationships
jurisdiction "1" --> "  * " bundle 
bundle "1" --> "  * " pack 
pack "1" --> "  * " folder 
folder "1" --> "0..  * " folder 
folder "1" --> "0..  * " briefing  
briefing "1" --> "1" brief 
briefing "1" --> "0..3" discussion  
briefing "1" --> "0..  * " attachment 
discussion "1" --> "0..  * " message  

@enduml
```