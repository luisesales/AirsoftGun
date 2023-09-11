using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float BackspinForce;
    private float bTimer = 0;
    private GameObject bb;
    [SerializeField] private GameObject bbPrefab, bbSpawner;
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bTimer > 0.3)
        {
            bTimer += Time.deltaTime;
            shootBB();
        }
        else bTimer = 0;

        
    }
    void shootBB()
    {
       bb = Instantiate(bbPrefab, bbSpawner.transform.position, transform.rotation );
       bb.GetComponent<bbBehaviour>().shootBB(BackspinForce);
    }
}
