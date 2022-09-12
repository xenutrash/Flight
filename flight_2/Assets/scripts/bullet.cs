using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Bullet :  ProjectileBase
{
  
    private void Awake()
    {
        RigBody = GetComponent<Rigidbody2D>();
        PuppetMaster = GameObject.Find("EventSystem").GetComponent<PuppetMaster>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RigBody.velocity = new Vector2(0, Speed * dir);
    }
    
     public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy collision");
            collision.gameObject.GetComponent<Enemy>().TakeDamage(PuppetMaster.PlayerGetDamage());
            Die();
            return;
        }

        if(collision.gameObject.CompareTag("Bounds"))
        {
            Die();
        }
    }

}
