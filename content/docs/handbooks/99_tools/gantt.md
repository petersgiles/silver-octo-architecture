# Project Timeline Overview

## Document Conversion

```plantuml format="svg" classes="uml myDiagram"
@startgantt

Project starts the 1 of january 2018

[Sharepoint Event Bridge] as [SEB] lasts 10 days

[DSuite Event Publisher] as [DEP]  lasts 10 days
[Brief Event Publisher] as [BEP]  lasts 10 days

[DSuite Document Converter]  as [DDC] lasts 10 days
[Item Metadata Management] as [IMM] lasts 10 days

[SEB] is colored in Coral/Green

[DEP] starts at [SEB]'s end
[BEP] starts at [DEP]'s end
[DDC] starts at [BEP]'s end
[IMM] starts at [BEP]'s end


@endgantt

```