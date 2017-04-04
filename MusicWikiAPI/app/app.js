angular.module('MyApp', ['ui.router'])
  .config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {

      // default route
      $urlRouterProvider.otherwise('/');

      $stateProvider
          .state('bands', {
              url: '/',
              templateUrl: 'app/bands/bands.html',
              controller: 'bandsCtrl'
          })
          .state('members', {
              url: '/members',
              templateUrl: 'app/members/members.html',
              controller: 'membersCtrl'
          })
          .state('albums', {
              url: '/albums',
              templateUrl: 'app/albums/albums.html',
              controller: 'albumsCtrl'
          })
  }]);