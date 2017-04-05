MusicWikiApp.factory('Band',[ '$resource', function ($resource) {
    return $resource('/api/bands/:bandId', {}, {
        query: {
            method: 'GET',
            params: { bandId: "" },
            isArray: true
        }
    });
}]);