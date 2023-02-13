using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[RequireComponent (typeof(Rigidbody), typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
    private Rigidbody unitRigidbody;
    private Animator unitAnimator;
    private NavMeshAgent agent;

    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] public List<GameObject> enemys;
    [SerializeField] internal bool IsEnemy;


    private void Awake() 
    {
        unitRigidbody = GetComponent<Rigidbody>();
        unitAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        
    }
    private void Start() 
    {
        ChooseEnemy();
        AddFightList();
    }
    private void Update() 
    {
        Movement();
        
    }
    private void ChooseEnemy()
    {
        if(gameObject.tag == "Ally")
        {
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
    private void Movement()
    {   
        if(FindClosestEnemy() != null)
        {
            agent.destination = FindClosestEnemy().transform.position;
        }
        
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(gameObject.tag == "Ally" && other.gameObject.tag == "Enemy" || gameObject.tag == "Enemy" && other.gameObject.tag == "Ally")
        {
            Destroy(gameObject);
        }
    }
}
