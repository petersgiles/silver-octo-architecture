# Document Conversion

## Component Overview 

![diagram](document-conversion.svg)

[PNG](document-conversion.png) | [SVG](document-conversion.svg)


## SharePoint Event Bridge Activity

![diagram](document-conversion_001.svg)

[PNG](document-conversion_001.png) | [SVG](document-conversion_001.svg)

## Event Publisher Activity

![diagram](document-conversion_002.svg)

[PNG](document-conversion_002.png) | [SVG](document-conversion_002.svg)

## Brief Document Changed Activity

![diagram](document-conversion_003.svg)

[PNG](document-conversion_003.png) | [SVG](document-conversion_003.svg)


## Brief Document Created Activity

![diagram](document-conversion_004.svg)

[PNG](document-conversion_004.png) | [SVG](document-conversion_004.svg)

## Brief Item Changed Activity

![diagram](document-conversion_005.svg)

[PNG](document-conversion_005.png) | [SVG](document-conversion_005.svg)


## Brief Document Converter

!!! note
    This only handles Briefs. It will use a service account that has permissions to write to Briefs site. If additional types are required in future, then this will probably moved to a generic instance based endpoints that operate under a specific account
    for each site.

- Grabs document from sharepoint source
- Send it to Dsuite document Converter
- Waits for reply
- Send document to SharePoint destination

![diagram](document-conversion_006.svg)

[PNG](document-conversion_006.png) | [SVG](document-conversion_006.svg)

