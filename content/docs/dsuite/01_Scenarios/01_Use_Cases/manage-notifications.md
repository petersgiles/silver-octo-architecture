# Manage Notifications

```plantuml
@startuml
left to right direction

(Manage\nMy\nSubscriptions) as (mesub)
(Set Notificaton\nChannel) as (set)
(Manage\nOther's\nSubscriptions) as (yousub)
(Be\nNotified) as (bnot)

ACT_READER .. (bnot) : Uses
note right of (bnot)
    Default read in App but can 
    add Email and others by setting
    notification channel
end note

ACT_READER .. (mesub)
(mesub) --> (Subscribe\nMe)
(mesub) --> (Unsubscribe\nMe)

ACT_READER .. (set)
note right of (set)
    Toggle channel for notifications
    other than the standard in app
    i.e. email
end note

ACT_EDITOR -down-|> ACT_READER
ACT_EDITOR .. (yousub)
(yousub) --> (Subscribe\nOther)
(yousub) --> (Unsubscribe\nOther)

@enduml

```



## Fidelity

Readers can increase fidelity but it will clear low fidelity notification subscriptions.

Editior can decrease fidelity but it will clear higher fidelity notification subscriptions.
