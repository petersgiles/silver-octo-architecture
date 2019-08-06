# Respond to recommendation


![Data structure](https://g.gravizo.com/svg?
@startuml;
(*) --> "Respond";
if "Has Delegation" then;
  -->[yes] "Enable Choices";
  --> (*);
else;
  ->[no] "Disable Choices";
  --> (*);
endif;
@enduml;
)
