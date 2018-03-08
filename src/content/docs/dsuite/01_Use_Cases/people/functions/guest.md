# Guest

A Guest is an Authenticated identity that has no Authorisation. 

- Request Access via Email

```plantuml format="svg" classes="uml myDiagram"
@startuml
!include /docs/includes/theme.iuml
!include /docs/includes/common.iuml!act_guest
!include /docs/includes/common.iuml!app_email

ACT_GUEST .. (Request\nAccess) : Uses
(Request\nAccess) .down. APP_EMAIL : access-request@dsuite.gov.au

@enduml
```