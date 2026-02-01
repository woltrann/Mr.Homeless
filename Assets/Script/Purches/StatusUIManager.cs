using TMPro;
using UnityEngine;

public class StatusUIManager : MonoBehaviour
{
    public static StatusUIManager instance;

    public TMP_Text housingText;
    public TMP_Text vehicleText;
    public TMP_Text educationText;

    private void Awake()
    {
        instance = this;
        LoadTexts();
    }

    public void RecalculateCategory(PurchaseCategory category)
    {
        int maxLevel = 0;
        string bestName = "Yok";

        foreach (var item in PurchaseManager.instance.allItems)
        {
            if (item.category != category)
                continue;

            if (!PurchaseManager.instance.IsPurchased(item))
                continue;

            if (item.level > maxLevel)
            {
                maxLevel = item.level;
                bestName = item.itemName;
            }
        }

        switch (category)
        {
            case PurchaseCategory.Education:
                educationText.text = "Eğitim: " + bestName + "din";
                PlayerPrefs.SetString("EDUCATION_TEXT", educationText.text);
                break;

            case PurchaseCategory.Housing:
                housingText.text = "Barınma: " + bestName;
                PlayerPrefs.SetString("HOUSING_TEXT", housingText.text);
                break;

            case PurchaseCategory.Vehicle:
                vehicleText.text = "Araç: " + bestName;
                PlayerPrefs.SetString("VEHICLE_TEXT", vehicleText.text);
                break;
        }

        PlayerPrefs.SetInt(category + "_LEVEL", maxLevel);
        PlayerPrefs.Save();
    }

    private void LoadTexts()
    {
        housingText.text = PlayerPrefs.GetString("HOUSING_TEXT", "Barınma: Park");
        vehicleText.text = PlayerPrefs.GetString("VEHICLE_TEXT", "Araç: Yalın ayak");
        educationText.text = PlayerPrefs.GetString("EDUCATION_TEXT", "Eğitim: Yok");
    }
}
