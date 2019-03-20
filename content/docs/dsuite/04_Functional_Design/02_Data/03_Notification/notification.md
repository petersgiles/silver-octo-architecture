# Notification

## ER Diagram

```plantuml
@startuml
' uncomment the line below if you're using computer with a retina display
' skinparam dpi 300
!define Table(name,desc) class name as "desc" << (T,#FFAAAA) >>
' we use bold for primary key
' green color for unique
' and underscore for not_null
!define primary_key(x) <b>x</b>
!define unique(x) <color:green>x</color>
!define not_null(x) <u>x</u>
' other tags available:
' <i></i>
' <back:COLOR></color>, where color is a color name or html color code
' (#FFAACC)
' see: http://plantuml.com/classes.html#More
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
