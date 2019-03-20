# Notification

## ER Diagram

```plantuml
@startuml

hide methods
hide stereotypes

title Notification Subscription Management

' entities
Table(subscription, "Subscription") {
}

Table(subscription_map, "Subscription Topic") {
}

Table(subscription_event, "Event") {
}

Table(message_templates, "Message Template") {
}

Table(user, "Subscriber <<person>> ") {
}

Table(notification_channel, "Notification Channel") {
}


' relationships

user }-left-{ subscription
user }-right-{ notification_channel

subscription *-- subscription_map
subscription *-- subscription_event

notification_channel --* message_templates 
subscription_event --* message_templates 

@enduml
```

## Definition

Message Templates are determined by a Subscribers current set of Notifications Channels. By default notifications occur within the system on the user's Home Page but they can add email as well
