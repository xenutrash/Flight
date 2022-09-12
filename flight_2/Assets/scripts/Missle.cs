using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileBase))]
public class Missle : MonoBehaviour
{

    Rigidbody2D RigBody;
    
    int dir = 1;
    public int speed = 12;
    public int BaseDamage = 2;
    PuppetMaster PuppetMaster;


    private void Awake()
    {
        RigBody = GetComponent<Rigidbody2D>();

        PuppetMaster = GameObject.Find("EventSystem").GetComponent<PuppetMaster>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RigBody.velocity = new Vector2(0, speed * dir);
    }

     public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided");


        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy collision");
            Debug.Log(PuppetMaster.PlayerGetDamage());
            collision.gameObject.GetComponent<Enemy>().TakeDamage(PuppetMaster.PlayerGetDamage() + BaseDamage);
            Die();
            return;

        }

        if(collision.gameObject.CompareTag("Bounds"))
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
