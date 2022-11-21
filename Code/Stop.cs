using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Stop : MonoBehaviour
{
    public TMP_Text scoretext;
    private void Awake() {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        var score = PlayerPrefs.GetInt("score");
        scoretext.text = score.ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
