using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoBar : MonoBehaviour
{
    public Text AmmoText;
    public Sprite Missle;
    public Sprite Laser;
    public Image AmmoIcon;



    public void SetAmmo(string ammo)
    {
        AmmoText.text = ammo;
    }


    public void UpdateTex(string ammoText, bool UpgradeWeapon)
    {
        SetAmmo(ammoText);
        if (UpgradeWeapon)
        {
            AmmoIcon.sprite = Missle;
            return;
        }

        AmmoIcon.sprite = Laser;

        
        

    }

}
