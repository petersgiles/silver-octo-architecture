# iOS Mobile Reader

This app is Offline Capable


```plantuml format="svg" classes="uml myDiagram"
@startuml
!include /docs/includes/theme.iuml

title Mobile


database CouchDB <<system>> as C 

queue "Event Bus" <<service>> as ESB


actor :Reader: <<person>> as R
actor :Owner: <<person>> as O
component [Mobile Iron] <<system>> as MI

node iPad <<device>> {


    package "DSuite" {
        component "Offline App" <<app>> as DS
        database PouchDB <<storage>> as P
    }
    
    
    MI --> DS : Secures
    DS <--> P : Uses 
    P <-right-> C : Replicates
    R -- DS: Edits
}

node SharePoint {
    component [Site] <<system>> as SP
}

package "Admin Web" {

    component [Admin] <<website>> as AW 
    database "SQL Server" <<database>> as SQL

    AW <--> SP : RW
    AW <-- SQL : R
    AW <--> ESB 
    
    O -- AW : Manages
}

ESB <--> SP: RW
ESB <--> SQL : RW
C <--> ESB
@enduml
```