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
    }

    private void OnClick()
    {
        purchaseManager.TryPurchase(itemData);
        SetPurchasedState();
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
            ItemStatType.Intellegent => $"+{data.statAmount} Ün",
            _ => ""
        };
    }
}
