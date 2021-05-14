using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public static bool actived = false;
    public static bool activeAsteroid = false;
    
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag.Equals("Player") || collider2D.tag.Equals("FireBall"))
        {
            actived = true;
        }
    }
}
