app.controller("calculatorController",
    ["$scope", "$http", "loggerService", "errorService", "$timeout", function ($scope, $http, loggerService, errorService, $timeout) {

        loggerService.logInfo("user on a calculation page");
        $scope.pointsArray = [];
        $scope.squareObj = {};

        $scope.calculate = function () {
            loggerService.logInfo("square calculation begin");
            var promise = $http({
                method: "POST",
                url: "api/Calculator/Calculate",
                data: prepareData($scope.pointsArray)
            });
            promise.then(function success(response) {
                $scope.squareObj = response.data;
                $timeout(function () {
                    draw($scope.squareObj.points);
                }, 100);
                loggerService.logInfo("square calculation enden, calculated square is: " + response.data.square);
            },
                function error(response) {
                    errorService.displayError(response.data);
                    //loggerService.logError("square calculation error: " + (response.data.message || response.data));
                });
        };


        $scope.ifCanDelete = function () {
            return $scope.pointsArray.length <= 1;
        };

        $scope.ifCanCalculate = function () {
            return $scope.pointsArray.length < 3;
        };

        $scope.remove = function () {
            var elem = $scope.pointsArray.pop();
            $("#point_" + elem.pointId).remove();
            loggerService.logInfo("user remove a point");
        };

        $scope.addNew = function () {
            var point = {};
            $scope.pointsArray.push(point);
            loggerService.logInfo("user add a new point");
        };

        $scope.$on("$destroy", function () {
            loggerService.logInfo("user leave the calculation page");
        });

        $scope.change = function (ind, tp) {
            var isError = false;
            var errors = $scope.pointsForm["point_" + tp + "_" + ind].$error;
            var message = "user change value of " + tp + " to " + getValue(ind, tp);

            for (var e in errors) {
                if (errors.hasOwnProperty(e)) {
                    message += ", with error: " + e;
                    isError = true;
                }
            }

            if (isError) {
                loggerService.logWarn(message);
            } else {
                loggerService.logInfo(message);
            }
        };

        function getValue(ind, tp) {
            var modVal = $scope.pointsArray[ind][tp];
            if (typeof (modVal) === "undefined") {
                modVal = $("input[name='point_" + tp + "_" + ind + "']").val();
            }
            return modVal;
        }

        function prepareData(array) {
            var temp = [];
            array.forEach(function (v) {
                v.x = v.x.replace(",", ".");
                v.y = v.y.replace(",", ".");
                temp.push(v);
            });
            return temp;
        }

        function draw(points) {
            if (!Array.isArray(points) || points.length === 0)
                return;
            console.log(points);
            var ctxObj = getCanvasContext();
            ctxObj.context.beginPath();

            var pointObj = {};
            pointObj = getPointObject(points, 0, ctxObj);

            ctxObj.context.moveTo(pointObj.dx, pointObj.dy);
            ctxObj.context.fillText(pointObj.text, pointObj.textPosition.x, pointObj.textPosition.y);

            for (var i = 1; i < points.length; i++) {
                pointObj = getPointObject(points, i, ctxObj);
                ctxObj.context.lineTo(pointObj.dx, pointObj.dy);
                ctxObj.context.fillText(pointObj.text, pointObj.textPosition.x, pointObj.textPosition.y);
            }
            ctxObj.context.closePath();
            ctxObj.context.stroke();
        }

        function getPointObject(points, ind, ctxObj) {
            var pointObj = {}
            pointObj.delta = getDelta(points, ctxObj.width, ctxObj.height);
            pointObj.x = points[ind].x;
            pointObj.y = points[ind].y;
            pointObj.dx = pointObj.x * pointObj.delta.x;
            pointObj.dy = ctxObj.height - pointObj.y * pointObj.delta.y;
            pointObj.text = "(" + pointObj.x + ", " + pointObj.y + ")";
            pointObj.textPosition = { x: pointObj.dx - 10, y: pointObj.dy + 10 };

            return pointObj;
        };


        function getDelta(points, width, height) {
            var maxX = 0, maxY = 0;
            var delta = {};
            for (var p in points) {
                if (points.hasOwnProperty(p)) {
                    if (points[p].x > maxX)
                        maxX = points[p].x;
                    if (points[p].y > maxY)
                        maxY = points[p].y;
                }
            }

            delta.x = (width - (width * 0.07)) / maxX;
            delta.y = (height - (height * 0.07)) / maxY;
            return delta;
        }

        function getCanvasContext() {
            var cx = {};
            cx.context = document.querySelector("canvas").getContext("2d");
            cx.width = cx.context.canvas.width;
            cx.height = cx.context.canvas.height;
            cx.context.clearRect(0, 0, cx.width, cx.height);
            return cx;
        }
    }]);