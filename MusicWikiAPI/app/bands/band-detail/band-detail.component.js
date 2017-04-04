angular.
  module('bandDetail').
  component('bandDetail', {
      template: 'TBD: Detail view for <span ng-bind="$ctrl.id">{{$ctrl.id}}</span>',
      controller: [function PhoneDetailController() {
          this.id = "blah";//$stateParams.id;
        }
      ]
  });