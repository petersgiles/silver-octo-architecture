# Pack Navigation

## Terms

<dl>
  <dt>Jurisdiction</dt>
  <dd>Department or Business Entity</dd>
  <dd>A jurisdiction has one or more bundles</dd>

  <dt>Bundle</dt>
  <dd>A bundle has one or more packs</dd>

  <dt>Folder</dt>
  <dd>A folder has zero to many folders</dd>
  <dd>A folder has zero to many briefings</dd>

  <dt>Briefing</dt>
  <dd>A briefing may have zero to one brief</dd>
  <dd>A briefing may have zero to three discussions</dd>  
  <dd>A briefing may have zero to many attachment</dd>  

  <dt>Brief</dt>
  <dd>A document managed by sharepoint</dd>  

  <dt>Attachment</dt>
  <dd>A document managed by sharepoint</dd>  

  <dt>Discussion</dt>
  <dd>A discussion may have zero to many messages</dd>  

  <dt>Message</dt>
  <dd>A message is just text</dd>  

</dl>

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
jurisdiction "1" --> "*" bundle 
bundle "1" --> "*" pack 
pack "1" --> "*" folder 
folder "1" --> "0..*" folder 
folder "1" --> "0..*" briefing  
briefing "1" --> "1" brief 
briefing "1" --> "0..3" discussion  
briefing "1" --> "0..*" attachment 
discussion "1" --> "0..*" message  

@enduml
```