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
   public class AdminDAL
    {
        private static string conString = string.Empty;
        static AdminDAL()
        {
            conString = ConfigurationManager.ConnectionStrings["conIMS"].ConnectionString;
        }
        public static bool Insert(Admin admin )
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO Admin (AdminId,UserName,Password) " + "VALUES (@AdminId,@UserName,@Password)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@AdminId", admin.AdminId));
                    cmd.Parameters.Add(new SqlParameter("@UserName",admin.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password",admin.Password));

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

        public static bool Update(Admin admin)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE Admin SET UserName=@UserName,Password=@Password" + "WHERE AdminId=@AdminId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // cmd.Parameters.Add(new SqlParameter("@CourseId", course.CourseId));
                    cmd.Parameters.Add(new SqlParameter("@UserName", admin.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password",admin.Password));

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

        public static bool Delete(int AdminId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE FROM Admin WHERE AdminId=@AdminId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@AdminId", AdminId));
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

        public static Admin Get(int AdminId)
        {
            Admin admin = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "Select  * FROM Admin WHERE AdminId=@AdminId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@AdminId", AdminId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                              admin = new Admin()
                                {
                                    AdminId = int.Parse(reader["AdminId"].ToString()),
                                   UserName = reader["UserName"].ToString(),
                                    Password = reader["Password"].ToString()
                                    //  ImageURL = reader["picture"].ToString(),
                                    //  UnitPrice = float.Parse(reader["price"].ToString()),
                                    //  Balance = int.Parse(reader["quantity"].ToString()),
                                    //  PaymentTerm = reader["paymentTerm"].ToString(),
                                    //  Delivery = reader["delivery"].ToString(),
                                    //  Category = reader["category"].ToString()
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

            return admin;
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

        public static List<Admin> GetAll()
        {
            List<Admin> admins = new List<Admin>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Admin";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Admin admin = new Admin()
                                {
                                    AdminId = int.Parse(reader["AdminId"].ToString()),
                                    UserName = reader["UserName"].ToString(),
                                    Password = reader["Password"].ToString()
                                };
                                admins.Add(admin);
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

            return admins;
        }


        public static Admin GetUserName(string UserName, string Password)
        {
            Admin admin = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Admin WHERE UserName=@UserName and Password=@Password";
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
                                admin = new Admin()
                                {
                                    AdminId=int.Parse(reader["AdminId"].ToString()),
                                    UserName = reader["UserName"].ToString(),
                                    Password = reader["Password"].ToString()


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

            return admin;
        }


    }
}
