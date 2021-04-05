using EHI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EHI.DA
{
    public class ContactRepository:IContactRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["EHI"].ToString();
            con = new SqlConnection(constr);

        }
        public int Contact_DM(Contact ObjBO)
        {
            try
            {
                connection();
                con.Open();
                SqlCommand cmd = new SqlCommand("Contact_DM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ObjBO.Id);
                cmd.Parameters.AddWithValue("@FirstName", ObjBO.FirstName);
                cmd.Parameters.AddWithValue("@LastName", ObjBO.LastName);
                cmd.Parameters.AddWithValue("@Email", ObjBO.EmailId);
                cmd.Parameters.AddWithValue("@PhoneNo", ObjBO.PhoneNo);
                cmd.Parameters.AddWithValue("@Active", ObjBO.Active);
                cmd.Parameters.AddWithValue("@Mode", ObjBO.Mode);
                cmd.Parameters.Add("@error", SqlDbType.Int);
                cmd.Parameters["@error"].Direction = ParameterDirection.Output;
       
                cmd.ExecuteNonQuery();
                int Result = Convert.ToInt32(cmd.Parameters["@error"].Value);
                cmd.Dispose();
                return Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public List<Contact> Contact_DS(Contact contact )
        {
            connection();
            List<Contact> ContactList = new List<Contact>();


            SqlCommand cmd = new SqlCommand("Contact_DS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", contact.Mode);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close(); 
            foreach (DataRow dr in dt.Rows)
            {

               ContactList.Add(

                    new Contact
                    {

                        Id = Convert.ToInt32(dr["Id"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        EmailId = Convert.ToString(dr["Email"]),
                        PhoneNo = Convert.ToString(dr["PhoneNo"]),
                        Active = Convert.ToBoolean(dr["Active"])

                    }
                    );
            }

            return ContactList;
        }
        public Contact Contact_DQ(int mode, int id)
        {
            connection();
            List<Contact> ContactList = new List<Contact>();


            SqlCommand cmd = new SqlCommand("Contact_DQ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Mode", mode);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();    
            foreach (DataRow dr in dt.Rows)
            {

                ContactList.Add(

                     new Contact
                     {

                         Id = Convert.ToInt32(dr["Id"]),
                         FirstName = Convert.ToString(dr["FirstName"]),
                         LastName = Convert.ToString(dr["LastName"]),
                         EmailId = Convert.ToString(dr["Email"]),
                         PhoneNo = Convert.ToString(dr["PhoneNo"]),
                         Active = Convert.ToBoolean(dr["Active"])

                     }
                     );
            }

            return ContactList.FirstOrDefault();
        }
        
    }
}