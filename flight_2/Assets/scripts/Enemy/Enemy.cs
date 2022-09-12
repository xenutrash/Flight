using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    Rigidbody2D RigBody;

    public float Xspeed;
    public float Yspeed;
    public bool canUseRanged = true;
    public float RateOfFire = 40;
    public float health = 5;
    public int BaseDamage = 1;
    public int ColliderMultiplier = 1;
    public int droprate = 80;
    public GameObject HelathPickUp;
    public GameObject AmmoPickUp;
    public int DropType = 0; //0 = health, 1 = ammo
    public GameObject Projectile;
    public bool Chaser = false;
    public PuppetMaster PuppetMaster; 
    int FireTimer = 0;
    public int KillScore = 20;
    private int XMoveDir = 1;

    

    void Awake()
    {

        if (Random.Range(0, 2) == 1)
        {
            ReverseXDir();

        }

        RigBody = GetComponent<Rigidbody2D>();
        //Attatches the object to Masterscript
        PuppetMaster = GameObject.Find("EventSystem").GetComponent<PuppetMaster>();
        //If the values are left as 0 or lower, they will automaticlly bet set to 1
        if (ColliderMultiplier <= 0)
        {
            Debug.Log("ColliderMultiplier was set to a value bellow 0");
            ColliderMultiplier = 1;
        }
        if (BaseDamage == 0)
        {
            Debug.Log("BaseDamage was set to 0");
            BaseDamage = 1;
           
        }

        if(KillScore < 0)
        {
            KillScore = 0;
        }

        //Makes the firerate "random"
        FireTimer = (int)Random.Range(0,RateOfFire);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTarget();
        if (canUseRanged)
        {
            FireGuns();
            
      
        }
    }





    void MoveTarget()
    {
        if (Chaser)
        { 
            return;
        }
            RigBody.velocity = new Vector2(Xspeed * XMoveDir, Yspeed * -1);
    }



    void ReverseXDir() => XMoveDir *= -1;


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided");
        if (collision.gameObject.CompareTag("Player"))
        {
            PuppetMaster.PlayerTakeDamage(BaseDamage*ColliderMultiplier);
            Die();

        }


        if (collision.gameObject.CompareTag("EnemyDeath"))
        {
            Debug.Log("Reached the end");
            Die();
        }

        if (collision.gameObject.CompareTag("Bounce"))
        {
            ReverseXDir();
        }

    }


    void FireGuns()
    {

        if(FireTimer >= RateOfFire)
        {
            Instantiate(Projectile, transform.position, Quaternion.identity);
            FireTimer = 0;
            return;
        }

        FireTimer++;


    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int Damage)
    {
        Debug.Log("Enemy has taken damage: " + Damage);
        //Allows enemies to deal different amounts of damage 
        health -= Damage;
        Debug.Log("Health left: " + health);

        //Negative damage = instant death 
        if (health < 1 || Damage < 0)
        {
            Debug.Log("Enemy has died");
            try
            {
                PuppetMaster.ScoreAdd(KillScore);

            }
            catch
            {
                Debug.Log("Score broke");
            }
            

            if (DropType < 2 && Random.Range(1, 100) >= droprate) {
                if(DropType == 0)
                {
                    Instantiate(HelathPickUp, RigBody.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(AmmoPickUp, RigBody.transform.position, Quaternion.identity);
                }
                
            }

            Die();

        }

    }


}
