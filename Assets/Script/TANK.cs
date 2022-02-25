using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TANK : BaseController
{
    public float moveSpeed;
    public float rotateSpeed;
    private bool delay = true;


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0,0,1*moveSpeed*Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0,0,-1*moveSpeed*Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0,-1*rotateSpeed*Time.deltaTime,0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0,1*rotateSpeed*Time.deltaTime,0));
        }
        
        
        
       GetMouseclic(); 
       followerCursorTank();
    }

    
    
    private void followerCursorTank()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            headDirection = new Vector3(hit.point.x, headTransform.position.y, hit.point.z);
            headTransform.forward = Vector3.Normalize(headDirection - headTransform.position);
            
        }
    }

    private void GetMouseclic()
    {
        
        if (Input.GetKey(KeyCode.Mouse0) && delay == true)
        {
            StartCoroutine(DebitBullet());
        }
        
        
    }

    private IEnumerator DebitBullet(float time=1f)
    {
        delay = false;
        yield return new WaitForSeconds(time);
        fire();
        delay = true;
    }
    
    private void fire()
    {
        Rigidbody rb;
        float fireForce = 1000f;

            
        GameObject bullet = Instantiate(projectilePrefab,projectileSpawnPoint.position,Quaternion.identity);
        rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(projectileSpawnPoint.up*fireForce);
            
        Debug.Log("fire!");
    }
}
