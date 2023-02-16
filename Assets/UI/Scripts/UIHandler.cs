using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    private GameManager gameManager;

    private void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    public void RestartButton()
    {
        gameManager.RestartGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
