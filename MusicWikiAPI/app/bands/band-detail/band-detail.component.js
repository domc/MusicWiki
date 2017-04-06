angular.
  module('bandDetail').
  component('bandDetail', {
      templateUrl: 'app/bands/band-detail/band-detail.template.html',
      controller: ['$stateParams', '$location', 'Band', function BandDetailController($stateParams, $location, Band) {
          this.band = Band.get({ bandId: $stateParams.id });
          this.deleteBand = function () {
              var ans = confirm('Are you sure you want to remove this band?');
              if (ans)
              {
                  Band.delete({ bandId: $stateParams.id },
                      function (band, ResponseHeaders, statusCode, statusText) {
                        alert(statusCode+" "+statusText);
                        $location.url('/bands');
                  }, function (httpResponse) {
                      alert(httpResponse.status+" "+httpResponse.statusText);
                  });
              }              
          }
      }]
  });