# DSuite

DSuite is a collection of tools designed to provide an Executive Decision Information Management System (EDIM).

It is designed to deliver enhanced communication and discovery of important information to very important people (VIPs).

!!! quote 
    DSuite is a software system I can use to brief a VIP

## Use Case

```plantuml
@startuml

left to right direction

actor :VIP: <<person>> as A_VIP
actor :PMO: <<person>> as A_PMO
actor :Pack\Owner: <<person>> as A_OWNER

rectangle "Brief and Pack CRUA" as RECT_BRIEF {
    
    usecase (Read Recommendation) as RR

    A_VIP -- RR
    RR ..> (Choose\nRecommendation) : include

    (Read brief)
    (Read brief) ..> RR : include

    note "May add attachments\nand recommendations." as N1
    (Edit brief) .. N1
    (Create brief)
    (Archive brief)
    
    (Read brief) ..> (Discuss brief) : include    
    (Edit brief) ..> (Read brief) : include
    (Create brief) ..> (Edit brief) : include

    (Read pack) .left.> (Read brief) : include
    A_VIP -- (Read pack)
    A_PMO -- (Edit pack)
    (Edit pack) .left.> (Edit brief)
    A_OWNER -- (Edit pack)
    (Create pack) .left.> (Create brief)
    A_OWNER -- (Create pack)
    (Archive pack) .left.> (Archive brief)
    A_OWNER -- (Archive pack)
}

@enduml

```