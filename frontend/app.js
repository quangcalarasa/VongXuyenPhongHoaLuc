var app = angular.module('HeroApp', []);

app.controller('HeroController', function ($scope, $http) {
    $scope.heroes = [];
    $scope.newHero = {};

    // Lấy danh sách hero
    function loadHeroes() {
        $http.get('http://localhost:40240/api/hero')
            .then(function (response) {
                $scope.heroes = response.data;
            }, function (error) {
                console.error('Error fetching heroes:', error);
            });
    }
    loadHeroes();

    // Thêm hero mới
    $scope.addHero = function () {
        $http.post('http://localhost:40240/api/hero', $scope.newHero)
            .then(function (response) {
                $scope.newHero = {};
                loadHeroes();
            }, function (error) {
                alert('Lỗi khi thêm hero!');
                console.error(error);
            });
    };

    // Xóa hero
    $scope.deleteHero = function (id) {
        if (confirm('Bạn có chắc muốn xóa hero này?')) {
            $http.delete('http://localhost:40240/api/hero/' + id)
                .then(function (response) {
                    loadHeroes();
                }, function (error) {
                    alert('Lỗi khi xóa hero!');
                    console.error(error);
                });
        }
    };

    // Tạo mảng số lượng sao
    $scope.getStars = function (rating) {
        return new Array(rating);
    };
});