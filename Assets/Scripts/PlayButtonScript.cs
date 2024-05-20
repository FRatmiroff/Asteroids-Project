using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButtonScript : MonoBehaviour
{
    public RectTransform buttonTransform;
    public Rigidbody2D buttonRB;

    void Start()
    {
        int rand = Random.Range(1, 3);
        int rand2 = Random.Range(1, 3);
        int neg = 1;
        int neg2 = 1;
        if(rand == 1)
        {
            neg = 1;
        }
        else if(rand == 2)
        {
            neg = -1;
        }
        if(rand2 == 1)
        {
            neg2 = 1;
        } 
        else if(rand2 == 2)
        {
            neg2 = -1;
        }

        buttonRB = gameObject.GetComponent<Rigidbody2D>();
        buttonRB.AddForce(new Vector2(Random.Range(100f, 200f) * neg, Random.Range(100f, 200f) * neg2), ForceMode2D.Impulse);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Asteroids");
    }
}
