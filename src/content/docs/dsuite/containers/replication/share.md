
# Sharing

```plantuml format="svg" classes="uml myDiagram""
@startuml
!include /docs/includes/theme.iuml

title Share Pack/Brief

partition "DSuite Collaboration" {
  (*) --> "Create/Modify Pack/Brief" 
  --> "Edit Distribution"
  --> === S1 ===
}

partition "DSuite AMR" {
  === S1 === --> "Add/Update Pack/Brief in AMR User Databases"
  --> === S2 ===
}

partition "DSuite Reader" {
  === S2 === --> "Synchronise user's available Pack/Brief"  
  --> === S3 ===
}

=== S1 === -down-> (*)
=== S2 === -down-> (*)
=== S3 === -down-> (*)


@enduml
```

