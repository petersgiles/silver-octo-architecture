var shell = require('gulp-shell')

module.exports = function (gulp, plugins, global) {

        return shell.task([
            'brew cask install java',
            'brew install mkdocs',
            'brew install graphviz',
            'brew install plantuml',
            'plantuml -version',
            'mkdocs --version',
            'pip install mkdocs-material',
            'pip install pygments',
            'pip install pymdown-extensions'                      
            ])

}