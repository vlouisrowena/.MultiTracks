using DataAccess;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class ArtistDetails : MultitracksPage
{
    protected string Biography { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();
        sql.Parameters.Add("@artistId", 31);
        var data = sql.ExecuteStoredProcedureDT("GetArtistDetails");   
        
        if (data.Rows.Count > 0)
        {
            DataTable dataTable = data.Clone();
            dataTable.ImportRow(data.Rows[0]);

            artistBanner.DataSource = dataTable;
            artistBanner.DataBind();

            Biography = data.Rows[0]["artistBiography"].ToString();
            
            songList.DataSource = data; 
            songList.DataBind();
            

            List<object> uniqueChecker = new List<object>();

            for(int i = 0; i < data.Rows.Count; i++)
            {
                var value = data.Rows[i]["albumTitle"];

                if(!uniqueChecker.Contains(value))
                {
                    uniqueChecker.Add(value);
                }
                else
                {
                    data.Rows.Remove(data.Rows[i]);
                }
            }
            
            albumList.DataSource = data;
            albumList.DataBind();


        }

    }

    protected string FormatBiographyText(string Biography)
    {
        string[] delimiters = { "<!-- read more -->", "\n" };
        string[] paragraphs = Biography.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        string formattedBiography = string.Empty;

        foreach (string paragraph in paragraphs)
        {
            formattedBiography += "<p>" + paragraph + "</p>";
        }

        return formattedBiography;
    }



}
