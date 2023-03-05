const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:43787';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/_configuration",
      "/.well-known",
      "/Identity",
      "/connect",
      "/ApplyDatabaseMigrations",
      "/_framework",
      "/api/Employee/ListEmployees",
      "/api/Employee/SaveEmployee",
      "/api/Employee/OneEmployee/",
      "/api/Employee/EditEmployee/",
      "/api/Employee/DeleteEmployee/",
      "/api/Department/ListDepartment",
      "/api/Department/ListDepartmentEnterprise",
      "/api/Department/SaveDepartment",
      "/api/Department/OneDepartment/",
      "/api/Department/EditDepartment/",
      "/api/Department/DeleteDepartment/",
      "/api/Enterprise/ListEnterprise",
      "/api/Enterprise/SaveEnterprise",
      "/api/Enterprise/OneEnterprise/",
      "/api/Enterprise/EditEnterprise/",
      "/api/Enterprise/DeleteEnterprise/"
    ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
