# EF DataModel


```plantuml format="svg" classes="uml myDiagram"
@startuml
!include /docs/includes/theme.iuml
!include /docs/includes/erd.iuml


hide methods
hide stereotypes

' entities

Table(document, "Document") {
    primary_key(id) GUID
    inlineData boolean
}

Table(container, "Container") {
    primary_key(id) GUID
    parentid GUID 
    createdutc datetime
    modifiedutc datetime
    type string
}

Table(documentcontainer, "DocumentToContainer") {
    primary_key(documentid) GUID
    primary_key(containerid) GUID
}

Table(ext_key_sp, "Sharepoint Key Mapping") {
    primary_key(id) GUID
    primary_key(web_url) VARCHAR[32]
    primary_key(list_id) GUID
    primary_key(item_id) INTEGER
}


' relationships
container "0" --> "1" container 
documentcontainer "0" --> "*" container 
documentcontainer "0" --> "*" document 
document  "1" ...> "0..1" ext_key_sp 

@enduml
```