using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        var transform1 = transform;
        
        transform1.position += transform1.forward * (20f * Time.deltaTime);
    }
}