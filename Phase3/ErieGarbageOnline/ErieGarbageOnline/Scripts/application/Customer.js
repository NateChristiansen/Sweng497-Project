var customer = angular.module('Customer', []);
customer.controller('MessageAdmin', ['$scope', function ($scope) {
    $scope.send = function() {
        $.post('/Customer/SendMessage', $scope.model, function(data, err) {
            alert(data);
        });
    }

    $scope.updatetype = function (type) {
        $.get('/Customer/' + type, function(data) {
            $('#MessageBody').html(data);
        });
    }

    $scope.init = function(model) {
        $scope.model = model;
    }
}]);