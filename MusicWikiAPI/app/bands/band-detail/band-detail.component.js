angular.
  module('bandDetail').
  component('bandDetail', {
      templateUrl: 'app/bands/band-detail/band-detail.template.html',
      controller: ['$stateParams', 'bandsService', function PhoneDetailController($stateParams, bandsService) {
          this.id = $stateParams.id;

          getBandDetails(this, this.id); // retrieve bands details from db

          function getBandDetails(ctrl, id) {
              var servCall = bandsService.getBandDetails(id);
              servCall.then(function (d) {
                  ctrl.band = d.data;
              }, function (error) {
                  ctrl.error='Oops! Something went wrong while fetching the data.';
              });
          }
        }
      ]
  });