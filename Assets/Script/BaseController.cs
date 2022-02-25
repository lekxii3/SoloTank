using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Transform headTransform;
    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    protected Vector3 headDirection;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

 
    void Update()
    {
        


    }
}
