# Document Conversion


![diagram](document-conversion.svg)

[PNG](document-conversion.png) | [SVG](document-conversion.svg)


![diagram](document-conversion_001.svg)

[PNG](document-conversion_001.png) | [SVG](document-conversion_001.svg)


### Brief Document Converter

!!! note
    This only handles Briefs. It will use a service account that has permissions to write to Briefs site. If additional types are required in future, then this will probably moved to a generic instance based endpoints that operate under a specific account
    for each site.

- Grabs document from sharepoint source
- Send it to Dsuite document Converter
- Waits for reply
- Send document to SharePoint destination