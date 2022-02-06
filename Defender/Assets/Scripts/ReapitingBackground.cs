using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapitingBackground : MonoBehaviour
{
    private BoxCollider2D spaceCollider;
    private float spaceHorizontalLength;
    // Start is called before the first frame update
    void Start()
    {
        spaceCollider = GetComponent<BoxCollider2D>();
        spaceHorizontalLength = spaceCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -spaceHorizontalLength)
        {
            reposiotionBackground();
        }
    }

    private void reposiotionBackground()
    {
        Vector2 spaceOffset = new Vector2(spaceHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + spaceOffset;

    }
}
