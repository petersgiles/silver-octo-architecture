# Guest

A Guest is an Authenticated identity that has no Authorisation. 

- Request Access via Email


![Data structure](https://g.gravizo.com/svg?
@startuml;
ACT_GUEST .. (Request\nAccess) : Uses;
(Request\nAccess) .down. APP_EMAIL : access-request@dsuite.gov.au;
@enduml;
)
