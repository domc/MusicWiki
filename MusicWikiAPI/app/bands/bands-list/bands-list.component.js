angular.module('bandsList')
	.component('bandsList', {
		templateUrl: 'app/bands/bands-list/bands-list.template.html',
		controller: ['Band', function BandsListController(Band) {
			this.sortBy = "name"; //default sorting by name
			this.sortDescending = false; // default ascending
			this.searchText = ''; // default blank

			this.bands = Band.query();
		}]
	});