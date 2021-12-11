using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_FallReset : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 normPos = Camera.main.WorldToViewportPoint(pos);
        if (normPos.y < 0)
        {
            transform.position += new Vector3(0, 12, 0);
        }
    }
}
