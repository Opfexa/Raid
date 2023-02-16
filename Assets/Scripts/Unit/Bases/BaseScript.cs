using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    [SerializeField] internal int health;
    [SerializeField] internal int attackDamage;
    private GameManager gameManager;

    private void Start() 
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();    
    }
    private void Update() 
    {
        CheckDeath();
    }
    private void CheckDeath()
    {
        if(health<=0 && gameObject.name == "EnemyMainBase")
        {
            Destroy(gameObject);
            gameManager.WinGame();
            
        }
        else if(health<=0 && gameObject.name == "MainBase")
        {
            Destroy(gameObject);
            gameManager.LoseGame();
        }
        else if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Deneme");
            
        }
        if(other.gameObject.tag == "Ally")
        {
            Debug.Log("Deneme2");
        }
    }
}
