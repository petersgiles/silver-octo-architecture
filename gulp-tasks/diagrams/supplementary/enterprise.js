
module.exports = function (gulp, plugins, global, mustache, gutils, rename) {

    var systems = global.getElements(global.data.systems, ["S_DSUITE"]);

    var actors = global.getElements(global.data.actors, ["P_VIP"]);

    gulp.src("./gulp-tasks/diagrams/supplementary/enterprise.mustache")
    // .on("data", function(x) { gutils.log(x)})
        .pipe(mustache({
            title: "Enterprise",
            actors: actors,
            systems: systems
        }))
        .pipe(rename(function (path) {
            path.extname = ".puml"
          }))
        .pipe(gulp.dest("./src/content/docs/diagrams/supplementary"))

        ;

}