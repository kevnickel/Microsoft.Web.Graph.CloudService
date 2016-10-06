﻿/// <binding BeforeBuild='css, js' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var sassSourceFiles = ['Content/src/*.scss'];
var cssDestFolder = 'Content/build';

var gulp = require('gulp');

var plugins = require("gulp-load-plugins")({
    pattern: ['gulp-*', 'gulp.*', 'main-bower-files'],
    replaceString: /\bgulp[\-.]/
});

gulp.task('default', function () {
    // place code for your default task here
});

gulp.task('deploy', ['css']);

gulp.task('sass', function () {
    gulp.src(sassSourceFiles)
        .pipe(plugins.sass())
        .pipe(gulp.dest(cssDestFolder));
});

gulp.task('css', function () {
    var cssOutputFile = 'main.css';
    var cssFiles = [cssDestFolder + '/*.css', '!' + cssDestFolder + '/' + cssOutputFile];

    gulp.src(plugins.mainBowerFiles().concat(cssFiles))
		.pipe(plugins.filter('**/*.css'))
		.pipe(plugins.concat(cssOutputFile))
        .pipe(plugins.cleanCss({ compatibility: 'ie8' }))
		.pipe(gulp.dest(cssDestFolder));
});

gulp.task('watch', function() {
    gulp.watch(sassSourceFiles, ['sass']);
});