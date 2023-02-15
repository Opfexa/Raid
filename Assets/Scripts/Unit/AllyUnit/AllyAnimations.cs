using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAnimations : MonoBehaviour
{
    private AllyUnit unitScript;
    private Animator unitAnimator;
    // Start is called before the first frame update
    void Start()
    {
        unitScript = GetComponent<AllyUnit>();
        unitAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animations();
    }
    private void Animations()
    {
        if(unitScript.IsRunning)
        {
            unitAnimator.SetBool("IsRunning", true);
        }
        else
        {
            unitAnimator.SetBool("IsRunning", false);
        }
    }
    internal void Attack()
    {
        unitAnimator.SetTrigger("attack");
    }
}
