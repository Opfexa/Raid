using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[RequireComponent (typeof(Rigidbody), typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
    private Rigidbody unitRigidbody;
    private NavMeshAgent agent;
    [SerializeField] GameObject currentEnemy;

    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] public List<GameObject> enemys;
    [SerializeField] internal bool IsEnemy;

    private UnitAnimations unitAnimations;

    internal bool IsRunning { get;  private set; }
    internal bool IsDead;
    private void Awake() 
    {
        unitRigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        
    }
    private void Start() 
    {
        unitAnimations = GetComponent<UnitAnimations>();

        IsRunning = false;
        IsDead = false;

        if(IsEnemy) gameObject.tag = "Enemy";
        else gameObject.tag = "Ally";

        ChooseEnemy();
        AddFightList();
    }
    private void Update() 
    {
        CheckDeath();
    }
    private void FixedUpdate() 
    {
        currentEnemy = FindClosestEnemy();
        Movement(currentEnemy);
    }
    private void ChooseEnemy()
    {
        if(gameObject.tag == "Ally")
        {
            agent.speed = agent.speed * 1.5f;
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemys.Add(enemy);
            }
        }
        else if(gameObject.tag == "Enemy")
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Ally"))
            {
                enemys.Add(enemy);
            }
            foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Base"))
            {
                enemys.Add(enemy);
            }
        }
    }
    private GameObject FindClosestEnemy()
    {
        GameObject closestEnemy = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject chosenEnemy in enemys)
        {
            if(chosenEnemy != null || gameObject.tag == "Ally" && chosenEnemy.activeInHierarchy == true)
            {
                Vector3 diff = chosenEnemy.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if(chosenEnemy.activeInHierarchy == true)
                {
                    if (curDistance < distance)
                    {
                        closestEnemy = chosenEnemy;
                        distance = curDistance;
                    }
                }
                else
                {
                    foreach (GameObject enemy in enemys)
                    {
                        enemy.GetComponent<Unit>().enemys.Remove(gameObject);
                    }
                }
            }
            else
            {
                closestEnemy = null;
            }
            
        }
        return closestEnemy;
    }
    //Oynayacağımız karakterleri düşmanlara bir düşman olarak ekleme
    private void AddFightList()
    {
        if(gameObject.tag == "Enemy" && GameObject.FindGameObjectsWithTag("Ally") != null)
        {
            foreach (GameObject ally in GameObject.FindGameObjectsWithTag("Ally"))
            {
                ally.GetComponent<Unit>().enemys.Add(gameObject);
            }
        }
        
    }
    private void Movement(GameObject enemy)
    {   
        if(enemy != null)
        {
            agent.destination = enemy.transform.position;
            IsRunning = true;
        }
        else
        {
            IsRunning = false;
        }
        
    }
    private void CheckDeath()
    {
        if(IsDead)
        {
            enemys.Clear();
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(gameObject.tag == "Enemy" && other.gameObject.tag == "Ally")
        {
            gameObject.SetActive(false);
            IsDead = true;
        }
        if(gameObject.tag == "Ally" && other.gameObject.tag == "Enemy")
        {
            foreach (GameObject enemy in enemys)
            {
                enemy.GetComponent<Unit>().enemys.Remove(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
