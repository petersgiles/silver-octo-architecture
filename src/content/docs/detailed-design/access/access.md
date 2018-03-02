# Access



```plantuml format="svg" classes="uml myDiagram"
@startuml
!include /docs/includes/theme.iuml
!include /docs/includes/erd.iuml

hide methods
hide stereotypes

title Roles & Access

' entities

Table(identity, "identity\n(a real person)") {
}

Table(profile, "profile\n(app related identity)") {
}

Table(personalisation, "personalisation\n(KVP to support\napp customisation)") {
}

Table(app, "app\n(available applications)") {
}

Table(id_source, "identity source\n(where is\nthis identity\nfrom)") {
}

Table(role, "role\n(operations and subroles)") {
}

Table(operation, "operation\n(an atomic act)") {
}


Table(artifact, "artifact\n(a thing)") {

}

' relationships


identity "1" .. "0..*" profile 
identity "1" .. "1..*" id_source 

app "1" .. "0..*" role 

app "1" .. "0..*" operation 
app "1" .. "0..*" artifact

profile  "1" .. "1" app 

profile "1" .. "0..*" role 

profile "1" .. "0..*" operation 
profile "1" .. "0..*" artifact

personalisation "1" .. "0..1" profile
personalisation "1" .. "0..1" app 

role "1" --> "1" role  
role "1" .. "0..*" operation 
role "1" .. "0..*" artifact 


@enduml
```

## Definition

This model defines the security for the application 

> _IMPORTANT_ This does not secure artefacts managed outside the system. It provides data that would be applied to external systems. The _identity source_ describes where the identity comes from 

- Identity
    - A real person who may have one or more identities managed elsewhere i.e. Active Directory, Vangard, SharePoint
- App
    - DSuite is built from multiple apps. Access to individual apps may be different depending on Identity
- Personalisation _Nice to Have_
    - Key Value pairs to set values for personalisation
- Profile _development and collaboration_
    - an Identity might have different profiles for different apps
- Role, Features & Operations
    - application operations grouped up by diferent levels

