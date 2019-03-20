# Software System

```plantuml
@startuml

title System Context diagram

folder "Corporate Domain" as DOMAIN {

node "Approved Device" as DEVICE {

}
note "Department issued\nlaptops and iPads" as N1

DEVICE .. N1
DEVICE .up. SVC_MI 
ACT_USER .. DEVICE 

APP_MS_OFFICE ... PLA_SP
APP_BROWSER ... PLA_WEB

SYS_DSUITE -up- PLA_SP 
SYS_DSUITE -up- PLA_WEB 
SYS_DSUITE -left- PLA_COUCH 
SYS_DSUITE -down- PLA_SQL 
SYS_DSUITE -down- SVC_ESB 

PLA_SP -- PLA_SQL  

SVC_ESB -up- PLA_COUCH 
SVC_ESB -- PLA_SP 
SVC_ESB -left- PLA_SQL 

}



@enduml
```

This is a zoomed out view showing the big picture of the system. Here we are focusing on people and software systems rather than technologies, protocols and other low-level details.

DSuite uses platforms and applications that we already have and use regularly use. It is secured by the Corporate network


!!! warning
    Do Not Assume subjects not explicitly included in these documents
    have not been considered. This documentation is capturing subjects that
    are not self evident or topics that have come up during development
    that have needed some explanation
