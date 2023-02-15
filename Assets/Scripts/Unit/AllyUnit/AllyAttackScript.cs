using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttackScript : MonoBehaviour
{
    private AllyUnit allyUnit;
    private AllyAnimations allyAnimations;
    [SerializeField] private float attackDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        allyUnit = GetComponent<AllyUnit>();
        allyAnimations = GetComponent<AllyAnimations>();
        attackDistance = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if(allyUnit.currentEnemy != null)
        {
            CheckFightArea();
        }
        
    }
    private void CheckFightArea()
    {
        Vector3 position = transform.position;
        Vector3 diff = allyUnit.currentEnemy.transform.position - position;
        float distance = diff.sqrMagnitude;

        if(distance <= attackDistance)
        {
            allyUnit.IsOnFight = true;
            transform.LookAt(allyUnit.currentEnemy.transform);
            allyAnimations.Attack();
        }
        else
        {
            allyUnit.IsOnFight = false;
        }
    }
    internal void TakeDamage(int damageCount)
    {
        if(GetComponent<MeleeWarriorScript>() != null)
        {
            MeleeWarriorScript meleeWarriorScript = GetComponent<MeleeWarriorScript>();
            meleeWarriorScript.health = meleeWarriorScript.health - damageCount;
        }
    }
}
