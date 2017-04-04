angular.module("MyApp")
   .controller("bandsCtrl", ['$scope', 'bandsService', function ($scope, bandsService) {
       $scope.pageTitle = 'List of all bands';
       getAllBends();

       function getAllBends() {
           var servCall = bandsService.getBands();
           servCall.then(function (d) {
               $scope.bands = d.data;
           }, function (error) {
               $scope.error('Oops! Something went wrong while fetching the data.')
           })
       }
   }]);