using System.Collections;
using System.Collections.Generic;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public string input;
    MainManager mainManager;
 
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        SceneData.Instance.LoadBestScore();
        mainManager.bestScoreNumber = SceneData.Instance.bestScoreNumber;
    }
    public void QuitGame()
    {
        SceneData.Instance.SaveBestScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
     public void PlayerName(string s)
    {
        input = s;
        SceneData.Instance.playerName = input;
    }
}
