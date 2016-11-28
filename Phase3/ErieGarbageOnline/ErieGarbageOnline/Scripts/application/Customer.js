var customer = angular.module('Customer', []);
customer.controller('MessageAdmin', ['$scope', function ($scope, customerModel) {
    $scope.messageType = messagemodel.MessageTypes;
    $scope.send = function(message) {

    };
}]);