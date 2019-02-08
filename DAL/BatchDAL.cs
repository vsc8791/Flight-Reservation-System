using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using BOL;
namespace DAL
{
  public  class BatchDAL
    {

        private static string conString = string.Empty;

        static BatchDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conIMS"].ConnectionString;
        }
        public static bool Insert(Batch batch)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO Batch (BatchId, BatchName,BatchNOS, BatchStart, BatchEnd,BatchDuration,BatchProgress,CourseOffered) " +
                        "VALUES (@BatchId, @BatchName,@BatchNOS, @BatchStart, @BatchEnd,@BatchDuration,@BatchProgress,@CourseOffered)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@BatchId", batch.BatchId));
                    //  cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                  //  cmd.Parameters.Add(new SqlParameter("@CourseName", result.CourseName));
                    cmd.Parameters.Add(new SqlParameter("@BatchName", batch.BatchName));
                    cmd.Parameters.Add(new SqlParameter("@BatchNOS", batch.BatchNOS));
                    cmd.Parameters.Add(new SqlParameter("@BatchStart",batch.BatchStart));
                    cmd.Parameters.Add(new SqlParameter("@BatchEnd",batch.BatchEnd));
                    cmd.Parameters.Add(new SqlParameter("@BatchDuration",batch.BatchDuration));
                    cmd.Parameters.Add(new SqlParameter("@BatchProgress",batch.BatchProgress));
                    cmd.Parameters.Add(new SqlParameter("@CourseOffered", batch.CourseOffered));
                    //  cmd.Parameters.Add(new SqlParameter("@State", faculty.State));
                    // cmd.Parameters.Add(new SqlParameter("@Email", faculty.Email));

                    // cmd.Parameters.Add(new SqlParameter("@CourseTeachs", faculty.CourseTeachs));
                    // cmd.Parameters.Add(new SqlParameter("@Qualification", faculty.Qualification));
                    // cmd.Parameters.Add(new SqlParameter("@BatchName", student.BatchName));
                    //cmd.Parameters.Add(new SqlParameter("@Experience", faculty.Experience));
                    //cmd.Parameters.Add(new SqlParameter("@JoiningDate", faculty.JoiningDate));
                    //cmd.Parameters.Add(new SqlParameter("@EndDate", faculty.EndDate));
                    //cmd.Parameters.Add(new SqlParameter("@MobileNumber", faculty.MobileNumber));
                    //  cmd.Parameters.Add(new SqlParameter("@FatherName", student.FatherName));
                    //  cmd.Parameters.Add(new SqlParameter("@MotherName", student.MotherName));
                    //  cmd.Parameters.Add(new SqlParameter("@GaurdianContact", student.GaurdianContact));
                    //  cmd.Parameters.Add(new SqlParameter("@UserName", faculty.UserName));
                    //  cmd.Parameters.Add(new SqlParameter("@Password", faculty.Password));
                    //  cmd.Parameters.Add(new SqlParameter("@PassingYear", student.PassingYear));

                    // cmd.Parameters.Add(new SqlParameter("@CollegeName", student.CollegeName));
                    //   cmd.Parameters.Add(new SqlParameter("@UniversityName", student.UniversityName));

                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

        public static bool Update(Batch batch)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE Batch SET(BatchName=@BatchName,BatchNOS=@BatchNOS, BatchStart=@BatchStart, BatchEnd=@BatchEnd,BatchDuration=@BatchDuration,BatchProgress=@BatchProgress,CourseOffered=@CourseOffered)" +
                                    "WHERE BatchId=@BatchId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    //   cmd.Parameters.Add(new SqlParameter("@PRNNumber", student.PRNNumber));
                    //  cmd.Parameters.Add(new SqlParameter("@FacultyId", faculty.FacultyId));
                    //  cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                 //   cmd.Parameters.Add(new SqlParameter("@BatchId", batch.BatchId));
                    //  cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                    //  cmd.Parameters.Add(new SqlParameter("@CourseName", result.CourseName));
                    cmd.Parameters.Add(new SqlParameter("@BatchName", batch.BatchName));
                    cmd.Parameters.Add(new SqlParameter("@BatchNOS", batch.BatchNOS));
                    cmd.Parameters.Add(new SqlParameter("@BatchStart", batch.BatchStart));
                    cmd.Parameters.Add(new SqlParameter("@BatchEnd", batch.BatchEnd));
                    cmd.Parameters.Add(new SqlParameter("@BatchDuration", batch.BatchDuration));
                    cmd.Parameters.Add(new SqlParameter("@BatchProgress", batch.BatchProgress));
                    cmd.Parameters.Add(new SqlParameter("@CourseOffered", batch.CourseOffered));

                    //cmd.Parameters.Add(new SqlParameter("@CourseTeachs", faculty.CourseTeachs));
                    //cmd.Parameters.Add(new SqlParameter("@Qualification", faculty.Qualification));
                    //// cmd.Parameters.Add(new SqlParameter("@BatchName", student.BatchName));
                    //cmd.Parameters.Add(new SqlParameter("@Experience", faculty.Experience));
                    //cmd.Parameters.Add(new SqlParameter("@JoiningDate", faculty.JoiningDate));
                    //cmd.Parameters.Add(new SqlParameter("@EndDate", faculty.EndDate));
                    //cmd.Parameters.Add(new SqlParameter("@MobileNumber", faculty.MobileNumber));
                    ////  cmd.Parameters.Add(new SqlParameter("@FatherName", student.FatherName));
                    ////  cmd.Parameters.Add(new SqlParameter("@MotherName", student.MotherName));
                    ////  cmd.Parameters.Add(new SqlParameter("@GaurdianContact", student.GaurdianContact));
                    //cmd.Parameters.Add(new SqlParameter("@UserName", faculty.UserName));
                    //cmd.Parameters.Add(new SqlParameter("@Password", faculty.Password));
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

        public static bool Delete(int BatchId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE FROM Batch WHERE BatchId=@BatchId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@BatchId",BatchId));
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }

        public static Batch Get(int BatchId)
        {
            Batch batch = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Batch WHERE BatchId=@BatchId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@BatchId", BatchId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                batch = new Batch()
                                {
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                    BatchId = int.Parse(reader["BatchId"].ToString()),
                                    BatchName = reader["BatchName"].ToString(),
                                    BatchNOS = int.Parse(reader["BatchNOS"].ToString()),
                                    BatchStart = reader["BatchStart"].ToString(),
                                    BatchEnd = reader["BatchEnd"].ToString(),
                                    BatchDuration = reader["BatchDuration"].ToString(),
                                    BatchProgress = reader["BatchProgress"].ToString(),
                                    CourseOffered = reader["CourseOffered"].ToString(),
                                    //ClassLabType = reader["ClassLabType"].ToString(),
                                    //State = reader["State"].ToString(),
                                    //Email = (reader["Email"].ToString()),
                                    //CourseTeachs = reader["CourseTeachs"].ToString(),
                                    //Qualification = reader["Qualification"].ToString(),
                                    //Experience = reader["Experience"].ToString(),
                                    //  CourseName = reader["CourseName"].ToString(),
                                    //  BatchName = reader["BatchName"].ToString(),
                                    //JoiningDate = reader["JoiningDate"].ToString(),
                                    //EndDate = reader["EndDate"].ToString(),
                                    //MobileNumber = reader["MobileNumber"].ToString(),
                                    //  FatherName = reader["FatherName"].ToString(),
                                    //  MotherName = reader["MotherName"].ToString(),
                                    //  GaurdianContact = reader["GaurdianContact"].ToString(),
                                    //UserName = reader["UserName"].ToString(),
                                    //Password = reader["Password"].ToString(),
                                    //  PassingYear = int.Parse(reader["PassingYear"].ToString()),

                                    //  CollegeName = (reader["CollegeName"].ToString()),
                                    //  UniversityName = reader["UniversityName"].ToString()


                                };
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return batch;
        }

        //public static Product Get(string productName)
        //{
        //    Product product = null;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conString))
        //        {
        //            if (con.State == ConnectionState.Closed)
        //                con.Open();
        //            string query = "SELECT * FROM Products WHERE Title=@ProductName";
        //            SqlCommand cmd = new SqlCommand(query, con);
        //            cmd.Parameters.Add(new SqlParameter("@ProductName", productName));
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            if (reader != null)
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        product = new Product()
        //                        {
        //                            ProductId = int.Parse(reader["productId"].ToString()),
        //                            Title = reader["title"].ToString(),
        //                            Description = reader["description"].ToString(),
        //                            ImageURL = reader["picture"].ToString(),
        //                            UnitPrice = float.Parse(reader["price"].ToString()),
        //                            Balance = int.Parse(reader["quantity"].ToString()),
        //                            PaymentTerm = reader["paymentTerm"].ToString(),
        //                            Delivery = reader["delivery"].ToString(),
        //                            Category = reader["category"].ToString()
        //                        };
        //                    }
        //                    reader.Close();
        //                }
        //            }
        //            if (con.State == ConnectionState.Open)
        //                con.Close();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return product;
        //}

        //public static List<Product> GetByCategory(string category)
        //{
        //    List<Product> products = new List<Product>();
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conString))
        //        {
        //            if (con.State == ConnectionState.Closed)
        //                con.Open();
        //            string query = "SELECT * FROM flowers WHERE category='" + category + "'"; SqlCommand cmd = new SqlCommand(query, con);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            if (reader != null)
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        Product product = new Product()
        //                        {
        //                            ProductId = int.Parse(reader["productId"].ToString()),
        //                            Title = reader["title"].ToString(),
        //                            Description = reader["description"].ToString(),
        //                            Category = reader["category"].ToString(),
        //                            ImageURL = reader["picture"].ToString(),
        //                            UnitPrice = float.Parse(reader["price"].ToString()),
        //                            Balance = int.Parse(reader["quantity"].ToString()),
        //                            PaymentTerm = reader["paymentTerm"].ToString(),
        //                            Delivery = reader["delivery"].ToString()
        //                        };
        //                        products.Add(product);
        //                    }
        //                    reader.Close();
        //                }
        //            }
        //            if (con.State == ConnectionState.Open)
        //                con.Close();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return products;
        //}

        public static List<Batch> GetAll()
        {
            List<Batch> batchs = new List<Batch>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Batch";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Batch batch = new Batch()
                                {
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                    BatchId = int.Parse(reader["BatchId"].ToString()),
                                    BatchName = reader["BatchName"].ToString(),
                                    BatchNOS = int.Parse(reader["BatchNOS"].ToString()),
                                    BatchStart = reader["BatchStart"].ToString(),
                                    BatchEnd = reader["BatchEnd"].ToString(),
                                    BatchDuration = reader["BatchDuration"].ToString(),
                                    BatchProgress = reader["BatchProgress"].ToString(),
                                    CourseOffered = reader["CourseOffered"].ToString(),
                                    //Qualification = reader["Qualification"].ToString(),
                                    //Experience = reader["Experience"].ToString(),
                                    ////  CourseName = reader["CourseName"].ToString(),
                                    ////  BatchName = reader["BatchName"].ToString(),
                                    //JoiningDate = reader["JoiningDate"].ToString(),
                                    //EndDate = reader["EndDate"].ToString(),
                                    //MobileNumber = reader["MobileNumber"].ToString(),
                                    ////  FatherName = reader["FatherName"].ToString(),
                                    ////  MotherName = reader["MotherName"].ToString(),
                                    ////  GaurdianContact = reader["GaurdianContact"].ToString(),
                                    //UserName = reader["UserName"].ToString(),
                                    //Password = reader["Password"].ToString(),
                                };
                                batchs.Add(batch);
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return batchs;
        }
    }
}
