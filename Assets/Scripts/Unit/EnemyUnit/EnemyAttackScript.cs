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
        if(GetComponent<MeleeWarriorScript>() != null)
        {
            attackDistance = 10;
        }
        if(GetComponent<RangedWarriorScript>() != null)
        {
            attackDistance = 150;
        }
        if(GetComponent<AerialUnitScript>() != null)
        {
            attackDistance = 150;
        }
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
            if(gameObject.GetComponent<AerialUnitScript>() == null)
            {
                enemyAnimations.Attack();
                transform.LookAt(new Vector3(enemyUnit.currentEnemy.transform.position.x,0,enemyUnit.currentEnemy.transform.position.z));
            }
            if(gameObject.GetComponent<AerialUnitScript>() != null)
            {
                gameObject.GetComponent<AerialUnitScript>().Attack();
            }
        }
        else
        {
            enemyUnit.IsOnFight = false;
        }
    }
    
}
