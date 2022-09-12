using System.Collections;
using System.Collections.Generic;
using UnityEngine;




 public class ProjectileBase : MonoBehaviour
{

 

    public Rigidbody2D RigBody;
    public int dir;
    public PuppetMaster PuppetMaster;
    public int Speed = 6;
    public void ReverseDir() => dir *= -1;
    public void Die()=> Destroy(gameObject);

    private void Awake()
    {
        RigBody = GetComponent<Rigidbody2D>();
        PuppetMaster = GameObject.Find("EventSystem").GetComponent<PuppetMaster>();
    }

}
