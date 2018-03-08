# Unshare


```plantuml format="svg" classes="uml myDiagram""
@startuml
!include /docs/includes/theme.iuml

title Unshare Pack/Brief

partition "DSuite Collaboration" {
  (*) --> "Edit Distribution"
  --> === S1 ===
}

partition "DSuite AMR" {
  === S1 === --> "Remove Brief To AMR User Databases"
  --> === S2 ===
}

partition "DSuite Reader" {
  === S2 === --> "Synchronise user's available Briefs"    
  --> === S3 ===
}

=== S1 === -down-> (*)
=== S2 === -down-> (*)
=== S3 === -down-> (*)


@enduml
```

