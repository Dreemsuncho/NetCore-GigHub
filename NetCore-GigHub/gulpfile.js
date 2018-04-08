

var gulp = require("gulp");

var paths = {
    srcBootstrapCSS: './node_modules/bootstrap/dist/**/*.min.css',
    srcBootstrapJS: './node_modules/bootstrap/dist/**/*.min.js',

    srcJQueryJS: './node_modules/jquery/dist/**/*.min.js',
};

gulp.task("default", ["bootstrap", "jquery"]);

gulp.task('bootstrap', function () {
    gulp.src([
        paths.srcBootstrapCSS,
        paths.srcBootstrapJS
    ]).pipe(gulp.dest("./wwwroot/lib/bootstrap"));
});

gulp.task('jquery', function () {
    gulp.src([
        paths.srcJQueryJS
    ]).pipe(gulp.dest("./wwwroot/lib/jquery"));
});