using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private Vector3 offfset;
    private void Awake()
    {
        offfset = transform.position - target.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = target.position + offfset;
    }
 
}
