using System.Collections;
using TMPro;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    public static PurchaseManager instance;

    public PurchaseUIBuilder purchaseUIBuilder;
    public CharacterStats stats;
    public PurchaseItemData[] allItems;

    public GameObject BildirimPaneli;
    public TextMeshProUGUI bildirimText;

    private void Awake()
    {
        instance = this;
    }
    public bool IsPurchased(PurchaseItemData item)
    {
        return PlayerPrefs.GetInt(GetKey(item), 0) == 1;
    }

    public bool TryPurchase(PurchaseItemData item)
    {
        if (IsPurchased(item))
            return false;

        if (stats.money < item.price)
        {
            bildirimText.text = "Yetersiz para";
            BildirimPaneli.SetActive(true);
            StartCoroutine(BildirimGosterVeKapat());
            return false;
        }

        stats.AddMoney(-item.price);
        ApplyItemEffect(item);

        PlayerPrefs.SetInt(GetKey(item), 1);

        // ⭐ KİRALIKSA BİTİŞ GÜNÜ KAYDET
        if (item.purchaseType == PurchaseType.Rental)
        {
            int endDay = stats.day + item.rentalDays;
            PlayerPrefs.SetInt(GetRentKey(item), endDay);
        }

        PlayerPrefs.Save();
        StatusUIManager.instance.RecalculateCategory(item.category);
        purchaseUIBuilder.RebuildUI();
        return true;
    }
    private string GetRentKey(PurchaseItemData item)
    {
        return "RENT_END_" + item.itemID;
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
    private void RemoveItemEffect(PurchaseItemData item)
    {
        switch (item.statType)
        {
            case ItemStatType.MaxEnergy:
                stats.IncreaseMaxEnergy(-item.statAmount);
                break;

            case ItemStatType.MaxHunger:
                stats.IncreaseMaxHunger(-item.statAmount);
                break;

            case ItemStatType.Power:
                stats.IncreasePower(-item.statAmount);
                break;

            case ItemStatType.Intellegent:
                stats.IncreaseIntellegent(-item.statAmount);
                break;

            case ItemStatType.MoneyBonus:
                stats.IncreaseMoneyX(-item.statAmount);
                break;
        }
    }
    public void CheckRentalExpirations()
    {
        bool anyExpired = false;

        foreach (var item in allItems)
        {
            if (item.purchaseType != PurchaseType.Rental)
                continue;

            if (!IsPurchased(item))
                continue;

            string endKey = GetRentKey(item);
            if (!PlayerPrefs.HasKey(endKey))
                continue;

            int endDay = PlayerPrefs.GetInt(endKey);
            int currentDay = stats.day;

            if (currentDay >= endDay)
            {
                // ❌ Kira bitti
                PlayerPrefs.DeleteKey(GetKey(item));
                PlayerPrefs.DeleteKey(endKey);

                RemoveItemEffect(item);
                if (item.category == PurchaseCategory.Housing)
                {
                    StatusUIManager.instance.RecalculateCategory(PurchaseCategory.Housing);
                }

                if (item.category == PurchaseCategory.Vehicle)
                {
                    StatusUIManager.instance.RecalculateCategory(PurchaseCategory.Vehicle);
                }

                if (item.category == PurchaseCategory.Education)
                {
                    StatusUIManager.instance.RecalculateCategory(PurchaseCategory.Education);
                }
                anyExpired = true;

                Debug.Log(item.itemName + " kiralama süresi bitti");


                bildirimText.text = "Kira sözleşmen bitti";
                BildirimPaneli.SetActive(true);
                StartCoroutine(BildirimGosterVeKapat());
            }
        }

        PlayerPrefs.Save();

        if (anyExpired)
        {
            stats.UpdateUI();
            purchaseUIBuilder.RebuildUI();
        }
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

    public IEnumerator BildirimGosterVeKapat()
    {
        yield return new WaitForSeconds(1f);
        BildirimPaneli.SetActive(false);
    }
}
