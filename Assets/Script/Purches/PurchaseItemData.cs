using UnityEngine;

public enum ItemStatType
{
    MaxEnergy,
    MaxHunger,
    Power,
    Intellegent,
    MoneyBonus
}

public enum PurchaseType
{
    Permanent,
    Rental
}
public enum PurchaseCategory
{
    Housing,
    Vehicle,
    Education,
    Other
}


[CreateAssetMenu(fileName = "PurchaseItem", menuName = "Shop/Purchase Item")]


public class PurchaseItemData : ScriptableObject
{
    [Header("ID")]
    public string itemID;   // Örn: "HOUSE_01", "WEAPON_01"

    [Header("Basic Info")]
    public string itemName;
    public Sprite itemIcon;
    public int price;

    [Header("Stat Effect")]
    public ItemStatType statType;
    public int statAmount;

    [Header("Purchase Type")]
    public PurchaseType purchaseType;
    public int rentalDays = 30; // sadece Rental için

    public PurchaseCategory category;
    public int level; // Seviye (1 = en düþük)


}
