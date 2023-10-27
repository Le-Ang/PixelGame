using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using DG.Tweening;

public class HighScore : MonoBehaviour
{
    private Transform entryContainer;
    public List<HighScoreEntry> highScoreEntryList = new List<HighScoreEntry>();
    [SerializeField] private Transform entryTemplate;
    [SerializeField] private Sprite goldCup;
    [SerializeField] private Sprite silverCup;
    [SerializeField] private Sprite bronzeCup;
    //private Transform cupImg;

    //private void Start()
    //{

    //}
    private void Start()
    {
        //goldCup = Resources.Load<Sprite>("Cup");
        //silverCup = Resources.Load<Sprite>("Cup/Cup_1");
        //bronzeCup = Resources.Load<Sprite>("Cup");
        Debug.Log("Create List at Awake ");
        entryContainer = transform.Find("HighScoreContainer");
        //entryTemplate = entryContainer.Find("HighScoreTemplate");


        float templateHeight = 25f;
        for(int i = 0; i< highScoreEntryList.Count; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryRectTransform.gameObject.SetActive(true);
            entryTransform.transform.localScale = Vector3.zero;
            entryTransform.transform.DOScale(1f, 1f).SetEase(Ease.InOutCirc);
            
            int rank = i + 1;
            string rankString;
            switch (rank)
            {                
                case 1:
                    entryTransform.Find("Image").GetComponent<Image>().enabled = true;
                    entryTransform.Find("Image").GetComponent<Image>().sprite = goldCup;
                    entryTransform.Find("RawImage").GetComponent<RawImage>().color = new Color32(241, 178, 128, 250);
                    rankString = "1ST";
                    break;
                case 2:
                    entryTransform.Find("Image").GetComponent<Image>().enabled = true;
                    entryTransform.Find("Image").GetComponent<Image>().sprite = silverCup;
                    entryTransform.Find("RawImage").GetComponent<RawImage>().color = new Color32(169, 241, 128, 240);
                    rankString = "2ND";
                    break;
                case 3:
                    entryTransform.Find("Image").GetComponent<Image>().enabled = true;
                    entryTransform.Find("Image").GetComponent<Image>().sprite = bronzeCup;
                    entryTransform.Find("RawImage").GetComponent<RawImage>().color = new Color32(233, 255, 50, 230);
                    rankString = "3RD";
                    break;
                default:
                    entryTemplate.Find("Image").GetComponent<Image>().enabled = false;                  
                    rankString = rank + "TH";                    
                    break;
            }

            entryTransform.Find("Rank").GetComponent<Text>().text = rankString;

            //int score = Random.Range(0, 100);
            entryTransform.Find("Score").GetComponent<Text>().text = highScoreEntryList[i].score.ToString();
            //entryTransform.Find("Score").GetComponent<Tea>

            //string name = "ABC";
            entryTransform.Find("Name").GetComponent<Text>().text = highScoreEntryList[i].name.ToString();
            StartCoroutine("Delay");
        }
    }
    public void ShowScore()
    {
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommand = dbConnection.CreateCommand();

        dbCommand.CommandText = "SELECT * FROM Leaderboard order by score DESC limit 10";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string readString = reader.GetString(0);
            int readScore = reader.GetInt32(1);
            Debug.Log("name: " + readString + "Score: " + readScore);
            highScoreEntryList.Add(new HighScoreEntry() { score = readScore, name = readString });
        }
        dbConnection.Close();
    }
    public class HighScoreEntry{
        public int score;
        public string name;
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
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
    }
}
