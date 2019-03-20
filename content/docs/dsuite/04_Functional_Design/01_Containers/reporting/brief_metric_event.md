# Brief Metric

Store a metric in the database and prepare relevant reports

```plantuml
@startuml
!include /docs/includes/theme.iuml

title Metric Changed Activity

start
:Publish\nBrief Metric\nEvent;

partition "Data Warehouse" {
    if (Is Brief Metric Event) then
        -[#green]->
        :Store in Table;
        :Prepare Report;
    else 
        stop
    endif
}

stop

@enduml


```
