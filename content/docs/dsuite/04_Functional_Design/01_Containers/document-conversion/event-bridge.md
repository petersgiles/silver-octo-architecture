# SharePoint Event Bridge Activity

```plantuml
@startuml



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
