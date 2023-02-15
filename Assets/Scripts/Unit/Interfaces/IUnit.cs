using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit
{
    GameObject FindClosestEnemy();
    void Movement(GameObject target);
    void CheckDeath();
} 
