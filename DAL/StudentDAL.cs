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
    public class StudentDAL
    {
        private static string conString = string.Empty;

        static StudentDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conIMS"].ConnectionString;
        }
        public static bool Insert(Student student)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO Student (PRNNumber,RollNumber,FirstName, MiddleName,LastName, Gender, Address,City,State,Email,Qualification,CourseName,BatchName,JoiningDate,MobileNumber,FatherName,MotherName,GaurdianContact,UserName,Password,PassingYear,Experience,CollegeName,UniversityName) " +
                        "VALUES (@PRNNumber,@RollNumber,@FirstName, @MiddleName,@LastName,@Gender, @Address,@City,@State,@Email,@Qualification,@CourseName,@BatchName,@JoiningDate,@MobileNumber,@FatherName,@MotherName,@GaurdianContact,@UserName,@Password,@PassingYear,@Experience,@CollegeName,@UniversityName)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@PRNNumber", student.PRNNumber));
                    cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                    cmd.Parameters.Add(new SqlParameter("@FirstName",student.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@MiddleName", student.MiddleName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", student.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Gender", student.Gender));
                    cmd.Parameters.Add(new SqlParameter("@Address", student.Address));
                    cmd.Parameters.Add(new SqlParameter("@City", student.City));
                    cmd.Parameters.Add(new SqlParameter("@State", student.State));
                    cmd.Parameters.Add(new SqlParameter("@Email", student.Email));
                    cmd.Parameters.Add(new SqlParameter("@Qualification", student.Qualification));
                    cmd.Parameters.Add(new SqlParameter("@CourseName", student.CourseName));
                    cmd.Parameters.Add(new SqlParameter("@BatchName", student.BatchName));
                    cmd.Parameters.Add(new SqlParameter("@JoiningDate", student.JoiningDate));
                    cmd.Parameters.Add(new SqlParameter("@MobileNumber", student.MobileNumber));
                    cmd.Parameters.Add(new SqlParameter("@FatherName", student.FatherName));
                    cmd.Parameters.Add(new SqlParameter("@MotherName", student.MotherName));
                    cmd.Parameters.Add(new SqlParameter("@GaurdianContact", student.GaurdianContact));
                    cmd.Parameters.Add(new SqlParameter("@UserName", student.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", student.Password));
                    cmd.Parameters.Add(new SqlParameter("@PassingYear", student.PassingYear));
                    cmd.Parameters.Add(new SqlParameter("@Experience", student.Experience));
                    cmd.Parameters.Add(new SqlParameter("@CollegeName", student.CollegeName));
                    cmd.Parameters.Add(new SqlParameter("@UniversityName", student.UniversityName));                  
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

        public static bool Update(Student student)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE Student SET RollNumber=@RollNumber,FirstName=@FirstName, MiddleName=@MiddleName,LastName=@LastName,Gender=@Gender,Address=@Address,City=@City,State=@State,Email=@Email,Qualification=@Qualification,CourseName=@CourseName,BatchName=@BatchName,JoiningDate=@JoiningDate,MobileNumber=@MobileNumber,FatherName=@FatherName,MotherName=@MotherName,GaurdianContact=@GaurdianContact,UserName=@UserName,Password=@Password,PassingYear=@PassingYear,Experience=@Experience,CollegeName=@CollegeName,UniversityName=@UniversityName " +
                                    "WHERE PRNNumber=@PRNNumber";
                    SqlCommand cmd = new SqlCommand(query, con);

                   cmd.Parameters.Add(new SqlParameter("@PRNNumber", student.PRNNumber));
                    cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", student.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@MiddleName", student.MiddleName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", student.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Gender", student.Gender));
                    cmd.Parameters.Add(new SqlParameter("@Address", student.Address));
                    cmd.Parameters.Add(new SqlParameter("@City", student.City));
                    cmd.Parameters.Add(new SqlParameter("@State", student.State));
                    cmd.Parameters.Add(new SqlParameter("@Email", student.Email));
                    cmd.Parameters.Add(new SqlParameter("@Qualification", student.Qualification));
                    cmd.Parameters.Add(new SqlParameter("@CourseName", student.CourseName));
                    cmd.Parameters.Add(new SqlParameter("@BatchName", student.BatchName));
                    cmd.Parameters.Add(new SqlParameter("@JoiningDate", student.JoiningDate));
                    cmd.Parameters.Add(new SqlParameter("@MobileNumber", student.MobileNumber));
                    cmd.Parameters.Add(new SqlParameter("@FatherName", student.FatherName));
                    cmd.Parameters.Add(new SqlParameter("@MotherName", student.MotherName));
                    cmd.Parameters.Add(new SqlParameter("@GaurdianContact", student.GaurdianContact));
                    cmd.Parameters.Add(new SqlParameter("@UserName", student.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", student.Password));
                    cmd.Parameters.Add(new SqlParameter("@PassingYear", student.PassingYear));
                    cmd.Parameters.Add(new SqlParameter("@Experience", student.Experience));
                    cmd.Parameters.Add(new SqlParameter("@CollegeName", student.CollegeName));
                    cmd.Parameters.Add(new SqlParameter("@UniversityName", student.UniversityName));
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

        public static bool Delete(string PRNNumber)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE FROM Student WHERE PRNNumber=@PRNNumber";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@PRNNumber", PRNNumber));
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

        public static Student Get(string PRNNumber)
        {
            Student student = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Student WHERE PRNNumber=@PRNNumber";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@PRNNumber", PRNNumber));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                student = new Student()
                                {
                                    PRNNumber = reader["PRNNumber"].ToString(),
                                    RollNumber = int.Parse(reader["RollNumber"].ToString()),
                                    FirstName = reader["FirstName"].ToString(),
                                    MiddleName = reader["MiddleName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    State = reader["State"].ToString(),
                                    Email = (reader["Email"].ToString()),
                                    Qualification = reader["Qualification"].ToString(),
                                    CourseName = reader["CourseName"].ToString(),
                                    BatchName = reader["BatchName"].ToString(),                                   
                                    JoiningDate = reader["JoiningDate"].ToString(),
                                    MobileNumber = reader["MobileNumber"].ToString(),
                                    FatherName= reader["FatherName"].ToString(),
                                    MotherName= reader["MotherName"].ToString(),
                                    GaurdianContact = reader["GaurdianContact"].ToString(),
                                    UserName = reader["UserName"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    PassingYear = int.Parse(reader["PassingYear"].ToString()),
                                    Experience = reader["Experience"].ToString(),
                                    CollegeName = (reader["CollegeName"].ToString()),
                                    UniversityName = reader["UniversityName"].ToString()
                                   

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

            return student;
        }
        public static Student GetUserName(string UserName,string Password)
        {
            Student student = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Student WHERE UserName=@UserName and Password=@Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password",Password ));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                student = new Student()
                                {
                                    PRNNumber = reader["PRNNumber"].ToString(),
                                    RollNumber = int.Parse(reader["RollNumber"].ToString()),
                                    FirstName = reader["FirstName"].ToString(),
                                    MiddleName = reader["MiddleName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    State = reader["State"].ToString(),
                                    Email = (reader["Email"].ToString()),
                                    Qualification = reader["Qualification"].ToString(),
                                    CourseName = reader["CourseName"].ToString(),
                                    BatchName = reader["BatchName"].ToString(),
                                    JoiningDate = reader["JoiningDate"].ToString(),
                                    MobileNumber = reader["MobileNumber"].ToString(),
                                    FatherName = reader["FatherName"].ToString(),
                                    MotherName = reader["MotherName"].ToString(),
                                    GaurdianContact = reader["GaurdianContact"].ToString(),
                                    UserName = reader["UserName"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    PassingYear = int.Parse(reader["PassingYear"].ToString()),
                                    Experience = reader["Experience"].ToString(),
                                    CollegeName = (reader["CollegeName"].ToString()),
                                    UniversityName = reader["UniversityName"].ToString()


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

            return student;
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

        public static List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Student";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Student student = new Student()
                                {
                                    PRNNumber = reader["PRNNumber"].ToString(),
                                    RollNumber = int.Parse(reader["RollNumber"].ToString()),
                                    FirstName = reader["FirstName"].ToString(),
                                    MiddleName = reader["MiddleName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    State = reader["State"].ToString(),
                                    Email = (reader["Email"].ToString()),
                                    Qualification = reader["Qualification"].ToString(),
                                    CourseName = reader["CourseName"].ToString(),
                                    BatchName = reader["BatchName"].ToString(),
                                    JoiningDate = reader["JoiningDate"].ToString(),
                                    MobileNumber = reader["MobileNumber"].ToString(),
                                    FatherName = reader["FatherName"].ToString(),
                                    MotherName = reader["MotherName"].ToString(),
                                    GaurdianContact = reader["GaurdianContact"].ToString(),
                                    UserName = reader["UserName"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    PassingYear = int.Parse(reader["PassingYear"].ToString()),
                                    Experience = reader["Experience"].ToString(),
                                    CollegeName = (reader["CollegeName"].ToString()),
                                    UniversityName = reader["UniversityName"].ToString()
                                };
                                students.Add(student);
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

            return students;
        }
    }
}
