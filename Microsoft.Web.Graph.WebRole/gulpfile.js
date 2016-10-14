/// <binding BeforeBuild='sass, css' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

// Location of files
var paths = {
    css: 'Content/build/css',
    scripts: 'Scripts/build/js'
};

// Lists of files to work with
var sources = {
    sass: 'Content/src/**/*.scss',
    css: [
        paths.css + '/**/*.css',
        '!' + paths.css + 'main.css'
    ]
};

var gulp = require('gulp');

var plugins = require("gulp-load-plugins")({
    pattern: ['gulp-*', 'gulp.*', 'run-sequence'],
    replaceString: /\bgulp[\-.]/
});

gulp.task('default', function () {
    // place code for your default task here
});

// Task to run during site deployment
gulp.task('deploy', function(callback) {
    plugins.runSequence('sass',
        ['css'],
        callback);
});

// Create css from sass files
gulp.task('sass', function () {
    gulp.src(sources.sass)
        .pipe(plugins.sass())
        .pipe(gulp.dest(paths.css));
});

// Bundle and minify the css
gulp.task('css', function () {
    var cssOutputFile = 'main.css';

    gulp.src(sources.css)
		.pipe(plugins.concat(cssOutputFile))
        .pipe(plugins.cleanCss({ compatibility: 'ie8' }))
		.pipe(gulp.dest(paths.css));
});

// Build sass on save
gulp.task('watch', function() {
    gulp.watch(sources.sass, ['sass']);
});