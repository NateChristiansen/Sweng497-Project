var admin = angular.module('Admin', []);
admin.controller('CreateAdmin', ['$scope', function($scope) {
        $scope.create = function(newAdmin) {
            $.post("/Admin/CreateNewAdmin", newAdmin, function(data, err) {
                alert(data);
            });
        };
    }
]);