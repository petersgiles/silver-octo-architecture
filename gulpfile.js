var gulp = require('gulp');
var gutils = require('gulp-util');
var plugins = require('gulp-load-plugins')();
var global = {};

global.SOURCES_BASE_PATH = __dirname + '/src';

function getTask(task) {
    return require('./gulp-tasks/' + task)(gulp, plugins, global);
}

gulp.task('build', getTask('build'));

gulp.task('serve', getTask('serve'));

gulp.task('default', ['build']);
