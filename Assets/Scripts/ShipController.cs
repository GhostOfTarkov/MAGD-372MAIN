using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameObject[] ships;
    private int currentShipIndex = 0;
    private Transform playerTransform;
    private GameObject currentWeapon;
    private GameObject currentActiveShip;

 //   private void Start()
 //   {
  //      playerTransform = transform.parent;
//
  //      Instantiate(ships[currentShipIndex], playerTransform.position, playerTransform.rotation, playerTransform.parent);
 //   }

    private void Update()
    {
        for (int i = 1; i <= 3; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                SwitchShip(i-1);
                break;
            }
        }
    }

    public void SwitchShip(int index)
    {
        if (index < 0 || index >= ships.Length) return;

       

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.gameObject.CompareTag("Ship"))
            {
                child.gameObject.SetActive(false);
            }
        }

        if (currentActiveShip != null)
        {
            Destroy(currentActiveShip);
        }

        Vector3 spawnPosition = transform.position;

        currentShipIndex = index;
        GameObject newShip = Instantiate(ships[currentShipIndex], spawnPosition, transform.rotation);
        newShip.transform.parent = transform;
        currentActiveShip = newShip;

        // Set the current ship object in the weapon controller
        WeaponController weaponController = GetComponent<WeaponController>();
        if (weaponController != null)
        {
            weaponController.SetCurrentShipObject(newShip);
        }

        // Re-attach the current weapon to the new ship (if there is one)
        if (currentWeapon != null)
        {
            currentWeapon.transform.parent = newShip.transform;
        }
                //camera follows new ship
        Camera.main.GetComponent<pointCamera>().myTarget = newShip.transform;
    }
}
