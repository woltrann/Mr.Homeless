using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    public CharacterStats stats;
    public PurchaseItemData[] allItems;

    public bool IsPurchased(PurchaseItemData item)
    {
        return PlayerPrefs.GetInt(GetKey(item), 0) == 1;
    }

    public void TryPurchase(PurchaseItemData item)
    {
        if (IsPurchased(item))
        {
            Debug.Log("Bu item zaten satýn alýndý");
            return;
        }

        if (stats.money < item.price)
        {
            Debug.Log("Yetersiz para");
            return;
        }

        stats.AddMoney(-item.price);
        ApplyItemEffect(item);

        // SATIN ALINDI OLARAK KAYDET
        PlayerPrefs.SetInt(GetKey(item), 1);
        PlayerPrefs.Save();
    }

    private void ApplyItemEffect(PurchaseItemData item)
    {
        switch (item.statType)
        {
            case ItemStatType.MaxEnergy:
                stats.IncreaseMaxEnergy(item.statAmount);
                break;

            case ItemStatType.MaxHunger:
                stats.IncreaseMaxHunger(item.statAmount);
                break;

            case ItemStatType.Power:
                stats.IncreasePower(item.statAmount);
                break;

            case ItemStatType.Intellegent:
                stats.IncreaseIntellegent(item.statAmount);
                break;
            case ItemStatType.MoneyBonus:
                stats.IncreaseMoneyX(item.statAmount);
                break;
        }

        stats.UpdateUI();
    }

    private string GetKey(PurchaseItemData item)
    {
        return "PURCHASED_" + item.itemID;
    }
    public string GetItemName(string itemID)
    {
        foreach (var item in allItems)
        {
            if (item.itemID == itemID)
                return item.itemName;
        }
        return itemID;
    }
    public bool HasItem(string itemID)
    {
        return PlayerPrefs.GetInt("PURCHASED_" + itemID, 0) == 1;
    }
}
