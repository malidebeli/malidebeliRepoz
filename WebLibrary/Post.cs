using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace WebLibrary
{

    public class Post
    {
        public int postID { get; set; }
        public string naziv { get; set; }
        public string sadrzaj { get; set; }
        public string autor { get; set; }
        public DateTime timestamp { get; set; }



        public static List<Post> getTopPosts()
        {
            SqlCommand stringCommand = new SqlCommand(@"SELECT TOP "+ ConfigurationManager.AppSettings["brojPostova"]+@" p.[PostID],p.[Naziv],p.[Sadrzaj],a.[Ime] +' '+a.[Prezime] as 'ImePrezime',p.[Timestamp]  
                                                        FROM [dbo].[Postovi]  as p inner join [dbo].[Autor] as a 
                                                        on p.Autor = a.AutorId  order by p.[Timestamp] desc");
            DataTable dt = WebLibrary.DBObjects.DB.GetData1(stringCommand);
            return BindPostList(dt);
        }



        public static List<Post> BindPostList(DataTable dt)
        {
            List<Post> lp = new List<Post>();

            foreach (DataRow row in dt.Rows)
            {
                Post p = new Post();
                p.postID = (int)row["PostID"];
                p.naziv = (string)row["Naziv"];
                p.sadrzaj = (string)row["Sadrzaj"];
                p.autor = (string)row["ImePrezime"];
                //p.timestamp = (DateTime)row["Naziv"];
                lp.Add(p);
            }
            return lp;
        }




    }
}
