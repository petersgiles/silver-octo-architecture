var gulp = require('gulp');
var gutils = require('gulp-util');
var plugins = require('gulp-load-plugins')();

var cache = require('gulp-cached');
var shell = require('gulp-shell');

var global = {};

global.SOURCES_BASE_PATH = __dirname + '/src';

function getTask(task) {
    return require('./gulp-tasks/' + task)(gulp, plugins, global);
}

gulp.task('watch', function(){
    gulp.watch('src/content/docs/**/*.*uml', ['puml']);
});

gulp.task('puml', function(){
    gulp.src(['src/content/docs/**/*.puml'])
        .pipe(cache('puml'))
        .pipe(shell([
            'echo <%= file.path %>',
            'plantuml -tsvg <%= file.path %>',
            'plantuml -tpng <%= file.path %>']))  
});
  

gulp.task('serve', getTask('serve'));

gulp.task('build', ['puml']);

gulp.task('default', ['watch', 'puml', 'serve']);
