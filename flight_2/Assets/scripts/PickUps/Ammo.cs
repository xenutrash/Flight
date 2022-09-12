using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    Rigidbody2D RigBody;
    public int AmmoGain = 10;
    public int AliveTimeMax = 400;
    private int AliveTime = 0;
    public PuppetMaster PuppetMaster;


    // Start is called before the first frame update
    void Awake()
    {
        RigBody = GetComponent<Rigidbody2D>();
        PuppetMaster = GameObject.Find("EventSystem").GetComponent<PuppetMaster>();

    }

    private void FixedUpdate()
    {

        if (AliveTime >= AliveTimeMax)
        {
            Die();
        }

        AliveTime++;
    }




    public void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collid");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("PickUp picked uped");
            PuppetMaster.PlayerIncAmmo(2);
            Die();
            return;

        }

        if (collision.gameObject.CompareTag("Bounds"))
        {

            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
