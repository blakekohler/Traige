var App = App || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('Triage');
    App.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

})(App);