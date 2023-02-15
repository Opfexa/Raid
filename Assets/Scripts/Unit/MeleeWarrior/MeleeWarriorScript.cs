using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWarriorScript : MonoBehaviour
{
    [SerializeField] internal int attackDamage;
    [SerializeField] internal int health;

    private void Start() 
    {
        if(gameObject.tag == "Enemy")
        {
            health = 20;
            attackDamage = 10;
        }
        if(gameObject.tag == "Ally")
        {
            health = 30;
            attackDamage = 15;
        }
    }
}
