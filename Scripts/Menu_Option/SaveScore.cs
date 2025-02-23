using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.SocialPlatforms.Impl;
using System.Data.Common;
using UnityEngine.UI;
using static HighScore;

public class SaveScore : MonoBehaviour
{
    private int rank;
    private int score;
    [SerializeField] private Text namePlayer;
    [SerializeField] private Text textRank;

    public void SaveNameAndScore()
    {
        Debug.Log(Application.persistentDataPath);
        HighScore findList = gameObject.GetComponent<HighScore>();
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommand = dbConnection.CreateCommand();

        score = ClassScore.getInstance().getScore();
        string sql = "INSERT OR REPLACE INTO Leaderboard (name, score) VALUES (\"" + namePlayer.text + "\", " + score + ");";//xu ly chung ten
        dbCommand.CommandText = sql;
        Debug.Log(sql);
        int testExcute = dbCommand.ExecuteNonQuery();

        //Debug.Log(testExcute);
        Debug.Log("dtb is connected");
        dbCommand.CommandText = "SELECT * FROM Leaderboard order by score DESC limit 10";
        IDataReader reader = dbCommand.ExecuteReader();
        int count = 1;
        while (reader.Read())
        {
            string readString = reader.GetString(0);
            if (readString == namePlayer.text)
            {
                rank = count;
            }
            count++;
        }
        if (rank != 0)
        {
            textRank.text = rank.ToString();
        } else
            textRank.text = "> 10";
        dbConnection.Close();
    }
    private IDbConnection CreateAndOpenDatabase()
    {
        string applicationdatapath = Application.persistentDataPath;
        string dbUri = "URI=file:"+applicationdatapath+"/MyDatabase.sqlite"; // 4
        IDbConnection dbConnection = new SqliteConnection(dbUri); // 5
        dbConnection.Open();

        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand(); // 6
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS Leaderboard (name TEXT PRIMARY KEY, score INTEGER )";
        dbCommandCreateTable.ExecuteReader();
        return dbConnection;
    }
}
