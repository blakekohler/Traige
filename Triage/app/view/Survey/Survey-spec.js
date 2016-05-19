///<reference path="../../../.grunt/grunt-contrib-jasmine/jasmine.js"/>
describe('SurveyCtrl', function() {

    beforeEach(module('Triage'));

    var scope,ctrl;

    beforeEach(inject(function($rootScope, $controller) {
      scope = $rootScope.$new();
      ctrl = $controller('SurveyCtrl', {$scope: scope});
    }));

    it('should ...', inject(function() {

        expect(1).toEqual(1);
        
    }));

});
