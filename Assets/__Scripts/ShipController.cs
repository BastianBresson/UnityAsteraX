using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float shipSpeed;

    private new Rigidbody rigidbody;

    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        
        HandleFire();
    }

    private void HandleMovement()
    {
        var horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        var vertical = CrossPlatformInputManager.GetAxis("Vertical");

        var direction = new Vector3(horizontal, vertical);

        // If both axis are 1 the magnitude would be higher than one
        if (direction.magnitude > 1f)
        {
            direction.Normalize();
        }

        rigidbody.velocity = direction * shipSpeed;
    }



    private void HandleFire()
    {
        var isFiring = CrossPlatformInputManager.GetButtonDown("Fire1");

        if (!isFiring) return;

        Instantiate(bullet, muzzle.transform.position, muzzle.rotation);
    }
}