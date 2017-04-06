angular.
  module('bandDetail').
  component('bandDetail', {
      templateUrl: 'app/bands/band-detail/band-detail.template.html',
      controller: ['$stateParams', 'Band', function BandDetailController($stateParams, Band) {
          this.band = Band.get({ bandId: $stateParams.id });
      }]
  });