
var mustache = require("gulp-mustache");
var gutils = require('gulp-util');
var rename = require("gulp-rename");

module.exports = function (gulp, plugins, global) {

    gulp.src("./gulp-tasks/diagrams/activity.mustache")
    // .on("data", function(x) { gutils.log(x)})
        .pipe(mustache({
            msg: "Hello Gulp!",
            actors: ["Alice", "Brett"]
        }))
        .pipe(rename(function (path) {
            path.extname = ".puml"
          }))
        .pipe(gulp.dest("./src/content/docs/diagrams"))

        ;

}