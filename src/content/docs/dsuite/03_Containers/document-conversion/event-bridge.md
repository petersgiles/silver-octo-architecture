#  SharePoint Event Bridge Activity


```plantuml format="png"
@startuml
!include /docs/includes/theme.iuml


title SharePoint Event Bridge Activity

start


partition SharePoint {
    :Create/Modify\nPack/Brief;
}

partition "Event Bridge" {
    split
        :Item\nUpdating;
    split again
        :Item\nUpdated;
    end split
    :Item\nAdded;

}
stop

@enduml


```
