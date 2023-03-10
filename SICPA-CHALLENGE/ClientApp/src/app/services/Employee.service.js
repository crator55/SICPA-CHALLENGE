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
exports.EmployeeService = void 0;
var core_1 = require("@angular/core");
var EmployeeService = /** @class */ (function () {
    function EmployeeService(HttpClient, baseUrl) {
        this.HttpClient = HttpClient;
        this.urlBase = "";
        this.urlBase = baseUrl;
    }
    EmployeeService.prototype.getEmployee = function () {
        return this.HttpClient.get("http://localhost:5062/" + "api/Employee/ListEmployees");
    };
    EmployeeService.prototype.SaveEmployee = function (employee) {
        return this.HttpClient.post("http://localhost:5062/" + "api/Employee/SaveEmployee", employee);
    };
    EmployeeService.prototype.GetOneEmployee = function (id) {
        return this.HttpClient.get("http://localhost:5062/" + "api/Employee/OneEmployee/" + id);
    };
    EmployeeService.prototype.UpdateEmployee = function (employee, id) {
        return this.HttpClient.put("http://localhost:5062/" + "api/Employee/EditEmployee/" + id, employee);
    };
    EmployeeService.prototype.DeleteEmployee = function (id) {
        return this.HttpClient.delete("http://localhost:5062/" + "api/Employee/DeleteEmployee/" + id);
    };
    EmployeeService = __decorate([
        core_1.Injectable({ providedIn: 'root' }),
        __param(1, core_1.Inject('BASE_URL'))
    ], EmployeeService);
    return EmployeeService;
}());
exports.EmployeeService = EmployeeService;
//# sourceMappingURL=Employee.service.js.map