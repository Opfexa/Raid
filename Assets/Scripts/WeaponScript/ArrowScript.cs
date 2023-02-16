using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other) 
    {
        if(gameObject.transform.parent.tag == "Enemy" && other.gameObject.tag == "Ally")
        {
            gameObject.SetActive(false);
            if(other.gameObject.GetComponent<BaseScript>() != null)
            {
                other.gameObject.GetComponent<BaseScript>().health -= 10;
            }
            if(other.gameObject.GetComponent<RangedWarriorScript>() != null)
            {
                other.gameObject.GetComponent<RangedWarriorScript>().health -= 10;
            }
            if(other.gameObject.GetComponent<MeleeWarriorScript>() != null)
            {
                other.gameObject.GetComponent<MeleeWarriorScript>().health -= 10;
            }
            if(other.gameObject.GetComponent<AerialUnitScript>() != null)
            {
                other.gameObject.GetComponent<AerialUnitScript>().health -= 10;
            }
        }
        if(gameObject.transform.parent.tag == "Ally" && other.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            if(other.gameObject.GetComponent<BaseScript>() != null)
            {
                other.gameObject.GetComponent<BaseScript>().health -= 10;
            }
            if(other.gameObject.GetComponent<RangedWarriorScript>() != null)
            {
                other.gameObject.GetComponent<RangedWarriorScript>().health -= 10;
            }
            if(other.gameObject.GetComponent<MeleeWarriorScript>() != null)
            {
                other.gameObject.GetComponent<MeleeWarriorScript>().health -= 10;
            }
            if(other.gameObject.GetComponent<AerialUnitScript>() != null)
            {
                other.gameObject.GetComponent<AerialUnitScript>().health -= 10;
            }
        }
    }
}
