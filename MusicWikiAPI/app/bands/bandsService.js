angular.module("MyApp")
    .service("bandsService", function ($http) {
        this.getBands = function () {
            return $http.get("/api/Bands")
        }
    });