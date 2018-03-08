# Core

## ER Diagram



```plantuml format="svg" classes="uml myDiagram"
@startuml
!include /docs/includes/theme.iuml
!include /docs/includes/typescript.iuml

hide methods
hide stereotypes

title Core

' entities

Class(_core_state, "core_state") {
    
}

Class(_user, "application_user") {
    public(key(id))  number
}

Class(_layout, "layout") {
    public(key(id))  number
}


' relationships
_core_state o-- _user
_core_state o-- _layout

@enduml

```