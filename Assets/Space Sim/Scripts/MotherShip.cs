using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MotherShip : MonoBehaviour
{
    [SerializeField] private Ship ship;
    [SerializeField] private Collider dockingBay;
    [SerializeField] private GameObject hologram1, hologram2;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider != ship) return;

        GameObject player = _collider.GetComponentInParent<Ship>().gameObject;
        player.transform.position = dockingBay.transform.position;
    }
}