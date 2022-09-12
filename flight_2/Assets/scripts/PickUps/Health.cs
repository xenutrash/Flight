using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    Rigidbody2D RigBody;
    public int HealthGain = 2;
    public int AliveTimeMax = 400;
    private int AliveTime = 0;
    public PuppetMaster PuppetMaster;


    // Start is called before the first frame update
    void Awake()
    {
        RigBody = GetComponent<Rigidbody2D>();
        PuppetMaster = GameObject.Find("EventSystem").GetComponent<PuppetMaster>();

    }


    // Auto destorys the object once the timer reaches max
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
            PuppetMaster.PlayerAddHealth(1);
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
