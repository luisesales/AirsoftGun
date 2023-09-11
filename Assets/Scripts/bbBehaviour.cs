using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bbBehaviour : MonoBehaviour
{
    private float backspinForce = 0.001f;
    private Rigidbody rb;    
    private float destroyTime = 0f;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destroyTime+= Time.deltaTime;
        if(destroyTime >= 10f) Destroy(gameObject);
        //bulletTrail.GetComponent<LineRenderer>().SetPosition(1, transform.position);
        //Debug.Log(rb.velocity.magnitude);
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, rb.velocity.normalized, Color.green, 100, false);
        //Debug.Log(rb.velocity.magnitude);
        Vector3 magnusDirection = Vector3.Cross(rb.velocity, transform.right).normalized;

        Vector3 magnusForce = Mathf.Sqrt(rb.velocity.magnitude) * magnusDirection * backspinForce * Time.fixedDeltaTime;

        rb.AddForce(magnusForce);
    }
    public void shootBB(float gunBackspinForce)
    {
        backspinForce = gunBackspinForce;
        rb.AddForce(transform.forward * backspinForce);
        
    }   
}
