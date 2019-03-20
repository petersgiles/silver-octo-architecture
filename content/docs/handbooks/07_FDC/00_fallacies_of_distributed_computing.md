# Fallacies of distributed computing

## The fallacies

The 8 fallacies are:

1. [The network is reliable](./01_network.md)
1. [Latency is zero](./02_latency.md)
1. [Bandwidth is infinite](./03_bandwidth.md)
1. [The network is secure](./04_secure.md)
1. [Topology doesn't change](./05_topology.md)
1. [There is one administrator](./06_one_admin.md)
1. [Transport cost is zero](./07_transport_cost.md)
1. [The network is homogeneous](./08_homogeneous.md)

## The effects of the fallacies

1. Software applications are written with little error-handling on networking errors. During a network outage, such applications may stall or infinitely wait for an answer packet, permanently consuming memory or other resources. When the failed network becomes available, those applications may also fail to retry any stalled operations or require a (manual) restart.
1. Ignorance of network latency, and of the packet loss it can cause, induces application- and transport-layer developers to allow unbounded traffic, greatly increasing dropped packets and wasting bandwidth.
1. Ignorance of bandwidth limits on the part of traffic senders can result in bottlenecks over frequency-multiplexed media.
1. Complacency regarding network security results in being blindsided by malicious users and programs that continually adapt to security measures.[2]
1. Changes in network topology can have effects on both bandwidth and latency issues, and therefore similar problems.
1. Multiple administrators, as with subnets for rival companies, may institute conflicting policies of which senders of network traffic must be aware in order to complete their desired paths.
1. The "hidden" costs of building and maintaining a network or subnet are non-negligible and must consequently be noted in budgets to avoid vast shortfalls.
1. If a system assumes a homogeneous network, then it can lead to the same problems that result from the first three fallacies.

## But there's more...

1. the system is atomic
    - centralized dba committee to sign off on schema changes.
    - solution: internal loose coupling, modularize, design for scale out in advance, design for interaction with other software.
1. the system is finished.
    - maintenance costs more than development - design for maintenance
    - the system is never finished. - design for upgrades.
    - how will you upgrade the system.
1. business logic can and should be centrailized
    - re-use can be bad. context matters.
    - single generic abstraction can make things more difficult, and can cause performance problems.
    - more classes but more maintainable. the number of lines and coupling is reduced.
    - generic abstractions can cause a lot of problems down the line. performance, maintainability. (small code base but much more complex to jump in)
    - rules that change often can be segrated from rules that don’t change often.
    - we are taught that re-use is one of the greatest values in software development, in reality, it doesn’t really help as much as we think it should.

!!! tip
    accept that business logic and validation will be distributed. plan for it.

## Other pearls of wisdom

1. best practices have yet to catch up to “best thinking”
1. tech cannot solve all problems
1. adding hardware doesn’t necessarily help

## Coupling

afferent : depends on you
efferent : you depend on

1. attempt to minimize afferent and efferent coupling.
1. zero coupling is not possible.
1. types of coupling for systems -platform -temporal -spatial    