//Define the app module and dependencies
var MusicWikiApp = angular.module('MusicWikiApp', [
        'ui.router',
        'ngResource',
        'bandsList',
        'bandDetail',
        'bandCreate',
        'membersList',
        'memberDetail'
]);