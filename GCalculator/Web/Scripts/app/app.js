var app = angular.module("gCalculator",
    ["ngMaterial", "ui.router", "ngMessages", "ui.bootstrap", "ui.grid", "ui.bootstrap.modal"]).config([
    "$stateProvider", "$locationProvider", function($stateProvider, $locationProvider) {
        $stateProvider
            .state("default",
                {
                    url: window.MApps.Location("sidebar/"),
                    templateUrl: function() {
                        return window.MApps.Location("Home/Index");
                    }
                })
            .state("calculator",
                {
                    url: window.MApps.Location("sidebar/Templates/Calculator"),
                    templateUrl: function() {
                        return window.MApps.Location("Templates/Calculator");
                    }
                })
            .state("logs",
                {
                    url: window.MApps.Location("sidebar/Templates/Logs"),
                    templateUrl: function() {
                        return window.MApps.Location("Templates/Logs");
                    }
                });
        $locationProvider.html5Mode(true);

    }
]).directive('changeOnBlur',
    function() {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function(scope, elm, attrs) {
                var expressionToCall = attrs.changeOnBlur;

                var oldValue = null;
                elm.bind('focus',
                    function() {
                        scope.$apply(function() {
                            oldValue = elm.val();
                        });
                    });

                elm.bind('blur',
                    function() {
                        scope.$apply(function() {
                            var newValue = elm.val();
                            if (newValue !== oldValue) {
                                scope.$eval(expressionToCall);
                            }
                        });
                    });
            }
        };
    });
