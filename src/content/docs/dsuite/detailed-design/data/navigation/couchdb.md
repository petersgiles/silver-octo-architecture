# CouchDB


```typescript

class CouchContainer {
  _id: GUID // DOMAIN GUID
  _rev: GUID // COUCH MANAGED GUID
  name: string
  parent: GUID | null
  $doctype: "container" | "list *"
  createdutc: datetimeutc
  modifiedutc: datetimeutc
  type: "jurisdiction" | "bundle" | "pack" | "folder" 
        | "briefing" | "brief" | "attachment" | "discussion" 
        | "message" 
  _attachments: {
    "metadata.json": JSON | null,
    "image.jpg": JSON | null,
    "chart.json": JSON | null,
    "document.md": JSON | null,
    "document.html": JSON | null,
  }
}

```