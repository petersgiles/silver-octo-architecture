
module.exports = function (gulp, plugins, global, mustache, gutils, rename) {

    var systems = global.getElements(global.data.systems, ["S_DIGITAL_SUITE"]);

    var actors = global.getElements(global.data.actors, ["P_VIP", "P_PMO"]);

    gulp.src("./gulp-tasks/diagrams/supplementary/deployment.mustache")
    // .on("data", function(x) { gutils.log(x)})
        .pipe(mustache({
            title: "Deployment",
            actors: actors,
            systems: systems
        }))
        .pipe(rename(function (path) {
            path.extname = ".puml"
          }))
        .pipe(gulp.dest("./src/content/docs/diagrams/supplementary"))

        ;

}