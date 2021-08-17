using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Location : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;
    }
}
