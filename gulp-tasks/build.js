var shell = require('gulp-shell')

module.exports = function (gulp, plugins, global) {

        return shell.task([
            'plantuml -tsvg ./src/content/docs/**/*.puml'   
            ])

}