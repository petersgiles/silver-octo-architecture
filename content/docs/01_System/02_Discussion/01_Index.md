# Discussions

## The discussion engine is Thing agnostic

A discussion service takes key material from a host and returns comments. it's pretty simple.

![Data structure](https://g.gravizo.com/svg?
@startuml;
together {;
class Discussion;
class Comment {;
text string;
author JSON;
edits JSON;
};
Discussion "0" -- "*" Comment ;
Comment "0" -- "*" Comment ;
};
@enduml;
)

## Discussion

- A grouping for Comments by key material.
- A discussion may have zero to many comments.

## Comment

- Like a Post on a social media site. 
- Has details about the Author.
- Has an Edit History. 
- Comments can be nested under other comments.