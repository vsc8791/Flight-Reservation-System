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
    public class ResultDAL
    {
        private static string conString = string.Empty;

        static ResultDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conIMS"].ConnectionString;
        }
        public static bool Insert(Result result)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO Result (ResultId,CourseName, BatchName,PRNNumber, SubjectName, DateOfExam,Marks,ResultType,ClassLabType) " +
                        "VALUES (@ResultId,@CourseName, @BatchName,@PRNNumber, @SubjectName, @DateOfExam,@Marks,@ResultType,@ClassLabType)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@ResultId", result.ResultId));
                    //  cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                    cmd.Parameters.Add(new SqlParameter("@CourseName", result.CourseName));
                    cmd.Parameters.Add(new SqlParameter("@BatchName", result.BatchName));
                    cmd.Parameters.Add(new SqlParameter("@PRNNumber", result.PRNNumber));
                    cmd.Parameters.Add(new SqlParameter("@SubjectName", result.SubjectName));
                    cmd.Parameters.Add(new SqlParameter("@DateOfExam", result.SubjectName));
                    cmd.Parameters.Add(new SqlParameter("@Marks", result.DateOfExam));
                    cmd.Parameters.Add(new SqlParameter("@ResultType", result.ResultType));
                    cmd.Parameters.Add(new SqlParameter("@ClassLabType", result.ClassLabType));
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

        public static bool Update(Result result)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE Result SET(CourseName=@CourseName, BatchName=@BatchName,PRNNumber=@PRNNumber, SubjectName=@SubjectName, DateOfExam=@DateOfExam,Marks=@Marks,ResultType=@ResultType,ClassType=@ClassLabType)" +
                                    "WHERE ResultId=@ResultId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    //   cmd.Parameters.Add(new SqlParameter("@PRNNumber", student.PRNNumber));
                    //  cmd.Parameters.Add(new SqlParameter("@FacultyId", faculty.FacultyId));
                    //  cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                    cmd.Parameters.Add(new SqlParameter("@ResultId", result.ResultId));
                    //  cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                    cmd.Parameters.Add(new SqlParameter("@CourseName", result.CourseName));
                    cmd.Parameters.Add(new SqlParameter("@BatchName", result.BatchName));
                    cmd.Parameters.Add(new SqlParameter("@PRNNumber", result.PRNNumber));
                    cmd.Parameters.Add(new SqlParameter("@SubjectName", result.SubjectName));
                    cmd.Parameters.Add(new SqlParameter("@DateOfExam", result.SubjectName));
                    cmd.Parameters.Add(new SqlParameter("@Marks", result.DateOfExam));
                    cmd.Parameters.Add(new SqlParameter("@ResultType", result.ResultType));
                    cmd.Parameters.Add(new SqlParameter("@ClassLabType", result.ClassLabType));

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

        public static bool Delete(int ResultId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE FROM Result WHERE ResultId=@ResultId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@ResultId", ResultId));
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

        public static Result Get(int ResultId)
        {
            Result result = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Result WHERE ResultId=@ResultId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@ResultId", ResultId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                result = new Result()
                                {
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                    ResultId = int.Parse(reader["ResultId"].ToString()),
                                    CourseName = reader["CourseName"].ToString(),
                                    BatchName = reader["BatchName"].ToString(),
                                    PRNNumber = reader["PRNNumber"].ToString(),
                                    SubjectName = reader["SubjectName"].ToString(),
                                    DateOfExam = reader["DateOfExam"].ToString(),
                                    Marks = reader["Marks"].ToString(),
                                    ResultType = reader["ResultType"].ToString(),
                                    ClassLabType = reader["ClassLabType"].ToString(),
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

            return result;
        }

        //get result by prnnumber
        public static List<Result> GetPRNNumber(string PRNNumber)
        {
            List<Result> results = new List<Result>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Result where PRNNumber='"+PRNNumber+"'";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Result result = new Result()
                                {
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                    ResultId = int.Parse(reader["ResultId"].ToString()),
                                    CourseName = reader["CourseName"].ToString(),
                                    BatchName = reader["BatchName"].ToString(),
                                    PRNNumber = reader["PRNNumber"].ToString(),
                                    SubjectName = reader["SubjectName"].ToString(),
                                    DateOfExam = reader["DateOfExam"].ToString(),
                                    Marks = reader["Marks"].ToString(),
                                    ResultType = reader["ResultType"].ToString(),
                                    ClassLabType = reader["ClassLabType"].ToString(),
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
                                results.Add(result);
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

            return results;
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
        //            string query = "SELECT * FROM flowers WHERE category='" + category + "'"; 
        //            SqlCommand cmd = new SqlCommand(query, con);
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

        public static List<Result> GetAll()
        {
            List<Result> results = new List<Result>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Result";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Result result = new Result()
                                {
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                    ResultId = int.Parse(reader["ResultId"].ToString()),
                                    CourseName = reader["CourseName"].ToString(),
                                    BatchName = reader["BatchName"].ToString(),
                                    PRNNumber = reader["PRNNumber"].ToString(),
                                    SubjectName = reader["SubjectName"].ToString(),
                                    DateOfExam = reader["DateOfExam"].ToString(),
                                    Marks = reader["Marks"].ToString(),
                                    ResultType = reader["ResultType"].ToString(),
                                    ClassLabType = reader["ClassLabType"].ToString(),
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
                                results.Add(result);
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

            return results;
        }
    }
}
