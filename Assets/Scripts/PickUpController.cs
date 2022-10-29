using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    //private float maxHeigth = 3;
    //private float minHeigth = 1;
    //private float positionY = 0.27f;
    private float positionX = 0.0f;
    private float positionZ = 0.0f;
    private bool goUP = true;
    // Start is called before the first frame update
    void Start()
    {
        positionX = transform.position.x;
        positionZ = transform.position.z;

        //comenzar en una altura aleatoria
        transform.position = new Vector3(positionX, Random.Range(0.5f,2f), positionZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15,45,10) * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (goUP)
        {
            transform.position = transform.position + new Vector3(0, 0.02f, 0);

            if (this.gameObject.transform.position.y > 1.5) goUP = false;
        }
        else 
        {
            transform.position = transform.position - new Vector3(0, 0.02f, 0);
            if(this.gameObject.transform.position.y < 0.7f)  goUP = true;
        }
    }
}
