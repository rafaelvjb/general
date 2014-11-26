(function () {
    'use strict';

    //create angularjs controller
    var app = angular.module('app', []);//set and get the angular module
    app.controller('customerController', ['$scope', '$http', customerController]);

    //angularController Method
    function customerController($scope, $http) {
        //declare variable for mainain ajax Load and entry or edit mode
        $scope.loading = true;
        $scope.addMode = false;

        //get all customers information
        $http.get('/api/Customer')
            .success(function (data) {
                $scope.customers = data;
                $scope.loading = false;
            })
            .error(function () {
                $scope.error = "An error occoured while loading posts!";
                $scope.loading = false;
            });

        //by pressing toggleEdit button ng-click in html, this method will de hit
        $scope.toggleEdit = function () {
            this.customer.editMode = !this.customer.editMode;
        };

        //by pressing toggleAdd button ng-click in html, this method will be hit
        $scope.toggleAdd = function () {
            $scope.addMode = !$scope.addMode;
        };

        //insert Customer
        $scope.add = function () {
            $scope.loading = true;
            $http.post('/api/Customer/', this.newcustomer)
                .success(function (data) {
                    alert("Added Successfully!");

                    $scope.addMode = false;
                    $scope.customers.push(data);
                    $scope.loading = false;

                })
                .error(function (data) {
                    $scope.error = "An Error occoured while insert a Customer! " + data;
                    $scope.loading = false;
                });
        };

        //Edit Customer
        $scope.save = function () {
            alert("Edit");

            $scope.loading = true;

            var frien = this.customer;
            alert(frien);

            $http.put('/api/Customer/' + frien.Id, frien)
                .success(function (data) {
                    alert("Saved Succefully!");

                    frien.editMode = false;
                    $scope.loading = false;
                })
                .error(function (data) {
                    $scope.error = "An error occoured while edit Customer!" + data;
                    scope.loading = false;
                });
        };

        //Delete Customer
        $scope.deleteCustomer = function () {
            $scope.loading = true;

            var Id = this.customer.Id;

            $http.delete('/api/Customer/' + Id)
                .success(function (data) {
                    alert("Deleted Succefully");

                    $.each($scope.customers, function (i) {
                        if ($scope.customers[i].Id === Id) {
                            $scope.customers[i].splice(i, 1);
                            return false;
                        }
                    });
                    $scope.loading = false;
                })
                .error(function (data) {
                    $scope.error = "An error occoured while Deleting Customer! " + data;
                    $scope.loading = false;
                });
        };

    }

})();