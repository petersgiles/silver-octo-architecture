# User Defined Topics

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

title ERD : Topic

' entities

Table(topic_owner, "topic_owner") {
    primary_key(id)  number
}

Table(topic, "topic") {
    primary_key(id)  number
    not_null(caption) string
    not_null(type_of_topic)  number
}

Table(type_of_topic, "type_of_topic") {
    primary_key(id)  number
    not_null(caption) string
    not_null(details) string
    
}

Table(attribute, "attribute") {
    unique(topic)  number
    unique(type_of_attribute)  number
    Value NVARCHAR[666]
    Text NVARCHAR[MAX]
    not_null(active)  number
    not_null(lastupdated) UTCDATETIME    
}

Table(type_of_attribute, "type_of_attribute") {
    primary_key(id)  number
    not_null(caption) string
    not_null(details) string
}

Table(display_hint, "display_hint") {
    primary_key(id)  number
    not_null(caption) string
    not_null(format) string
}


Table(relationship, "relationship") {
    primary_key(id)  number
    not_null(relationship_to_topic_1)  number
    not_null(relationship_to_topic_2)  number
    not_null(type_of_relationship)  number
    not_null(caption) string
}


Table(type_of_relationship, "type_of_relationship") {
    primary_key(id)  number
    not_null(caption) string
    not_null(details) string
}

' relationships

topic "*".."1" type_of_topic : "Is a"
attribute "*".."1" type_of_attribute :  "Is a"
type_of_attribute "1".."*" display_hint : "Has"

topic "1".."*" attribute : "Has many"
relationship "*".."1" type_of_relationship :  "Is a"

relationship "1" .. "1" topic :  "Relationship 1"
relationship "1" .. "1" topic :  "Relationship 2"

topic_owner "1".."*" type_of_topic : "Owns"
topic_owner "1".."*" type_of_relationship : "Owns"
topic_owner "1".."*" type_of_attribute : "Owns"
topic_owner "1".."*" display_hint : "Owns"

@enduml
```

## Definition

Very often adhoc information stores to be added to a DataStore

This design allows for diverse data needs


## How to enter data

- Add a 'type of topic'
- Add a 'type of attribute' for each attribute a topic has
- If the topic has relationships Add a 'type of relationship'
    - it could describe a relationship to another topic
    - it could be a parent child relationship for a single topic
    - it could describe a relationship to an item in another system
- Assign a User (subject matter expert) to each of these types 
    - someone who can explain why the topic, attribute or relationship needs to exist
    - reason could also be captured as a topic with attributes & relationship etc.
- Enter data into the Topic, Attribute & Relationship tables