using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PurchaseItemList", menuName = "Shop/Purchase Item List")]
public class PurchaseItemList : ScriptableObject
{
    public List<PurchaseItemData> items = new List<PurchaseItemData>();
}
