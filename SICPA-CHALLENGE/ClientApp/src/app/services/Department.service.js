"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.DepartmentService = void 0;
var core_1 = require("@angular/core");
var DepartmentService = /** @class */ (function () {
    function DepartmentService(HttpClient, baseUrl) {
        this.HttpClient = HttpClient;
        this.urlBase = "";
        this.urlBase = baseUrl;
    }
    DepartmentService.prototype.getDepartment = function () {
        return this.HttpClient.get("http://localhost:5062/" + "api/Department/ListDepartment");
    };
    DepartmentService.prototype.getDepartmentEnterprise = function () {
        return this.HttpClient.get("http://localhost:5062/" + "api/Department/ListDepartmentEnterprise");
    };
    DepartmentService.prototype.SaveDepartment = function (department) {
        return this.HttpClient.post("http://localhost:5062/" + "api/Department/SaveDepartment", department);
    };
    DepartmentService.prototype.GetOneDepartment = function (id) {
        return this.HttpClient.get("http://localhost:5062/" + "api/Department/OneDepartment/" + id);
    };
    DepartmentService.prototype.UpdateDepartment = function (department, id) {
        return this.HttpClient.put("http://localhost:5062/" + "api/Department/EditDepartment/" + id, department);
    };
    DepartmentService.prototype.DeleteDepartment = function (id) {
        return this.HttpClient.delete("http://localhost:5062/" + "api/Department/DeleteDepartment/" + id);
    };
    DepartmentService = __decorate([
        core_1.Injectable({ providedIn: 'root' }),
        __param(1, core_1.Inject('BASE_URL'))
    ], DepartmentService);
    return DepartmentService;
}());
exports.DepartmentService = DepartmentService;
//# sourceMappingURL=Department.service.js.map