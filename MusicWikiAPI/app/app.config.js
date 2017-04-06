MusicWikiApp.config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {

      // default route
      $urlRouterProvider.otherwise('/bands');

      $stateProvider
          .state('bands', {
              url: '/bands',
              template: '<bands-list></bands-list>'
          })
          .state('bands.detail', {
              url: '/{id:int}',
              views: {
                  '@': {
                      template: '<band-detail></band-detail>'
                  }
              },
          })
          .state('bands.create', {
              url: '/create',
              views: {
                  '@': {
                      template: '<band-create></band-create>'
                  }
              },
          })
          .state('members', {
              url: '/members',
              template: '<members-list></members-list>'
          })
          .state('members.detail', {
              url: '/:id',
              views: {
                  '@': {
                      template: '<member-detail></member-detail>'
                  }
              },
          })
          .state('albums', {
              url: '/albums',
              templateUrl: 'app/albums/albums.html',
              controller: 'albumsCtrl'
          })
  }]);