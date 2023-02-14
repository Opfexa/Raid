using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimations : MonoBehaviour
{
    private Unit unitScript;
    private Animator unitAnimator;
    // Start is called before the first frame update
    void Start()
    {
        unitScript = GetComponent<Unit>();
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
}
