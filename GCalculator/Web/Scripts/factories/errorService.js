app.controller("errorModalController", ["$scope", "errorService", "$uibModalInstance",
    function ($scope, errorService, $uibModalInstance) {

        $scope.ok = function () {
            $uibModalInstance.close();
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }
]);
app.service("errorService",
    ["$uibModal", function factory($uibModal) {
        var promise = function (message) {
           return $uibModal.open({
                backdrop: false,
                controller: "errorModalController",
                template: "<div class='modal-header'><h3><i class='far fa-exclamation-triangle' style='background-color:red'></i>Error</h3></div><div class='modal-body'>" + (message.message || message) + " " + (message.exceptionMessage) + "</div><div class='modal-footer'><button class='btn btn-primary' ng-click='cancel()'>Continue</button></div>"
            });
        }

        var service = {
            displayError: displayError
        }

        return service;

        function displayError(message) {
            promise(message);
        }
    }
    ]);