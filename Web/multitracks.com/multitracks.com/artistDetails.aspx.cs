using DataAccess;
using System;
using System.Activities.Expressions;
using System.Drawing;
using System.Web.UI.WebControls;

public partial class ArtistDetails : MultitracksPage
{
    protected string Biography { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();
        sql.Parameters.Add("@artistId", 5);
        var data = sql.ExecuteStoredProcedureDT("GetArtistDetails");
        
        if (data.Rows.Count > 0)
        {
            
            artistBanner.DataSource = data.Rows[0].Table;          
            artistBanner.DataBind();

            Biography = data.Rows[0]["artistBiography"].ToString();       

            songList.DataSource = data; 
            songList.DataBind();

            albumList.DataSource = data;
            albumList.DataBind();


        }




    }
}
