# Owner 

An Owner is able to Manage a Brief's lifecycle they can perform all the actions of an [Editor](editor.md)

- Create 
    - Briefs and associated Material
- Archive 
    - Briefs and associated Material


```plantuml format="svg" classes="uml myDiagram"
@startuml
!include /docs/includes/theme.iuml
!include /docs/includes/common.iuml!act_owner
!include /docs/includes/common.iuml!act_editor

ACT_EDITOR <|-- ACT_OWNER: Can Do

ACT_OWNER .. (Create) : Uses
ACT_OWNER .. (Archive)  : Uses


@enduml
```