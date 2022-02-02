using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintHighScoreTable : MonoBehaviour
{
    private void Start()
    {
        ScoreDatabase.CreateDB();
        GetComponent<Text>().text = ScoreDatabase.DBGetTopScores(5);

        if (GetComponent<Text>().text == "")
            GetComponent<Text>().text = "- No Highscores -";
    }
}
