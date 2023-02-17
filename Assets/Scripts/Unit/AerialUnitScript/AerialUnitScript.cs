using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AerialUnitScript : MonoBehaviour
{
    [SerializeField] internal int attackDamage;
    [SerializeField] internal int health;
    [SerializeField] private GameObject arrow;
    [SerializeField] private List<GameObject> arrowList;
    [SerializeField] private int arrowCount;
    [SerializeField] private int arrowNumber;
    [SerializeField] private GameObject currentEnemy;
    [SerializeField] private Transform arrowCreatePoint;
    [SerializeField] private GameObject createdArrow;
    [SerializeField] private bool canAttack;
    private HealthBar healthBar;
    
    private void Start() 
    {
        healthBar = GetComponentInChildren<HealthBar>();
        arrowList = new List<GameObject>();
        arrowNumber = 0;
        FillArrowSlot();
        canAttack = true;
        healthBar.SetMaxValue();
    }
    private void FillArrowSlot()
    {
        for (int i = 0; i < arrowCount; i++)
        {   
            createdArrow = Instantiate(arrow);
            createdArrow.transform.SetParent(gameObject.transform);
            createdArrow.SetActive(false);
            arrowList.Add(createdArrow);
        }
    }
    private void Update() 
    {
        CheckArrowStatus();
        GetEnemy();
    }
    private void GetEnemy()
    {
        if(GetComponent<EnemyUnit>() != null)
        {
            currentEnemy = GetComponent<EnemyUnit>().currentEnemy;
        }
        if(GetComponent<AllyUnit>() != null)
        {
            currentEnemy = GetComponent<AllyUnit>().currentEnemy;
        }
    }
    public void CreateArrow()
    {
        if(arrowNumber <= arrowCount-1)
        {
            if(currentEnemy != null)
            {
                arrowList[arrowNumber].SetActive(true);
                arrowList[arrowNumber].transform.DOMove(currentEnemy.transform.position,0.2f).SetEase(Ease.OutSine);
                
            }
            arrowNumber++;
        }
        else
        {
            arrowNumber = 0;
            
        }
    }
    private void CheckArrowStatus()
    {
        foreach(GameObject arrow in arrowList)
        {
            if(arrow.activeInHierarchy == false)
            {
                arrow.transform.position = arrowCreatePoint.position;
            }
        }
    }
    internal void Attack()
    {
        if(canAttack == true)
        {
            canAttack = false;
            CreateArrow();
            StartCoroutine(AttackCountDown());
        }
        
    }
    internal void TakeDamage()
    {
        health = health - 10;
        healthBar.SetValue();
    }
    IEnumerator AttackCountDown()
    {
        yield return new WaitForSeconds(1);
        canAttack = true;
    }
}
