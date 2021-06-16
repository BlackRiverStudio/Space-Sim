using UnityEngine;
[RequireComponent(typeof(Light))]
public class LightNet : MonoBehaviour
{
    private void Awake() => GetComponent<Light>().enabled = false;
}