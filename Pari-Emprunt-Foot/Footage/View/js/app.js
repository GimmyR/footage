var app = angular.module('app', ['route']);

var route = angular.module('route', ['ngRoute']);

route.config(['$routeProvider', function($routeProvider){

	$routeProvider
		.when('/login', {
			templateUrl: 'View/templates/login.html',
			controller: 'ctrl-login'
		})

		.when('/matchs', {
			templateUrl: 'View/templates/matchs.html',
			controller: 'ctrl-matchs'
		})

		.when('/configPari', {
			templateUrl: 'View/templates/config-pari.html',
			controller: 'ctrl-config-pari'
		})

		.when('/choixPari', {
			templateUrl: 'View/templates/choix-pari.html',
			controller: 'ctrl-choix-pari'
		})

		.when('/pariInt', {
			templateUrl: 'View/templates/pari-int.html',
			controller: 'ctrl-pari-int'
		})

		.when('/jonction', {
			templateUrl: 'View/templates/jonction.html',
			controller: 'ctrl-jonction'
		})

		.when('/paris', {
			templateUrl: 'View/templates/paris.html',
			controller: 'ctrl-paris'
		})

		.when('/emprunter', {
			templateUrl: 'View/templates/emprunter.html',
			controller: 'ctrl-emprunter'
		})

		.when('/simplePlan', {
			templateUrl: 'View/templates/simple-plan.html',
			controller: 'ctrl-simple-plan'
		})

		.when('/planDefinitif', {
			templateUrl: 'View/templates/plan-definitif.html',
			controller: 'ctrl-plan-definitif'
		})

		.when('/emprunts', {
			templateUrl: 'View/templates/emprunts.html',
			controller: 'ctrl-emprunts'
		})

		.when('/voirPlan', {
			templateUrl: 'View/templates/voir-plan.html',
			controller: 'ctrl-voir-plan'
		})

		.when('/modifSimplePlan', {
			templateUrl: 'View/templates/modif-simple-plan.html',
			controller: 'ctrl-modif-simple-plan'
		})

		.when('/modifPlanDefinitif', {
			templateUrl: 'View/templates/modif-plan-definitif.html',
			controller: 'ctrl-modif-plan-definitif'
		})

		.when('/crediter', {
			templateUrl: 'View/templates/crediter.html',
			controller: 'ctrl-crediter'
		})

		.when('/admin', {
			templateUrl: 'View/templates/admin.html',
			controller: 'ctrl-admin'
		})

		.otherwise({
			redirectTo: '/login'
		});

}]);