# PMO 

A Parlimentary Officer who works with a Parlimentary VIP i.e. The Prime Minister's Chief of Staff

```plantuml format="svg" classes="uml myDiagram"
@startuml
left to right direction
!include /docs/includes/theme.iuml
!include /docs/includes/common.iuml!act_editor
!include /docs/includes/common.iuml!act_pmo

ACT_PMO --|> ACT_EDITOR  : Is a

@enduml
```