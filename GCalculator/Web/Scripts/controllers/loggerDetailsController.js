app.controller("loggerDetailsController",
    ["$scope", "$http", "$uibModal", "$uibModalInstance", "uiGridConstants", "$interval", "errorService", function ($scope, $http, $uibModal, $uibModalInstance, uiGridConstants, $interval, errorService) {
        var vm = this;
        $scope.gridOptions = {};
        $scope.tableHeight = 0;
        $scope.logDescr = $scope.$resolve.item;

        var columnDefs = [
            {
                field: 'type',
                displayName: 'Log entry type',
                width: '15%',
                enableSorting: true,
                enableFiltering: true,
                type: "string"
            },
            {
                field: 'date',
                displayName: 'Log entry date',
                width: '13%',
                type: "date",
                enableSorting: true,
                enableFiltering: true,
                cellFilter: "date:'dd.MM.yyyy HH:mm:ss'",
                sort: { direction: uiGridConstants.ASC }
            },
            {
                field: 'message',
                displayName: 'Log entry message',
                width: '72%',
                enableSorting: true,
                enableFiltering: true,
                type: "string"
            }
        ];

        $scope.gridOptions = {
            exporterMenuCsv: false,
            enableGridMenu: true,
            enableScrollbars: false,
            enableVerticalScrollbar: 2,
            enableFiltering: true,
            columnDefs: columnDefs,
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            }
        };

        $scope.ok = function () {
            $uibModalInstance.close(-1);
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss("cancel");
        };

        $http({
            url: 'api/log/getlogdetails',
                method: "GET",
                params: { logName: $scope.logDescr.name }
            })
            .then(function success(response) {
                $scope.gridOptions.data = response.data;
            }, function error(response) {
                errorService.displayError(response.data);
            });

    }]);