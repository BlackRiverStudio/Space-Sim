using UnityEngine;
namespace Wakaba.Loot
{
    // Data bank.
    [CreateAssetMenu(menuName = "Wakaba/Loot/Lootable", fileName = "NewLootable")]
    public class Lootable : ScriptableObject
    {
        [SerializeField] protected string itemName = "";
#pragma warning disable 0414
        [SerializeField, TextArea] private string description = "";
#pragma warning restore 0414
        [SerializeField] protected Sprite sprite;
    }
}