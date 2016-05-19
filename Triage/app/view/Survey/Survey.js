angular.module('Triage').config(function($stateProvider, $urlRouterProvider) {
    
    $stateProvider.state('Survey', {
        url: '/Survey/:id',
        controller: 'SurveyCtrl as vm',
        templateUrl: 'app/view/Survey/Survey.html',
    });    

}).controller('SurveyCtrl', function ($scope) {
 
    var vm = this;
    var destroy = $scope.$on("$destroy", function () {
        //Cleanup anything that would persist beyond destruction, including $on/$watch
        destroy();
    });
});