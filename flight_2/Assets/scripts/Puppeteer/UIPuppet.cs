using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPuppet : MonoBehaviour
{


    public Text Score;
    public Text AmmoText;
    public Image AmmoIcon;
    public Sprite Missle;
    public Sprite Laser;
    public HealtBar HealthBar;
    


    public void UpdateHealthBarMax(int MaxHealth)
    {
        HealthBar.SetMaxHealth(MaxHealth);
    }

    public void SetHealthValue(int HealthToUpdate)
    {
        HealthBar.SetHealth(HealthToUpdate);
    }




    public void UpdateScore(string Newscore) => Score.text = Newscore;
    

    //Sets the ammotext value 
    public void SetAmmo(string ammo)
    {
        AmmoText.text = ammo;
    }


    public void UpdateSprite(string ammoText, bool UpgradeWeapon)
    {

        if (UpgradeWeapon)
        {
            SetAmmo(ammoText);
            AmmoIcon.sprite = Missle;
            return;
        }

        SetAmmo("∞");
        AmmoIcon.sprite = Laser;




    }

}
