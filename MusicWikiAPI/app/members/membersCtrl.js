angular.module("MusicWikiApp")
   .controller("membersCtrl", ['$scope', 'membersService', function ($scope, membersService) {
       $scope.pageTitle = 'List of members';
       $scope.sortBy = "lastName"; //default sorting by last name
       $scope.sortDescending = false; // default ascending
       $scope.searchText = ''; // default blank
       getAllMembers();

       function getAllMembers() {
           var servCall = membersService.getMembers();
           servCall.then(function (d) {
               $scope.members = d.data;
           }, function (error) {
               $scope.error('Oops! Something went wrong while fetching the data.')
           })
       }
   }]);