var shell = require('gulp-shell')

module.exports = function (gulp, plugins, global) {

        return shell.task([
            'choco install jre8',
            'choco install mkdocs',
            'choco install graphviz',
            'choco install plantuml',
            'plantuml -version',
            'mkdocs --version'                      
            ])

}