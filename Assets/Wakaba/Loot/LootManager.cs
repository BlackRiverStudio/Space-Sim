using System.Collections.Generic;
using UnityEngine;
namespace Wakaba.Loot
{
    public class LootManager : MonoSingleton<LootManager>
    {
        [SerializeField] private List<LootTable> tables = new List<LootTable>();

        private void Awake()
        {
            CreateInstance();
            FlagAsPersistant();

            tables.ForEach((table) => table.GenerateTable()); // C: this guy is a function without being a function. thanks lambda
        }
    }
}