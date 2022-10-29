using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedInMoveController : MonoBehaviour
{
    private bool MoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + new Vector3(Random.Range(-10f,10f), 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (MoveDirection)
        {
            transform.position = transform.position + new Vector3(0.2f, 0, 0);

            if (this.gameObject.transform.position.x > 9.8f) MoveDirection = false;
        }
        else
        {
            transform.position = transform.position - new Vector3(0.2f, 0f, 0);
            if (this.gameObject.transform.position.x < -9.8f) MoveDirection = true;
        }
    }
}
