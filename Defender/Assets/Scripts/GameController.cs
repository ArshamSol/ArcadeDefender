using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private ScrollingObject spaceParaentScrolling;
    [SerializeField] private ShipController ship;
    private ShipController.shipSpeedStates relativeScrolling;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        relativeScrolling = ship.getRelativeScrollingSpeed();
        spaceParaentScrolling.setVelocity((int)relativeScrolling);
    }
}
