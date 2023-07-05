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
        sql.Parameters.Add("@artistId", 5);
        var data = sql.ExecuteStoredProcedureDS("GetArtistDetails");

        if (data.Tables[0].Rows.Count > 0)
        {
           
            artistBanner.DataSource = data.Tables[0];
            artistBanner.DataBind();

            Biography = data.Tables[0].Rows[0]["artistBiography"].ToString();

            songList.DataSource = data.Tables[2];
            songList.DataBind();

            albumList.DataSource = data.Tables[1];
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
