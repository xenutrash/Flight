using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider HealthSlider;




    public void SetMaxHealth(int MaxHealth)
    {
        HealthSlider.maxValue = MaxHealth;
        SetHealth(MaxHealth);  
    }

    public void SetHealth(int health)
    {
        if (((int)HealthSlider.maxValue) < health){
            Debug.Log("Failsafe called");

            HealthSlider.value = HealthSlider.maxValue;
            return;
        }

        HealthSlider.value = health;
    }
}
