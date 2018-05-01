
(function () {

    var gulp = require("gulp");
    var sass = require("gulp-sass");

    var paths = {
        srcBootstrapCSS: "./node_modules/bootstrap/dist/**/*.min.css",
        srcBootstrapJS: "./node_modules/bootstrap/dist/**/*.min.js",

        srcSass: "./Client/scss/*.scss",

        srcJQueryJS: './node_modules/jquery/dist/**/*.min.js',

        srcToastrCSS: "./node_modules/toastr/build/toastr.min.css",
        srcToastrJS: "./node_modules/toastr/build/toastr.min.js",
    };

    var _CONST = {
        bootstrap: "bootstrap",
        sass: "sass",
        jquery: "jquery",
        toastr: "toastr"
    }

    gulp.task("default", Object.values(_CONST));

    gulp.task(_CONST.bootstrap, function () {
        gulp.src([
            paths.srcBootstrapCSS,
            paths.srcBootstrapJS
        ]).pipe(toLib(_CONST.bootstrap));
    });

    gulp.task(_CONST.sass, function () {
        gulp.src([
            paths.srcSass
        ])
            .pipe(sass())
            .pipe(to("css"))
    });

    gulp.task(_CONST.jquery, function () {
        gulp.src([
            paths.srcJQueryJS
        ]).pipe(toLib(_CONST.jquery));
    });

    gulp.task(_CONST.toastr, function () {
        gulp.src([
            paths.srcToastrCSS,
            paths.srcToastrJS
        ]).pipe(toLib(_CONST.toastr));
    });

    function toLib(folder) {
        return gulp.dest("./wwwroot/lib/" + folder)
    }
    function to(folder) {
        return gulp.dest("./wwwroot/" + folder)
    }

})();