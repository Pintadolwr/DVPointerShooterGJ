using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class ChangeScenes : MonoBehaviour
{

    public void LoadScene(string sceneName) {
        if (sceneName.CompareTo("Sala1POV") == 0) {
            PlayerPrefs.SetInt("totalScore", 0);
        }
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel(string sceneName) {
        
        /*int totalScore = PlayerPrefs.GetInt("totalScore");

        if (sceneName.CompareTo("Sala2POV") == 0 && totalScore >= 50)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (sceneName.CompareTo("Sala3POV") == 0 && totalScore >= 100)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (sceneName.CompareTo("Sala4POV") == 0 && totalScore >= 150)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (sceneName.CompareTo("Sala5POV") == 0 && totalScore >= 200)
        {
            SceneManager.LoadScene(sceneName);
        }*/

        SceneManager.LoadScene(sceneName);
    }
}
