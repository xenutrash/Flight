using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(PlayerPuppet))]
[RequireComponent(typeof(UIPuppet))]
[RequireComponent(typeof(ScoreMaster))]

public class PuppetMaster : MonoBehaviour
{


    public PlayerPuppet Puppet;
    public UIPuppet UIPuppet;
    public ScoreMaster ScoreHandler;
    public int PlayerMaxHealth_initvalue;
    public int PlayerStartingAmmo_initvalue;
    private int Timer;
    public int PlayerStartingSpeed_value;
    public int PlayerStartingDamage_value;
    private bool BuffActive;
    public Text GameOver;
    

    // Player related systems

    //Health related relays
    public void PlayerTakeDamage(int Damage)
    {
        Puppet.RemoveHealth(Damage);
        UIPuppet.SetHealthValue(PlayerGetHealth());
     }

    public void PlayerSetHealth(int Health)
    {
        Puppet.SetHealth(Health);
        UIPuppet.SetHealthValue(PlayerGetHealth());
    }


    public void PlayerAddHealth(int HealthToAdd)
    {
        Puppet.AddHealth(HealthToAdd);
        UIPuppet.SetHealthValue(PlayerGetHealth());
    }

    public void PlayerSetMaxHealth(int MaxHealth)
    {
        Puppet.SetMaxHealth(MaxHealth);
        UIPuppet.UpdateHealthBarMax(MaxHealth);
    }

    public int PlayerGetMaxHealth() => Puppet.GetMaxHealth();
    public int PlayerGetHealth() => Puppet.GetHealth();


    //Ammo relays
    public int PlayerGetAmmo() => Puppet.GetAmmo();
    public int PlayerGetMaxAmmo() => Puppet.GetMaxAmmo();

    public void PlayerSetRawDamage(int NewRawDamage) => Puppet.SetBaseDamage(NewRawDamage);
    public int PlayerGetDamage() => Puppet.GetDamage();
    public int PlayerGetRawDamage() => Puppet.GetBaseDamage();
    public int PlayerGetDamageModifer() => Puppet.GetDamageModifer();

    public void PlayerDecAmmo(int DecValue) {
        Puppet.RemoveAmmo(DecValue);
        UIPuppet.SetAmmo(PlayerGetAmmoString());
     }

    public void PlayerSetAmmo(int AammoToSet)
    {
        Puppet.SetAmmo(AammoToSet);
        UIUpdateAmmoSprite();
    }

    public void PlayerIncAmmo(int ammo)
    {
        Puppet.AddAmmo(ammo);
        UIUpdateAmmoSprite();
    }

    public bool PlayerIsDead() => Puppet.IsDead();

    public void EndGame()
    {
        GameOver.gameObject.SetActive(true);

        Debug.Log("End game called");

    }


    public void PlayerSetMaxAmmo(int MaxAmmo) => Puppet.SetMaxAmmo(MaxAmmo);
    public string PlayerGetAmmoString() => PlayerGetAmmo() + "/" + PlayerGetMaxAmmo();

    public void PlayerSetSpeed(int SpeedValue) => Puppet.SetSpeed(SpeedValue);
    public int PlayerGetSpeed() => Puppet.GetSpeed();

    //Weapon realted
    public void PlayerToggleSpecialWeapon()
    {
        Puppet.ToggleSpecialWeapon();
        UIUpdateAmmoSprite();
    }
    public bool PlayerGetSpecialWeaponState() => Puppet.GetSpecialWeaponState();

    //Ui relays
    public void UIUpdateAmmoString() => UIPuppet.SetAmmo(PlayerGetAmmoString());
    public void UIUpdateAmmoSprite() => UIPuppet.UpdateSprite(PlayerGetAmmoString(), PlayerGetSpecialWeaponState());



    public int ScoreGet() => ScoreHandler.GetScore();

    public void ScoreAdd(int ScoreToAdd) => ScoreHandler.AddScore(ScoreToAdd);

    public void ScoreTextUpdate() => ScoreHandler.UpdateScoreText();
    public void ScoreReset() => ScoreHandler.ResetScore();



    public void InitPlayer()
    {

        if (PlayerMaxHealth_initvalue < 1)
        {
            Debug.Log("Init health failsafe");
            PlayerMaxHealth_initvalue = 5;
        }

        if (PlayerStartingAmmo_initvalue < 0)
        {
            Debug.Log("Starting ammo Failsafe");
            PlayerStartingAmmo_initvalue = 5;
        }

        if(PlayerStartingSpeed_value < 1)
        {
            Debug.Log("Speed Failsafe reached");
            PlayerStartingSpeed_value = 6;
        }

        if (PlayerStartingDamage_value < 1)
        {
            Debug.Log("Damage Failsafe reached");
            PlayerStartingDamage_value = 1;
        }

        PlayerSetRawDamage(PlayerStartingDamage_value);
        PlayerSetSpeed(PlayerStartingSpeed_value);
        PlayerSetMaxHealth(PlayerMaxHealth_initvalue);
        PlayerSetHealth(PlayerMaxHealth_initvalue);
        PlayerSetMaxAmmo(PlayerStartingAmmo_initvalue);
        PlayerSetAmmo(PlayerStartingAmmo_initvalue);
        UIUpdateAmmoSprite();
       
    }

    private void Awake()
    {
        GameOver.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void FixedUpdate()
    {

    }
}                      
