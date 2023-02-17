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
            if(gameObject.GetComponent<AerialUnitScript>() == null)
            {
                allyAnimations.Attack();
                transform.LookAt(new Vector3(allyUnit.currentEnemy.transform.position.x,0,allyUnit.currentEnemy.transform.position.z));
            }
            if(gameObject.GetComponent<AerialUnitScript>() != null)
            {
                gameObject.GetComponent<AerialUnitScript>().Attack();
            }
        }
        else
        {
            allyUnit.IsOnFight = false;
        }
    }
}
