using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    private EnemyUnit enemyUnit;
    private EnemyAnimations enemyAnimations;
    [SerializeField] private float attackDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyUnit = GetComponent<EnemyUnit>();
        enemyAnimations = GetComponent<EnemyAnimations>();
        attackDistance = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyUnit.currentEnemy != null)
        {
            CheckFightArea();
        }
        
    }
    private void CheckFightArea()
    {
        Vector3 position = transform.position;
        Vector3 diff = enemyUnit.currentEnemy.transform.position - position;
        float distance = diff.sqrMagnitude;

        if(distance <= attackDistance)
        {
            enemyUnit.IsOnFight = true;
            transform.LookAt(enemyUnit.currentEnemy.transform);
            enemyAnimations.Attack();
        }
        else
        {
            enemyUnit.IsOnFight = false;
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
