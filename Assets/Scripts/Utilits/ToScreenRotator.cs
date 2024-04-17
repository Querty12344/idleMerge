using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class ToScreenRotator : MonoBehaviour
{
    private Transform camera;
    
    private void Start()
    {
        camera = Camera.main.transform;
        transform.SetParent(null);
    }
    private void Update()
    {
        Vector3 direction = (camera.position - transform.position).normalized;
        direction.x = 0;
        transform.forward = -direction;
        transform.localScale = new Vector3(1, 1, 1);
    }
}
