MusicWikiApp.service("bandsService", function ($http) {
    this.getBands = function () {
        return $http.get("/api/Bands")
    };
    this.getBandDetails = function (id) {
        return $http.get("/api/Bands/" + id);
    };
});