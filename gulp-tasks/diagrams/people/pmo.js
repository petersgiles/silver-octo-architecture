


module.exports = function (gulp, plugins, global, mustache, gutils, rename) {

    var actors = global.getElements(global.data.actors, ["P_PACK_OWNER"]);
    var systems = global.getElements(global.data.systems, ["S_DIGITAL_SUITE"]);

    var actorsystems = actors.reduce((acc, item) => {
            systems.forEach(element => {
                acc.push( { actor: item.id, system: element.id })
            });
            return acc;
    }, [])

    gulp.src("./gulp-tasks/diagrams/people/pmo.mustache")
    // .on("data", function(x) { gutils.log(x)})
        .pipe(mustache({
            title: "PMO : Actor",
            actors: actors,
            systems: systems,
            actorsystems: actorsystems
        }))
        .pipe(rename(function (path) {
            path.extname = ".puml"
          }))
        .pipe(gulp.dest("./src/content/docs/diagrams/people"))

        ;

}