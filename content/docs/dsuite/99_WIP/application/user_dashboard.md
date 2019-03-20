# User Dashboard

## ER Diagram

```plantuml
@startuml

hide methods
hide stereotypes

title User Dashboard

' entities

Class(application_user, "application_user") {
    public(key(id))  number
}

Class(business_unit, "business_unit") {
    public(key(id))  number
}

Class(news_feed, "news_feed_item") {
    public(key(id))  number
    public(caption) string
    public(details) string  
    public(uri) string 
    public(created_on) datetime
}

Class(quick_stat_type, "quick_stat_type") {
    public(key(id))  number
    public(caption) string
    public(details) string
}

Class(quick_stat, "quick_stat_item") {
    public(key(id))  number
    public(caption) string
    public(details) string 
    public(data) string
}

Class(briefing_group, "briefing_group") {
    public(key(id))  number
    public(caption) string
    public(details) string  

}

Class(briefing_pack, "briefing_pack") {
    public(key(id))  number
    public(caption) string
    public(details) string  
    public(alert_count) number 
}

' relationships

application_user ..{ quick_stat 
application_user ..{ news_feed 
application_user ..{ briefing_pack 

quick_stat_type .up.{ quick_stat 

business_unit .up.{ briefing_group
briefing_group .up.{ briefing_pack


@enduml
```