app.service('service', ['$http', function($http){
	
	this.url = 'http://localhost:51549/api/';

	this.checkLogin = function(){

		if(localStorage.getItem('login') == null)
			document.location.href = "#/";

	};

	this.checkLoginRoot = function(){

		if(localStorage.getItem('login') != 'CL000')
			document.location.href = "#/";

	};

	this.getPromise = function(method, controller, data, contentType){

		if(method == 'POST' || method == 'PUT')
			return $http({ method: method, url: this.url + controller, data: data, headers:{ 'Content-type': contentType } });
		else
			return $http({ method: method, url: this.url + controller });

	};

	this.getDate = function(){

		var date = new Date();

		return date.getFullYear() + '-' + this.complete(date.getMonth() + 1) + '-' + this.complete(date.getDate()) + ' ' + this.complete(date.getHours()) + ':' + this.complete(date.getMinutes()) + ':' + this.complete(date.getSeconds());

	};

	this.complete = function(value){

		if(value.toString().length < 2)
			return '0' + value;
		else
			return value;

	};

	this.data = {};
	
}]);