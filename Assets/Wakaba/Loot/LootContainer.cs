using System.Collections.Generic;
using UnityEngine;
namespace Wakaba.Loot
{
    public class LootContainer : MonoBehaviour
    {
        [SerializeField] protected LootTable lootTable;
        [SerializeField, Range(0, 17)] private int lootCount = 5;

        protected List<Lootable> contents = new List<Lootable>();

        protected virtual void Start() => lootTable.FillContents(ref contents, lootCount);
    }
}