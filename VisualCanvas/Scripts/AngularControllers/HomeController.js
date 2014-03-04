angular.module('root', [])
.controller('homeController', ['$scope', '$http', '$sce', function($scope, $http, $sce) {
     $scope.inputText = '<StackPanel Orientation="Horizontal"><Element1 /><TextBlock Text="test2" Width="100" HorizontalAlignment="Right"/><Element1 /></StackPanel>'
    $scope.submit = function () {
        $http.post(baseUrl + 'api/homeapi/submit?inputText=' + $scope.inputText).success(function (result) {
            var trimmed = result.substring(1, result.length - 2);
            $scope.result = $('#hidden').html(trimmed).text();
            console.log($scope.result);
        });
    }

    $scope.trustMe = function () {
        return $sce.trustAsHtml($scope.result);
    }
}]);