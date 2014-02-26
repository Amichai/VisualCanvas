angular.module('root', [])
.controller('homeController', ['$scope', '$http', function($scope, $http) {
    var hub = $.connection.HomeHub;
    $.connection.hub.start().done(function () {

    });

    hub.client.ConnectionEstablished = function () {

        console.log('connection established!');
    }

    $scope.submit = function () {
        debugger;
        $http.post(baseUrl + 'api/homeapi/submit?inputText=' + $scope.inputText).success(function () {

        });
    }

    $scope.buttonPress = function () {
        hub.server.buttonPress().done(function(result){
            console.log(result);

        });
    }
}]);