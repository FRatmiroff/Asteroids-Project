using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoScript : MonoBehaviour
{
    public Transform ammoTransform;
    
    void Update()
    {
        if(ammoTransform.position.y < -5.85f)
        {
            ammoTransform.position = new Vector2(ammoTransform.position.x, 5.85f);
        }
        if(ammoTransform.position.y > 5.85f)
        {
            ammoTransform.position = new Vector2(ammoTransform.position.x, -5.85f);
        }
        if(ammoTransform.position.x < -9.8f)
        {
            ammoTransform.position = new Vector2(9.8f, ammoTransform.position.y);
        }
        if(ammoTransform.position.x > 9.8f)
        {
            ammoTransform.position = new Vector2(-9.8f, ammoTransform.position.y);
        }
    }
}
