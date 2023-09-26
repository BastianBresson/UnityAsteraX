using UnityEngine;

public class PointAtMouse : MonoBehaviour
{
    private Camera cameraMain;
    private Vector3 lookAtPosition;

    private void Awake()
    {
        cameraMain = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Input.mousePosition;

        lookAtPosition = cameraMain.ScreenToWorldPoint(mousePosition);
        lookAtPosition.z = transform.position.z;

        transform.LookAt(lookAtPosition, Vector3.back);
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(lookAtPosition, .4f);
            Gizmos.DrawLine(transform.position, lookAtPosition);
        }
    }
}
