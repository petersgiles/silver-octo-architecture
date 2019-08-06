# Editor 

An Editor is able to Collaborate on a Brief they can perform all the actions of a [Reader](reader.md)

- Edit 
    - Brief Material
    - Attachments
- Process   
    - Change Collaboration State


![Data structure](https://g.gravizo.com/svg?
@startuml;
ACT_READER <|-- ACT_EDITOR: Can Do;
ACT_EDITOR .. (Edit) : Uses;
ACT_EDITOR .. (Change\nCollaboration\nState)  : Uses;
@enduml;
)

