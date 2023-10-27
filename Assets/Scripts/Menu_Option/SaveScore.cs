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
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    public void SaveNameAndScore()
    {
        HighScore findList = gameObject.GetComponent<HighScore>();
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommand= dbConnection.CreateCommand();

        //dbCommand.CommandText = "SELECT * FROM Leaderboard";
        //IDataReader readerCheck = dbCommand.ExecuteReader();
        //while (readerCheck.Read())
        //{
        //    string readDB = readerCheck.GetString(1);
        //    if (readDB == namePlayer.text || namePlayer.text == "")
        //    {
        //        Debug.Log("Naming Failed");
        //    }
        //    else
        //    {
                score =100/*ClassScore.getInstance().getScore()*/;
                string sql = "INSERT OR REPLACE INTO Leaderboard (name, score) VALUES (\""+namePlayer.text + "\", " + score + ");";//xu ly chung ten
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
                    //int readScore = reader.GetInt32(1);
                    //Debug.Log("name: " + readString + "Score: " + readScore);
                    //findList.highScoreEntryList.Add(new HighScoreEntry() { score = readScore, name = readString });

                    
                    //Debug.Log("Your name: " + readString  + "Your score: " + readScore);
                    if (readString == namePlayer.text)
                    {
                        rank = count;
                       
                        //}                
                    }                    
                    
                    count++;
                    //biet diem tim index
                }
                if(rank != 0)
                {                    
                    textRank.text = rank.ToString();
                }else
                    textRank.text = "> 10";
        {

        }
        //    }
        //}


        dbConnection.Close();
    }
    private IDbConnection CreateAndOpenDatabase()
    {
        string dbUri = "URI=file:MyDatabase.sqlite"; // 4
        IDbConnection dbConnection = new SqliteConnection(dbUri); // 5
        dbConnection.Open();

        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand(); // 6
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS Leaderboard (name TEXT PRIMARY KEY, score INTEGER )";
        dbCommandCreateTable.ExecuteReader();
        return dbConnection;
    }
}
