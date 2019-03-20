# Brief Item Changed Activity

```plantuml
@startuml
!include /docs/includes/theme.iuml


title Brief Item Changed Activity

start
:Publish\nItem\nChanged;

partition "Brief Event Publisher" {

    if (Is a Brief Event) then
        -[#green]->
        :Publish\nBrief Item\nChanged;
    else
        stop
    endif    
}

partition "DSuite Document Item Metadata Management" {
    :Store\nBrief Metadata;
}

stop

@enduml


```