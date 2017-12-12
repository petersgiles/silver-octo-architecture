# Digital Suite C4 Architecture

## Enterprise Context

In the real-world, software systems never live in isolation. For this reason, and particularly if you are responsible for a collection of software systems, it's often useful to understand how all of these software systems fit together within the bounds of an enterprise.

[![Enterprise System](svg/c4.svg)](svg/c4.svg)

## System Context

A software system is the highest level of abstraction and describes something that delivers value to its users, whether they are human or not. This includes the software system you are modelling, and the other software systems upon which your software system depends (or vice versa).

[![Software System](svg/c4_001.svg)](svg/c4_001.svg)

## Container

A container represents something that hosts code or data. A container is something that needs to be running in order for the overall software system to work. 

A container is essentially a context or boundary inside which some code is executed or some data is stored. And each container is a separately deployable thing.

[![Container](svg/c4_002.svg)](svg/c4_002.svg)

# Component

The word "component" is a hugely overloaded term in the software development industry, but in this context a component is simply a grouping of related functionality encapsulated behind a well-defined interface. If you're using a language like Java or C#, the simplest way to think of a component is that it's a collection of implementation classes behind an interface. Aspects such as how those components are packaged (e.g. one component vs many components per JAR file, DLL, shared library, etc) is a separate and orthogonal concern.

[![Component](svg/c4_003.svg)](svg/c4_003.svg)

# Deployment

A deployment diagram allows you to illustrate how containers in the static model are mapped to infrastructure. This deployment diagram is based upon a UML deployment diagram, although simplified slightly to show the mapping between containers and deployment nodes. A deployment node is something like physical infrastructure (e.g. a physical server or device), virtualised infrastructure (e.g. IaaS, PaaS, a virtual machine), containerised infrastructure (e.g. a Docker container), an execution environment (e.g. a database server, Java EE web/application server, Microsoft IIS), etc. Deployment nodes can be nested.

[![Deployment](svg/c4_004.svg)](svg/c4_004.svg)

