using DG.Tweening;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance;
    [Header("Panels")]
    public GameObject[] panels;
    public GameObject healthBar;
    public GameObject energyBar;

    [Header("Other Panels")]
    public GameObject[] otherPanel;
    
    [Header("Bottom Buttons")]
    public Button[] buttons;

    [Header("Button Visual Settings")]
    public Vector3 selectedScale = new Vector3(1.2f, 1.2f, 1.2f);
    public Vector3 normalScale = Vector3.one;
    public Color selectedColor = Color.white;
    public Color normalColor = new Color(1, 1, 1, 0.5f);

    [Header("Character Panel Animation")]
    public RectTransform panel;
    private bool isOpen = false;

    private int currentIndex = 0;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        // Baþlangýç paneli ortadaki panel olsun
        currentIndex = panels.Length / 2;
        UpdatePanels();
        AssignButtonEvents();
    }

    private void AssignButtonEvents()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnPanelButtonPressed(index));
        }
    }
    private void OnPanelButtonPressed(int index)
    {
        currentIndex = index;
        UpdatePanels();
    }
    private void UpdatePanels()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(i == currentIndex);

            // Buton görseli
            var btnImage = buttons[i].GetComponent<Image>();

            if (i == currentIndex)
            {
                buttons[i].transform.localScale = selectedScale;
                btnImage.color = selectedColor;
            }
            else
            {
                buttons[i].transform.localScale = normalScale;
                btnImage.color = normalColor;
            }

        }
        for (int i = 0; i < otherPanel.Length; i++)
        {
            otherPanel[i].SetActive(false);        
        }
        if (isOpen)
        {
            CharacterPanel();        
        }

    }

    public void CharacterPanel()
    {
        if (isOpen)
        {
            // Kapanýþ animasyonu
            panel.DOScale(Vector3.zero, 0.3f)
                 .SetEase(Ease.InBack);
        }
        else
        {
            // Açýlýþ animasyonu
            panel.DOScale(Vector3.one, 0.3f)
                 .SetEase(Ease.OutBack);
        }

        isOpen = !isOpen;
    }
    public void LegalJobPanel() => otherPanel[0].SetActive(!otherPanel[0].activeSelf);
    public void IllegalJobPanel() => otherPanel[1].SetActive(!otherPanel[1].activeSelf);
    public void HungerPanel()
    {
        otherPanel[2].SetActive(!otherPanel[2].activeSelf);
        if (otherPanel[3].activeSelf)
        {
            otherPanel[3].SetActive(false);  
        }
    }
    public void EnergyPanel()
    {
        otherPanel[3].SetActive(!otherPanel[3].activeSelf);
        if (otherPanel[2].activeSelf)
        {
            otherPanel[2].SetActive(false);  
        }
    }
    public void BuildingsPanel() => otherPanel[4].SetActive(!otherPanel[4].activeSelf);
    public void CarsPanel () => otherPanel[5].SetActive(!otherPanel[5].activeSelf);
    public void GunsPanel () => otherPanel[6].SetActive(!otherPanel[6].activeSelf);
    public void AcademicPanel() => otherPanel[7].SetActive(!otherPanel[7].activeSelf);
    public void KriminalPanel() => otherPanel[8].SetActive(!otherPanel[8].activeSelf);
    public void SpecialPanel() => otherPanel[9].SetActive(!otherPanel[9].activeSelf);
    public void CasinoPanel() => otherPanel[10].SetActive(!otherPanel[10].activeSelf);
    public void TefeciPanel()
    {
        otherPanel[11].SetActive(!otherPanel[11].activeSelf);
        if (Casino.instance.TefecidenAldýMi)
        {
            Casino.instance.TefeciBildirim.text = "Sanýrým borcun var. Geri ödeme günü yaklaþýyor.";
        }
        else
        {
            Casino.instance.TefeciBildirim.text = "Demek paraya ihtiyacýn var? Burada kimse bedavaya yaþamaz. Faizler acýtýr, ama seni ayaða kaldýrýrým. Hazýr mýsýn?";
        }
    }
    public void RuletPanel() => otherPanel[12].SetActive(!otherPanel[12].activeSelf);
    public void BJPanel() => otherPanel[13].SetActive(!otherPanel[13].activeSelf);
    public void DicePanel() => otherPanel[14].SetActive(!otherPanel[14].activeSelf);
    public void RuletInfoPanelOpen() => otherPanel[15].SetActive(!otherPanel[15].activeSelf);
    public void BJInfoPanelOpen() => otherPanel[16].SetActive(!otherPanel[16].activeSelf);
    public void BarbutInfoPanelOpen() => otherPanel[17].SetActive(!otherPanel[17].activeSelf);
    public void MulkPanel() => otherPanel[18].SetActive(!otherPanel[18].activeSelf);


}
