using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Casino : MonoBehaviour
{
    public static Casino instance;
    [Header("InfoPanel")]
    public GameObject KumarBildirimPaneli;
    public TextMeshProUGUI BildirimText;
    private Coroutine closeRoutine;

    [Header("Rulet")]
    string[] renkler = {
    "Yeþil", // 0
    "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", // 1-6
    "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", "Siyah", "Kýrmýzý", // 7-12
    "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý", // 13-18
    "Siyah", "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", // 19-24
    "Kýrmýzý", "Siyah", "Kýrmýzý", "Kýrmýzý", "Siyah", "Kýrmýzý", // 25-30
    "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý"};// 31-36
    System.Random rnd = new System.Random();
    public int bahisGir = -1;
    public InputField BahisGir;
    public InputField ParaKoy;
    public int paraKoy = 0;

    [Header("Black Jack")]
    public GameObject BjBildirimPaneli;
    public TextMeshProUGUI BjBildirimText;
        public List<int> deste = new List<int>();
    Dictionary<int, int> kartDegerleri = new Dictionary<int, int>() {
    // Karo kartlarý
    {1, 11}, {2, 2}, {3, 3}, {4, 4}, {5, 5}, {6, 6}, {7, 7}, {8, 8}, {9, 9}, {10, 10}, // 1: As, 2-10: Sayýlar, 11: Vale, 12: Kýz, 13: Papaz
    {11, 10}, {12, 10}, {13, 10},
    // Kupa kartlarý
    {14, 11}, {15, 2}, {16, 3}, {17, 4}, {18, 5}, {19, 6}, {20, 7}, {21, 8}, {22, 9}, {23, 10}, // 14: As, 15-23: Sayýlar, 24: Vale, 25: Kýz, 26: Papaz
    {24, 10}, {25, 10}, {26, 10},
    // Maça kartlarý
    {27, 11}, {28, 2}, {29, 3}, {30, 4}, {31, 5}, {32, 6}, {33, 7}, {34, 8}, {35, 9}, {36, 10}, // 27: As, 28-36: Sayýlar, 37: Vale, 38: Kýz, 39: Papaz
    {37, 10}, {38, 10}, {39, 10},
    // Sinek kartlarý
    {40, 11}, {41, 2}, {42, 3}, {43, 4}, {44, 5}, {45, 6}, {46, 7}, {47, 8}, {48, 9}, {49, 10}, // 40: As, 41-49: Sayýlar, 50: Vale, 51: Kýz, 52: Papaz
    {50, 10}, {51, 10}, {52, 10} };
    public Sprite[] kartGorselleri;
    public Image O1;
    public Image O2;
    public Image O3;
    public Image O4;
    public Image O5;
    public Image O6;
    public Image O7;
    public Image K1;
    public Image K2;
    public Image K3;
    public Image K4;
    public Image K5;
    public Image K6;
    public Image K7;
    public Button Hit;
    public Button Stand;
    public Button BJButton;
    public InputField ParaKoy21;
    public int paraKoy21 = -1;
    private int hitCount = 0;
    private int oyuncuPuan = 0;
    private int kurpierPuan = 0;
    private int kart3 = 0;
    private int asSayisi = 0;
    private int asSayisiKurpiyer;

    [Header("Barbut")]
    public GameObject BarbutBildirimPaneli;
    public TextMeshProUGUI BarbutBildirimText;
    public TextMeshProUGUI BarbutBildirimText2;
    public InputField ParaKoyBarbut;
    public int paraKoyBarbut = -1;
    private int BarbutPuan = 0;
    public Sprite[] zarGorselleri;
    private int dice1Result; // Birinci zar sonucu
    private int dice2Result; // Ýkinci zar sonucu
    public Image dice1Image; // Birinci zarýn görselini gösterecek UI Image
    public Image dice2Image; // Ýkinci zarýn görselini gösterecek UI Image 
    public Button BarbutButton;
    public Button TekrarAt;
    public Button YeniOyun;

    [Header("Tefeci")]
    public Button BirSans;
    public Button Son;
    public GameObject BildirimPaneli;
    public TextMeshProUGUI tefeciBorcTect;
    public TextMeshProUGUI TefeciBildirim;
    public TextMeshProUGUI BorcMiktari;
    public TextMeshProUGUI OdemeGunu;
    public InputField Tefeci;
    public bool tefeciPanelAcildi = false;
    public bool TefecidenAldýMi = false;
    public int tefeciOdemeGunu = -1; 
    public int tefeci = 0;
    public int sayac = 0;
    private int borc = 0;
    private int Odemegunu = -1;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoadTefeciData();
    }

    #region Rulet
    public void RuletBahisYap()
    {
        int.TryParse(BahisGir.text, out bahisGir);
        int.TryParse(ParaKoy.text, out paraKoy);
        int ruletSonucu = rnd.Next(0, 37); // 0-36 arasý bir sayý döner
        string ruletRengi = renkler[ruletSonucu]; // Sonucun rengi

        if (bahisGir >= 0 && bahisGir < 37 && paraKoy > 0 && CharacterStats.Instance.money >= paraKoy)
        {
            CharacterStats.Instance.AddMoney(-paraKoy);

            if (bahisGir == ruletSonucu)
            {
                int y = 35 * paraKoy;
                CharacterStats.Instance.AddMoney(y);
                BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + y + "$";
                Show();

            }
            else
            {
                BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                Show();
            }
  
        }
        else
        {
            BildirimText.text = "Geçersiz Bahis";
            Show();
        }
    }
    public void RuletOyna(int bahis)
    {
        int.TryParse(ParaKoy.text, out paraKoy);
        if (paraKoy > 0 && CharacterStats.Instance.money >= paraKoy)
        {
            int ruletSonucu = rnd.Next(0, 37); // 0-36 arasý bir sayý döner
            string ruletRengi = renkler[ruletSonucu]; // Sonucun rengi
            CharacterStats.Instance.AddMoney(-paraKoy);

            if (bahis == 0)
            {
                if (ruletSonucu > 0 && ruletSonucu < 13)
                {
                    int a = 3 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show();
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show();
                }

            }
            else if (bahis == 1)
            {
                if (ruletSonucu > 12 && ruletSonucu < 25)
                {
                    int a = 3 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show() ;
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show() ;
                }
            }
            else if (bahis == 2)
            {
                if (ruletSonucu > 24 && ruletSonucu < 37)
                {
                    int a = 3 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show();
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show();
                }
            }
            else if (bahis == 3)
            {
                int[] sayilar = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
                if (sayilar.Contains(ruletSonucu))
                {
                    int a = 3 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show();
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show();
                }
            }
            else if (bahis == 4)
            {
                int[] sayilar = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
                if (sayilar.Contains(ruletSonucu))
                {
                    int a = 3 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show();
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show();
                }
            }
            else if (bahis == 5)
            {
                int[] sayilar = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
                if (sayilar.Contains(ruletSonucu))
                {
                    int a = 3 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show();
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show();
                }
            }
            else if (bahis == 6)
            {
                if (ruletSonucu > 0 && ruletSonucu < 19)
                {
                    int a = 2 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show();
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show();
                }
            }
            else if (bahis == 7)
            {
                if (ruletSonucu % 2 == 0)
                {
                    int a = 2 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show();
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show();
                }
            }
            else if (bahis == 8)
            {
                int[] kirmiziSayilar = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 21, 23, 25, 27, 28, 30, 32, 34, 36 };
                if (kirmiziSayilar.Contains(ruletSonucu))
                {
                    int a = 2 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show();
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show();
                }
            }
            else if (bahis == 9)
            {
                int[] kirmiziSayilar = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 19, 20, 22, 24, 26, 29, 31, 33, 35 };
                if (kirmiziSayilar.Contains(ruletSonucu))
                {
                    int a = 2 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show();
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show();
                }
            }
            else if (bahis == 10)
            {
                if (ruletSonucu % 2 != 0)
                {
                    int a = 2 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show();
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show();
                }
            }
            else if (bahis == 11)
            {
                if (ruletSonucu > 18 && ruletSonucu < 37)
                {
                    int a = 2 * paraKoy;
                    CharacterStats.Instance.AddMoney(a);
                    BildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    Show();
                }
                else
                {
                    BildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    Show();
                }
            }
        }
        else
        {
            BildirimText.text = "Geçersiz Bahis";
            Show();
        }

    }
    #endregion

    #region Black Jack
    public void BlackJackPaneliAc()
    {
        deste.Clear();
        Sprite secilenKartO1 = kartGorselleri[0];
        Sprite secilenKartO2 = kartGorselleri[0];
        Sprite secilenKartK1 = kartGorselleri[0];
        Sprite secilenKartK2 = kartGorselleri[0];
        O1.sprite = secilenKartO1;
        O2.sprite = secilenKartO2;
        K1.sprite = secilenKartK1;
        K2.sprite = secilenKartK2;
        Hit.interactable = false;
        Stand.interactable = false;
        BJButton.interactable = true;
        kart3 = 0;
        kurpierPuan = 0;
        oyuncuPuan = 0;
        asSayisi = 0;
        asSayisiKurpiyer = 0;
        O3.color = new Color(O1.color.r, O1.color.g, O1.color.b, 0f);
        O4.color = new Color(O1.color.r, O1.color.g, O1.color.b, 0f);
        O5.color = new Color(O1.color.r, O1.color.g, O1.color.b, 0f);
        O6.color = new Color(O1.color.r, O1.color.g, O1.color.b, 0f);
        O7.color = new Color(O1.color.r, O1.color.g, O1.color.b, 0f);
        K3.color = new Color(O1.color.r, O1.color.g, O1.color.b, 0f);
        K4.color = new Color(O1.color.r, O1.color.g, O1.color.b, 0f);
        K5.color = new Color(O1.color.r, O1.color.g, O1.color.b, 0f);
        K6.color = new Color(O1.color.r, O1.color.g, O1.color.b, 0f);
        K7.color = new Color(O1.color.r, O1.color.g, O1.color.b, 0f);
    }
    public void BJOyna()
    {
        hitCount = 0;
        kart3 = 0;
        int.TryParse(ParaKoy21.text, out paraKoy21);

        if (CharacterStats.Instance.money >= paraKoy21 && paraKoy21 >= 100)
        {
            CharacterStats.Instance.AddMoney(-paraKoy21);
            BJButton.interactable = false;
            Hit.interactable = true;
            Stand.interactable = true;
            for (int i = 1; i < 53; i++)// Desteye 1-52 arasý numaralarý ekle
            {
                deste.Add(i);
            }
            // Rastgele bir kart çek
            int rastgeleKartO1 = Random.Range(1, deste.Count);
            int kart1 = deste[rastgeleKartO1];
            deste.RemoveAt(rastgeleKartO1);
            int rastgeleKartO2 = Random.Range(1, deste.Count);
            int kart2 = deste[rastgeleKartO2];
            deste.RemoveAt(rastgeleKartO2);
            int rastgeleKartK1 = Random.Range(1, deste.Count);
            kart3 = deste[rastgeleKartK1];
            deste.RemoveAt(rastgeleKartK1);
            Sprite secilenKartO1 = kartGorselleri[kart1];
            Sprite secilenKartO2 = kartGorselleri[kart2];
            Sprite secilenKartK1 = kartGorselleri[kart3];

            // Kartý bir UI elementine ata
            O1.sprite = secilenKartO1;
            O2.sprite = secilenKartO2;
            K1.sprite = secilenKartK1;

            oyuncuPuan = kartDegerleri[kart1] + kartDegerleri[kart2];
            if (kartDegerleri[kart1] == 11) asSayisi++;
            if (kartDegerleri[kart2] == 11) asSayisi++;
            if (kartDegerleri[kart3] == 11) asSayisiKurpiyer++;

            if (oyuncuPuan == 21)
            {
                hitCount = 0;
                kart3 = 0;
                CharacterStats.Instance.AddMoney(3*paraKoy21);
                Hit.interactable = false;
                Stand.interactable = false;
                BjBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>" + "\n" + "+" + paraKoy21 * 3 + "$";
                BJResultPanelOpen();
            }
        }
        else
        {
            BjBildirimText.text = "Geçersiz Bahis\n" + "Minimum Bahis 100$";
            BJResultPanelOpen();
        }

    }
    public void HitBas()
    {
        if (deste.Count > 0 && hitCount < 5)
        { // Sadece 3 kart eklemek için kontrol        
            int rastgeleKart = Random.Range(1, deste.Count);
            int kart = deste[rastgeleKart];
            deste.RemoveAt(rastgeleKart);
            if (kartDegerleri[kart] == 11) asSayisi++;
            Sprite secilenKart = kartGorselleri[kart];
            if (hitCount == 0)
            {
                O3.sprite = secilenKart;
                oyuncuPuan += kartDegerleri[kart];
                O3.color = new Color(O1.color.r, O1.color.g, O1.color.b, 1f);
            }
            else if (hitCount == 1)
            {
                O4.sprite = secilenKart;
                oyuncuPuan += kartDegerleri[kart];
                O4.color = new Color(O1.color.r, O1.color.g, O1.color.b, 1f);
            }
            else if (hitCount == 2)
            {
                O5.sprite = secilenKart;
                oyuncuPuan += kartDegerleri[kart];
                O5.color = new Color(O1.color.r, O1.color.g, O1.color.b, 1f);
            }
            else if (hitCount == 3)
            {
                O6.sprite = secilenKart;
                oyuncuPuan += kartDegerleri[kart];
                O6.color = new Color(O1.color.r, O1.color.g, O1.color.b, 1f);
            }
            else if (hitCount == 4)
            {
                O7.sprite = secilenKart;
                oyuncuPuan += kartDegerleri[kart];
                O7.color = new Color(O1.color.r, O1.color.g, O1.color.b, 1f);
            }
            if (oyuncuPuan > 21)
            {
                if (asSayisi > 0)
                {
                    oyuncuPuan -= 10;
                    asSayisi--;
                }
                else
                {
                    BjBildirimText.text = "<color=red>KAYBETTÝNÝZ</color>";
                    BJResultPanelOpen();
                    hitCount = 0;
                    kart3 = 0;
                    BJButton.interactable = false;
                    Hit.interactable = false;
                    Stand.interactable = false;
                }

            }
            if (oyuncuPuan == 21)
            {

                hitCount = 0;
                kart3 = 0;
                CharacterStats.Instance.AddMoney(3 * paraKoy21);

                BjBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>" + "\n" + "+" + paraKoy21 * 3 + "$";
                BJResultPanelOpen();
                Hit.interactable = false;
                Stand.interactable = false;
            }
        }
        hitCount++;
    }
    public void StandBas()
    {
        Hit.interactable = false;
        Stand.interactable = false;
        int rastgeleKart = Random.Range(1, deste.Count);
        int kart4 = deste[rastgeleKart];
        deste.RemoveAt(rastgeleKart);
        if (kartDegerleri[kart4] == 11) asSayisiKurpiyer++;
        Sprite secilenKart = kartGorselleri[kart4];
        K2.sprite = secilenKart;
        kurpierPuan = kartDegerleri[kart3] + kartDegerleri[kart4];
        Debug.Log("kart3:" + kartDegerleri[kart3] + " kart4:" + kartDegerleri[kart4] + "," + asSayisiKurpiyer);
        while (kurpierPuan > 21 && asSayisiKurpiyer > 0)
        {
            kurpierPuan -= 10;
            asSayisiKurpiyer--;  // As deðerini 11'den 1'e düþürdük
        }
        if (kurpierPuan < 17)
        {
            int rastgeleKart5 = Random.Range(1, deste.Count);
            int kart5 = deste[rastgeleKart5];
            deste.RemoveAt(rastgeleKart5);
            Sprite secilenKart5 = kartGorselleri[kart5];
            K3.sprite = secilenKart5;
            kurpierPuan += kartDegerleri[kart5];
            K3.color = new Color(O1.color.r, O1.color.g, O1.color.b, 1f);
            if (kartDegerleri[kart5] == 11) asSayisiKurpiyer++;
            Debug.Log("kart5:" + kartDegerleri[kart5] + "," + asSayisiKurpiyer);
            while (kurpierPuan > 21 && asSayisiKurpiyer > 0)
            {
                kurpierPuan -= 10;
                asSayisiKurpiyer--;
            }
            if (kurpierPuan < 17)
            {
                int rastgeleKart6 = Random.Range(1, deste.Count);
                int kart6 = deste[rastgeleKart6];
                deste.RemoveAt(rastgeleKart6);
                Sprite secilenKart6 = kartGorselleri[kart6];
                K4.sprite = secilenKart6;
                kurpierPuan += kartDegerleri[kart6];
                K4.color = new Color(O1.color.r, O1.color.g, O1.color.b, 1f);
                if (kartDegerleri[kart6] == 11) asSayisiKurpiyer++;
                Debug.Log("kart6:" + kartDegerleri[kart6] + "," + asSayisiKurpiyer);
                while (kurpierPuan > 21 && asSayisiKurpiyer > 0)
                {
                    kurpierPuan -= 10;
                    asSayisiKurpiyer--;
                }
                if (kurpierPuan < 17)
                {
                    int rastgeleKart7 = Random.Range(1, deste.Count);
                    int kart7 = deste[rastgeleKart7];
                    deste.RemoveAt(rastgeleKart7);
                    Sprite secilenKart7 = kartGorselleri[kart7];
                    K5.sprite = secilenKart7;
                    kurpierPuan += kartDegerleri[kart7];
                    K5.color = new Color(O1.color.r, O1.color.g, O1.color.b, 1f);
                    if (kartDegerleri[kart7] == 11) asSayisiKurpiyer++;
                    Debug.Log("kart7:" + kartDegerleri[kart7] + "," + asSayisiKurpiyer);
                    while (kurpierPuan > 21 && asSayisiKurpiyer > 0)
                    {
                        kurpierPuan -= 10;
                        asSayisiKurpiyer--;
                    }
                    if (kurpierPuan < 17)
                    {
                        int rastgeleKart8 = Random.Range(1, deste.Count);
                        int kart8 = deste[rastgeleKart8];
                        deste.RemoveAt(rastgeleKart8);
                        Sprite secilenKart8 = kartGorselleri[kart8];
                        K6.sprite = secilenKart8;
                        kurpierPuan += kartDegerleri[kart8];
                        K6.color = new Color(O1.color.r, O1.color.g, O1.color.b, 1f);
                        if (kartDegerleri[kart8] == 11) asSayisiKurpiyer++;
                        Debug.Log("kart8:" + kartDegerleri[kart8] + "," + asSayisiKurpiyer);
                        while (kurpierPuan > 21 && asSayisiKurpiyer > 0)
                        {
                            kurpierPuan -= 10;
                            asSayisiKurpiyer--;
                        }
                        if (kurpierPuan < 17)
                        {
                            int rastgeleKart9 = Random.Range(1, deste.Count);
                            int kart9 = deste[rastgeleKart9];
                            deste.RemoveAt(rastgeleKart9);
                            Sprite secilenKart9 = kartGorselleri[kart9];
                            K7.sprite = secilenKart9;
                            kurpierPuan += kartDegerleri[kart9];
                            K7.color = new Color(O1.color.r, O1.color.g, O1.color.b, 1f);
                            if (kartDegerleri[kart9] == 11) asSayisiKurpiyer++;
                            Debug.Log("kart9:" + kartDegerleri[kart9] + "," + asSayisiKurpiyer);
                            while (kurpierPuan > 21 && asSayisiKurpiyer > 0)
                            {
                                kurpierPuan -= 10;
                                asSayisiKurpiyer--;
                            }
                        }
                    }
                }
            }

            Debug.Log("Kurpiyer puaný: " + kurpierPuan);
        }

        if (kurpierPuan >= 17)
        {
            if (oyuncuPuan > kurpierPuan)
            {

                CharacterStats.Instance.AddMoney(2 * paraKoy21);
                BjBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>" + "\n" + "+" + paraKoy21 * 2 + "$";
                BJResultPanelOpen();
            }
            else if (oyuncuPuan < kurpierPuan)
            {
                if (kurpierPuan > 21)
                {
                    CharacterStats.Instance.AddMoney(2 * paraKoy21);
                    BjBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>" + "\n" + "+" + paraKoy21 * 2 + "$";
                    BJResultPanelOpen();
                }
                else
                {
                    BjBildirimText.text = "<color=red>KAYBETTÝNÝZ</color>";
                    BJResultPanelOpen();
                }
            }
            else if (oyuncuPuan == kurpierPuan)
            {
                BjBildirimText.text = "<color=white>BERABERE</color>";
                BJResultPanelOpen();
                CharacterStats.Instance.AddMoney(paraKoy21);
            }
            Debug.Log(kart3 + "," + kart4 + "Kurpiyer kart çekmeyecek" + kurpierPuan);
        }
        hitCount = 0;
        kart3 = 0;
    }
    public void BJResultPanelOpen()
    {
        BjBildirimPaneli.SetActive(true);

    }
    #endregion

    #region Zar Oyunu
    public void BarbutOyna()
    {
        int.TryParse(ParaKoyBarbut.text, out paraKoyBarbut);
        BarbutBildirimText.text = "";

        if (CharacterStats.Instance.money >= paraKoyBarbut && paraKoyBarbut >= 50)
        {
            CharacterStats.Instance.AddMoney(-paraKoyBarbut);
            dice1Result = Random.Range(1, 7); // 1-6 arasý bir sayý döner.
            dice2Result = Random.Range(1, 7);

            dice1Image.sprite = zarGorselleri[dice1Result - 1];        // Zar yüzeylerinin güncellenmesi
            dice2Image.sprite = zarGorselleri[dice2Result - 1];
            int toplam = dice1Result + dice2Result;
            if (toplam == 7 || toplam == 11)
            {
                BarbutBildirimText.text = "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "\n" + "TEBRÝKLER KAZANDINIZ" + "\n" + "+" + paraKoyBarbut * 2 + "$";
                CharacterStats.Instance.AddMoney(2*paraKoyBarbut);
                YeniOyun.gameObject.SetActive(true);
                BarbutButton.interactable = false;
            }
            else if (toplam == 2 || toplam == 3 || toplam == 12)
            {
                BarbutBildirimText.text = "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "\n" + "KAYBETTÝNÝZ";
                YeniOyun.gameObject.SetActive(true);
                BarbutButton.interactable = false;
            }
            else
            {
                TekrarAt.gameObject.SetActive(true);
                BarbutButton.interactable = false;
                BarbutPuan = toplam;
                BarbutBildirimText.text = "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "Puanýnýz: " + BarbutPuan.ToString() + "\n" + "TEKRAR ZAR ATIN";
            }
        }
        else
        {
            BarbutBildirimText.text = "Geçersiz Bahis\n" + "Minimum Bahis 50$";
            //BarbutResultPanelOpen();

        }

    }
    public void BarbutTekrarAt()
    {
        dice1Result = Random.Range(1, 7); // 1-6 arasý bir sayý döner.
        dice2Result = Random.Range(1, 7);

        dice1Image.sprite = zarGorselleri[dice1Result - 1];        // Zar yüzeylerinin güncellenmesi
        dice2Image.sprite = zarGorselleri[dice2Result - 1];
        int toplam = dice1Result + dice2Result;
        if (toplam == BarbutPuan)
        {
            BarbutBildirimText.text = "Puanýnýz: " + BarbutPuan.ToString() + "\n" + "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "\n" + "TEBRÝKLER KAZANDINIZ" + "\n" + "+" + paraKoyBarbut * 3 + "$";
            BarbutPuan = 0;
            CharacterStats.Instance.AddMoney(3 * paraKoyBarbut);
            TekrarAt.gameObject.SetActive(false);
            YeniOyun.gameObject.SetActive(true);
        }
        else if (toplam == 7)
        {
            BarbutBildirimText.text = "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "\n" + "KAYBETTÝNÝZ";
            BarbutPuan = 0;
            TekrarAt.gameObject.SetActive(false);
            YeniOyun.gameObject.SetActive(true);
            BarbutButton.interactable = false;
        }
        else
        {
            BarbutBildirimText.text = "Puanýnýz: " + BarbutPuan.ToString() + "\n" + "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "TEKRAR ZAR ATIN";
        }
    }
    public void NewGameBarbut()
    {
        YeniOyun.gameObject.SetActive(false);
        TekrarAt.gameObject.SetActive(false);
        BarbutButton.interactable = true;
        dice1Image.sprite = zarGorselleri[5];        // Zar yüzeylerinin güncellenmesi
        dice2Image.sprite = zarGorselleri[5];
        BarbutBildirimText.text = " ";
    }
    public void BarbutResultPanelOpen()
    {
        BarbutBildirimPaneli.SetActive(true);
    }
    #endregion

    #region Tefeci
    public void TefeciButon()
    {
        int.TryParse(Tefeci.text, out tefeci);
        if (CharacterStats.Instance.money >= 5000)
        {
            if (tefeci >= 5000 && tefeci< CharacterStats.Instance.money*2 && !TefecidenAldýMi)
            {
                TefeciBildirim.text = tefeci.ToString() + " dolar...\n" + "Umarým bu parayý kullanmayý biliyorsundur. Geri ödemezsen bacaklarýný da faize eklerim. Al þimdi ve 30 gün içinde 2 katý olarak geri öde.";
                CharacterStats.Instance.AddMoney(tefeci);
                tefeciOdemeGunu = sayac;
                Tefeci.text = "";
                borc = tefeci * 2;
                BorcMiktari.text = borc.ToString();
                TefecidenAldýMi = true;
                Odemegunu = 30;
                OdemeGunu.text = "30 Gün";
                PlayerPrefs.SetInt("BORC", borc);
                PlayerPrefs.SetInt("ODEME_GUNU", Odemegunu);
                PlayerPrefs.SetInt("TEFECI_ODEME_GUNU", tefeciOdemeGunu);
                PlayerPrefs.SetInt("TEFECIDEN_ALDI_MI", 1);
                PlayerPrefs.Save();
            }
            else if(tefeci < 5000  && !TefecidenAldýMi)
            {
                TefeciBildirim.text = "Bu meblað için baþýný derde sokmana deðmez. En az 5000$ en fazla " + CharacterStats.Instance.money*2 +  "$ veririm sana. ";
            }
            else if (tefeci > CharacterStats.Instance.money *2 && !TefecidenAldýMi)
            {
                TefeciBildirim.text = "Bunun altýndan kalkamazsýn evlat sana en fazla " + CharacterStats.Instance.money * 2 + "$ verebilirim. ";
            }
            else if (TefecidenAldýMi)
            {
                TefeciBildirim.text = "Yeni baþlangýçlar için eski defterleri kapatmalýsýn.";
            }
        }
        else if (CharacterStats.Instance.money < 5000)
        {
            TefeciBildirim.text = "Hiç güven vermedin. Borcunu ödeyeceðine inanabilmem için en az 5000$ göstermen lazým.";   
        }
    }
    public void BorcOde()
    {
        if (borc > 0 && CharacterStats.Instance.money >= borc)
        {
            TefeciBildirim.text = "Ýyi iþ çýkardýn. Borcunu zamanýnda ödedin, bu hoþuma gitti. Tekrar ihtiyacýn olursa bilirsin, buralardayým.";
            CharacterStats.Instance.AddMoney(-borc);
            borc = 0;
            BorcMiktari.text = borc.ToString();
            PlayerPrefs.SetString("BorçMiktarý", BorcMiktari.text);
            tefeciOdemeGunu = -1;
            Odemegunu = 0;
            OdemeGunu.text = Odemegunu.ToString();
            tefeciPanelAcildi = false;
            TefecidenAldýMi = false;
            PlayerPrefs.SetInt("BORC", 0);
            PlayerPrefs.SetInt("ODEME_GUNU", 0);
            PlayerPrefs.SetInt("TEFECIDEN_ALDI_MI", 0);
            PlayerPrefs.SetInt("TEFECI_PANEL_ACILDI", 0);
            PlayerPrefs.Save();
        }
        else if (borc > 0 && CharacterStats.Instance.money < borc)
        {
            TefeciBildirim.text = "Bu kadarý yetmez. Borçlarýn bu kadar küçük deðil. Bir dahaki sefere tam getir, yoksa bu son görüþmemiz olmaz.";
        }
        else
        {
            TefeciBildirim.text = "Henüz borcun yok evlat";
        }
    }
    public void LoadTefeciData()
    {
        borc = PlayerPrefs.GetInt("BORC", 0);
        Odemegunu = PlayerPrefs.GetInt("ODEME_GUNU", 0);
        tefeciOdemeGunu = PlayerPrefs.GetInt("TEFECI_ODEME_GUNU", -1);
        TefecidenAldýMi = PlayerPrefs.GetInt("TEFECIDEN_ALDI_MI", 0) == 1;
        tefeciPanelAcildi = PlayerPrefs.GetInt("TEFECI_PANEL_ACILDI", 0) == 1;

        BorcMiktari.text = borc.ToString();
        OdemeGunu.text = Odemegunu > 0 ? Odemegunu + " Gün" : "0";

        if (TefecidenAldýMi)
        {
            TefeciBildirim.text = "Tefeciye borcun var. Geri ödeme günü yaklaþýyor.";
        }
    }
    public void GunIlerle()
    {
        if (!TefecidenAldýMi || Odemegunu <= 0)
            return;

        Odemegunu--;
        OdemeGunu.text = Odemegunu + " Gün";

        PlayerPrefs.SetInt("ODEME_GUNU", Odemegunu);

        if (Odemegunu <= 0)
        {
            if (!tefeciPanelAcildi)
            {
                tefeciBorcTect.text = "Tefeciye olan borcun 2 katýna çýktý. 10 gün içinde ödemezsen sonun hiç iyi olmayacak!";
                Odemegunu = 10;
                PlayerPrefs.SetInt("ODEME_GUNU", Odemegunu);
                OdemeGunu.text = Odemegunu + " Gün";
                tefeciPanelAcildi = true;
                PlayerPrefs.SetInt("TEFECI_PANEL_ACILDI", 1);
                BildirimPaneli.SetActive(true);
            }
            else
            {
                tefeciBorcTect.text = "Borçlarýnýn bedelini canýnla ödedin. Bu dünya acýmasýz ve sen bunu unuttun... Oyun Bitti.";
                BildirimPaneli.SetActive(true);
                BirSans.gameObject.SetActive(false);
                Son.gameObject.SetActive(true);
                tefeciPanelAcildi = false;
                PlayerPrefs.SetInt("TEFECI_PANEL_ACILDI", 0);
            }
        }
        PlayerPrefs.Save();
    }
    public void CloseTefeciPanel()
    {
        BildirimPaneli.SetActive(false);
    }
    public IEnumerator BildirimGosterVeKapat5sn()
    {
        yield return new WaitForSeconds(5f);
        BildirimPaneli.SetActive(false);
    }
    #endregion


    #region Panel Aç-Kapat
    public void Show()
    {
        if (!KumarBildirimPaneli.activeSelf)
            KumarBildirimPaneli.SetActive(true);
       
        // Eðer daha önce kapanma coroutine'i varsa durdur
        if (closeRoutine != null)
            StopCoroutine(closeRoutine);

        closeRoutine = StartCoroutine(AutoClose());
    }
    public void CloseShow()
    {
        if (closeRoutine != null)
            StopCoroutine(closeRoutine);
        Close();
    }
    private IEnumerator AutoClose()
    {
        yield return new WaitForSeconds(2f);
        Close();
    }
    public void Close()
    {
        KumarBildirimPaneli.SetActive(false);
    }
    #endregion
}
