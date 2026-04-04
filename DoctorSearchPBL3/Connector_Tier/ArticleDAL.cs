using System;
using System.Collections.Generic;
using System.Text;

using DTO_Tier;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL_Tier
{
    public class ArticleDAL
    {
        public List<ArticleDTO> SearchArticles(string keyword)
        {
            List<ArticleDTO> list = new List<ArticleDTO>();
            // Tìm trong Tiêu đề hoặc Nội dung bài viết
            string query = "SELECT * FROM Articles WHERE Title LIKE @key OR Content LIKE @key";
            SqlParameter[] parameters = {
                new SqlParameter("@key", "%" + keyword + "%")
            };

            DataTable dt = DBHelper.GetDataTable(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ArticleDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Title = row["Title"].ToString(),
                    Content = row["Content"].ToString(),
                    Thumbnail = row["Thumbnail"].ToString(),
                    Views = Convert.ToInt32(row["Views"]),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"])
                });
            }
            return list;
        }
    }
}
