MusicWikiApp.controller("bandsCtrl", ['$scope', 'bandsService', function ($scope, bandsService) {
    $scope.pageTitle = 'List of all bands';
    $scope.sortBy = "name"; //default sorting by name
    $scope.sortDescending = false; // default ascending
    $scope.searchText = ''; // default blank

       
    getAllBends(); // retrieve all bands from db

    function getAllBends() {
        var servCall = bandsService.getBands();
        servCall.then(function (d) {
            $scope.bands = d.data;
        }, function (error) {
            $scope.error('Oops! Something went wrong while fetching the data.')
        })
    }
}]);