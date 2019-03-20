# Setup

## Things

- [plantuml extension](https://marketplace.visualstudio.com/items?itemName=jebbs.plantuml)

## Visual Studio Code

All you need to do is to get the PlantUML extension to enable VS Code's native Markdown preview feature to also parse inline diagrams.

By default the plugin requires a local PlantUML process to be running and accepting the rendering requests. I recommend switching it to use a server for rendering; this could be the official plantuml.com server, an on premise instance or a locally running container. After installing the plugin go to the VS Code options (ctrl/⌘ + ,) and change the plantuml.render property.

In a nutshell add these things to your `settings.json`.

```json
// PlantUMLServer: Render diagrams by server which is specified with 
// "plantuml.server". It's much faster, but requires a server.
// Local is the default configuration.
"plantuml.render": "PlantUMLServer",

// Plantuml server to generate UML diagrams on-the-fly.
"plantuml.server": "http://www.plantuml.com/plantuml",

// and reference the stylesheet
"markdown.styles": [
    "github-markdown.css"
]
```

## Compiling markdown

- [https://code.visualstudio.com/Docs/languages/markdown#_using-your-own-css](https://code.visualstudio.com/Docs/languages/markdown#_using-your-own-css)

## plantuml

- https://blog.anoff.io/2018-07-31-diagrams-with-plantuml/