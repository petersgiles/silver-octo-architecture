# VIP 

A Very Important Person i.e. The Prime Minister, A Minister or a Departmental Secretary

```plantuml format="svg" classes="uml myDiagram"
@startuml
left to right direction
!include /docs/includes/theme.iuml
!include /docs/includes/common.iuml!act_reader
!include /docs/includes/common.iuml!act_vip

ACT_VIP --|> ACT_READER  : Is a

@enduml
```