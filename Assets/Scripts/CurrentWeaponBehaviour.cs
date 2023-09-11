using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeaponBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject currentWeapon;
    public GameObject weaponText, magazineText;
    public List<GameObject> weapons ,magazines;
    private bool onWeaponRange, onMagazineRange;
    private int controller;
    void Start()
    {
        currentWeapon = null;
        onWeaponRange = false;
        onMagazineRange = false;
    }

    private void OnTriggerStay(Collider other)
    {
        //onWeaponRange = true;
        if (other.gameObject.tag.Equals("weaponPickup")) 
        {
            Debug.Log("Entrou no alcance de uma arma");
            onWeaponRange = true;
            controller = gameObject.name[1];

        }
        if (other.gameObject.tag.Equals ("magazinePickup")) 
        {
            onMagazineRange = true;
            controller = gameObject.name[1];

        }
    }
    /*private void OnTriggerExit(Collider other)
    {
        onWeaponRange = false; 
        onMagazineRange = false;
    }*/
    

    // Update is called once per frame
    void Update()
    {
        if (onWeaponRange)
            {

                weaponText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    changeWeapon(weapons[controller]);
                }
        }
        else
        {
            weaponText.SetActive(false);
        }
        if (onWeaponRange == false && onMagazineRange)
        {
            magazineText.SetActive(true);
        }
        else
        {
            magazineText.SetActive(false);
        }        
       
    }
    void changeWeapon(GameObject weapon)
    {
        if(currentWeapon != null)
        {
            Destroy(currentWeapon);
            currentWeapon = Instantiate(weapon, transform.position, transform.rotation);
        }
    }
}

