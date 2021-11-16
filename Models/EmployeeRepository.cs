using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace DapperMVC.Models
{
    public class EmployeeRepository
    {
       
        private static string connectionString;
        public EmployeeRepository()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }
        public List<Employee> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
                return db.Query<Employee>("sp_Employees_GetAll", commandType: CommandType.StoredProcedure).ToList();
        }

        public Employee Get(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
                return db.Query<Employee>("sp_Employees_Get", new { Id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public Employee Create(Employee emp)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
                return db.Query<Employee>("sp_Employees_Create", emp, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public Employee Update(Employee emp)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
                return db.Query<Employee>("Employees_Update", emp, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public Employee Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
                return db.Query<Employee>("sp_Employees_Delete", new { Id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }



        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                con.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return (T)Convert.ChangeType(con.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T)); ;
            }
        }

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}