using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

        bulletRigidbody.velocity =transform.forward*speed;

        Destroy(gameObject, 3f);
    }
     

    // Update is called once per frame
    void Update()
    {
        
    }
}
