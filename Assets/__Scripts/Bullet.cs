using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private static Transform bulletAnchor;
    private static Transform BulletAchor
    {
        get
        {
            if (bulletAnchor == null)
            {
                bulletAnchor = new GameObject("Bullet Anchor").transform;
            }

            return bulletAnchor;

        }
    }

    [SerializeField] private float bulletSpeed;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        transform.parent = BulletAchor;

        GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
}