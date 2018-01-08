
module.exports = function (gulp, plugins, global, mustache, gutils, rename) {

    var systems = global.getElements(global.data.systems, ["S_DIGITAL_SUITE"]);
    var actors = global.getElements(global.data.actors, ["P_VIP", "P_PMO", "P_OFFICER", "P_PACK_OWNER", "P_ADMIN", "P_EXTERNAL"]);

    gulp.src("./gulp-tasks/diagrams/uc.mustache")
    // .on("data", function(x) { gutils.log(x)})
        .pipe(mustache({
            title: "Use Case: DSuite",
            actors: actors

        }))
        .pipe(rename(function (path) {
            path.extname = ".puml"
          }))
        .pipe(gulp.dest("./src/content/docs/diagrams"))

        ;

}