angular.module('Triage').config(function($stateProvider, $urlRouterProvider) {

    $stateProvider.state('Home', {
        url: '/home',
        controller: 'HomeCtrl as vm',
        templateUrl: 'app/view/Home/Home.html',
    });

}).controller('HomeCtrl', function ($scope) {

    var vm = this;
    var destroy = $scope.$on("$destroy", function () {
        //Cleanup anything that would persist beyond destruction, including $on/$watch
        destroy();
    });

	vm.results = [
		{
			SurveyTitle: 'Cookie Survey',
			ResultTitle: 'BlakeKohler',
			Id: 1,
			Date: '12/12/12'
		},
		{
			SurveyTitle: 'Cookie Survey',
			ResultTitle: 'BlakeKohler',
			Id: 2,
			Date: '12/12/12'
		},
		{
			SurveyTitle: 'Cookie Survey',
			ResultTitle: 'BlakeKohler',
			Id: 3,
			Date: '12/12/12'
		},
		{
			SurveyTitle: 'Cookie Survey',
			ResultTitle: 'BlakeKohler',
			Id: 4,
			Date: '12/12/12'
		},
		{
			SurveyTitle: 'Cookie Survey',
			ResultTitle: 'BlakeKohler',
			Id: 5,
			Date: '12/12/12'
		},
		{
			SurveyTitle: 'Cookie Survey',
			ResultTitle: 'BlakeKohler',
			Id: 6,
			Date: '12/12/12'
		},
		{
			SurveyTitle: 'Cookie Survey',
			ResultTitle: 'BlakeKohler',
			Id: 7,
			Date: '12/12/12'
		}
	];
});
