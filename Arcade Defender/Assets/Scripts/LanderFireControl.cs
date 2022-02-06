using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LanderFireControl : MonoBehaviour
{
    public Action _onShipFired;

    IEnumerator Start()
    {
        var t = 0f;//desstroying fire after 4 seconds
        while (t < 4f)
        {
            t += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _onShipFired?.Invoke();//Destroy player ship
        }
        
    }
  
}
