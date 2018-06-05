var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http, $httpParamSerializerJQLike) {
    debugger;

    var ng = $scope;
    ng.serviceBase = "http://localhost:8080";
    ng.usuario = "USUARIO";
    ng.senha = "SENHA";
    ng.login = false;
    ng.busca = {};
    ng.buscaFeita = false;


    ng.somenteNumeros = function (num) {
        var er = /[^0-9.]/;
        er.lastIndex = 0;
        var campo = num;
        if (er.test(campo.value)) {
            campo.value = "";
        }
    }

    ng.ListarAmigos = function () {
        $.ajax({
            url: ng.serviceBase + '/api/LocalizacaoAmigo/ListarAmigos',
            type: "GET",
            headers: {
                'Authorization': ng.token_type + ' ' + ng.token
            },
            dataType: 'json',
            data: ng.data,
            success: function (response) {
                ng.ListAmigos = response;
                ng.$apply();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Erro ao Listar Amigos");
            }
        });
    };

    ng.ListarAmigosProximos = function () {

        if (ng.busca.nome != '' && ng.busca.nome != null && ng.busca.latitude != '' && ng.busca.latitude != null && ng.busca.longitude != '' && ng.busca.longitude != null) {
            $.ajax({
                url: ng.serviceBase + '/api/LocalizacaoAmigo/ObterAmigosProximos',
                type: "POST",
                headers: {
                    'Authorization': ng.token_type + ' ' + ng.token,
                    'Content-Type': 'application/json'
                },
                dataType: 'json',
                data: JSON.stringify(ng.busca),
                success: function (response) {
                    ng.ListAmigosProximos = response;
                    ng.buscaFeita = true;
                    ng.$apply();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert("Erro ao Listar Amigos");
                }
            });
        } else {
            alert('Dados informados invalidos, favor informar Nome, Latitude e logitude');
        }
    };


    ng.Login = function () {
        if (ng.usuario != '' && ng.usuario != null && ng.senha != '' && ng.senha != null) {
            ng.gerarToken(ng.usuario, ng.senha);
        } else {
            alert('Dados informados invalidos');
        }
    }

    ng.Limpar = function () {
        ng.buscaFeita = false;
        ng.busca = {};
    }

    ng.gerarToken = function (usuario, senha) {
        ng.data = "grant_type=password&username=" + usuario + "&password=" + senha;
        $.ajax({
            url: ng.serviceBase + '/token',
            type: "POST",
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            dataType: 'json',
            data: ng.data,
            success: function (response) {
                ng.token = response.access_token;
                ng.token_type = response.token_type;
                ng.login = true;
                ng.ListarAmigos();
                ng.$apply();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                ng.login = false;
                alert("Erro ao gerar token e logar usuario!!");
            }
        });
    }

})