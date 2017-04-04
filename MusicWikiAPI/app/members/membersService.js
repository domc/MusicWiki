angular.module("MusicWikiApp")
    .service("membersService", function ($http) {
        this.getMembers = function () {
            return $http.get("/api/members")
        }
    });