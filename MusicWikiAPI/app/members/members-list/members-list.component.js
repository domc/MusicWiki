angular.module('membersList')
    .component('membersList', {
        templateUrl: 'app/members/members-list/members-list.template.html',
        controller: ['membersService', function MembersListController(membersService) {
            this.sortBy = "firstName"; //default sorting by last name
            this.sortDescending = false; // default ascending
            this.searchText = ''; // default blank

            getAllMembers(this); // retrieve all bands from db

            function getAllMembers(controller) {
                var servCall = membersService.getMembers();
                servCall.then(function (d) {
                    controller.members = d.data;
                }, function (error) {
                    controller.error('Oops! Something went wrong while fetching the data.');
                });
            }
        }]
    });