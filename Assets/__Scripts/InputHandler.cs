using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Transform shipCannon;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Bullet bullet;
    
    
    private Camera cameraMain;
    private Transform bulletAnchor;

    // Start is called before the first frame update
    private void Awake()
    {
        cameraMain = Camera.main;
        bulletAnchor = new GameObject("Bullet Anchor").transform;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        HandleLook();
        
        HandleFire();
    }

    private void HandleMovement()
    {
        var horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        var vertical = CrossPlatformInputManager.GetAxis("Vertical");

        var direction = new Vector3(horizontal, vertical);

        transform.position += direction * (10 * Time.deltaTime);
        
        HandleTilt(direction);
    }

    private void HandleTilt(Vector3 direction)
    {
        var directionalRotation= new Vector3(direction.y, -direction.x);
        
        transform.eulerAngles = directionalRotation * 15f;
    }

    private void HandleFire()
    {
       var isFiring = CrossPlatformInputManager.GetButtonDown("Fire1");

        if (!isFiring) return;

        Instantiate(bullet, muzzle.transform.position, muzzle.rotation, bulletAnchor);
    }
    
    private void HandleLook()
    {
        var mousePosition = Input.mousePosition;

        var lookAtPosition = cameraMain.ScreenToWorldPoint(mousePosition);
        lookAtPosition.z = shipCannon.position.z;
        
        shipCannon.LookAt(lookAtPosition, Vector3.back);
    }
}