# Notifications

## The notification engine is Thing agnostic

A notification service takes key material from a host and returns a list of users that need to know about that event.

![Data structure](https://g.gravizo.com/svg?
@startuml;
together {;
class Subscription;
class User;
class Event;
class Host;
User "0" -- "*" Subscription ;
Event "0" -- "*" Subscription ;
Host "0" -- "*" Event ;
};
@enduml;
)

## Host

- A grouping of events.

## Event

- A subscribable event. 

## Subscription

- A record of a user's interest in an event.
- A subscription may have caveats. i.e. when a particular artifact ID has the event.
- It may have a preferred change of communication i.e. email or txt.

## User

- A user.