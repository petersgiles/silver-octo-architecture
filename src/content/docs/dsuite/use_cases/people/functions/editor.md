# Editor 

An Editor is able to Collaborate on a Brief they can perform all the actions of a [Reader](reader.md)

- Edit 
    - Brief Material
    - Attachments
- Process   
    - Change Collaboration State



```plantuml format="svg" classes="uml myDiagram"
@startuml
!include /docs/includes/theme.iuml

!include /docs/includes/common.iuml!act_reader
!include /docs/includes/common.iuml!act_editor

ACT_READER <|-- ACT_EDITOR: Can Do


ACT_EDITOR .. (Edit) : Uses
ACT_EDITOR .. (Change\nCollaboration\nState)  : Uses


@enduml
```