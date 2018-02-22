# Collect Data


```plantuml format="png"
@startuml
!include /docs/includes/theme.iuml

title Metric Changed Activity

start
:Publish\ Document\nChanged;

partition "Reporting Metric Publisher" {
    if (Is Brief Event) then
        -[#green]->
        :Publish\nBrief Metric\nEvent;
    else if (Is Activity Event) then
        -[#green]->
        :Publish\nActivity Metric\nEvent;
    else
        stop
    endif
}

stop

@enduml


```
