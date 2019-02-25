using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Online_Music_Library.Models;

namespace Online_Music_Library.Controllers
{
    public class SongController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-1RVC546;Initial Catalog=Online_Music_Library;Integrated Security=SSPI";
        [HttpGet]
        public ActionResult Song()
        {
            DataTable dtblSong = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM tblSongs",sqlCon);
                sqlda.Fill(dtblSong);
            }
                return View(dtblSong);
        }


        // GET: Song/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new SongModel());
        }

        // POST: Song/Create
        [HttpPost]
        public ActionResult Create(SongModel songModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO tblSongs VALUES(@song_name,@song_artist,@song_category,@language,@lyrics)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@song_name",songModel.song_name);
                sqlCmd.Parameters.AddWithValue("@song_artist", songModel.song_artist);
                sqlCmd.Parameters.AddWithValue("@song_category", songModel.song_category);
                sqlCmd.Parameters.AddWithValue("@language", songModel.language);
                sqlCmd.Parameters.AddWithValue("@lyrics", songModel.lyrics);
                sqlCmd.ExecuteNonQuery();
            }
                return RedirectToAction("Song");
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int id)
        {
            SongModel songModel = new SongModel();
            DataTable dtblSong = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM tblSongs WHERE song_id=@song_id";
                SqlDataAdapter sqlda = new SqlDataAdapter(query,sqlCon);
                sqlda.SelectCommand.Parameters.AddWithValue("@song_id",id);
                sqlda.Fill(dtblSong);
            }
            if (dtblSong.Rows.Count == 1)
            {
                songModel.song_id = Convert.ToInt32(dtblSong.Rows[0][0].ToString());
                songModel.song_name = dtblSong.Rows[0][1].ToString();
                songModel.song_artist = dtblSong.Rows[0][2].ToString();
                songModel.song_category = dtblSong.Rows[0][3].ToString();
                songModel.language = dtblSong.Rows[0][4].ToString();
                songModel.lyrics = dtblSong.Rows[0][5].ToString();
                return View(songModel);

            }
            else
                return RedirectToAction("Song");
                
        }

        // POST: Song/Edit/5
        [HttpPost]
        public ActionResult Edit(SongModel songModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE tblSongs SET song_name=@song_name,song_artist=@song_artist,song_category=@song_category,language=@language,lyrics=@lyrics where song_id=@song_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@song_id", songModel.song_id);
                sqlCmd.Parameters.AddWithValue("@song_name", songModel.song_name);
                sqlCmd.Parameters.AddWithValue("@song_artist", songModel.song_artist);
                sqlCmd.Parameters.AddWithValue("@song_category", songModel.song_category);
                sqlCmd.Parameters.AddWithValue("@language", songModel.language);
                sqlCmd.Parameters.AddWithValue("@lyrics", songModel.lyrics);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Song");
        }

        // GET: Song/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM tblSongs where song_id=@song_id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@song_id", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Song");
        }

        
    }
}
