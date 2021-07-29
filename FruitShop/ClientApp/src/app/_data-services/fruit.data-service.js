"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FruitDataService = void 0;
var FruitDataService = /** @class */ (function () {
    function FruitDataService(http) {
        this.http = http;
        this.module = '/api/fruits';
    }
    FruitDataService.prototype.get = function () {
        this.http.get(this.module);
    };
    return FruitDataService;
}());
exports.FruitDataService = FruitDataService;
//# sourceMappingURL=fruit.data-service.js.map