using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PShipMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotateSpeed = 200f;
    float offSetAngle = -90f;
    public float speedBoostMultiplier = 2f;
    private bool isSpeedBoostActive = false;
   // float shipBoundaryRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSpeedBoostActive = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSpeedBoostActive = false;
        }

        float currentMoveSpeed = maxSpeed;
        if (isSpeedBoostActive)
        {
            currentMoveSpeed *= speedBoostMultiplier;
        }
        Vector3 pos = transform.position;
       Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       Vector3 direction = mousePosition - transform.position;
        pos.y += Input.GetAxis("Vertical") * currentMoveSpeed * Time.deltaTime;
        pos.x += Input.GetAxis("Horizontal") * currentMoveSpeed * Time.deltaTime;

        //24.5 Y 37.5 X
        if(pos.y > 24.5f)
        {
            pos.y = 24.5f;
        }
        if(pos.y < -24.5f)
        {
            pos.y = -24.5f;
        }
        if (pos.x > 37.5f)
        {
            pos.x = 37.5f;
        }
        if (pos.x < -37.5f)
        {
            pos.x = -37.5f;
        }
        transform.position = pos;
        
       
      

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offSetAngle;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
}
