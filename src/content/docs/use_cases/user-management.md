# User Management

CabNet have an Authorisaion Portal that could be whiteboxed to manage Users

```plantuml format="png" classes="uml myDiagram"
@startuml
left to right direction
!include /docs/includes/theme.iuml
!include /docs/includes/common.iuml!act_owner
!include /docs/includes/common.iuml!act_admin

actor "System"  as ACT_SYS

(Manage\nArtifact) as (mar)
(Manage\nOperation) as (mop)
note right of (mop)
    Operations could be enumerated from 
    the Codebase
end note

(Manage\nFeature) as (mfe)
(Manage\nFunction) as (mfu)
(Manage\nGroup) as (mgr)
note right of (mgr)
    Groups could be enumerated from 
    External Systems like Aurion and
    Active Directory 
end note


(Manage\nUser) as (mus)
note right of (mus)
    Users could be enumerated from 
    External Systems like Aurion and
    Active Directory 
end note

ACT_SYS .. (mop)


ACT_SYS .. (mar)

ACT_ADMIN --|> ACT_OWNER

ACT_OWNER .. (mfe)
ACT_OWNER .. (mgr)

ACT_ADMIN .. (mfu)
ACT_ADMIN .. (mus)

@enduml


```