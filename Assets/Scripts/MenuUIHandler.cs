using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public string playerName = "Player";
    private string inputName;

    public string bestPlayerName;
    public int bestScore = 0;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        StateManager.instance.LoadBestScore();
        if (StateManager.instance.bestScore == 0)
        {
            scoreText.text = "";
        }
        else
        {
            bestScore = StateManager.instance.bestScore;
            bestPlayerName = StateManager.instance.bestPlayerName;
            scoreText.text = "Best Score: " + bestPlayerName + ": " + bestScore;
        }
    }

    public void StartGame()
    {
        //if input is blank, use default value of "Player"
        inputName = GameObject.Find("Player Name").GetComponent<TMP_InputField>().text;
        if (inputName.Equals("")) inputName = "Player";
        StateManager.instance.playerName = inputName;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit();
        #endif
    }
}
