using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[RequireComponent (typeof(Rigidbody), typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
    protected Rigidbody unitRigidbody;
    protected NavMeshAgent agent;
    /* 
    private UnitAnimations unitAnimations; */

    public bool IsRunning { get;  protected set; }
    internal bool IsDead;
    private void Awake() 
    {
        unitRigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        /* unitAnimations = GetComponent<UnitAnimations>(); */
    }
    
}
