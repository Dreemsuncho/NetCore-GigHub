
(function () {

    var gulp = require("gulp");

    var paths = {
        srcBootstrapCSS: "./node_modules/bootstrap/dist/**/*.min.css",
        srcBootstrapJS: "./node_modules/bootstrap/dist/**/*.min.js",

        srcJQueryJS: './node_modules/jquery/dist/**/*.min.js',

        srcToastrCSS: "./node_modules/toastr/build/toastr.min.css",
        srcToastrJS: "./node_modules/toastr/build/toastr.min.js"
    };

    var _CONST = {
        bootstrap: "bootstrap",
        jquery: "jquery",
        toastr: "toastr"
    }

    gulp.task("default", Object.values(_CONST));

    gulp.task(_CONST.bootstrap, function () {
        gulp.src([
            paths.srcBootstrapCSS,
            paths.srcBootstrapJS
        ]).pipe(to(_CONST.bootstrap));
    });

    gulp.task(_CONST.jquery, function () {
        gulp.src([
            paths.srcJQueryJS
        ]).pipe(to(_CONST.jquery));
    });

    gulp.task(_CONST.toastr, function () {
        gulp.src([
            paths.srcToastrCSS,
            paths.srcToastrJS
        ]).pipe(to(_CONST.toastr));
    });

    function to(folder) {
        return gulp.dest("./wwwroot/lib/" + folder)
    }

})();