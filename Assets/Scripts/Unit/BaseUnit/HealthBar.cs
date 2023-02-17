using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] internal Slider healthBar;
    internal void SetValue() 
    {
        if(gameObject.GetComponentInParent<AerialUnitScript>() != null)
        {
            healthBar.value = gameObject.GetComponentInParent<AerialUnitScript>().health;
        }
        if(gameObject.GetComponentInParent<MeleeWarriorScript>() != null)
        {
            healthBar.value = gameObject.GetComponentInParent<MeleeWarriorScript>().health;
        }
        if(gameObject.GetComponentInParent<RangedWarriorScript>() != null)
        {
            healthBar.value = gameObject.GetComponentInParent<RangedWarriorScript>().health;
        }
        if(gameObject.GetComponentInParent<BaseScript>() != null)
        {
            healthBar.value = gameObject.GetComponentInParent<BaseScript>().health;
        }
    }
    internal void SetMaxValue()
    {
        if(gameObject.GetComponentInParent<BaseScript>() != null)
        {
            healthBar.maxValue = gameObject.GetComponentInParent<BaseScript>().health;
            healthBar.value = gameObject.GetComponentInParent<BaseScript>().health;
        }
        if(gameObject.GetComponentInParent<AerialUnitScript>() != null)
        {
            healthBar.maxValue = gameObject.GetComponentInParent<AerialUnitScript>().health;
            healthBar.value = gameObject.GetComponentInParent<AerialUnitScript>().health;
        }
        if(gameObject.GetComponentInParent<MeleeWarriorScript>() != null)
        {
            healthBar.maxValue = gameObject.GetComponentInParent<MeleeWarriorScript>().health;
            healthBar.value = gameObject.GetComponentInParent<MeleeWarriorScript>().health;
        }
        if(gameObject.GetComponentInParent<RangedWarriorScript>() != null)
        {
            healthBar.maxValue = gameObject.GetComponentInParent<RangedWarriorScript>().health;
            healthBar.value = gameObject.GetComponentInParent<RangedWarriorScript>().health;
        }
    }
}
