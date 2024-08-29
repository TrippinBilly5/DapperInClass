using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using DapperInClass;
using Org.BouncyCastle.Security;

#region Configuration
var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
#endregion

IDbConnection conn = new MySqlConnection(connString);
var repo = new DapperDepartmentRepository(conn);

Console.WriteLine("Hello user, here are the current departments:");
Console.WriteLine("Please press Enter ...");
Console.ReadLine();
var departments = repo.GetAllDepartments();

Print(departments);

Console.WriteLine("Do you want to add a department?");
string userResponse = Console.ReadLine();

if(userResponse.ToLower() == "yes")
{
    Console.WriteLine("What is the name of your new department?");
    userResponse = Console.ReadLine();

    repo.InsertDepartment(userResponse);
    Print(repo.GetAllDepartments());
}

Console.WriteLine("Have a great day!");

static void Print(IEnumerable<Department> departments)
{
    foreach (var dept in departments)
    {
        Console.WriteLine($"Id: {dept.DepartmentId} Name: {dept.Name}");
    }
}
