MusicWikiApp.component('bandsList', {
	templateUrl: 'app/bands/bands-list.template.html',
	controller: function BandsListController(bandsService) {
		this.sortBy = "name"; //default sorting by name
		this.sortDescending = false; // default ascending
		this.searchText = ''; // default blank

		getAllBends(this); // retrieve all bands from db

		function getAllBends(controller) {
			var servCall = bandsService.getBands();
			servCall.then(function (d) {
				controller.bands=d.data;
			}, function (error) {
				controller.error('Oops! Something went wrong while fetching the data.');
			});
		}
	}
});