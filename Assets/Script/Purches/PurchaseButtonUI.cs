using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButtonUI : MonoBehaviour
{
    public TMP_Text itemNameText;
    public TMP_Text statText;
    public TMP_Text priceText;
    public Image itemIcon;
    public Button button;

    private PurchaseItemData itemData;
    private PurchaseManager purchaseManager;
    public TMP_Text rentalDayText;

    public void Setup(PurchaseItemData data, PurchaseManager manager)
    {
        itemData = data;
        purchaseManager = manager;

        itemNameText.text = data.itemName;
        itemIcon.sprite = data.itemIcon;
        statText.text = GetStatText(data);

        if (purchaseManager.IsPurchased(data))
        {
            SetPurchasedState();
        }
        else
        {
            priceText.text = data.price + "$";
            button.onClick.AddListener(OnClick);
        }
        if (purchaseManager.IsPurchased(data))
        {
            if (data.purchaseType == PurchaseType.Rental)
            {
                int endDay = PlayerPrefs.GetInt("RENT_END_" + data.itemID);
                int currentDay = CharacterStats.Instance.day;
                int dayLeft = Mathf.Max(0, endDay - currentDay);

                rentalDayText.text = $"Kalan Gün: {dayLeft}";
                rentalDayText.gameObject.SetActive(true);

            }
            else
            {
                rentalDayText.gameObject.SetActive(false);
            }

            SetPurchasedState();
        }

    }

    private void OnClick()
    {
        bool success = purchaseManager.TryPurchase(itemData);

        if (success)
        {
            purchaseManager.purchaseUIBuilder.RebuildUI();
            SetPurchasedState();
        }
    }

    private void SetPurchasedState()
    {
        priceText.text = "Satýn Alýndý";
        button.interactable = false;
    }

    private string GetStatText(PurchaseItemData data)
    {
        return data.statType switch
        {
            ItemStatType.MaxEnergy => $"+{data.statAmount} Max Enerji",
            ItemStatType.MaxHunger => $"+{data.statAmount} Max Açlýk",
            ItemStatType.Power => $"+{data.statAmount} Güç",
            ItemStatType.Intellegent => $"+{data.statAmount} Zeka",
            ItemStatType.MoneyBonus => $"+{data.statAmount} Para Bonusu",
            _ => ""
        };
    }
}
