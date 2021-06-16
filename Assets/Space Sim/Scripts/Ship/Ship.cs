using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ShipMovement), typeof(ShipPhysics), typeof(ShipRaycast))]
public class Ship : MonoBehaviour
{
    private ShipMovement movement;
    private ShipPhysics physics;
    private ShipRaycast raycast;

    private void Awake()
    {
        movement = GetComponent<ShipMovement>();
        physics = GetComponent<ShipPhysics>();
        raycast = GetComponent<ShipRaycast>();

        if (movement == null || physics == null || raycast == null) Debug.LogWarning("How.");
    }

    private void Start()
    {
        // Debug.LogWarning($"The ship has {physics}, and {movement}.");
    }

    private void Update()
    {
        physics.SetPhysicsInput(new Vector3(movement.strafe, 0, movement.throttle), new Vector3(movement.pitch, movement.yaw, movement.roll));
    }
}