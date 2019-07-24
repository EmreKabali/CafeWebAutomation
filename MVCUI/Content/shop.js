var app = angular.module("shoppingListApp", []);
app.controller("shoppingController", function ($scope) {

    $scope.shoppingList = [];
    $scope.shoppingList.itemName;
    $scope.shoppingList.quantity;
    $scope.shoppingList.subtotal;


  

    $scope.removeItem = function (index) {
        $scope.shoppingList.splice(index, 1);
    }

    $scope.addOne = function (index) {
        $scope.shoppingList[index].quantity += 1;
    }

    $scope.azalt = function (index) {
        $scope.shoppingList[index].quantity -= 1;
        if ($scope.shoppingList[index].quantity == 0) {
            $scope.shoppingList.splice(index, 1);
        }
    }

});