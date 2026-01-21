using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    public static CharacterStats Instance;
    [Header("Stats")]
    public int money;
    public int hunger;
    public int energy;
    public int maxHunger = 100;
    public int maxEnergy = 100;
    public int power;
    public int intellegent;
    public float moneyX=1;

    [Header("UI - TMP")]
    public TMP_Text moneyText;
    public TMP_Text hungerText;
    public TMP_Text energyText;
    public Slider hungerSlider;
    public Slider energySlider;

    [Header("Time")]
    public TextMeshProUGUI timeText;
    public int day = 1;
    public int year = 18;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        LoadStats();
        hungerSlider.maxValue = maxHunger;
        energySlider.maxValue = maxEnergy;
        timeText.text = $"Gün: {day} \nYaþ: {year}";

        UpdateUI();
    }
    public void Time()
    {
        day++;
        if (day >= 365)
        {
            day = 1;
            year++;
        }
        PlayerPrefs.SetInt("DAY", day);
        PlayerPrefs.SetInt("YEAR", year);
        timeText.text = $"Gün: {day} \nYaþ: {year}";
        Casino.instance.GunIlerle();
        Casino.instance.HasilatGunuGecti();
    }
    #region Stats
    public void AddMoney(int amount)    // ----- MONEY -----
    {
        amount += ((int)(amount * (moneyX / 10)));
        money += amount;
        SaveStats();
        UpdateUI();
    }

    public void ChangeHunger(int amount)    // ----- HUNGER -----
    {
        hunger += amount;
        hunger = Mathf.Clamp(hunger, 0, maxHunger);
        SaveStats();
        UpdateUI();
    }

    public void ChangeEnergy(int amount)    // ----- ENERGY -----
    {
        energy += amount;
        energy = Mathf.Clamp(energy, 0, maxEnergy);
        SaveStats();
        UpdateUI();
    }

    public void IncreaseMaxHunger(int amount)    // ----- MAX HUNGER UPGRADE -----
    {
        maxHunger += amount;

        hungerSlider.maxValue = maxHunger;
        hunger = Mathf.Clamp(hunger, 0, maxHunger);

        SaveStats();
        UpdateUI();
    }

    public void IncreaseMaxEnergy(int amount)    // ----- MAX ENERGY UPGRADE -----
    {
        maxEnergy += amount;

        energySlider.maxValue = maxEnergy;
        energy = Mathf.Clamp(energy, 0, maxEnergy);

        SaveStats();
        UpdateUI();
    }
    public void IncreasePower(int amount)
    {
        power += amount;
        SaveStats();
        UpdateUI();
    }
    public void IncreaseIntellegent(int amount)
    {
        intellegent += amount;
        SaveStats();
        UpdateUI();
    }
    public void IncreaseMoneyX(int amount)
    {
        moneyX += amount;
        SaveStats();
    }
    #endregion
    #region UI-Save-Load
    public void UpdateUI()    // ----- UI UPDATE -----
    {
        moneyText.text = money.ToString() + "$";
        hungerText.text = $"{hunger}/{maxHunger}";
        energyText.text = $"{energy}/{maxEnergy}";

        hungerSlider.value = hunger;
        energySlider.value = energy;
    }

    private void SaveStats()    // ----- SAVE -----
    {
        PlayerPrefs.SetInt("MONEY", money);
        PlayerPrefs.SetInt("HUNGER", hunger);
        PlayerPrefs.SetInt("ENERGY", energy);
        PlayerPrefs.SetInt("MAX_HUNGER", maxHunger);
        PlayerPrefs.SetInt("MAX_ENERGY", maxEnergy);
        PlayerPrefs.SetInt("POWER", power);
        PlayerPrefs.SetInt("INTELLEGENT", intellegent);
        PlayerPrefs.SetFloat("MONEYX", moneyX);
        PlayerPrefs.Save();
    }

    private void LoadStats()    // ----- LOAD -----
    {
        money = PlayerPrefs.GetInt("MONEY", money);
        hunger = PlayerPrefs.GetInt("HUNGER", hunger);
        energy = PlayerPrefs.GetInt("ENERGY", energy);
        maxHunger = PlayerPrefs.GetInt("MAX_HUNGER", maxHunger);
        maxEnergy = PlayerPrefs.GetInt("MAX_ENERGY", maxEnergy);
        power = PlayerPrefs.GetInt("POWER", power);
        intellegent = PlayerPrefs.GetInt("INTELLEGENT", intellegent);
        moneyX = PlayerPrefs.GetFloat("MONEYX", moneyX);
        day = PlayerPrefs.GetInt("DAY", day);
        year = PlayerPrefs.GetInt("YEAR", year);
    }
    public void ResetStats()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
}
