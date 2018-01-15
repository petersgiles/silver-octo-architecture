var shell = require('gulp-shell')

module.exports = function (gulp, plugins, global) {

        return shell.task([
            'plantuml -tsvg **/*.puml',
            'plantuml -tpng **/*.puml',
            'cd src/content && mkdocs build'
            ])

}