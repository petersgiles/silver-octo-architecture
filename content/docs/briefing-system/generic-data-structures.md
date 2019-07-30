# The Mother of all relational data structures

This version of the Data Model includes a DataValue Table showing how data could be stored in this flexible  example of "Entity-Attribute-Value" see [Wikipedia](https://en.wikipedia.org/wiki/Entity%E2%80%93attribute%E2%80%93value_model).

![Data structure](https://g.gravizo.com/svg?
@startuml;
!define Table(name,desc) class name as "desc" << (T,#FFAAAA) >>;
!define primary_key(x) <b>PK x</b>;
!define foreign_key(x) <i>FK x</i>;
Table(thing, "Thing") {;
   primary_key(id) GUID;
   foreign_key(thingType) GUID;
};
Table(thingtype, "ThingType") {;
   primary_key(id) GUID;
   description string;
};
Table(attribute, "Attribute") {;
   primary_key(id) GUID;
   foreign_key(attribute) GUID;
   foreign_key(attributeType) GUID;
};
Table(attributetype, "AttributeType") {;
   primary_key(id) GUID;
   description string;
};
Table(datavalue, "DataValue") {;
   primary_key(id) GUID;
   foreign_key(attribute) GUID;
   value any;
};
Table(relationship, "Relationship") {;
   primary_key(id) GUID;
   foreign_key(thing1) GUID;
   foreign_key(thing2) GUID;
   foreign_key(relationshipType) GUID;
};
Table(relationshiptype, "RelationshipType") {;
   primary_key(id) GUID;
   description string;
};
thing "*" -- "1" thingtype;
thing "1" -- "*" attribute;
thing "1" -- "*" relationship;
relationship "*" -- "1" relationshiptype;
attribute "*" -- "1" attributetype;
attribute "1" -- "*" datavalue;
@enduml;
)

## Things in Hierarchies

Users should be able to create any __Hierarchy__ they like by using this parent sibling model 

![Data structure](https://g.gravizo.com/svg?
@startuml;
!define Table(name,desc) class name as "desc" << (T,#FFAAAA) >>;
!define primary_key(x) <b>PK x</b>;
!define foreign_key(x) <i>FK x</i>;
Table(thing, "Thing") {;
   primary_key(id) GUID;
   foreign_key(thingType) GUID;
};
Table(hierarchyparent, "Parent") {;
   primary_key(parent) GUID;
   primary_key(hierarchy) GUID;
};
Table(siblingnext, "SiblingNext") {;
   primary_key(hierarchy) GUID;
   primary_key(next) GUID;
};
Table(siblingprev, "SiblingPrev") {;
   primary_key(hierarchy) GUID;
   primary_key(previous) GUID;
};
Table(hierarchy, "Hierarchy") {;
   primary_key(id) GUID;
   foreign_key(thing) GUID;
};
Table(hierarchylevel, "HierarchyLevel") {;
   primary_key(id) GUID;
   number string;
   name string;
   description string;
};
thing .. hierarchy;
hierarchylevel  "1" .u. "*" hierarchy;hierarchy .d. hierarchyparent;
hierarchy .d. hierarchyparent;
hierarchy .r. siblingnext;
hierarchy .r. siblingnext;
hierarchy .l. siblingprev;
hierarchy .l. siblingprev;
@enduml;
)

### Example of __Hierarchy__ Level in Briefs

| Level | Name                 |
| ----- | :------------------- |
| 1     | Category             |
| 2     | Sub-Category         |
| 3     | Sub-Sub-Category     |
| 4     | Sub-Sub-Sub-Category |
| 5     | etc.                 |

### Example of __Hierarchy__ Level in Locations

| Level | Name                 |
| ----- | -------------------- |
| 1     | International |
| 2     | National |
| 3     | State-Territory |
| 4     | Electorate |
| 5     | etc. |

## Access to Things

![Data structure](https://g.gravizo.com/svg?
@startuml;
!define Table(name,desc) class name as "desc" << (T,#FFAAAA) >>;
!define primary_key(x) <b>PK x</b>;
!define foreign_key(x) <i>FK x</i>;
Table(user, "User") {;
   primary_key(id) GUID;
   name string;
};
Table(role, "Role") {;
   primary_key(id) GUID;
   name string;
};
Table(userrole, "UserRole") {;
   primary_key(id) GUID;
   foreign_key(user) GUID;
   foreign_key(role) GUID;
};
Table(thingaccess, "ThingAccess") {;
   primary_key(id) GUID;
   foreign_key(thing) GUID;
   foreign_key(role) GUID;
};
Table(thing, "Thing") {;
   primary_key(id) GUID;
   foreign_key(thingType) GUID;
};
Table(hierarchyaccess, "HierarchyAccess") {;
   primary_key(id) GUID;
   foreign_key(hierarchy) GUID;
   foreign_key(role) GUID;
};
Table(hierarchy, "Hierarchy") {;
   primary_key(id) GUID;
   foreign_key(thing) GUID;
};
userrole .. user;
userrole .. role;
userrole .. thingaccess;
userrole ..  hierarchyaccess;
thing .. thingaccess;
hierarchy .. hierarchyaccess;
hierarchy .. thing;
@enduml;
)
