using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [Range(-1, 1)] public float pitch;
    [Range(-1, 1)] public float yaw;
    [Range(-1, 1)] public float roll;
    [Range(-1, 1)] public float strafe;
    [Range(0, 1)] public float throttle;

    [SerializeField, Tooltip("Rate of acceleration.")] private float throttleSpeed = 0.5f;
    [SerializeField, Tooltip("Bank angle acceleration.")] private float rollSpeed = 5f;

    private void Update()
    {
        strafe = Input.GetAxis("Horizontal");
        SetDirectionsUsingMouse();

        UpdateKeyboardRoll(KeyCode.Q, KeyCode.E);
        UpdateKeyboardThrottle(KeyCode.UpArrow, KeyCode.DownArrow);
        UpdateMouseWheelThrottle();
    }
    #region Uncormfortable, but working, Controls
    private void SetDirectionsUsingMouse() // <- aka not how real planes. bank angle and rudder displacement are swapped
    {
        Vector3 mousePos = Input.mousePosition;

        pitch = (mousePos.y - (Screen.height * 0.5f)) / (Screen.height * 0.5f);
        yaw = (mousePos.x - (Screen.width * 0.5f)) / (Screen.height * 0.5f);

        pitch = -Mathf.Clamp(pitch, -1f, 1f);
        yaw = Mathf.Clamp(yaw, -1f, 1f);
    }

    private void UpdateKeyboardRoll(KeyCode _increase, KeyCode _decrease)
    {
        float target = 0;

        if (Input.GetKey(_increase)) target = 1;
        else if (Input.GetKey(_decrease)) target = -1;

        roll = Mathf.MoveTowards(roll, target, Time.deltaTime * rollSpeed);
    }
    #endregion
    #region Revised Controls
    private void SetStickCommandsUsingMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        pitch = (mousePos.y - (Screen.height * 0.5f)) / (Screen.height * 0.5f);
        pitch = -Mathf.Clamp(pitch, -1f, 1f);

        
    }
    #endregion
    #region Throttle
    private void UpdateKeyboardThrottle(KeyCode _increase, KeyCode _decrease)
    {
        float target = throttle;

        if (Input.GetKey(_increase)) target = 1;
        else if (Input.GetKey(_decrease)) target = 0;

        throttle = Mathf.MoveTowards(throttle, target, Time.deltaTime * throttleSpeed);
    }

    private void UpdateMouseWheelThrottle()
    {
        throttle += Input.GetAxis("Mouse ScrollWheel");
        throttle = Mathf.Clamp01(throttle);
    }
  #endregion
}