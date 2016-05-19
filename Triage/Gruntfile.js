/// <binding ProjectOpened='watch' />
'use strict';

module.exports = function (grunt) {

	var bower_components = grunt.file.readJSON("bower_components.json");

	require('load-grunt-tasks')(grunt);

	//Using exclusion patterns slows down Grunt significantly
	//instead of creating a set of patterns like '**/*.js' and '!**/node_modules/**'
	//this method is used to create a set of inclusive patterns for all subdirectories
	//skipping node_modules, bower_components, dist, and any .dirs
	//This enables users to create any directory structure they desire.
	var createFolderGlobs = function (fileTypePatterns) {
		fileTypePatterns = Array.isArray(fileTypePatterns) ? fileTypePatterns : [fileTypePatterns];
		var ignore = ['node_modules', 'bower_components', 'dist', 'temp', 'Scripts', 'obj'];
		var fs = require('fs');
		return fs.readdirSync(process.cwd())
				.map(function (file) {
					if (ignore.indexOf(file) !== -1 ||
							file.indexOf('.') === 0 ||
							!fs.lstatSync(file).isDirectory()) {
						return null;
					} else {
						return fileTypePatterns.map(function (pattern) {
							return file + '/**/' + pattern;
						});
					}
				})
				.filter(function (patterns) {
					return patterns;
				})
				.concat(fileTypePatterns);
	};

	// Project configuration.
	grunt.initConfig({
		ngAnnotate: {
			appScripts: {
				options: {
					sourceMap: true
				},
				files: [{
						expand: true,
						src: ["app/**/*.js", "!app/**/*-spec.js"],
						dest: 'temp/annotated/',
						ext: '.annotated.js'
					}]
			},
			dist: {
				options: {
					sourceMap: false
				},
				files: [{
						expand: true,
						src: ["app/**/*.js", "!app/**/*-spec.js"],
						dest: 'temp/dist/annotated/',
						ext: '.annotated.js'
					}]
			}
		},
		htmlmin: {
			index: {
				options: {
					collapseWhitespace: true
				},
				files: {
					'dist/index.html': 'temp/dist/index.html'
				}
			},
			distHtml: {
				options: {
					collapseWhitespace: true
				},
				files: [
					{expand: true, src: ['app/**/*.html'], dest: 'dist/'}
				]
			}
		},
		concat: {
			options: {
				separator: ';\n',
				sourceMap: true
			},
			vendorScripts: {
				src: bower_components.vendor,
				dest: 'temp/bower_scripts.js'
			},
			distVendorScripts: {
				options: {
					sourceMap: false
				},
				src: bower_components.vendor,
				dest: 'temp/dist/bower_scripts.js'
			},
			vendorDevScripts: {
				src: bower_components.dev,
				dest: 'temp/vendor_dev_scripts.js'
			},
			appScripts: {
				src: ['temp/annotated/app/app.js', "temp/annotated/app/**/*.js"],
				dest: 'temp/app_scripts.js'
			},
			distSuperAppScripts: {
				options: {
					sourceMap: false
				},
				src: ['temp/dist/annotated/app/app.js', "temp/dist/annotated/app/**/*.js", "temp/dist/templates.js"],
				dest: 'temp/dist/app_scripts.js'
			},
			distAppScripts: {
				options: {
					sourceMap: false
				},
				src: ['temp/dist/annotated/app/app.js', "temp/dist/annotated/app/**/*.js"],
				dest: 'temp/dist/app_scripts.js'
			},
			dist: {
				options: {
					sourceMap: false
				},
				src: ['temp/dist/bower_scripts.js', 'temp/dist/app_scripts.min.js'],
				dest: 'dist/app.js'
			}
		},
		uglify: {
			app: {
				options: {
					sourceMap: true,
					sourceMapIn: 'temp/app_scripts.js.map',
					mangle: false
				},
				files: {
					'temp/app_scripts.min.js': ['temp/app_scripts.js']
				}
			},
			dist: {
				options: {
					sourceMap: false
				},
				files: {
					'temp/dist/app_scripts.min.js': ['temp/dist/app_scripts.js']
				}
			}
		},
		ngtemplates: {
			dist: {
				options: {
					module: 'Triage',
					htmlmin: {
						collapseBooleanAttributes: true,
						collapseWhitespace: true,
						removeAttributeQuotes: true,
						removeComments: false, // Only if you don't use comment directives!
						removeEmptyAttributes: true,
						removeRedundantAttributes: true,
						removeScriptTypeAttributes: true,
						removeStyleLinkTypeAttributes: true
					}
				},
				src: 'app/**/*.html',
				dest: 'temp/dist/templates.js'
			}
		},
		less: {
			app: {
				options: {
					compress: true,
					sourceMap: true,
					sourceMapFileInline: true
				},
				files: {
					'temp/app.css': 'app/app.less'
				}
			},
			appDist: {
				options: {
					compress: true,
					sourceMap: false
				},
				files: {
					'dist/app.css': 'app/app.less'
				}
			},
		},
		jshint: {
			options: {
				jshintrc: '.jshintrc',
			},
			teamcity: {
				options: {
					force: true,
					reporter: 'checkstyle',
					reporterOutput: 'temp/reports/jshint_checkstyle.xml'
				},
				files: {src: [createFolderGlobs('*.js')]}
			},
			app: {
				options: {
					force: true
				},
				files: {src: [createFolderGlobs('*.js')]}
			}
		},
		// lesslint: { //This includes bootstrap, need to figure out how to not include bootstrap.
		//     options: {
		//         csslint: { csslintrc: '.csslintrc' },
		//         force: true
		//     },
		//     teamcity: {
		//         options: {
		//             formatters: [{ id: 'checkstyle-xml', dest: 'temp/reports/csslint_checkstyle.xml' }]
		//         },
		//     },
		//     app: {
		//         src: ["app/app.less"]
		//     }
		// },
		jasmine: {
			tests: {
				src: ['temp/app_scripts.min.js'],
				options: {
					junit: {path: "temp/reports/jasmine_junit"},
					specs: 'app/**/*-spec.js',
					vendor: ["temp/bower_scripts.js", "temp/vendor_dev_scripts.js"],
					outfile: 'temp/specrunner.html',
					keepRunner: true
				}
			}
		},
		connect: {
			tests: {
				options: {
					port: 9001,
					open: 'http://localhost:9001/temp/specrunner.html'
				}
			},
			app: {
				options: {
					port: 9000,
					open: 'http://localhost:9000/index.html'
				}
			}
		},
		watch: {
			options: {
				livereload: true,
				atBegin: true
			},
			tasks: {
			  files: [],
			  tasks: ['copy:build']
			},
			less: {
				files: ['app/**/*.less'],
				tasks: ['less:app'],
				options: {
					livereload: false
				}
			},
			js: {
				files: ['app/**/*.js', '!app/**/*-spec.js'],
				tasks: ['ngAnnotate', 'concat:appScripts', 'uglify:app']
			},
			devJs: {
				files: ['bower_components/**/*.js', 'bower_components.json'],
				tasks: ['concat:vendorScripts', 'concat:vendorDevScripts']
			},
			html: {
				files: ['app/**/*.html', 'index.html', 'index.cshtml'],
				tasks: []
			},
			css: {
				files: ['temp/app.css'],
				tasks: []
			},
			bower: {
				files: ['bower.json'],
				tasks: ['bowerinstall']
			},
			tests: {
				files: ['app/**/*-spec.js'],
				tasks: ['jasmine:tests:build']
			}
		},
		clean: {
			dist: ['dist', 'temp/dist'],
			temp: ['temp']
		},
		copy: {
			dist: {
				files: [
					{expand: true, src: ['img/*'], dest: 'dist/'},
					{expand: true, flatten: true, src: ['bower_components/font-awesome/fonts/*'], dest: 'dist/fonts/'},
					{expand: true, flatten: true, src: ['bower_components/bootstrap/fonts/*'], dest: 'dist/fonts/'}
				]
			},
			build: {
				files: [
					{expand: true, flatten: true, src: ['bower_components/font-awesome/fonts/*'], dest: 'temp/fonts/'},
					{expand: true, flatten: true, src: ['bower_components/bootstrap/fonts/*'], dest: 'temp/fonts/'}
				]
			}
		},
		dom_munger: {
			dist: {
				options: {
					remove: 'script[replace=true]',
					append: {selector: 'body', html: '<script src="app.js"></script>'},
					update: {selector: 'link[href="temp/app.css"]', attribute: 'href', value: 'app.css'}
				},
				src: 'index.html',
				dest: 'temp/dist/index.html'
			}
		},
		concurrent: {
			build: ['concat:vendorScripts', 'concat:vendorDevScripts', 'less:app', 'jasmine:tests:build']
		}
	});

	grunt.registerTask('bowerinstall', 'install the backend and frontend dependencies', function () {
		var exec = require('child_process').exec;
		var cb = this.async();
		exec('bower install', {cwd: ''}, function (err, stdout, stderr) {
			console.log(stdout);
			cb();
		});
	});
	grunt.registerTask('build', 'Generates temp/compiled files necessary to run', ['clean:temp', 'ngAnnotate', 'concat:appScripts', 'uglify:app', 'concurrent:build', 'copy:build']);
	grunt.registerTask('serve', 'Builds and hosts project with watch', ['build', 'connect:app', 'watch']);
	grunt.registerTask('lint', 'Runs code quality inspections', ['jshint:app']);
	grunt.registerTask('lintTeamcity', 'Runs code quality inspections and generates reports for teamcity', ['jshint:teamcity']);
	grunt.registerTask('tests', 'Runs jasmine tests', ['build', 'jasmine:tests']);
	grunt.registerTask('debugTests', 'Debugs jasmine tests.', ['build', 'connect:tests', 'watch:tests']);
	grunt.registerTask('distWithTemplates', [
		'clean:dist',
		'ngAnnotate:dist',
		'ngtemplates:dist',
		'concat:distSuperAppScripts',
		'concat:distVendorScripts',
		'uglify:dist',
		'concat:dist',
		'less:appDist',
		'dom_munger:dist',
		'htmlmin:index',
		'copy:dist']);
	grunt.registerTask('dist', [
		'clean:dist',
		'ngAnnotate:dist',
		'concat:distAppScripts',
		'concat:distVendorScripts',
		'uglify:dist',
		'concat:dist',
		'less:appDist',
		'dom_munger:dist',
		'htmlmin:index',
		'htmlmin:distHtml',
		'copy:dist']);
};
