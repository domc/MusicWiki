angular.
  module('memberDetail').
  component('memberDetail', {
      templateUrl: 'app/members/member-detail/member-detail.template.html',
      controller: ['$stateParams', 'Member', function MemberDetailController($stateParams, Member) {
          this.member = Member.get({ memberId: $stateParams.id });
      }]
  });