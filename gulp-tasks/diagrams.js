var mustache = require("gulp-mustache");
var gutils = require('gulp-util');
var rename = require("gulp-rename");
var data = require('./diagrams/metadata.json');
var fs = require('fs');

const through = require('through2')

module.exports = function (gulp, plugins, global) {

    var tasks = [];
    var taskName = nextChar('a');

    function nextChar(c) {
        return String.fromCharCode(c.charCodeAt(0) + 1);
    }
    
    function requireTask(file) {
        var path = file.path;
        gulp.task(taskName, require(path)(gulp, plugins, global, mustache, gutils, rename));
        tasks.push(taskName);
        taskName = nextChar(taskName);
        
    }

    function createPlaceHolder(file) {
        var pathsegs = file.path.split('/');
        var newarray = pathsegs.slice(pathsegs.indexOf('gulp-tasks') + 1).reverse();
        var filename = newarray[0];
        newarray[0] = newarray[0].replace('.js', '.md');
        newarray.reverse();
        var path  = [".","src","content","docs"].concat(newarray).join('/');

        fs.open(path, 'wx', (err, fd) => {
            if (err) {
              if (err.code === 'EEXIST') {
                console.error(path + ' already exists');
                return;
              }
            }

            gulp.src("./gulp-tasks/diagrams.mustache")
                .pipe(mustache({
                    title: filename.replace('.js', ''),
                }))
                .pipe(rename(path))
                .pipe(gulp.dest("."));

          });
    }

    global.data = data;

    global.getElements = function(source, ids){
        return source.filter(el => ids.find(id => id === el.id) !== undefined);
    }

    gulp.src('./gulp-tasks/diagrams/**/*.js')
        .pipe(through.obj((file, enc, cb) => {
            requireTask(file);
            return cb(null, file);
        }))
        .pipe(through.obj((file, enc, cb) => {
            createPlaceHolder(file);
            return cb(null, file);
        }))
    ;

    gulp.task('diagrams', tasks);

}