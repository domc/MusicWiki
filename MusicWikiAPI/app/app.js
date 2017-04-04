//Define the app module and dependencies
var MusicWikiApp = angular.module('MusicWikiApp', [
        'ui.router',
        'bandsList',
        'bandDetail',
        'membersList'
]);

MusicWikiApp.config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {

      // default route
      $urlRouterProvider.otherwise('/');

      $stateProvider
          .state('bands', {
              url: '/bands',
              template: '<bands-list></bands-list>'
          })
            .state('bands.detail', {
                url: '/:id',
                views: {
                    '@': {
                        template: '<band-detail></band-detail>'
                    }
                },
            })
          .state('members', {
              url: '/members',
              template: '<members-list></members-list>'
          })
          .state('albums', {
              url: '/albums',
              templateUrl: 'app/albums/albums.html',
              controller: 'albumsCtrl'
          })
  }]);