using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBasic : MonoBehaviour
{
    //private float maxHeigth = 3;
    //private float minHeigth = 1;
    //private float positionY = 0.27f;
    private float positionX = 0.0f;
    private float positionZ = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 45, 10) * Time.deltaTime);
    }

    private void FixedUpdate()
    {
       
    }
}
