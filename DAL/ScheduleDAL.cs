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
    public class ScheduleDAL
    {

        private static string conString = string.Empty;

        static ScheduleDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conIMS"].ConnectionString;
        }
        public static bool Insert(Schedule schedule)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO Schedule (ScheduleId,CourseName, BatchName, SubjectName,FacultyName ,Timing,Venue,DateOfLec) " +
                        "VALUES (@ScheduleId,@CourseName, @BatchName, @SubjectName,@FacultyName ,@Timing,@Venue,@DateOfLec)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@ScheduleId", schedule.ScheduleId));
                    //  cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                    cmd.Parameters.Add(new SqlParameter("@CourseName", schedule.CourseName));
                    cmd.Parameters.Add(new SqlParameter("@BatchName", schedule.BatchName));
                    cmd.Parameters.Add(new SqlParameter("@SubjectName", schedule.SubjectName));
                    cmd.Parameters.Add(new SqlParameter("@FacultyName", schedule.FacultyName));
                    cmd.Parameters.Add(new SqlParameter("@Timing", schedule.Timing));
                    cmd.Parameters.Add(new SqlParameter("@Venue",schedule.Venue));
                    cmd.Parameters.Add(new SqlParameter("@DateOfLec", schedule.DateOfLec));
                  //  cmd.Parameters.Add(new SqlParameter("@ClassLabType", result.ClassLabType));
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

        public static bool Update(Schedule schedule)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE Schedule SET(CourseName=@CourseName, BatchName=@BatchName, SubjectName=@SubjectName,FacultyName=@FacultyName ,Timing=@Timing,Venue=@Venue,DateOfLec=@DateOfLec)" +
                                    "WHERE ScheduleId=@ScheduleId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    //   cmd.Parameters.Add(new SqlParameter("@PRNNumber", student.PRNNumber));
                    //  cmd.Parameters.Add(new SqlParameter("@FacultyId", faculty.FacultyId));
                    //  cmd.Parameters.Add(new SqlParameter("@RollNumber", student.RollNumber));
                    cmd.Parameters.Add(new SqlParameter("@CourseName", schedule.CourseName));
                    cmd.Parameters.Add(new SqlParameter("@BatchName", schedule.BatchName));
                    cmd.Parameters.Add(new SqlParameter("@SubjectName", schedule.SubjectName));
                    cmd.Parameters.Add(new SqlParameter("@FacultyName", schedule.FacultyName));
                    cmd.Parameters.Add(new SqlParameter("@Timing", schedule.Timing));
                    cmd.Parameters.Add(new SqlParameter("@Venue", schedule.Venue));
                    cmd.Parameters.Add(new SqlParameter("@DateOfLec", schedule.DateOfLec));

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

        public static bool Delete(int ScheduleId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE FROM Schedule WHERE ScheduleId=@ScheduleId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@ScheduleId", ScheduleId));
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

        public static Schedule Get(int ScheduleId)
        {
            Schedule schedule = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Schedule WHERE ScheduleId=@ScheduleId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@ScheduleId", ScheduleId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                schedule = new Schedule()
                                {
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                    ScheduleId = int.Parse(reader["ScheduleId"].ToString()),
                                    CourseName = reader["CourseName"].ToString(),
                                    BatchName = reader["BatchName"].ToString(),
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                    SubjectName = reader["SubjectName"].ToString(),
                                    FacultyName = reader["FacultyName"].ToString(),
                                    Timing = reader["Timing"].ToString(),
                                    Venue = reader["Venue"].ToString(),
                                    DateOfLec = reader["DateOfLec"].ToString()
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

            return schedule;
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

        public static List<Schedule> GetAll()
        {
            List<Schedule> schedules = new List<Schedule>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Schedule";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Schedule schedule = new Schedule()
                                {
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                    ScheduleId = int.Parse(reader["ScheduleId"].ToString()),
                                    CourseName = reader["CourseName"].ToString(),
                                    BatchName = reader["BatchName"].ToString(),
                                    //PRNNumber = reader["PRNNumber"].ToString(),
                                    SubjectName = reader["SubjectName"].ToString(),
                                    FacultyName = reader["FacultyName"].ToString(),
                                    Timing = reader["Timing"].ToString(),
                                    Venue = reader["Venue"].ToString(),
                                    DateOfLec = reader["DateOfLec"].ToString()
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
                                schedules.Add(schedule);
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

            return schedules;
        }
    }
}
