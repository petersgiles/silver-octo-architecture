var shell = require('gulp-shell')

module.exports = function (gulp, plugins, global) {

        return shell.task([       
            'plantuml -tpng **/*.puml',
            'cd src/content && mkdocs build',
            'cd src/content && mkdocscombine -o ../../mydocs.pd',
            'pandoc --toc -f markdown+grid_tables+table_captions -o mydocs.pdf mydocs.pd'  
            ])

}