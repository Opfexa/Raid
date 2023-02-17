using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] internal GameObject parent;
    private void OnTriggerEnter(Collider other) 
    {
        if(parent.tag == "Enemy" && other.gameObject.tag == "Ally")
        {
            
            if(other.gameObject.GetComponent<BaseScript>() != null)
            {
                other.gameObject.GetComponent<BaseScript>().health -= 10;
            }
            if(other.gameObject.GetComponent<RangedWarriorScript>() != null)
            {
                other.gameObject.GetComponent<RangedWarriorScript>().TakeDamage();
            }
            if(other.gameObject.GetComponent<MeleeWarriorScript>() != null)
            {
                other.gameObject.GetComponent<MeleeWarriorScript>().TakeDamage();
            }
            if(other.gameObject.GetComponent<AerialUnitScript>() != null)
            {
                other.gameObject.GetComponent<AerialUnitScript>().TakeDamage();
            }
        }
        if(parent.tag == "Ally" && other.gameObject.tag == "Enemy")
        {
            
            if(other.gameObject.GetComponent<BaseScript>() != null)
            {
                other.gameObject.GetComponent<BaseScript>().health -= 10;
            }
            if(other.gameObject.GetComponent<RangedWarriorScript>() != null)
            {
                other.gameObject.GetComponent<RangedWarriorScript>().TakeDamage();
            }
            if(other.gameObject.GetComponent<MeleeWarriorScript>() != null)
            {
                other.gameObject.GetComponent<MeleeWarriorScript>().TakeDamage();
            }
            if(other.gameObject.GetComponent<AerialUnitScript>() != null)
            {
                other.gameObject.GetComponent<AerialUnitScript>().TakeDamage();
            }
        }
    }
}
