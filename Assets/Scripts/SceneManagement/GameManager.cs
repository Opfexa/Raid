using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject LoseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    internal void WinGame()
    {
        Debug.Log("Kazandin");
        WinScreen.SetActive(true);
        Time.timeScale = 0;
    }
    internal void LoseGame()
    {
        LoseScreen.SetActive(true);
        Debug.Log("Kaybettin");
        Time.timeScale = 0;
    }
    internal void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
