using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    [SerializeField] internal int health;
    [SerializeField] internal int attackDamage;
    private GameManager gameManager;
    private HealthBar healthBar;
    private void Start() 
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();    
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxValue();
    }
    private void Update() 
    {
        CheckDeath();
        healthBar.SetValue();
    }
    private void CheckDeath()
    {
        if(health<=0 && gameObject.name == "EnemyMainBase")
        {
            gameObject.SetActive(false);
            gameManager.WinGame();
            
        }
        else if(health<=0 && gameObject.name == "MainBase")
        {
            gameObject.SetActive(false);
            gameManager.LoseGame();
        }
        else if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
}
