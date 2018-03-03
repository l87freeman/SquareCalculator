app.factory('$exceptionHandler', ['$log', '$injector', function ($log, $injector) {
    return function customExceptionHandler(exception, cause) {
        var loggerService = $injector.get("loggerService");
        loggerService.logError('User interface error: ' + exception, cause);
        $log.warn(exception, cause);
    };
}]);