# Web App Client 

```plantuml format="svg" classes="uml myDiagram"
@startuml
!include /docs/includes/theme.iuml

title Browser

actor :Collaborator: <<person>> as R
actor :Owner: <<person>> as O
component [Active Directory] <<service>> as AD
database "SQL Server" <<database>> as SQL
database CouchDB <<system>> as C 
queue "Event Bus" <<service>> as ESB

node SharePoint as SP {
    component [Site] <<system>>
}

node IIS {
package "DSuite" as DS <<web app>> {
    component "App" <<app>> as DSAPP
    database PouchDB <<storage>> as P
}


AD --> DS : Secures
DSAPP <--> P : Uses 
P <--> C : Replicates
R -- DS: Reads

package "Admin Host" as AH {

    component [Admin] <<website>> as AW 
    component WebApi <<system>> as WAPI 

    AW <--> SP
    AW <--> SQL
    AW <--> ESB
    
    WAPI <--> SP
    WAPI <--> SQL
    WAPI <--> ESB
    
}

ESB <-up-> SQL

DSAPP --> WAPI
O -- AH : Manages
ESB <--> SP

C <--> ESB
}
@enduml
```