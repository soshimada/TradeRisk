using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TradeRisk.Domain.Model;

namespace TradeRisk.Infra.Repository
{
    public class CategoryRepository
    {
        private readonly IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        public bool Add(Category category)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                int rowsAffected = db.Execute(@"INSERT Category([Risk],[Sector],[Operator],[Value]) values (@Risk, @Sector, @Operator, @Value",
                new
                {
                    Risk = category.Risk,
                    Sector = category.Sector,
                    Operator = category.Operator,
                    Value = category.Value
                });
                if (rowsAffected > 0)
                {
                    return true;
                }

                return false;
            }

        }

        public bool Delete(int Id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                int rowsAffected = db.Execute(@"DELETE FROM [Category] WHERE Id = @Id",
                new { Id = Id });

                if (rowsAffected > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public bool Edit(Category category)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                int rowsAffected = db.Execute(
                     "UPDATE [Category] SET [Risk] = @Risk ,[Sector] = @Sector, [Operator] = @Operator,[Value] = @Value WHERE Id = " +
                     category.Id, category);

                if (rowsAffected > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public Category Get(int id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                return db.Query<Category>("SELECT * FROM [Category] WHERE Id = @Id", new { Id = id }).SingleOrDefault();
            }
        }

        public List<Category> GetAll()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                return db.Query<Category>(@"SELECT * FROM Category").ToList();
            }
        }
    }
}
