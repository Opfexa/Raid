using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] internal float gameCountDownValue;
    [SerializeField] private TextMeshProUGUI countDownTimerValue;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameCountDownValue > 0)
        {
            countDownTimerValue.text = Mathf.RoundToInt(gameCountDownValue).ToString();
            CountDown();
        }
        else if(gameCountDownValue < 0)
        {
            Time.timeScale = 0;
            gameManager.WinGame();
        }
    }
    private void CountDown()
    {
        if(gameCountDownValue > 0)
        {
            gameCountDownValue -= Time.deltaTime;
        }
    }
    
}
