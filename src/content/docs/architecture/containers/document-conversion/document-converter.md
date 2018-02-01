# Brief Document Converter

!!! note
    This only handles Briefs. It will use a service account that has permissions to write to Briefs site. If additional types are required in future, then this will probably moved to a generic instance based endpoints that operate under a specific account
    for each site.

- Grabs document from sharepoint source
- Send it to Dsuite document Converter
- Waits for reply
- Send document to SharePoint destination


```plantuml format="png"
@startuml
!include /docs/includes/theme.iuml

title Brief Document Converter

start
:Publish\nBrief Document\nChanged;

partition "Brief Event Publisher" {

    if (Is a Brief Event) then
        -[#green]->
        :Convert SharePoint Hosted Document;
    else
        stop
    endif    
}

partition "DSuite Document Converter" {
    :Convert Document;
    :Reply;
}

stop

@enduml


```