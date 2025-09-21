using System.Numerics;
using UnityEngine;

public class floating : MonoBehaviour
{
    float waterlevel = 0f;
    float itemdepth = 0f;
    public float resistance = 1f;
    public float buoyancy = 1f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        itemdepth = transform.position.y - waterlevel; 
        //under water
        if (transform.position.y < waterlevel)
        {
            UnityEngine.Vector3 buoyanceforce = UnityEngine.Vector3.up * buoyancy * -itemdepth;
            rb.AddForce(buoyanceforce - rb.linearVelocity * resistance, ForceMode.Acceleration);
        }
    }
}
