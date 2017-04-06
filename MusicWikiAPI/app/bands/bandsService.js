MusicWikiApp.factory('Band',[ '$resource', function ($resource) {
    return $resource('/api/bands/:bandId', { bandId: "" });
}]);