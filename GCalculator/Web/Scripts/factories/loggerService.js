app.service("loggerService",
    ['$http', 'errorService', function factory($http, errorService) {
        var urls = {};
        urls.warn = "api/log/logwarning";
        urls.info = "api/log/loginfo";
        urls.error = "api/log/logerror";
        urls.fatal = "api/log/logfatal";


        var service = {
            logWarn: logWarn,
            logInfo: logInfo,
            logError: logError,
            logFatal: logFatal
        };

        return service;

        function logWarn(message) {
            log(urls.warn, message);
        }

        function logInfo(message) {
            log(urls.info, message);
        }

        function logError(message) {
            log(urls.error, message);
        }

        function logFatal(message) {
            log(urls.fatal, message);
        }

        function log(url, message) {
            var promise = $http({
                method: "PUT",
                url: url,
                data: { message: message }
            });
            promise.then(function success(response) {
                console.log(response);
            },
                function error(response) {
                    errorService.display(response.data);
                });
        }
    }
    ]);