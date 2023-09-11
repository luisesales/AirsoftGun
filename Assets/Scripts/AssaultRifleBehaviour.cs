using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float BackspinForce, FireRateSeconds;
    private GameObject bb;
    private float LastShotTime = 0.0f;
    private int counter = 0;
    [SerializeField] private GameObject bbPrefab, bbSpawner;
    void Start()
    {
        LastShotTime = 1.0f / FireRateSeconds;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= LastShotTime)
            {
                shootBB();
                LastShotTime = Time.time + 1.0f / FireRateSeconds;
                counter++;
                //limit = Time.time;
            }
            /*if (limit >= 1f)
            {
                Debug.Log("Bullets : " + counter.ToString());
                Debug.Log("Time: " + Time.time.ToString());
                counter = 0;                
            }*/
        }
        



        }
        void shootBB()
        {
            bb = Instantiate(bbPrefab, bbSpawner.transform.position, transform.rotation);
            bb.GetComponent<bbBehaviour>().shootBB(BackspinForce);
        }
    }
