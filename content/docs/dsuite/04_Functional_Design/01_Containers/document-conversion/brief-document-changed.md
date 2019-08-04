# Brief Document SharePoint Activity



![Data structure](https://g.gravizo.com/svg?
@startuml;
[*] --> EventReceiver;
state EventReceiver {;
[*] -> Publish;
Publish: Document Changed;
Publish -> [*];
};
@enduml;
)

