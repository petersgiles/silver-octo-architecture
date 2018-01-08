var gulp = require('gulp');
var gutils = require('gulp-util');
var plugins = require('gulp-load-plugins')();
var global = {};

global.SOURCES_BASE_PATH = __dirname + '/src';


function getTask(task) {
    return require('./gulp-tasks/' + task)(gulp, plugins, global);
}

gulp.task('install', getTask('install'));

gulp.task('install-win', getTask('install-win'));

gulp.task('diagram', getTask('diagrams'));

gulp.task('build', getTask('build'));

gulp.task('default', ['diagrams', 'build']);
