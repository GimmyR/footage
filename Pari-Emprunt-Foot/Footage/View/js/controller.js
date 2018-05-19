app.controller('ctrl-login', ['$scope', 'service', function ($scope, service) {

	$scope.login = {};

	var verifConnect = function(res){

		if(!res.error){

			localStorage.setItem('login', res.data);

			if(res.data != 'CL000')
				document.location.href = "#/matchs";
			else
				document.location.href = "#/admin";

		} else if(res.message != null){

			alert(res.message);

		}

	};

    $scope.connect = function(){

    	service.getPromise('POST', 'Client', $scope.login, 'application/json')

    	.then(function(res){
			
			verifConnect(res.data);
			
		}, function(err){
			
			console.log(err);
			
		});

    };

    if(localStorage.getItem('login') != null)
    	document.location.href = "#/matchs";

    $('.header').hide();
    $('.section-content').hide();
    $('.login').fadeIn(300);

}])

.controller('ctrl-matchs', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navMatchs').addClass('clicked');

	$scope.matchs = [];

	var verifGetMatchs = function(res){

		if(!res.error)
				$scope.matchs = res.data;

	};

	var getMatchs = function(){

		service.getPromise('GET', 'Matchs', null, null)

		.then(function(res){
			
			verifGetMatchs(res.data);
			
		}, function(err){
			
			console.log(err);
			
		});

	};

	$scope.parier = function(e, idMatch){

		e.preventDefault();

		$scope.matchs.forEach(function(item){

			if(item.Id == idMatch){

				localStorage.setItem('partie', JSON.stringify(item));
				document.location.href = '#/configPari';

			}

		});

	};

	service.checkLogin();

	getMatchs();

    $('.header').show();
    $('.section-content').hide();
    $('.matchs').fadeIn(300);

}])

.controller('ctrl-config-pari', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navMatchs').addClass('clicked');

	$scope.actions = [];
	$scope.pari = { client: localStorage.getItem('login'), partie: JSON.parse(localStorage.getItem('partie')).Id };

	var verifActions = function(res){

		if(!res.error)
			$scope.actions = res.data;

	};

	var getActions = function(){

		service.getPromise('GET', 'Action', null, null)

		.then(function(res){

			verifActions(res.data);

		}, function(err){

			console.log(err);

		});

	};

	$scope.config = function(){

		localStorage.setItem('pari', JSON.stringify($scope.pari));
		document.location.href = '#/choixPari';

	};

	service.checkLogin();
	getActions();

    $('.header').show();
    $('.section-content').hide();
    $('.config-pari').fadeIn(300);

}])

.controller('ctrl-choix-pari', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navMatchs').addClass('clicked');

	$scope.partie = JSON.parse(localStorage.getItem('partie'));
	$scope.pari = JSON.parse(localStorage.getItem('pari'));
	$scope.equipes = [
		$scope.partie.Equipe1,
		$scope.partie.Equipe2
	];
	$scope.detail = {
		ecartMax: 1, ecart: 1, montantEcart: 1
	};

	var verifValider = function(res){

		if(res.error){

			if(res.message != null) alert(res.message);

		} else{

			localStorage.setItem('pari', JSON.stringify(res.data.pari));
			localStorage.setItem('detail', JSON.stringify(res.data.detail));
			document.location.href = '#/pariInt';

		}

	};

	$scope.valider = function(){

		var structPari = { pari: $scope.pari, detail: $scope.detail };

		service.getPromise('PUT', 'Pari/0', structPari, 'application/json')

		.then(function(res){

			verifValider(res.data);

		}, function(err){

			console.log(err);

		});

	};

	service.checkLogin();

    $('.header').show();
    $('.section-content').hide();
    $('.choix-pari').fadeIn(300);

}])

.controller('ctrl-pari-int', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navMatchs').addClass('clicked');

	$scope.pari = JSON.parse(localStorage.getItem('pari'));
	$scope.detail = JSON.parse(localStorage.getItem('detail'));
	$scope.details = [];

	var verifGetDetails = function(res){

		if(!res.error){
			console.log(res.data);
			$scope.details = res.data;
		}

	};

	var getDetails = function(){

		service.getPromise('POST', 'PariInt', $scope.pari, 'application/json')

		.then(function(res){

			verifGetDetails(res.data);

		}, function(err){ console.log(err); });

	};

	var verifRejoindre = function(res){

		if(res.error){

			if(res.message != null) alert(res.message);

		} else{

			document.location.href = '#/jonction';

		}

	};

	$scope.rejoindre = function(e, idPari){

		e.preventDefault();

		var jonction = { pari: idPari, contrePari: $scope.pari.id };

		service.getPromise('PUT', 'Jonction/0', jonction, 'application/json')

		.then(function(res){

			verifRejoindre(res.data);

		}, function(err){ console.log(err); });

	};

	service.checkLogin();
	getDetails();

    $('.header').show();
    $('.section-content').hide();
    $('.pari-int').fadeIn(300);

}])

.controller('ctrl-jonction', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navParis').addClass('clicked');

	$scope.login = localStorage.getItem('login');
	$scope.pari = JSON.parse(localStorage.getItem('pari'));
	$scope.jonctions = [];

	var verifGetJonction = function(res){

		if(!res.error){
			console.log(res.data);
			$scope.jonctions = res.data;
		}

	};

	var getJonction = function(){

		var pari = { id: $scope.pari.Id };

		service.getPromise('POST', 'Jonction', pari, 'application/json')

		.then(function(res){

			verifGetJonction(res.data);

		}, function(err){ console.log(err); });

	};

	service.checkLogin();
	getJonction();

    $('.header').show();
    $('.section-content').hide();
    $('.jonction').fadeIn(300);

}])

.controller('ctrl-paris', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navParis').addClass('clicked');

	$scope.paris = [];

	var verifGetParis = function(res){

		if(!res.error)
			$scope.paris = res.data;

	};

	var getParis = function(){

		service.getPromise('POST', 'Pari', { id: localStorage.getItem('login') }, 'application/json')

		.then(function(res){
			
			verifGetParis(res.data);
			
		}, function(err){
			
			console.log(err);
			
		});

	};

	$scope.voirDetails = function(e, pari){

		e.preventDefault();

		localStorage.setItem('pari', JSON.stringify(pari));

		document.location.href = '#/jonction';

	};

	service.checkLogin();

	getParis();

    $('.header').show();
    $('.section-content').hide();
    $('.paris').fadeIn(300);

}])

.controller('ctrl-emprunter', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navEmprunter').addClass('clicked');

	$scope.pret = {};

	$scope.emprunter = function(e){
		
		$scope.pret.datePret = service.getDate();

		localStorage.setItem('pret', JSON.stringify($scope.pret));

		document.location.href = '#/simplePlan';

	};

	service.checkLogin();

    $('.header').show();
    $('.section-content').hide();
    $('.emprunter').fadeIn(300);

}])

.controller('ctrl-simple-plan', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navEmprunter').addClass('clicked');

	$scope.pret = JSON.parse(localStorage.getItem('pret'));
	$scope.reste = 0;
	$scope.remboursement = {};
	$scope.remboursements = [];

	$scope.ajouter = function(){

		$scope.remboursement.dateRemboursement += ' 00:00:00';
		$scope.remboursement.fait = 0;
		$scope.remboursements.push($scope.remboursement);
		$scope.remboursement = {};

		$scope.calculerReste();

	};

	var verifPlanifier = function(res){

		if(res.error){

			if(res.message != null) alert(res.message);

		} else{

			localStorage.setItem('plan', JSON.stringify(res.data));
			document.location.href = '#/planDefinitif';

		}

	};

	$scope.planifier = function(){

		$scope.pret.client = { id: localStorage.getItem('login') };

		var plan = { pret: $scope.pret, remboursements: $scope.remboursements };

		service.getPromise('PUT', 'Pret/0', plan, 'application/json')

		.then(function(res){
			
			verifPlanifier(res.data);
			
		}, function(err){
			
			console.log(err);
			
		});

	};

	$scope.calculerReste = function(){

		$scope.reste = $scope.pret.montant;

		$scope.remboursements.forEach(function(item){

			$scope.reste -= item.montant;
			if($scope.reste <= 0){

				$('.btn-simple-plan-planifier').prop('disabled', false);
				$('.div-simple-plan').fadeOut(300);
				if($scope.reste < 0)
					$scope.reste = 0;

			}

		});

	};

	service.checkLogin();
	$scope.calculerReste();

    $('.header').show();
    $('.section-content').hide();
    $('.simple-plan').fadeIn(300);
    $('.btn-simple-plan-planifier').prop('disabled', true);

}])

.controller('ctrl-plan-definitif', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navEmprunter').addClass('clicked');

	$scope.plan = JSON.parse(localStorage.getItem('plan'));
	$scope.remboursements = $scope.plan.remboursements;
	$scope.total = 0;

	var calculTotal = function(){

		$scope.remboursements.forEach(function(item){

			$scope.total += item.montant + item.interet;

		});

	};

	var verifValider = function(res){

		if(res.error){

			if(res.message != null) alert(res.message);

		} else{

			localStorage.removeItem('pret');
			localStorage.removeItem('plan');
			document.location.href = '#/emprunts';

		}

	};

	$scope.valider = function(){

		var plan = JSON.parse(localStorage.getItem('plan'));

		service.getPromise('PUT', 'Pret/1', plan, 'application/json')

		.then(function(res){
			
			verifValider(res.data);
			
		}, function(err){
			
			console.log(err);
			
		});

	};

	service.checkLogin();
	calculTotal();

	$('.header').show();
    $('.section-content').hide();
    $('.plan-definitif').fadeIn(300);

}])

.controller('ctrl-emprunts', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navEmprunts').addClass('clicked');

	$scope.emprunts = [];

	var verifGetEmprunts = function(res){

		console.log(res);
		if(!res.error)
			$scope.emprunts = res.data;

	};

	var getEmprunts = function(){

		service.getPromise('POST', 'Pret', { id: localStorage.getItem('login') }, 'application/json')

		.then(function(res){
			
			verifGetEmprunts(res.data);
			
		}, function(err){
			
			console.log(err);
			
		});

	};

	var verifMonPlan = function(res, pret){

		if(res.error){

			if(res.message != null) alert(res.message);

		} else{

			localStorage.setItem('pret', JSON.stringify(pret));
			localStorage.setItem('remboursements', JSON.stringify(res.data));
			document.location.href = '#/voirPlan';

		}

	};

	$scope.monPlan = function(e, pret){

		e.preventDefault();

		service.getPromise('POST', 'Plan', { id: pret.Id }, 'application/json')

		.then(function(res){
			
			verifMonPlan(res.data, pret);
			
		}, function(err){
			
			console.log(err);
			
		});

	};

	service.checkLogin();

	getEmprunts();

    $('.header').show();
    $('.section-content').hide();
    $('.emprunts').fadeIn(300);

}])

.controller('ctrl-voir-plan', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navEmprunts').addClass('clicked');

	$scope.remboursements = JSON.parse(localStorage.getItem('remboursements'));
	$scope.total = 0;

	var calculTotal = function(){

		$scope.remboursements.forEach(function(item){

			$scope.total += item.Montant + item.Interet;

		});

	};

	$scope.modifier = function(){

		document.location.href = '#/modifSimplePlan';

	};

	service.checkLogin();
	calculTotal();

    $('.header').show();
    $('.section-content').hide();
    $('.voir-plan').fadeIn(300);

}])

.controller('ctrl-modif-simple-plan', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navEmprunts').addClass('clicked');

	$scope.pret = JSON.parse(localStorage.getItem('pret'));
	$scope.remboursements = JSON.parse(localStorage.getItem('remboursements'));

	var verifSimuler = function(res){

		if(res.error){

			if(res.message != null) alert(res.message);

		} else{

			localStorage.setItem('plan', JSON.stringify(res.data));
			document.location.href = '#/modifPlanDefinitif';

		}

	};

	$scope.simuler = function(){

		var plan = { pret: $scope.pret, remboursements: $scope.remboursements };

		service.getPromise('PUT', 'Plan/0', plan, 'application/json')

		.then(function(res){

			verifSimuler(res.data);

		}, function(err){ console.log(err); });

	};

	service.checkLogin();

    $('.header').show();
    $('.section-content').hide();
    $('.modif-simple-plan').fadeIn(300);

}])

.controller('ctrl-modif-plan-definitif', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navEmprunts').addClass('clicked');

	$scope.plan = JSON.parse(localStorage.getItem('plan'));
	$scope.pret = $scope.plan.pret;
	$scope.remboursements = $scope.plan.remboursements;
	$scope.total = 0;

	var calculTotal = function(){

		$scope.remboursements.forEach(function(item){

			$scope.total += item.montant + item.interet;

		});

	};

	var verifValider = function(res){

		if(res.error){

			if(res.message != null) alert(res.message);

		} else{

			localStorage.removeItem('pret');
			localStorage.removeItem('plan');
			document.location.href = '#/emprunts';

		}

	};

	$scope.valider = function(){

		var plan = { pret: $scope.pret, remboursements: $scope.remboursements };

		service.getPromise('PUT', 'Plan/1', plan, 'application/json')

		.then(function(res){
			
			verifValider(res.data);
			
		}, function(err){
			
			console.log(err);
			
		});

	};

	service.checkLogin();
	calculTotal();

	$('.header').show();
    $('.section-content').hide();
    $('.modif-plan-definitif').fadeIn(300);

}])

.controller('ctrl-crediter', ['$scope', 'service', function ($scope, service) {

	$('.clicked').removeClass('clicked');
	$('#navCrediter').addClass('clicked');

	$scope.credit = {
		id: localStorage.getItem('login')
	};

	var verifCrediter = function(res){

		if(res.error && res.message != null)
			alert(res.message);
		else
			alert('Operation reussie !');
		$scope.credit = { id: localStorage.getItem('login') };

	};

	$scope.crediter = function(){

		service.getPromise('POST', 'Crediter', $scope.credit, 'application/json')

    	.then(function(res){
			
			verifCrediter(res.data);
			
		}, function(err){
			
			console.log(err);
			
		});

	};

	$('.header').show();
    $('.section-content').hide();
    $('.crediter').fadeIn(300);

}])

.controller('ctrl-admin', ['$scope', 'service', function ($scope, service) {

	$('.section-content').hide();
    $('.admin').fadeIn(300);

    $scope.running = 0;

    var verifGetRunning = function(res){

    	console.log(res);
    	if(!res.error)
    		$scope.running = res.data;

    };

    var getRunning = function(){

    	service.getPromise('GET', 'RembAuto', null, null)

    	.then(function(res){

    		verifGetRunning(res.data);

    	}, function(err){ console.log(err); });

    };

	$scope.switch = function(){

		var request = ($scope.running + 1) % 2;

		service.getPromise('GET', 'RembAuto/' + request, null, null)

    	.then(function(res){

    		verifGetRunning(res.data);

    	}, function(err){ console.log(err); });
		
	};

	$scope.disconnect = function(e){

		localStorage.clear();
		document.location.href = "#/";
		
	};

	service.checkLoginRoot();
	getRunning();

	$('.header').hide();
	$('.section-content').hide();
    $('.admin').fadeIn(300);

}])

.controller('ctrl-menu', ['$scope', function ($scope) {

	$scope.disconnect = function(e){

		e.preventDefault();

		localStorage.clear();
		document.location.href = "#/";
		
	};

}]);