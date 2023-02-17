using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyUnit : Unit,IUnit
{
    [SerializeField] public GameObject[]enemys;
    [SerializeField] internal GameObject currentEnemy;
    [SerializeField] internal bool IsOnFight;
    private EnemyAttackScript enemyAttackScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyAttackScript = GetComponent<EnemyAttackScript>();
        List<GameObject> listOfGameObjects = new List<GameObject>();
        agent.speed = agent.speed * 2f;
        gameObject.tag = "Enemy";
        IsOnFight = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
        
    }
    private void FixedUpdate() 
    {
        currentEnemy = FindClosestEnemy();
        Movement(currentEnemy); 
    }
    public GameObject FindClosestEnemy()
    {
        enemys = GameObject.FindGameObjectsWithTag("Ally");
        if(gameObject.GetComponent<MeleeWarriorScript>() != null)
        {
            enemys = Array.FindAll(enemys, c => !c.GetComponent<AerialUnitScript>());
        }
        GameObject closestEnemy = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject chosenEnemy in enemys)
        {
            if(chosenEnemy != null)
            {
                Vector3 diff = chosenEnemy.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                
                if (curDistance < distance)
                {
                    closestEnemy = chosenEnemy;
                    distance = curDistance;
                }
            }
            else
            {
                closestEnemy = null;
            }
            
        }
        return closestEnemy;
    }
    
    public void Movement(GameObject enemy)
    {
         if(enemy != null && !IsOnFight)
        {
            agent.destination = enemy.transform.position;
            IsRunning = true;
        }
        else
        {
            agent.destination = transform.position;
            IsRunning = false;
        }
    }
    public void CheckDeath()
    {
        if(IsDead)
        {
            Array.Clear(enemys,0,enemys.Length);
        }
        if(gameObject.GetComponent<MeleeWarriorScript>() != null)
        {
            
            if(gameObject.GetComponent<MeleeWarriorScript>().health <= 0)
            {
                
                gameObject.SetActive(false);
                IsDead = true;
            }
        }
        if(gameObject.GetComponent<RangedWarriorScript>() != null)
        {  
            if(gameObject.GetComponent<RangedWarriorScript>().health <= 0)
            {
                
                gameObject.SetActive(false);
                IsDead = true;
            }
        }
        if(gameObject.GetComponent<AerialUnitScript>() != null)
        {  
            if(gameObject.GetComponent<AerialUnitScript>().health <= 0)
            {
                
                gameObject.SetActive(false);
                IsDead = true;
            }
        }
    }
}
