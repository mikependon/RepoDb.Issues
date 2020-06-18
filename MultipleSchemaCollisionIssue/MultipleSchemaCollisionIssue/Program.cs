using Microsoft.Data.SqlClient;
using MultipleSchemaCollisionIssue.Models;
using RepoDb;

namespace MultipleSchemaCollisionIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();
            InsertItems();
            QueryItems();
        }

        public static void Initialize()
        {
            // Initialize
            SqlServerBootstrap.Initialize();

            // Models
            FluentMapper
                .Entity<DirectoryCompany>()
                .Table("[directory].[Companies]");
            FluentMapper
                .Entity<SurveyCompany>()
                .Table("[survey].[Companies]");
        }

        public static void InsertItems()
        {
            using (var connection = new SqlConnection("Server=.;Database=TestDB;Integrated Security=SSPI;"))
            {
                var directoryCompanyId = connection.Insert(new DirectoryCompany
                {
                    Name = "DirectoryCompany"
                });
                var surveyCompanyId = connection.Insert(new SurveyCompany
                {
                    Name = "DirectoryCompany"
                });
            }
        }

        public static void QueryItems()
        {
            using (var connection = new SqlConnection("Server=.;Database=TestDB;Integrated Security=SSPI;"))
            {
                var directoryCompanies = connection.QueryAll<DirectoryCompany>();
                var surveyCompanies = connection.QueryAll<SurveyCompany>();
            }
        }
    }
}
