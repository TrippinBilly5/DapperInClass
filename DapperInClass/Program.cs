using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using DapperInClass;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var repo = new DepartmentRepository(conn);
var departments = repo.GetAllDepartments();

foreach(var dept in departments)
{
    Console.WriteLine($"{dept.DepartmentId} {dept.Name}");
}
