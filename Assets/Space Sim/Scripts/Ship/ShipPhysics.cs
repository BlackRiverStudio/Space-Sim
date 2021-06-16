using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ShipPhysics : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector3 linearForce = new Vector3(100, 100, 100);

    [SerializeField] private Vector3 angularForce = new Vector3(100, 100, 100);

    public float forceMultiplyer = 100f;

    private Vector3 appliedLinearForce = Vector3.zero;
    private Vector3 appliedAngularForce = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError($"{name} has no rigidbody, and ShipPhysics relys on it.", gameObject);
            return;
        }
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.AddRelativeForce(appliedLinearForce * forceMultiplyer, ForceMode.Force);
            rb.AddRelativeTorque(appliedAngularForce, ForceMode.Force);
        }
    }

    public void SetPhysicsInput(Vector3 _linearInput, Vector3 _angularInput)
    {
        appliedLinearForce = MultiplyByComponent(_linearInput, linearForce);
        appliedAngularForce = MultiplyByComponent(_angularInput, angularForce);
    }

    private Vector3 MultiplyByComponent(Vector3 _a, Vector3 _b)
    {
        Vector3 temp;
        temp.x = _a.x * _b.x;
        temp.y = _a.y * _b.y;
        temp.z = _a.z * _b.z;
        return temp;
    }
}