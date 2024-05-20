using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombBoxScript : MonoBehaviour
{
    public Transform bombTransform;
    
    void Update()
    {
        if(bombTransform.position.y < -5.85f)
        {
            bombTransform.position = new Vector2(bombTransform.position.x, 5.85f);
        }
        if(bombTransform.position.y > 5.85f)
        {
            bombTransform.position = new Vector2(bombTransform.position.x, -5.85f);
        }
        if(bombTransform.position.x < -9.8f)
        {
            bombTransform.position = new Vector2(9.8f, bombTransform.position.y);
        }
        if(bombTransform.position.x > 9.8f)
        {
            bombTransform.position = new Vector2(-9.8f, bombTransform.position.y);
        }
    }
}
