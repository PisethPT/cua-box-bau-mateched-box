using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndScale : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("dices"))
        {
            
        }
    }
}
