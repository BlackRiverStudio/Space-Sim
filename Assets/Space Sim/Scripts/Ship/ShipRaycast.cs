using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRaycast : MonoBehaviour
{
    [SerializeField] private float rayDistance;
    [SerializeField] private Texture2D crosshair;

    private void Start()
    {
        SetCursorActive(false);
        if (rayDistance == 0) throw new System.NullReferenceException("Float 'Ray Distance' equals zero. Give it a value.");
    }

    private void SetCursorActive(bool isActive)
    {
        Cursor.SetCursor(isActive ? null : crosshair, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Confined;
    }

    private void Update()
    {
        SendRaycast(KeyCode.Mouse0);
    }

    private void SendRaycast(KeyCode _key)
    {
        if (Input.GetKey(_key))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red, 1.75f);
            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
            {
                try
                {
                    Minable minable = hit.collider.gameObject.GetComponent<Minable>();
                    minable.TestInJayServer(1);
                }
                catch (System.NullReferenceException e)
                {
                    Debug.LogError(e.Message);
                }
                catch (System.Exception e)
                {
                    Debug.LogWarning(e.Message);
                }
            }
        }
    }
}