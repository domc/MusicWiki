angular.module('membersList')
    .component('membersList', {
        templateUrl: 'app/members/members-list/members-list.template.html',
        controller: ['Member', function MembersListController(Member) {
            this.sortBy = "firstName"; //default sorting by last name
            this.sortDescending = false; // default ascending
            this.searchText = ''; // default blank

            this.members = Member.query();
        }]
    });