angular.module('Triage', ['ui.bootstrap','ui.router', 'angular-loading-bar','ngAnimate','angularMoment']);

angular.module('Triage').config(function($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/home');

});

angular.module('Triage').run(function($rootScope) {



});
