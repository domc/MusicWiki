﻿angular.module("MusicWikiApp")
    .service("bandsService", function ($http) {
        this.getBands = function () {
            return $http.get("/api/Bands")
        }
    });