using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassScore
{
    private static ClassScore instance;
    private int score = 0;
    public static ClassScore getInstance()
    {
        
        if(instance == null)
            instance =  new ClassScore();
        return instance;
    }
    public int getScore()
    {
        return score;
    }
    public void setScore(int score)
    {
        this.score = score;
    }
    public void scoreIncrease(int increase)
    {
        this.score += increase;
    }
}
