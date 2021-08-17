using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorDirection : MonoBehaviour
{
    private float vec;
    private float previousVec = 0;
    private bool facingRight;
    private Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        CursorDirection();
    }
    void CursorDirection()
    {
        vec = transform.position.x;
        if (vec > previousVec)
        {
            facingRight = true;
        }
        else if (vec < previousVec)
        {
            facingRight = false;
        }
        //Change the direction if the current localScale and direction do not match. The velocity of the x direction must be greater than 0 as well
        if (((facingRight) && (localScale.x < 0) && (vec != 0)) || ((!facingRight) && (localScale.x > 0) && (vec != 0)))
        {
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        previousVec = vec;
    }
}
