using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatest : MonoBehaviour
{
    [SerializeField] Animator ani;
    public bool hit;
    private void Update()
    {
        if (hit == true)
        {
            hit = false;
            ani.SetTrigger("isHit");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) ani.SetTrigger("isHit");
    }
}
