using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D RigBody;

    int dir = -1; // Defaults to one
    public int Damage = 1;
    public int speed = 6;
    PuppetMaster PuppetMaster;


    private void Awake()
    {
        RigBody = GetComponent<Rigidbody2D>();
        PuppetMaster = GameObject.Find("EventSystem").GetComponent<PuppetMaster>();

    }

    public void ReverseDir()
    {

        dir *= -1;
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        RigBody.velocity = new Vector2(0, speed * dir);
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {



        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collision");
            PuppetMaster.PlayerTakeDamage(Damage);
            Die();
            return;

        }

        if (collision.gameObject.CompareTag("EnemyDeath"))
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
