angular.module("MyApp")
   .controller("bandsCtrl", ['$scope', function ($scope) {
       $scope.pageTitle = 'home page';
       $scope.message = 'This is the message from controller to view on page';
   }]);