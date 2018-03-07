hero: DSuite System
title: Software System
description: C4 Software System.

# Software System


```plantuml format="svg" classes="uml myDiagram"
@startuml

title System Context diagram

folder "Corporate Domain" as DOMAIN {

!include /docs/includes/common.iuml!sys_dsuite
!include /docs/includes/theme.iuml
!include /docs/includes/common.iuml!pla_sql
!include /docs/includes/common.iuml!pla_sp
!include /docs/includes/common.iuml!pla_couch
!include /docs/includes/common.iuml!pla_web
!include /docs/includes/common.iuml!svc_mi
!include /docs/includes/common.iuml!svc_esb

!include /docs/includes/common.iuml!act_user

node "Approved Device" as DEVICE {
    !include /docs/includes/common.iuml!app_ms_office
    !include /docs/includes/common.iuml!app_browser
    !include /docs/includes/common.iuml!app_email
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
