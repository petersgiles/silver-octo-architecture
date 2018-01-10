var shell = require('gulp-shell')

module.exports = function (gulp, plugins, global) {

        return shell.task([
            'cd src/content && mkdocs serve',
            'open http://127.0.0.1:8000'                      
            ])

}