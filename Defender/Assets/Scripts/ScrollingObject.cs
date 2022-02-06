using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour//https://youtu.be/AyNhGthBFdg
{
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity =new Vector2(-1.5f,0);
    }

    public void setVelocity(int relativeSpeed)
    {
        if (relativeSpeed==0)
        {
            rb2d.velocity = new Vector2(0f, 0);
            
        }
        if (relativeSpeed == 1)
        {
            rb2d.velocity = new Vector2(-1.5f, 0);
            
        }
        if (relativeSpeed == 2)
        {
            rb2d.velocity = new Vector2(-5, 0);

        }


    }

    // Update is called once per frame
    void Update()
    {
        //Stop scrolling game over
    }
}
