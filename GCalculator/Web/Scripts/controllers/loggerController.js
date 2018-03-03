app.controller("loggerController", ["$scope", "$http", "$timeout", "uiGridConstants", "$uibModal", "errorService", "$log",
    function ($scope, $http, $timeout, uiGridConstants, $uibModal, errorService, $log, $document) {
        var vm = this;

        $scope.tableHeight = 0;

        var columnDefs = [
            {
                field: 'name',
                displayName: 'Log name',
                width: '50%',
                enableSorting: true,
                enableFiltering: true,
                type: "string"
            },
            {
                field: 'date',
                displayName: 'Log creation date',
                width: '40%',
                type: "date",
                enableSorting: true,
                enableFiltering: true,
                cellFilter: "date:'dd.MM.yyyy HH:mm:ss'",
                sort: { direction: uiGridConstants.DESC }
            },
            {
                name: "actions",
                displayName: "",
                width: '10%',
                enableSorting: false,
                enableFiltering: false,
                cellTemplate:
                '<div class="container text-center"><button class="btn btn-primary" title="Ditails" ' +
                'type="button" ng-click="grid.appScope.viewDetails(row.entity)">' +
                '<i class="fas fa-info-circle"></i></button></div>'
            }
        ];

        $scope.gridOptions = {
            exporterMenuCsv: false,
            enableGridMenu: true,
            enableScrollbars: true,
            enableVerticalScrollbar: 2,
            enableFiltering: true,
            columnDefs: columnDefs,
            onRegisterApi: function (gridApi) {
                vm.gridApi = gridApi;
            }
        };


        $scope.viewDetails = function (row) {
            var uibModalInstance = $uibModal.open({
                backdrop: false,
                controller: 'loggerDetailsController',
                templateUrl: '/Templates/LogDetails',
                resolve: {
                    item: function () {
                        return row;
                    }
                },
                windowClass: 'modal-lg'
            }).result.then(function () {
                $log.info("Modal closed");
            }, function () {
                $log.info("Modal dismissed");
            });
        }

        $http.get('api/log/getloglist')
            .then(function success(response) {
                $scope.gridOptions.data = response.data;
                $timeout(resize, 50);
            },
            function error(response) {
                errorService.displayError(response.data);
            });

        function resize() {
            $scope.tableHeight = $scope.gridOptions.data.length * 30 + 60;
        }
    }]);