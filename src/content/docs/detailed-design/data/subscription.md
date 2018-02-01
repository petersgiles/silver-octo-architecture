# Subscription

## ER Diagram


```plantuml format="svg" classes="uml myDiagram"
@startuml
!include /docs/includes/theme.iuml
!include /docs/includes/typescript.iuml
hide methods
hide stereotypes

title Subscription

' entities


Table(subscription, "subscription\n(subscription)") {
}

Table(user, "user\n(user)") {
}


' relationships

user "1" .. "*" subscription

@enduml
```



## Definition