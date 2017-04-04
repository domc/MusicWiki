angular.
  module('bandDetail').
  component('bandDetail', {
      template: 'TBD: Detail view for <span ng-bind="$ctrl.id"></span>',
      controller: ['$stateParams', function PhoneDetailController($stateParams) {
          this.id = $stateParams.id;
        }
      ]
  });