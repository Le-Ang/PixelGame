using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] public static Text textScore;

    private void Start()
    {
        textScore.text = ClassScore.getInstance().getScore().ToString();
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
    }
    
    public void showLeaderBoard()
    {
        Debug.Log("Show LeaderBoard");
        //Todo
    }
}
