using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    GameObject gun1, gun2;
    Rigidbody2D RigBody;
    public GameObject pew;
    public GameObject missle;

    int delay = 0;
    public int DelayTarget = 10;
    public KeyCode shoot = KeyCode.Space;
    public KeyCode shiftWeapon = KeyCode.LeftShift;
    public PuppetMaster PuppetMaster;
  


    void Awake() {
        RigBody = GetComponent<Rigidbody2D>();
        PuppetMaster.InitPlayer();
        gun1 = transform.Find("gun1").gameObject;
        gun2 = transform.Find("gun2").gameObject;
    }



    public Vector3 GetCordinates()
    {
        return RigBody.transform.position;
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        RigBody.AddForce(new Vector2(Input.GetAxis("Horizontal")*PuppetMaster.PlayerGetSpeed(), 0));
        RigBody.AddForce(new Vector2(0,Input.GetAxis("Vertical") *PuppetMaster.PlayerGetSpeed()));

        if (PuppetMaster.PlayerIsDead())
        {
            Debug.Log("Player has died");
            PuppetMaster.EndGame();
            Die();
        }

        if (PuppetMaster.PlayerGetSpecialWeaponState() && PuppetMaster.PlayerGetAmmo() < 1)
        {
            PuppetMaster.PlayerToggleSpecialWeapon();
        }

        if (Input.GetKey(shoot) && delay >= DelayTarget)
        {
            FireGuns();
        }
       
        delay++;
    }


 


    //Prevents movement keys from blocking input
    private void Update()
    {
        if (Input.GetKeyDown(shiftWeapon))
        {
            PuppetMaster.PlayerToggleSpecialWeapon();
        }
    }

    void FireGuns()
    {
        delay = 0;

        if(PuppetMaster.PlayerGetSpecialWeaponState() && PuppetMaster.PlayerGetAmmo() > 0)
        {
            Instantiate(missle, gun1.transform.position, Quaternion.identity);
            Instantiate(missle, gun2.transform.position, Quaternion.identity);
            PuppetMaster.PlayerDecAmmo(1);
            return;
        }
        Instantiate(pew, gun1.transform.position, Quaternion.identity);
        Instantiate(pew, gun2.transform.position, Quaternion.identity);
        
    }

    void Die()
    {
        Destroy(gameObject);

    }


}
