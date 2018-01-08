
module.exports = function (gulp, plugins, global, mustache, gutils, rename) {

    var systems = global.getElements(global.data.systems, ["S_DIGITAL_SUITE"]);
    var actors = global.getElements(global.data.actors, ["P_VIP", "P_OFFICER"]);
    var ipadcomponents = global.getElements(global.data.components, ["C_APP_MOB", "C_APP_BROWSER"]);

    gulp.src("./gulp-tasks/diagrams/uc.dsuite.mustache")
    // .on("data", function(x) { gutils.log(x)})
        .pipe(mustache({
            title: "Use Case: DSuite",
            actors: actors,
            systems: systems,
            ipadcomponents: ipadcomponents
        }))
        .pipe(rename(function (path) {
            path.extname = ".puml"
          }))
        .pipe(gulp.dest("./src/content/docs/diagrams"))

        ;

}