using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TiltWithVelocity : MonoBehaviour
{
    [SerializeField] private float tiltMultiplier;

    private new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        HandleTilt(rigidbody.velocity);
    }

    private void HandleTilt(Vector3 direction)
    {
        var directionalRotation = new Vector3(direction.y, -direction.x);

        transform.eulerAngles = directionalRotation * tiltMultiplier;
    }
}
