using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
        public GameObject[] weapons;
        private int currentWeaponIndex = 0;
        private GameObject currentWeaponObject;
    private GameObject currentShipObject;

  //  private void Start()
  //  {
        // Instantiate the first weapon and attach it to the player ship
  //      currentWeaponObject = Instantiate(weapons[currentWeaponIndex], transform.position, transform.rotation);
    //    currentWeaponObject.transform.parent = transform;
   // }

    private void Update()
    {
         
             if (Input.GetKeyDown(KeyCode.R))
            {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;

            // Destroy the current weapon object
            Destroy(currentWeaponObject);

            // Instantiate the new weapon and attach it to the current ship object
            currentWeaponObject = Instantiate(weapons[currentWeaponIndex], currentShipObject.transform.position, currentShipObject.transform.rotation);
            currentWeaponObject.transform.parent = currentShipObject.transform;
          
        }
    }

    public void SetCurrentShipObject(GameObject shipObject)
    {
        currentShipObject = shipObject;
    }

        public void SwitchWeapon(int index)
        {
            if (index < 0 || index >= weapons.Length) return;

        Destroy(currentWeaponObject);

        // Instantiate the new weapon and attach it to the player ship
        currentWeaponIndex = index;
        currentWeaponObject = Instantiate(weapons[currentWeaponIndex], currentShipObject.transform.position, currentShipObject.transform.rotation, currentShipObject.transform);
        currentWeaponObject.transform.parent = transform;
    }
  }
