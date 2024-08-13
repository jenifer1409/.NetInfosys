using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class3
{
    public class VehicleBookingADONET
    {
        public static void AddBooking(string cusName,string from,string to,DateTime bookDate)
        {
            using(SqlConnection con=new SqlConnection("Data Source=DESKTOP-PL0KJBQ;Initial Catalog=adonet;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Command Timeout=0"))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.usp_insertbooking", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customername", cusName);
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);
                    cmd.Parameters.AddWithValue("@bookingdate", bookDate);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Data is saved successfully");

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                finally
                {
                    con.Close();
                }
                
            }

        }
        public static void CancelBooking()
        {

        }
        public static void GetBookingDetails()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-PL0KJBQ;Initial Catalog=adonet;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Command Timeout=0"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from vehicleBooking", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader != null)
                {


                    if (reader.Read())
                    {
                        Console.WriteLine(reader["Id"].ToString());
                        Console.WriteLine(reader["CustomerName"].ToString());
                        Console.WriteLine(reader["FromLocation"].ToString());
                        Console.WriteLine(reader["ToLocation"].ToString());
                        Console.WriteLine(reader["BookingDate"].ToString());

                    }
                }

            }
         }
        public static void UpdateBooking()
        {

        }
    }
}
