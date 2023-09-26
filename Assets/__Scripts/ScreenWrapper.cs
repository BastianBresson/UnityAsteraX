using System;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    private Camera main;

    private void Awake()
    {
        main = Camera.main;
    }
    
    private void OnTriggerExit(Collider other)
    {
        var position = transform.position;
        
        Vector3 viewportPosition = main.WorldToViewportPoint(position);
        Vector3 newPosition = position;
        
        if (viewportPosition.x > 1 || viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x;
        }
        if (viewportPosition.y > 1 || viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y;
        }
        
        transform.position = newPosition;
    }
}
