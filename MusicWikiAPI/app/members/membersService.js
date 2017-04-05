MusicWikiApp.factory('Member', ['$resource', function ($resource) {
    return $resource('/api/members/:memberId', {}, {
        query: {
            method: 'GET',
            params: { memberId: "" },
            isArray: true
        }
    });
}]);