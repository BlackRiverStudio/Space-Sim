using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minable : MonoBehaviour
{
    public struct Element
    {
        public string name;
        public int weight;
        public float value;
    }
    public Element Hydrogen, Helium, Carbon, Neon, Oxygen, Silicon;
    private void Start()
    {
        Hydrogen.weight = 1;
          Helium.weight = 2;
          Carbon.weight = 6;
            Neon.weight = 10;
          Oxygen.weight = 8;
         Silicon.weight = 14;
    }

    public void TestInJayServer(int _element)
    {
        if (_element == 1) ReturnElementShutUpMonkey(Hydrogen);
        Spawner.pool.Despawn(this);
    }

    public void ReturnElementShutUpMonkey(Element _element)
    {
        Debug.Log("Look, Punk, it's " + _element.ToString());
    }
}