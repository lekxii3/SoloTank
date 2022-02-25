using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TURRETS : BaseController
{
   public Transform tankTransform;
   public float detectionDistance;
   private bool _isTankDetected;
   public float timeBeforeFire;
   private float _timer;
   
   

   private void FixedUpdate()
   {
      isTankDetected();

    
   }

   private void isTankDetected()
   {
      RaycastHit hit;
      Vector3 direction = tankTransform.position - headTransform.position;
      
      if (Physics.Raycast(headTransform.position, direction, out hit, detectionDistance));
      {
         //headTransform.Rotate(new Vector3(hit.point.x, headTransform.position.y, hit.point.z));
         headTransform.forward = new Vector3(tankTransform.position.x,tankTransform.position.y,tankTransform.position.z);
         
         if (hit.collider.gameObject.GetComponentInParent<TANK>() != null && !_isTankDetected)
         {
            
            Debug.DrawRay(headTransform.position,direction,Color.green,1f);

            StartCoroutine(DebitBullet());
            
         }
      }
   }

   private IEnumerator DebitBullet()
   {
      _isTankDetected = true;
      yield return new WaitForSeconds(timeBeforeFire);
      Fire();
      _isTankDetected = false;
   }

   private void Fire()
   {
      Rigidbody rb;
      float fireForce = 1000f;
            
      GameObject bullet = Instantiate(projectilePrefab,projectileSpawnPoint.position,Quaternion.identity);
      rb = bullet.GetComponent<Rigidbody>();
      rb.AddForce(projectileSpawnPoint.up*fireForce);
   }
}
