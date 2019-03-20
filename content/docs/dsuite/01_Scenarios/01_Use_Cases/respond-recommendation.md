# Respond to recommendation

```plantuml
@startuml

(*) --> "Respond"

if "Has Delegation" then
  -->[yes] "Enable Choices"
  --> (*)
else
  ->[no] "Disable Choices"
  --> (*)
endif

@enduml
```