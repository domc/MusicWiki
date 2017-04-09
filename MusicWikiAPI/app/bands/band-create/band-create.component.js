angular.
  module('bandCreate').
  component('bandCreate', {
      templateUrl: 'app/bands/band-create/band-create.template.html',
      controller: ['Band', '$location', function BandCreateController(Band, $location) {
          this.saveBand = function (formValidationCheck) {
              if (formValidationCheck) {
                  var band = {
                      'name': this.bandName,
                      'country': this.country,
                      'formationDate': this.formationDate,
                      'genre': this.genre
                  };
                  Band.save(band, function (band, ResponseHeaders, statusCode, statusText) {
                      alert(statusCode + " " + statusText);
                      $location.url('/bands');
                  }, function (httpResponse) {
                      alert(httpResponse.status + " " + httpResponse.statusText);
                  });
              }
          }
      }]
  });