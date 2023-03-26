using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private ShipController shipController;
    private WeaponController weaponController;
    // Start is called before the first frame update
    void Start()
    {
        shipController = GetComponent<ShipController>();
        weaponController = GetComponent<WeaponController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputShip();
        HandleInputWeapon();
    }

    void HandleInputShip()
    {
        for (int i = 1; i <= 3; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                shipController.SwitchShip(i - 1);
                break;
            }
        }
    }

    void HandleInputWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            weaponController.SwitchWeapon(weaponController.GetCurrentWeaponIndex() + 1);
        }
    }


}
