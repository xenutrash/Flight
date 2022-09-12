using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPuppet : MonoBehaviour
{




    private int AmmoCount;
    private int MaxAmmo;
    private int MaxHealth;
    private int CurrentHealth;
    private int baseDamage;
    private int DamageModifer = 1;
    private bool SpecialWeaponActive;
    private int Speed;
    private int BuffTimer;



    //Buff related code
    public void AddBuffTimer(int time) => BuffTimer += time;
    public int GetBuffTimer() => BuffTimer;
    public int GetDamageModifer() => DamageModifer;




    //Ammo Funcs
    public void SetAmmo(int Ammo) => AmmoCount = Ammo;
    public void SetMaxAmmo(int AmmoMax) => MaxAmmo = AmmoMax;
    public int GetMaxAmmo() => MaxAmmo;

    public int GetAmmo() => AmmoCount;
   
    public void RemoveAmmo(int RemoveAmmo)
    {
        // Prevents ammo from becoming a negative value
        if((AmmoCount - RemoveAmmo)< 0)
        {
            AmmoCount = 0;
            return;
        }

        AmmoCount -= RemoveAmmo;
    } 



    public void AddAmmo(int Ammo)
    {
        //Prevents ammo from going over the limit
        if((AmmoCount + Ammo) > MaxAmmo)
        {
            AmmoCount = MaxAmmo;
            return;
        }
        AmmoCount += Ammo;
    }

    public void SetSpeed(int speedValue) => Speed = speedValue;
    public int GetSpeed() => Speed;


    // Health
    public void SetMaxHealth(int HealthValue) => MaxHealth = HealthValue;
    public int GetMaxHealth() => MaxHealth;
    public void RemoveHealth(int HealthToDec) => CurrentHealth -= HealthToDec;
    public int GetHealth() => CurrentHealth;
    public void SetHealth(int Health) => CurrentHealth = Health;

    public void AddHealth(int Health)
    {
    if((CurrentHealth + Health) > MaxHealth)
        {
            CurrentHealth = MaxHealth;
            return;
        }
        CurrentHealth += Health;
    }

    public bool IsDead() => CurrentHealth < 1;

    public void ToggleSpecialWeapon() => SpecialWeaponActive = !SpecialWeaponActive;
    public bool GetSpecialWeaponState() => SpecialWeaponActive;

    //Damage

    public void SetBaseDamage(int NewBaseDamage) => baseDamage = NewBaseDamage;
    public int GetBaseDamage() => baseDamage;
    public int GetDamage() => baseDamage * DamageModifer;

    public void SetDamageModifer(int Modifer) => DamageModifer = Modifer;


}
