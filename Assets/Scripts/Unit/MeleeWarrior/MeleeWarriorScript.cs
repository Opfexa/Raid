using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWarriorScript : MonoBehaviour
{
    [SerializeField] internal int attackDamage;
    [SerializeField] internal int health;
    private HealthBar healthBar;

    private void Start() 
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxValue();
    }
    internal void TakeDamage()
    {
        health = health - 10;
        healthBar.SetValue();
    }
}
