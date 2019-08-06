# Owner 

An Owner is able to Manage a Brief's lifecycle they can perform all the actions of an [Editor](editor.md)

- Create 
    
    - Briefs and associated Material
- Archive 
    
    - Briefs and associated Material
    
![Data structure](https://g.gravizo.com/svg?
@startuml;
ACT_EDITOR <|-- ACT_OWNER: Can Do;
ACT_OWNER .. (Create) : Uses;
ACT_OWNER .. (Archive)  : Uses;
@enduml;
)

