# CouchDB


## Nav Container

```typescript

class CouchContainer {
  _id: GUID // DOMAIN GUID
  _rev: GUID // COUCH MANAGED GUID
  title: string
  parent: GUID | null
  $doctype: "container" | "list *"
  createdutc: datetimeutc
  modifiedutc: datetimeutc
  type: "jurisdiction" | "bundle" | "pack" | "folder"      
  _attachments: {
    "metadata.json": JSON | null, // Colours, sorts, ui garbage etc
    "image.jpg": JSON | null,
    "chart.json": JSON | null,
    "document.md": JSON | null,
  }
}

```

## Document Container

```typescript

class CouchContainer {
  _id: GUID // DOMAIN GUID
  _rev: GUID // COUCH MANAGED GUID
  title: string
  parent: GUID | null // the parent container
  $doctype: "container" | "list *"
  createdutc: datetimeutc
  modifiedutc: datetimeutc
  type: "briefing" | "brief" | "attachment" 
  _attachments: {
    "metadata.json": JSON | null,
    "document.md": JSON | null,
    "document.html": JSON | null,
  }
}

```

## Discussuion Container

```typescript

class CouchDiscussion {
  _id: GUID // DOMAIN GUID
  _rev: GUID // COUCH MANAGED GUID
  title: string // Channel
  parent: GUID | null // The Brief ID (or container)
  $doctype: "container" | "list *"
  createdutc: datetimeutc
  modifiedutc: datetimeutc
  type: "discussion" 
        | "message",
}

```

## Comment Container

```typescript

class CouchComment {
  _id: GUID // DOMAIN GUID
  _rev: GUID // COUCH MANAGED GUID
  title: string // Channel
  parent: GUID | null // The Discussion ID 
  $doctype: "container" 
  createdutc: datetimeutc
  modifiedutc: datetimeutc
  type: "message"
  text : string
  markdown: string // The pretty text for the markdown
  user: string
}

```