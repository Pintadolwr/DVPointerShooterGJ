using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalVariableStorage : MonoBehaviour
{
    //Sets a Global variable to store int value
    private int totalScore;

    [SerializeField]
    public Text totalScoreText;

    void Start()
    {
        totalScore = PlayerPrefs.GetInt("totalScore");
        totalScoreText.text = "Total Points: " + totalScore;
    }
}
