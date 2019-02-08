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
   public class FacultyDAL
    {
        private static string conString = string.Empty;

        static FacultyDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conIMS"].ConnectionString;
        }
        public static bool Insert(Faculty faculty)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO Faculty (FacultyId,FirstName, MiddleName,LastName, Specialization, Status,Gender,Address,City,State,Email,CourseTeachs,Qualification,Experience,JoiningDate,EndDate,MobileNumber,UserName,Password) " +
                        "VALUES (@FacultyId,@FirstName, @MiddleName,@LastName, @Specialization, @Status,@Gender,@Address,@City,@State,@Email,@CourseTeachs,@Qualification,@Experience,@JoiningDate,@EndDate,@MobileNumber,@UserName,@Password)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@FacultyId", faculty.FacultyId));
                  //  cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", faculty.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@MiddleName", faculty.MiddleName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", faculty.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Specialization", faculty.Specialization));
                    cmd.Parameters.Add(new SqlParameter("@Status", faculty.Status));
                    cmd.Parameters.Add(new SqlParameter("@Gender", faculty.Gender));
                    cmd.Parameters.Add(new SqlParameter("@Address", faculty.Address));
                    cmd.Parameters.Add(new SqlParameter("@City", faculty.City));
                    cmd.Parameters.Add(new SqlParameter("@State",faculty.State));
                    cmd.Parameters.Add(new SqlParameter("@Email", faculty.Email));
                    
                    cmd.Parameters.Add(new SqlParameter("@CourseTeachs", faculty.CourseTeachs));
                    cmd.Parameters.Add(new SqlParameter("@Qualification", faculty.Qualification));
                    // cmd.Parameters.Add(new SqlParameter("@BatchName", student.BatchName));
                    cmd.Parameters.Add(new SqlParameter("@Experience", faculty.Experience));
                    cmd.Parameters.Add(new SqlParameter("@JoiningDate", faculty.JoiningDate));
                    cmd.Parameters.Add(new SqlParameter("@EndDate", faculty.EndDate));
                    cmd.Parameters.Add(new SqlParameter("@MobileNumber", faculty.MobileNumber));
                  //  cmd.Parameters.Add(new SqlParameter("@FatherName", student.FatherName));
                  //  cmd.Parameters.Add(new SqlParameter("@MotherName", student.MotherName));
                  //  cmd.Parameters.Add(new SqlParameter("@GaurdianContact", student.GaurdianContact));
                    cmd.Parameters.Add(new SqlParameter("@UserName", faculty.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", faculty.Password));
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

        public static bool Update(Faculty faculty)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE Faculty SET(FacultyId=@FacultyId,FirstName@FirstName,MiddleName=@MiddleName,LastName=@LastName,Specialization=@Specialization,Status=@Status,Gender=@Gender,Address=@Address,City=@City,State=@State,Email=@Email,CourseTeachs=@CourseTeachs,Qualification=@Qualification,Experience=@Experience,JoiningDate=@JoiningDate,EndDate=@EndDate,MobileNumber=@MobileNumber,UserName=@UserName,Password=@Password)" +
                                    "WHERE FacultyId=@FacultyId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    //   cmd.Parameters.Add(new SqlParameter("@PRNNumber", student.PRNNumber));
                  //  cmd.Parameters.Add(new SqlParameter("@FacultyId", faculty.FacultyId));
                    //  cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", faculty.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@MiddleName", faculty.MiddleName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", faculty.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Specialization", faculty.Specialization));
                    cmd.Parameters.Add(new SqlParameter("@Status", faculty.Status));
                    cmd.Parameters.Add(new SqlParameter("@Gender", faculty.Gender));
                    cmd.Parameters.Add(new SqlParameter("@Address", faculty.Address));
                    cmd.Parameters.Add(new SqlParameter("@City", faculty.City));
                    cmd.Parameters.Add(new SqlParameter("@State", faculty.State));
                    cmd.Parameters.Add(new SqlParameter("@Email", faculty.Email));

                    cmd.Parameters.Add(new SqlParameter("@CourseTeachs", faculty.CourseTeachs));
                    cmd.Parameters.Add(new SqlParameter("@Qualification", faculty.Qualification));
                    // cmd.Parameters.Add(new SqlParameter("@BatchName", student.BatchName));
                    cmd.Parameters.Add(new SqlParameter("@Experience", faculty.Experience));
                    cmd.Parameters.Add(new SqlParameter("@JoiningDate", faculty.JoiningDate));
                    cmd.Parameters.Add(new SqlParameter("@EndDate", faculty.EndDate));
                    cmd.Parameters.Add(new SqlParameter("@MobileNumber", faculty.MobileNumber));
                    //  cmd.Parameters.Add(new SqlParameter("@FatherName", student.FatherName));
                    //  cmd.Parameters.Add(new SqlParameter("@MotherName", student.MotherName));
                    //  cmd.Parameters.Add(new SqlParameter("@GaurdianContact", student.GaurdianContact));
                    cmd.Parameters.Add(new SqlParameter("@UserName", faculty.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", faculty.Password));
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

        public static bool Delete(int FacultyId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE FROM Faculty WHERE FacultyId=@FacultyId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@FacultyId", FacultyId));
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

        public static Faculty Get(int FacultyId)
        {
            Faculty faculty = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Faculty WHERE FacultyId=@FacultyId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@FacultyId", FacultyId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                faculty = new Faculty()
                                {
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                  FacultyId= int.Parse(reader["FacultyId"].ToString()),
                                    FirstName = reader["FirstName"].ToString(),
                                    MiddleName = reader["MiddleName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Specialization= reader["Specialization"].ToString(),
                                    Status = reader["Status"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    State = reader["State"].ToString(),
                                    Email = (reader["Email"].ToString()),
                                    CourseTeachs = reader["CourseTeachs"].ToString(),
                                    Qualification = reader["Qualification"].ToString(),
                                    Experience = reader["Experience"].ToString(),
                                  //  CourseName = reader["CourseName"].ToString(),
                                  //  BatchName = reader["BatchName"].ToString(),
                                    JoiningDate = reader["JoiningDate"].ToString(),
                                    EndDate = reader["EndDate"].ToString(),
                                    MobileNumber = reader["MobileNumber"].ToString(),
                                  //  FatherName = reader["FatherName"].ToString(),
                                  //  MotherName = reader["MotherName"].ToString(),
                                  //  GaurdianContact = reader["GaurdianContact"].ToString(),
                                    UserName = reader["UserName"].ToString(),
                                    Password = reader["Password"].ToString(),
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

            return faculty;
        }
        //.....................................

        public static Faculty GetUserName(string UserName,string Password)
        {
            Faculty faculty = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Faculty WHERE UserName=@UserName and Password=@Password";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                faculty = new Faculty()
                                {
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                    FacultyId = int.Parse(reader["FacultyId"].ToString()),
                                    FirstName = reader["FirstName"].ToString(),
                                    MiddleName = reader["MiddleName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Specialization = reader["Specialization"].ToString(),
                                    Status = reader["Status"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    State = reader["State"].ToString(),
                                    Email = (reader["Email"].ToString()),
                                    CourseTeachs = reader["CourseTeachs"].ToString(),
                                    Qualification = reader["Qualification"].ToString(),
                                    Experience = reader["Experience"].ToString(),
                                    //  CourseName = reader["CourseName"].ToString(),
                                    //  BatchName = reader["BatchName"].ToString(),
                                    JoiningDate = reader["JoiningDate"].ToString(),
                                    EndDate = reader["EndDate"].ToString(),
                                    MobileNumber = reader["MobileNumber"].ToString(),
                                    //  FatherName = reader["FatherName"].ToString(),
                                    //  MotherName = reader["MotherName"].ToString(),
                                    //  GaurdianContact = reader["GaurdianContact"].ToString(),
                                    UserName = reader["UserName"].ToString(),
                                    Password = reader["Password"].ToString(),
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

            return faculty;
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

        public static List<Faculty> GetAll()
        {
            List<Faculty> facultys = new List<Faculty>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Faculty";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Faculty faculty = new Faculty()
                                {
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                    FacultyId = int.Parse(reader["FacultyId"].ToString()),
                                    FirstName = reader["FirstName"].ToString(),
                                    MiddleName = reader["MiddleName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Specialization = reader["Specialization"].ToString(),
                                    Status = reader["Status"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    State = reader["State"].ToString(),
                                    Email = (reader["Email"].ToString()),
                                    CourseTeachs = reader["CourseTeachs"].ToString(),
                                    Qualification = reader["Qualification"].ToString(),
                                    Experience = reader["Experience"].ToString(),
                                    //  CourseName = reader["CourseName"].ToString(),
                                    //  BatchName = reader["BatchName"].ToString(),
                                    JoiningDate = reader["JoiningDate"].ToString(),
                                    EndDate = reader["EndDate"].ToString(),
                                    MobileNumber = reader["MobileNumber"].ToString(),
                                    //  FatherName = reader["FatherName"].ToString(),
                                    //  MotherName = reader["MotherName"].ToString(),
                                    //  GaurdianContact = reader["GaurdianContact"].ToString(),
                                    UserName = reader["UserName"].ToString(),
                                    Password = reader["Password"].ToString(),
                                };
                                facultys.Add(faculty);
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

            return facultys;
        }

    }
}
