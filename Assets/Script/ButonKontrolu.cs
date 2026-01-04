using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using GoogleMobileAds.Api;
using GoogleMobileAds;
//using Unity.Mathematics;
public class ButonKontrolu : MonoBehaviour
{
    public GameObject BaslangicPaneli;
    public GameObject ProfilPaneli;
    public GameObject KarakterPaneli;
    public GameObject YemekPaneli;
    public GameObject EnerjiPaneli;
    public GameObject MeslekPaneli;
    public GameObject LegalPaneli;
    public GameObject IllegalPaneli;
    public GameObject KumarPaneli;
    public GameObject RuletPaneli;
    public GameObject RuletHelpPaneli;
    public GameObject BlackJackPaneli;    
    public GameObject BJHelpPaneli;
    public GameObject ZarPaneli;
    public GameObject BarbutHelpPaneli;
    public GameObject KumarBildirimPaneli;
    public GameObject BJBildirimPaneli;
    public GameObject TefeciPaneli;
    public GameObject EgitimPaneli;
    public GameObject AkademiPaneli;
    public GameObject KriminalPaneli;
    public GameObject OzelEgitimPaneli;
    public GameObject PazarPaneli;
    public GameObject BarinmaPaneli;
    public GameObject AracPaneli;
    public GameObject SilahPaneli;
    public GameObject MulkPaneli;
    public GameObject GameOverPaneli;
    public GameObject IhtiyacListesiPaneli;
    public GameObject BildirimPaneli;

    public Text aclikText;
    public Text enerjiText;  // Enerji seviyesini göstermek için bir Text UI eleman
    public Text aclikText2;
    public Text enerjiText2;
    public Text paraText;
    public Text paraText2;
    public Text toplamParaText;
    public Text iyilikText2;
    public Text kotulukText2;
    public Text barinmaText;
    public Text aracText;
    public Text egitimText;
    public Text ihtiyacText;
    public Text bildirimText;
    public Text yasText;
    public Text iyilikText;
    public Text kotulukText;
    public Text baskanText;
    public Text baskanText2;
    public Text baskanText3;
    public Text baskanText4;
    public Text mafyaText;
    public Text mafyaText2;
    public Text mafyaText3;
    public Text mafyaText4;
    public Text RuletBildirimText;
    public Text BJBildirimText;
    public Text BarbutBildirim;
    public Text TefeciBildirim;
    public Text BorcMiktari;
    public Text OdemeGunu;
    public Text OldunBildirim;
    public Text TutulduMu1;
    public Text TutulduMu2;
    public Text TutulduMu3;
    public Text TutulduMu4;
    public Text TutulduMu5;
    public Text TutulduMu6;
    public Image aclikBar;
    public Image enerjiBar;
    public Image aclikBar2;
    public Image enerjiBar2;
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
    public Button baskanButton;
    public Button mafyaButton;
    public Button Hit;
    public Button Stand;
    public Button BJButton;
    public Button BarbutButton;
    public Button TekrarAt;
    public Button YeniOyun;
    public Button BirSans;
    public Button Otelim;
    private int aclik = 200;
    private int enerji = 200;  // Baþlangýç enerjisi
    private int para = 0;
    private int yas = 18;
    public int gun = 1;
    public int sayac = 0;
    private int iyilik = 0;
    private int kotuluk = 0;
    public int gecekonduAlindigiGun = -1;
    public int evAlindigiGun = -1;
    public int tefeciOdemeGunu = -1;
    public int bahisGir = -1;
    public int paraKoy = 0;
    public int paraKoy21 = -1;
    public int paraKoyBarbut = -1;
    public int tefeci = 0;
    public int reklamSayaci = 0;
    private int borc = 0;
    private int toplampara = 0;
    private int iyilikSayac = 0;
    private int kotulukSayac = 0;
    private int Odemegunu = -1;
    private int hitCount = 0;
    private int oyuncuPuan = 0;
    private int kurpierPuan = 0;
    private int kart3 = 0;
    private int asSayisi = 0;
    private int asSayisiKurpiyer;
    private int BarbutPuan=0;
    private int hasilatDegeri = 30;
    
    private string baskanismi = "Ülke baþkaný ol";
    private string baskanismi2 = "Açlýk : 75";
    private string baskanismi3 = "Enerji : 50";
    private string baskanismi4 = "50000$";
    private string mafyaismi = "Mafya babasý ol";
    private string mafyaismi2 = "Açlýk : 50";
    private string mafyaismi3 = "Enerji : 75";
    private string mafyaismi4 = "50000$-?";
    System.Random random = new System.Random();
    System.Random rnd = new System.Random();

    private AudioSource audioSource;
    private Coroutine bildirimCoroutine;
    public InputField BahisGir;
    public InputField ParaKoy;
    public InputField Tefeci;
    public InputField ParaKoy21;
    public InputField ParaKoyBarbut;

    private Color aclikColorStart;
    private Color aclikColorEnd;
    private Color enerjiColorStart;
    private Color enerjiColorEnd;
    public bool tefeciPanelAcildi = false;
    public bool TefecidenAldýMi = false;
    private bool panelAcik = false;
    private bool panelAcik2 = false;
    public bool gecekondu = false, daire = false, ev = false, villa = false, otel = false,
                ayakkabi = false, bisiklet = false, araba = false, kamyon = false, tir = false, gemi = false, ucak = false,
                bicak = false, tabanca = false, pompali = false, makineli = false, celikyelek = false, elbombasi = false, roketatar = false,
                ilkokul = false, lise = false, universite = false, master = false,
                ehliyet = false, ustalik = false, ekonomi = false, isletme = false, hukuk = false,
                yankesicilik = false, hirsizlik = false, soygun = false, acemi = false, usta = false, tetikci = false;

    public GameObject[] paneller;
    string[] ihtiyacListesi = {
    " ",
    "Ayakkabý al",
    "Ayakakbý al.Gecekondu kirala",
    "Bisiklet al.Gecekondu kirala.Ýlkokulu bitir",
    "Araba al.Daire kirala.Ehliyet al",
    "Araba al.Daire kirala.Ustalýk belgesi al",
    "Araba al.Ev satýn al.Liseyi bitir",
    "Kamyon al.Ev satýn al.Üniversiteyi bitir.Ekonomi eðitimi al",
    "Týr al.Ev satýn al.Üniversiteyi bitir.Ýþletme eðitimi al",
    "Gemi al.Villa al.Master yap.Hukuk eðitimi al",
    "Uçak al.Otel satýn al.Master yap.Hukuk eðitimi al",
    "Uçak al.Otel satýn al.Master yap.Hukuk eðitimi al",
    };
    string[] ihtiyacListesi2 = {
    " ",
    " ",
    "Ayakkabý al.Býçak al.Yankesiciliði öðren",
    "Ayakkabý al.Gecekondu kirala.Býçak al.Yankesiciliði öðren",
    "Bisiklet al.Gecekondu kirala.Tabanca al.Acemi niþancýlýðý öðren",
    "Araba al.Daire kirala.Pompalý silah al.Usta niþancýlýðý öðren.Hýrsýzlýðý öðren",
    "Kamyon al.Daire kirala.Makineli tüfek al.Usta niþancýlýðý öðren",
    "Týr al.Ev satýn al.Makineli tüfek al.Usta niþancýlýðý öðren",
    "Týr al.Ev satýn al.Çelik yelek al.Makineli tüfek al.Tetikçi niþancýlýðý öðren.Soygun yapmayý öðren",
    "Gemi al.Villa satýn al.Çelik yelek al.El bombasý al.Tetikçi niþancýlýðý öðren",
    "Uçak al.Otel satýn al.Çelik yelek al.Roketatar al.Tetikçi niþancýlýðý öðren. Soygun yapmayý öðren",
    "Uçak al.Otel satýn al.Çelik yelek al.Roketatar al.Tetikçi niþancýlýðý öðren. Soygun yapmayý öðren",

    };
    string[] bildirim = {
    "Satýn Alýndý",
    "Zaten Mevcut",
    "Yetersiz Para",
    "Gücün Azalýyor",
    "Çok Yakýnda",
    "Kira Sözleþmen Bitti",
    "Daha çok legal iþ yapmalýsýn",
    "Daha çok illegal iþ yapmalýsýn",
    "Mülk Satýn Alýndý",
    "Tefeciye olan borcun 2 katýna çýktý. 10 gün içinde ödemezsen sonun hiç iyi olmayacak!",
    "Tefeci borcuna karþýlýk canýn yerine cebindeki tüm parayý aldý þanslýsýn. "
    };
    string[] bilgiListe = {"Kiralýk Gecekondu", "Kiralýk Daire", "Ev", "Villa", "Otel",
                           "Ayakkabý","Bisiklet","Araba","Kamyon","Týr","Gemi","Uçak",
                           "Ýlkokul Mezunu","Lise Mezunu","Üniversite Mezunu","Master"};
    string[] renkler = {
    "Yeþil", // 0
    "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", // 1-6
    "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", "Siyah", "Kýrmýzý", // 7-12
    "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý", // 13-18
    "Siyah", "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", // 19-24
    "Kýrmýzý", "Siyah", "Kýrmýzý", "Kýrmýzý", "Siyah", "Kýrmýzý", // 25-30
    "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý", "Siyah", "Kýrmýzý"};// 31-36

    public int[] aclikAzaltilari = { 5,7,12,15,20,25,30,35,40,45,50,75 }; // Örnek açlýk azaltma deðerleri
    public int[] enerjiAzaltilari = { 5,7,10,12,14,16,18,20,22,24,26,50};
    public int[] paraKazancilari = { 1,5,20,50,100,150,500,1000,2500,6000,20000,50000 };
    public int[] minKazanc = { 0,0,20, 50, 100, 150, 500, 1000, 2500, 6000, 20000, 50000 };  // Ýþlere göre minimum kazançlar
    public int[] maxKazanc = { 0,0,40, 90, 140, 400, 750, 1500, 4000, 10000, 25000, 100000  }; // Ýþlere göre maksimum kazançlar
    public int[] yemekUcretleri = { 0,3,10,25,100,300,1000 };  //yemekler için fiyatlar
    public int[] artis = { 10,15,25,40,75,100,200 }; // yemekler için açlýk artýrma deðerleri  
    public int[] düsüs = { 5,5,5,5,0,0,0 };
    public int[] EsyaUcretleri = { 100,5000,75000,250000,
                                   400,900,2500,600,2000,10000,
                                   500,900,5000,12000,25000,    
                                   100,400,30000,150000,500000, 
                                   40,400,5000,20000,50000,150000,300000,
                                   50,400,1000,3000,5000,7000,15000};
    public int[] sonParaGunu = new int[6]; // 6 mülkiyet için
    public int[] hasilat = new int[6];
    public int[] MulkUcretleri = { 50000, 150000, 250000, 350000, 400000, 1000000 };
    public int[] MulkKazanclari = {10000,30000,50000,70000,80000,250000 };
    public bool[] esyaAlindiMi = {false, false, false, false, false, false, false, false, false, false,false, false,
                                  false, false, false, false, false, false, false, false, false, false,false, false,
                                  false, false, false, false, false, false, false, false, false, false };
    public bool[] mulkAlindiMi ={false,false,false,false,false,false,};
    public Text[] TutulduMu;



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



    public Sprite[] zarGorselleri;
    private int dice1Result; // Birinci zar sonucu
    private int dice2Result; // Ýkinci zar sonucu
    public Image dice1Image; // Birinci zarýn görselini gösterecek UI Image
    public Image dice2Image; // Ýkinci zarýn görselini gösterecek UI Image







    private string adUnitId = "ca-app-pub-2969178840845794/9086371383";
    private string adUnitIdBanner = "ca-app-pub-2969178840845794/9880276988";
    private string adUnitIdOdul = "ca-app-pub-2969178840845794/3314868635";
    private InterstitialAd interstitialAd;
    private BannerView bannerReklam;
    private RewardedAd odulluReklam;

    #region Kod
    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>{});
        LoadLoadInterstitialAd(); //reklamý oyun baþlar baþlamaz yüklesin izlenmeye hazýr hale getirsin diye void startta çaðrýlýr fonksiyon
        RequestBanner();
        LoadOdulluReklam();
        PanelleriAc();
        PanelleriAc(BaslangicPaneli);
        OyunuYukle();
        AclikGuncelle();
        AclikBarGuncelle();
        EnerjiGuncelle();
        EnerjiBarGuncelle();
        ParaGuncelle();
        yasText.text = "Gün: " + gun.ToString() + "\n" + "Yaþ: " + yas.ToString();

        iyilik = PlayerPrefs.GetInt("iyiliksave",0);
        kotuluk = PlayerPrefs.GetInt("kotuluksave", 0);
        iyilikSayac = PlayerPrefs.GetInt("ÝyilikSayacý", 0);
        kotulukSayac = PlayerPrefs.GetInt("KötülükSayacý", 0);
        iyilikText.text = iyilik.ToString() + "/1000";
        iyilikText2.text= iyilikSayac.ToString();
        kotulukText.text = kotuluk.ToString() + "/1000";
        kotulukText2.text= kotulukSayac.ToString();
        BorcMiktari.text=borc.ToString();
        OdemeGunu.text=Odemegunu.ToString()+" Gün";
        Otelim.gameObject.SetActive(false);
        
        if(iyilik < 1000)
        {
            baskanText.text = "Daha çok çalýþmalýsýn";  // Baþlangýçta iþ ismi soru iþareti
            baskanText2.text = "? ? ?";
            baskanText3.text = "? ? ?";
            baskanText4.text = "? ? ? ?";
            baskanButton.interactable = false;  // Baþlangýçta týklanamaz
        }
        else if(iyilik >= 1000)
        {
            baskanButton.interactable = true;
            baskanText.text = baskanismi;  // Ýþ ismi gösterilir
            baskanText2.text = baskanismi2;
            baskanText3.text = baskanismi3;
            baskanText4.text = baskanismi4;
          
        }
        if (kotuluk < 1000)
        {
            mafyaText.text = "Daha çok çalýþmalýsýn";  // Baþlangýçta iþ ismi soru iþareti
            mafyaText2.text = "? ? ?";
            mafyaText3.text = "? ? ?";
            mafyaText4.text = "? ? ? ?";
            mafyaButton.interactable = false;  // Baþlangýçta týklanamaz
        }
        else if (kotuluk >= 1000)
        {
            mafyaButton.interactable = true;
            mafyaText.text = mafyaismi;  // Ýþ ismi gösterilir
            mafyaText2.text = mafyaismi2;
            mafyaText3.text = mafyaismi3;
            mafyaText4.text = mafyaismi4;

        }

        ihtiyacText.text = " ";
        TutulduMu = new Text[] { TutulduMu1, TutulduMu2, TutulduMu3, TutulduMu4, TutulduMu5, TutulduMu6 };
        aclikColorStart = new Color(16f / 255f, 16f / 255f, 144f / 255f);
        aclikColorEnd = new Color(104f / 255f, 3f / 255f, 6f / 255f);
        enerjiColorStart = new Color(11f / 255f, 138f / 255f, 11f / 255f);
        enerjiColorEnd = new Color(104f / 255f, 3f / 255f, 6f / 255f);
    } 
    void Update()
    {
        if (villa|| otel||ev)
        {
            Otelim.gameObject.SetActive(true);
        }
        if (aclik <= 0 || enerji <= 0) // Açlýk veya enerji sýfýrsa
        {
            aclik = Mathf.Max(0, aclik);  // Deðerin eksiye düþmesini engelle
            enerji = Mathf.Max(0, enerji); // Deðerin eksiye düþmesini engelle
            OldunBildirim.text = "Buraya kadarmýþ...";
            PanelleriAc(GameOverPaneli);
            PlayerPrefs.DeleteAll();
            Time.timeScale = 0f;          // Oyunu durdur                        
        }
        if (gecekondu && sayac - gecekonduAlindigiGun == 30)
        {
            if (daire || ev || villa || otel)
            {
                gecekondu = false;
            }
            else
            {
                bildirimText.text = bildirim[5];
                BildirimPaneli.SetActive(true);
                bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat());
                gecekondu = false;
                barinmaText.text = "Park";
                PlayerPrefs.SetString("barinmasave", barinmaText.text);
            }
        }
        if (daire && sayac - evAlindigiGun == 30)
        {
            if(ev || villa || otel)
            {
                daire= false;
            }
            else
            {
                bildirimText.text = bildirim[5];
                BildirimPaneli.SetActive(true);
                bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat());
                daire = false;
                barinmaText.text = "Park";
                PlayerPrefs.SetString("barinmasave", barinmaText.text);
            }
        }
        if (tefeciOdemeGunu > 0 && sayac - tefeciOdemeGunu == 30 && !tefeciPanelAcildi)
        {
            bildirimText.text = bildirim[9];
            BildirimPaneli.SetActive(true);
            bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat5sn());
            tefeciPanelAcildi = true;
            PlayerPrefs.SetInt("TefeciPanelAçýldý", 1);
            PlayerPrefs.Save();
            borc *= 2;
            BorcMiktari.text = borc.ToString();
            PlayerPrefs.SetString("BorçMiktarý", BorcMiktari.text);
        }
        if (sayac - tefeciOdemeGunu == 40 && TefecidenAldýMi)
        {
            BirSans.gameObject.SetActive(false);
            OldunBildirim.text = "Borçlarýnýn bedelini canýnla ödedin. Bu dünya acýmasýz ve sen bunu unuttun... Oyun Bitti.";
            PanelleriAc(GameOverPaneli);
            PlayerPrefs.DeleteAll();
            Time.timeScale = 0f;
        }
    }
    public void DurumKontrol()
    {
        if (aclik <= 30 || enerji <= 30)
        {
            bildirimText.text = bildirim[3];
            BildirimPaneli.SetActive(true);
            bildirimCoroutine = StartCoroutine(BildirimKapat());
        }
    }
    public void OtelAlindiMi()
    {
        if (ev && !villa && !otel)
        {
            enerji += 50;
            aclik += 50;

            if (enerji > 200)
            {
                enerji = 200;
            }
            if (aclik > 200)
            {
                aclik= 200;
            }
        }
        else if (villa && !otel)
        {
            enerji += 100;
            aclik += 100;

            if (enerji > 200)
            {
                enerji = 200;
            }
            if (aclik > 200)
            {
                aclik = 200;
            }
        }
        else if (otel)
        {
            enerji = 200;
            aclik = 200;
        }
        AclikGuncelle();
        AclikBarGuncelle();
        EnerjiGuncelle();
        EnerjiBarGuncelle();
    }
    public void PanelleriAc(params GameObject[] acilacakPaneller) //panel dizisi oluþturmak için
    {
        // Önce tüm panelleri kapatýyoruz
        foreach (GameObject panel in paneller)
        {
            panel.SetActive(false);
        }

        // Sonra açmak istediðimiz panelleri aktif hale getiriyoruz
        foreach (GameObject acikPanel in acilacakPaneller)
        {
            acikPanel.SetActive(true);
        }
    }

    public void LegalIsYap(int isIndex)
    {
        if (IhtiyaclarKarsilandi(isIndex))
        {
            // Ýhtiyaçlar karþýlanmýþ, iþ yapýlýr
            AclikAzalt(aclikAzaltilari[isIndex]); // Her iþ için açlýk azaltma
            EnerjiAzalt(enerjiAzaltilari[isIndex]);
            ParaArtir(paraKazancilari[isIndex]);
            ParaGuncelle();
            Hasilat();
            MulkGeliriKontrol();
            iyilik += 1;
            iyilikSayac += 1;
            kotuluk -= 1;
            if (kotuluk< 0)
            {
                kotuluk = 0;
            }
            if (iyilik >= 1000)
            {   
                baskanButton.interactable = true;
                baskanText.text = baskanismi;  // Ýþ ismi gösterilir
                baskanText2.text = baskanismi2;
                baskanText3.text = baskanismi3;
                baskanText4.text = baskanismi4;
                PlayerPrefs.SetInt("baskanButton", baskanButton.interactable ? 1 : 0);
            }
            iyilikText.text = iyilik.ToString() + "/1000";
            iyilikText2.text=iyilikSayac.ToString();
            kotulukText.text = kotuluk.ToString() + "/1000";
            PlayerPrefs.SetString("iyiliksavetext", iyilikText.text);
            PlayerPrefs.SetString("iyiliksavetext2", iyilikText2.text);
            PlayerPrefs.SetString("kotuluksavetext", kotulukText.text);
            PlayerPrefs.SetInt("iyiliksave", iyilik);
            PlayerPrefs.SetInt("ÝyilikSayacý", iyilikSayac);
            PlayerPrefs.SetInt("kotuluksave", kotuluk);
            sayac += 1;
            gun += 1;
            if (gun == 366)
            {
                yas += 1;
                gun = 1;
            }
            yasText.text = "Gün: " + gun.ToString() + "\n" + "Yaþ: " + yas.ToString();
            if (!tefeciPanelAcildi && TefecidenAldýMi)
            {
                Odemegunu -= 1;
                OdemeGunu.text = Odemegunu.ToString() + " Gün";
                PlayerPrefs.SetInt("ÖdemeGünü", Odemegunu);
            }
        }
        else
        {
            // Ýhtiyaçlar karþýlanmamýþ, sadece ihtiyaç listesi gösterilir
            IhtiyacGoster(isIndex);
        }
    }
    public void IllegalIsYap(int isIndex)
    {
        if (IhtiyaclarKarsilandi2(isIndex))
        {
            // Ýhtiyaçlar karþýlanmýþ, iþ yapýlýr
            EnerjiAzalt(aclikAzaltilari[isIndex]); // Her iþ için açlýk azaltma
            AclikAzalt(enerjiAzaltilari[isIndex]);

            if (isIndex >= 0 && isIndex < minKazanc.Length)
                {
                    // isIndex'e göre kazanç aralýðýna baðlý olarak rastgele bir sayý döndür
                    int kazanc = random.Next(minKazanc[isIndex], maxKazanc[isIndex] + 1);
                para += kazanc;
                toplampara += kazanc;

                }
            ParaGuncelle();
            Hasilat();
            MulkGeliriKontrol();
            kotuluk += 2;
            kotulukSayac += 1;
            iyilik -= 1;
            
            if ( iyilik < 0)
            {
                iyilik = 0;
            }
            if (kotuluk >= 1000)
            {                
                mafyaButton.interactable = true; 
                mafyaText.text = mafyaismi;  // Ýþ ismi gösterilir
                mafyaText2.text = mafyaismi2;
                mafyaText3.text = mafyaismi3;
                mafyaText4.text = mafyaismi4;
                PlayerPrefs.SetInt("mafyaButton", mafyaButton.interactable ? 1 : 0);
            }
            iyilikText.text = iyilik.ToString() + "/1000";
            kotulukText.text = kotuluk.ToString() + "/1000";
            kotulukText2.text = kotulukSayac.ToString();
            PlayerPrefs.SetString("iyiliksavetext", iyilikText.text);
            PlayerPrefs.SetString("kotuluksavetext", kotulukText.text);
            PlayerPrefs.SetString("kotuluksavetext2", kotulukText2.text);
            PlayerPrefs.SetInt("iyiliksave", iyilik);
            PlayerPrefs.SetInt("kotuluksave", kotuluk);
            PlayerPrefs.SetInt("KötülükSayacý", kotulukSayac);
            sayac += 1;
            gun += 1;
            if (gun == 366)
            {
                yas += 1;
                gun = 0;
            }
            yasText.text = "Gün: " + gun.ToString() + "\n" + "Yaþ: " + yas.ToString();
            if (!tefeciPanelAcildi && TefecidenAldýMi)
            {
                Odemegunu -= 1;
                OdemeGunu.text = Odemegunu.ToString() + " Gün";
                PlayerPrefs.SetInt("ÖdemeGünü", Odemegunu);
            }
        }
        else
        {
            // Ýhtiyaçlar karþýlanmamýþ, sadece ihtiyaç listesi gösterilir
            IhtiyaciGoster(isIndex);
        }
    }
    bool IhtiyaclarKarsilandi(int isIndex)
    {
        switch (isIndex)
        {
            case 0: // Dilenmek
                return true; // Dilenmek için hiçbir þeye gerek yok
            case 1: // Ayakkabý Boya
                return ayakkabi; 
            case 2: 
                return ayakkabi && (gecekondu || daire || ev || villa || otel); 
            case 3:
                return bisiklet && ilkokul && (gecekondu|| daire || ev || villa || otel); 
            case 4:
                return araba && (daire || ev || villa || otel) && ehliyet;
            case 5:
                return araba && (daire || ev || villa || otel) && ustalik;
            case 6:
                return araba && ev && lise;
            case 7:
                return kamyon && ev && universite && ekonomi;
            case 8:
                return tir && ev && universite && isletme;
            case 9:
                return gemi && villa && master && hukuk;
            case 10:
                return ucak && otel && master && hukuk;
            case 11:
                return ucak && otel && master && hukuk;

            default:
                return false;
        }
    }
    bool IhtiyaclarKarsilandi2(int isIndex)
    {
        switch (isIndex)
        {
            case 0: 
                return false;
            case 1:
                return false;
            case 2: //Yankesicilik Yap
                return ayakkabi && bicak && yankesicilik;
            case 3:
                return ayakkabi && (gecekondu || daire || ev || villa || otel) && bicak && yankesicilik;
            case 4:
                return bisiklet && (gecekondu || daire || ev || villa || otel) && tabanca && acemi;
            case 5:
                return araba && (daire || ev || villa || otel) && pompali && usta && hirsizlik;
            case 6:
                return kamyon && (daire || ev || villa || otel) && makineli && usta;
            case 7:
                return tir && ev && makineli && usta;
            case 8:
                return tir && ev && celikyelek && makineli && tetikci && soygun;
            case 9:
                return gemi && villa && celikyelek && elbombasi && tetikci;
            case 10:
                return ucak && otel && celikyelek && roketatar && tetikci && soygun;
            case 11:
                return ucak && otel && celikyelek && roketatar && tetikci && soygun;

            default:
                return false;
        }
    }
    public void IhtiyacGoster(int isIndex)// Diziden gelen iþin ihtiyaç listesini Text objesine yazýyoruz
    {
        string[] kelimeler = ihtiyacListesi[isIndex].Split('.');
        string altAltaYazi = string.Join("\n", kelimeler);
        ihtiyacText.text = altAltaYazi;
        IhtiyacListesiPaneli.SetActive(true);
        bildirimCoroutine = StartCoroutine(PaneliKapat());
    }
    public void IhtiyaciGoster(int isIndex)
    {
        string[] kelimeler2 = ihtiyacListesi2[isIndex].Split('.');
        string altAltaYazi2 = string.Join("\n", kelimeler2);
        ihtiyacText.text = altAltaYazi2;
        IhtiyacListesiPaneli.SetActive(true);
        bildirimCoroutine = StartCoroutine(PaneliKapat());
    }

    IEnumerator PaneliKapat()
    {
        if (bildirimCoroutine != null)
        {
            StopCoroutine(bildirimCoroutine);
        }
        yield return new WaitForSeconds(1f);  // 1 saniye bekle
        IhtiyacListesiPaneli.SetActive(false);  // Paneli kapat
        bildirimCoroutine = null;
    }
    public IEnumerator BildirimGosterVeKapat()
    {
        if (bildirimCoroutine != null)
        {
            StopCoroutine(bildirimCoroutine);
        }
        yield return new WaitForSeconds(1f); 
        BildirimPaneli.SetActive(false);
        bildirimCoroutine = null;
    }
    public IEnumerator BildirimGosterVeKapat5sn()
    {
        if (bildirimCoroutine != null)
        {
            StopCoroutine(bildirimCoroutine);
        }
        yield return new WaitForSeconds(5f);
        BildirimPaneli.SetActive(false);
        bildirimCoroutine = null;
    }
    public IEnumerator BildirimKapat()
    {
        if (bildirimCoroutine != null)
        {
            StopCoroutine(bildirimCoroutine);
        }
        yield return new WaitForSeconds(1f);
        BildirimPaneli.SetActive(false);
        bildirimCoroutine = null;
    }
    public void CokYakinda()
    {
        bildirimText.text = bildirim[4];
        BildirimPaneli.SetActive(true);
        bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat());
    }
    public IEnumerator BildirimAcKapa()
    {
        if (bildirimCoroutine != null)
        {
            StopCoroutine(bildirimCoroutine);
        }
        yield return new WaitForSeconds(1f);
        KumarBildirimPaneli.SetActive(false);
        bildirimCoroutine = null;
    }

    public void KarakterPaneliAc()
    {PanelleriAc(); PanelleriAc(KarakterPaneli); Time.timeScale = 1f; }
    public void ProfilPaneliAc()
    { ProfilPaneli.SetActive(true);  }
    public void YemekPaneliAc()
    {PanelleriAc(KarakterPaneli, YemekPaneli); }
    public void EnerjiPaneliAc()
    {PanelleriAc(KarakterPaneli, EnerjiPaneli); }
    public void IslerPaneliAc()
    { PanelleriAc(MeslekPaneli); Time.timeScale = 1f; }
    public void LegalPaneliAc()
    {PanelleriAc(MeslekPaneli, LegalPaneli);}
    public void IllegalPaneliAc()
    { PanelleriAc(MeslekPaneli, IllegalPaneli); }
    public void KumarPaneliAc()
    { PanelleriAc(MeslekPaneli, KumarPaneli); ParaKoy21.text = ""; ParaKoyBarbut.text = ""; Time.timeScale = 1f; }
    public void RuletPaneliAc()
    {RuletPaneli.SetActive(true);
        BahisGir.text = 0.ToString();
        ParaKoy.text = ""; Time.timeScale = 1f;
    }
    public void RuletHelpPaneliAc()
    {
        panelAcik2 = !panelAcik2; // Panelin açýk olup olmadýðýný tersine çevir

        if (panelAcik2)
        {
            RuletHelpPaneli.SetActive(true); // Paneli aç
        }
        else
        {
            RuletHelpPaneli.SetActive(false); // Paneli kapat
        }
    }
    public void BlackJackPaneliAc()
    {   BlackJackPaneli.SetActive(true);
        BJBildirimPaneli.SetActive(false);
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
    public void BJHelpPaneliAc()
    {
        panelAcik = !panelAcik; // Panelin açýk olup olmadýðýný tersine çevir

        if (panelAcik)
        {
            BJHelpPaneli.SetActive(true); // Paneli aç
        }
        else
        {
            BJHelpPaneli.SetActive(false); // Paneli kapat
        }
        Time.timeScale = 1f;
    }
    public void ZarPaneliAc()
    { ZarPaneli.SetActive(true); Time.timeScale = 1f;
        dice1Image.sprite = zarGorselleri[5];
        dice2Image.sprite = zarGorselleri[5];
        TekrarAt.gameObject.SetActive(false);
        YeniOyun.gameObject.SetActive(false);
        BarbutButton.interactable = true;
        BarbutBildirim.text = "";
    }
    public void BarbutHelpPaneliAc()
    {
        panelAcik = !panelAcik; // Panelin açýk olup olmadýðýný tersine çevir

        if (panelAcik)
        {
            BarbutHelpPaneli.SetActive(true); // Paneli aç
        }
        else
        {
            BarbutHelpPaneli.SetActive(false); // Paneli kapat
        }
        Time.timeScale = 1f;
    }
    public void TefeciPaneliAc()
    { TefeciPaneli.SetActive(true); Tefeci.text = "";
      TefeciBildirim.text = "Demek paraya ihtiyacýn var? Burada kimse bedavaya yaþamaz. Faizler acýtýr, ama seni ayaða kaldýrýrým. Hazýr mýsýn? "; }
    public void EgitimPaneliAc()
    {PanelleriAc(EgitimPaneli); Time.timeScale = 1f; }
    public void AkademiPaneliAc()
    { PanelleriAc(EgitimPaneli, AkademiPaneli); Time.timeScale = 1f; }
    public void KriminalPaneliAc() 
    { PanelleriAc(EgitimPaneli, KriminalPaneli); Time.timeScale = 1f; }
    public void OzelEgitimPaneliAc() 
    { PanelleriAc(EgitimPaneli, OzelEgitimPaneli); }
    public void PazarPaneliAc()
    {PanelleriAc(PazarPaneli); Time.timeScale = 1f; }
    public void BarinmaPaneliAC() 
    { PanelleriAc(PazarPaneli, BarinmaPaneli); }
    public void AracPaneliAc() 
    { PanelleriAc(PazarPaneli,AracPaneli); }
    public void SilahPaneliAc() 
    { PanelleriAc(PazarPaneli, SilahPaneli); }
    public void MulkPaneliAc()
    { PanelleriAc(PazarPaneli, MulkPaneli); }

    public void AclikAzalt(int aclikazalmasi)
    {
        if (aclik > 0)
        {   
            aclik -= aclikazalmasi;
            if (aclik < 0)
            {
                aclik = 0;
            }
            AclikGuncelle();
            AclikBarGuncelle();
            DurumKontrol();
        }
    }
    public void EnerjiAzalt(int enerjiazalmasi)
    {
        if (enerji > 0)
        {
            enerji -= enerjiazalmasi;  
            if(enerji < 0)
            {
                enerji = 0;
            }
            EnerjiGuncelle();
            EnerjiBarGuncelle();
            DurumKontrol();
        }
    }
    public void ParaArtir(int paraartmasi)
    {
        para += paraartmasi;
        toplampara += paraartmasi;
        ParaGuncelle();
    }
    public void YemekYeme(int yemekIndex)
    {
        if (yemekIndex >= 0 && yemekIndex < yemekUcretleri.Length)// Yemek indexini kontrol et, geçerli bir deðer mi
        {
            int secilenYemekUcreti = yemekUcretleri[yemekIndex];
            int secilenartis = artis[yemekIndex];
            int secilendüsüs = düsüs[yemekIndex];

            if (para >= secilenYemekUcreti)
            {
                para -= secilenYemekUcreti;// Para yeterli, yemek yenebilir
                aclik += secilenartis;
                enerji -= secilendüsüs;

                if (aclik > 200)// Açlýk seviyesi max deðeri aþmasýn
                {
                    aclik = 200;
                }

                AclikGuncelle();
                AclikBarGuncelle();
                EnerjiGuncelle();
                EnerjiBarGuncelle();
                ParaGuncelle();
            }
        }
    }
    public void EnerjiYeme(int yemekIndex)
    {
        if (yemekIndex >= 0 && yemekIndex < yemekUcretleri.Length)// Yemek indexini kontrol et, geçerli bir deðer mi
        {
            int secilenYemekUcretii = yemekUcretleri[yemekIndex];
            int secilenartiss = artis[yemekIndex];
            int secilendüsüss = düsüs[yemekIndex];

            if (para >= secilenYemekUcretii)
            {
                para -= secilenYemekUcretii;// Para yeterli, yemek yenebilir
                enerji += secilenartiss;
                aclik -= secilendüsüss;

                if (enerji > 200)// Açlýk seviyesi max deðeri aþmasýn
                {
                    enerji = 200;
                }
                AclikGuncelle();
                AclikBarGuncelle();
                EnerjiGuncelle();
                EnerjiBarGuncelle();
                ParaGuncelle();

            }
            
        }
        
    }
    public void EsyaSatinAl(int esyaIndex)
    {
        if (esyaIndex >= 0 && esyaIndex < EsyaUcretleri.Length)
        {
            int esyaUcreti = EsyaUcretleri[esyaIndex];
            if (esyaIndex == 15 && !gecekondu && para >= 100) // Gecekondu Kirala
            {
                if (daire || ev || villa || otel)
                {
                    bildirimText.text = bildirim[1];
                    BildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat()); // Bildirim gösteriliyor ve 1 saniye sonra kapanýyor
                }
                else
                {
                    gecekondu = true;
                    gecekonduAlindigiGun = sayac; // Satýn alýnan gün kaydedilir
                    para -= esyaUcreti;
                    esyaAlindiMi[15] = true;
                    ParaGuncelle();
                    bildirimText.text = bildirim[0];
                    BildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat()); // Bildirim gösteriliyor ve 1 saniye sonra kapanýyor
                    barinmaText.text = bilgiListe[0];
                    PlayerPrefs.SetInt("esya_" + esyaIndex, 1); // 1 = satýn alýndý
                    PlayerPrefs.SetString("barinmasave", barinmaText.text);
                }
            }
            else if (esyaIndex == 16 && !daire && para >= 400) // Ev Kirala
            {
                if(ev || villa || otel)
                {
                    bildirimText.text = bildirim[1];
                    BildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat()); // Bildirim gösteriliyor ve 1 saniye sonra kapanýyor
                }
                else
                {
                    daire = true;
                    evAlindigiGun = sayac;
                    para -= esyaUcreti;
                    esyaAlindiMi[16] = true;
                    ParaGuncelle(); 
                    bildirimText.text = bildirim[0];
                    BildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat()); 
                    barinmaText.text = bilgiListe[1];
                    PlayerPrefs.SetInt("esya_" + esyaIndex, 1); // 1 = satýn alýndý
                    PlayerPrefs.SetString("barinmasave", barinmaText.text);
                }
            }
            else if (para >= esyaUcreti && !esyaAlindiMi[esyaIndex]) // Eþya alýnmamýþsa ve para yeterliyse
            {
                para -= esyaUcreti;

                // Eþya satýn alýndý, bool deðeri true olarak ayarlanýyor
                esyaAlindiMi[esyaIndex] = true;
                bildirimText.text = bildirim[0];
                BildirimPaneli.SetActive(true);
                bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat()); 

                if (esyaIndex <= 3)
                {
                    egitimText.text = bilgiListe[esyaIndex+12];
                    PlayerPrefs.SetString("egitimsave",egitimText.text);
                }
                else if(esyaIndex > 14 && esyaIndex<20)
                {
                    barinmaText.text = bilgiListe[esyaIndex - 15];
                    PlayerPrefs.SetString("barinmasave", barinmaText.text);
                }
                else if (esyaIndex >19 && esyaIndex < 27)
                {
                    aracText.text = bilgiListe[esyaIndex-15];
                    PlayerPrefs.SetString("aracsave", aracText.text);
                }
                if (para < 0)
                {
                    para = 0;
                }
                ParaGuncelle(); // Para güncelleniyor
                PlayerPrefs.SetInt("esya_" + esyaIndex, 1); // 1 = satýn alýndý
                Debug.Log("Eþya satýn alýndý: " + esyaIndex + "fiyat=" + EsyaUcretleri[esyaIndex]);
            }
            else if (esyaAlindiMi[esyaIndex])
            {
                bildirimText.text = bildirim[1];
                BildirimPaneli.SetActive(true);
                bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat()); // Bildirim gösteriliyor ve 1 saniye sonra kapanýyor
            }
            else
            {
                bildirimText.text = bildirim[2];
                BildirimPaneli.SetActive(true);
                bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat()); // Bildirim gösteriliyor ve 1 saniye sonra kapanýyor
            }
            switch (esyaIndex)
            {
                case 0:
                    ilkokul = true;
                    break;
                case 1:
                    lise = true;
                    break;
                case 2:
                    universite = true;
                    break;
                case 3:
                    master = true; ShowInterstitialAd();
                    break;
                case 4:
                    yankesicilik = true;
                    break;
                case 5:
                    hirsizlik = true;
                    break;
                case 6:
                    soygun = true;
                    break;
                case 7:
                    acemi = true;
                    break;
                case 8:
                    usta = true;
                    break;
                case 9:
                    tetikci = true; ShowInterstitialAd();
                    break;
                case 10:
                    ehliyet = true;
                    break;
                case 11:
                    ustalik = true;
                    break;
                case 12:
                    ekonomi = true;
                    break;
                case 13:
                    isletme = true;
                    break;
                case 14:
                    hukuk = true; ShowInterstitialAd();
                    break;
                case 17:
                    ev = true;
                    break;
                case 18:
                    villa = true;
                    break;
                case 19:
                    otel = true; ShowInterstitialAd();
                    break;
                case 20:
                    ayakkabi = true;
                    break;
                case 21:
                    bisiklet = true;
                    break;
                case 22:
                    araba = true;
                    break;
                case 23:
                    kamyon = true;
                    break;
                case 24:
                    tir = true;
                    break;
                case 25:
                    gemi = true;
                    break;
                case 26:
                    ucak = true; ShowInterstitialAd();
                    break;
                case 27:
                    bicak = true;
                    break;
                case 28:
                    tabanca = true;
                    break;
                case 29:
                    pompali = true;
                    break;
                case 30:
                    makineli = true;
                    break;
                case 31:
                    celikyelek = true;
                    break;
                case 32:
                    elbombasi = true;
                    break;
                case 33:
                    roketatar = true; ShowInterstitialAd();
                    break;
            }
            PlayerPrefs.SetInt("ilkokul", ilkokul ? 1 : 0);
            PlayerPrefs.SetInt("lise", lise ? 1 : 0);
            PlayerPrefs.SetInt("universite", universite ? 1 : 0);
            PlayerPrefs.SetInt("master", master ? 1 : 0);
            PlayerPrefs.SetInt("yankesicilik", yankesicilik ? 1 : 0);
            PlayerPrefs.SetInt("hirsizlik", hirsizlik ? 1 : 0);
            PlayerPrefs.SetInt("soygun", soygun ? 1 : 0);
            PlayerPrefs.SetInt("acemi", acemi ? 1 : 0);
            PlayerPrefs.SetInt("usta", usta ? 1 : 0);
            PlayerPrefs.SetInt("tetikci", tetikci ? 1 : 0);
            PlayerPrefs.SetInt("ehliyet", ehliyet ? 1 : 0);
            PlayerPrefs.SetInt("ustalik", ustalik ? 1 : 0);
            PlayerPrefs.SetInt("ekonomi", ekonomi ? 1 : 0);
            PlayerPrefs.SetInt("isletme", isletme ? 1 : 0);
            PlayerPrefs.SetInt("hukuk", hukuk ? 1 : 0);
            PlayerPrefs.SetInt("gecekondu", gecekondu ? 1 : 0);
            PlayerPrefs.SetInt("daire", daire ? 1 : 0);
            PlayerPrefs.SetInt("ev", ev ? 1 : 0);
            PlayerPrefs.SetInt("villa", villa ? 1 : 0);
            PlayerPrefs.SetInt("otel", otel ? 1 : 0);
            PlayerPrefs.SetInt("ayakkabi", ayakkabi ? 1 : 0);
            PlayerPrefs.SetInt("bisiklet", bisiklet ? 1 : 0);
            PlayerPrefs.SetInt("araba", araba ? 1 : 0);
            PlayerPrefs.SetInt("kamyon", kamyon ? 1 : 0);
            PlayerPrefs.SetInt("tir", tir ? 1 : 0);
            PlayerPrefs.SetInt("gemi", gemi ? 1 : 0);
            PlayerPrefs.SetInt("ucak", ucak ? 1 : 0);
            PlayerPrefs.SetInt("bicak", bicak ? 1 : 0);
            PlayerPrefs.SetInt("tabanca", tabanca ? 1 : 0);
            PlayerPrefs.SetInt("pompali", pompali ? 1 : 0);
            PlayerPrefs.SetInt("makineli", makineli ? 1 : 0);
            PlayerPrefs.SetInt("celikyelek", celikyelek ? 1 : 0);
            PlayerPrefs.SetInt("elbombasi", elbombasi ? 1 : 0);
            PlayerPrefs.SetInt("roketatar", roketatar ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public void MulkSatinAl(int mulk)
    {
        int mulkUcreti = MulkUcretleri[mulk];
        if (para >= mulkUcreti && !mulkAlindiMi[mulk])
        {
            mulkAlindiMi[mulk] = true;
            para -= mulkUcreti;
            bildirimText.text = bildirim[8];
            BildirimPaneli.SetActive(true);
            bildirimCoroutine =StartCoroutine(BildirimGosterVeKapat());
            PlayerPrefs.SetInt("esya__" + mulk, 1);
            ParaGuncelle();
            sonParaGunu[mulk] = sayac;
            TutulduMu[mulk].text = "<color=green>Satýn alýndý</color>\n" + "Ödeme için " + hasilat[mulk] + "gün";
            PlayerPrefs.SetString("TutulduMu_" + mulk, TutulduMu[mulk].text);
            PlayerPrefs.Save();
            ShowInterstitialAd();
        }
        else if (mulkAlindiMi[mulk])
        {
            bildirimText.text = bildirim[1];
            BildirimPaneli.SetActive(true);
            bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat());
        }
        else
        {
            bildirimText.text = bildirim[2];
            BildirimPaneli.SetActive(true);
            bildirimCoroutine = StartCoroutine(BildirimGosterVeKapat());
        }
    }
    void MulkGeliriKontrol()
    {
        for (int i = 0; i < mulkAlindiMi.Length; i++)
        {
            if (mulkAlindiMi[i] && sayac - sonParaGunu[i] >= 30)
            {
                TutulduMu[i].text = "<color=green>Satýn alýndý</color>\n" + "Ödeme için " + hasilat[i] + "gün";
                PlayerPrefs.SetString("TutulduMu_" + i, TutulduMu[i].text);
                PlayerPrefs.Save();
                //para += MulkKazanclari[i]; // Mülk gelirini ekler
                //toplampara += MulkKazanclari[i];
                //sonParaGunu[i] = sayac; // Son para eklenen gün güncellenir
                //ParaGuncelle();
            }
        }
    }
    void Hasilat()
    {
        for (int i = 0; i < TutulduMu.Length; i++)
        {
            if (mulkAlindiMi[i]) // Eðer TutulduMu[i] aktifse
            {
                hasilat[i]--;
                
                if (hasilat[i] == 0) 
                {
                    para += MulkKazanclari[i];
                    toplampara += MulkKazanclari[i];
                    hasilat[i] = hasilatDegeri; // Hasýlatý tekrar 30 olarak baþlat
                    sonParaGunu[i] = sayac;
                    ParaGuncelle(); 
                }
                TutulduMu[i].text = "<color=green>Satýn alýndý</color>\n" + "Ödeme için " + hasilat[i] + "gün";
                PlayerPrefs.SetString("TutulduMu_" + i, TutulduMu[i].text);
                PlayerPrefs.Save();
            }
            
            PlayerPrefs.SetInt("hasilat_" + i, hasilat[i]);
            PlayerPrefs.Save();
        }
    }
    void AclikGuncelle()
    {
        aclikText.text = aclik.ToString() + "/200";
        aclikText2.text = aclik.ToString() + "/200";
        PlayerPrefs.SetInt("acliksave", aclik);
    }
    void EnerjiGuncelle()
    {
        enerjiText.text = enerji.ToString() + "/200";
        enerjiText2.text = enerji.ToString() + "/200";
        PlayerPrefs.SetInt("enerjisave", enerji);

    }
    void ParaGuncelle()
    {
        paraText.text = para.ToString() + "$";
        paraText2.text= para.ToString() + "$";
        toplamParaText.text=toplampara.ToString() + "$";
        PlayerPrefs.SetInt("parasave", para);
        PlayerPrefs.SetInt("ToplamPara", toplampara);
    }
    void AclikBarGuncelle()
    {    
        float fillValue = (float)aclik / 200.0f;  // Açlýk deðerini 0-1 arasý bir deðere dönüþtür
        aclikBar.fillAmount = fillValue;          // Barýn doluluk oranýný güncelle
        aclikBar.color = Color.Lerp(aclikColorEnd, aclikColorStart, fillValue);  //Barýn rengini açlýk durumuna göre deðiþtirmek için
        aclikBar2.fillAmount = fillValue;
        aclikBar2.color = Color.Lerp(aclikColorEnd, aclikColorStart, fillValue);
    }
    void EnerjiBarGuncelle()
    {
        float fillValue = (float)enerji / 200.0f;  
        enerjiBar.fillAmount = fillValue;          
        enerjiBar.color = Color.Lerp(enerjiColorEnd, enerjiColorStart, fillValue);
        enerjiBar2.fillAmount = fillValue;
        enerjiBar2.color = Color.Lerp(enerjiColorEnd, enerjiColorStart, fillValue);
    }
    #endregion

    #region Rulet
    public void RuletBahisYap()
    {
        int.TryParse(BahisGir.text, out bahisGir);
        int.TryParse(ParaKoy.text, out paraKoy);
        int ruletSonucu = rnd.Next(0, 37); // 0-36 arasý bir sayý döner
        string ruletRengi = renkler[ruletSonucu]; // Sonucun rengi

        if (bahisGir>=0 && bahisGir<37 && paraKoy>0 && para>=paraKoy)
        {
            reklamSayaci++;
            para -= paraKoy;
            
            if(bahisGir == ruletSonucu)
            {
                int y = 35 * paraKoy;
                para += y;
                toplampara += y;
                RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + y + "$";
                KumarBildirimPaneli.SetActive(true);
                bildirimCoroutine = StartCoroutine(BildirimAcKapa());
            }
            else
            {
                RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                KumarBildirimPaneli.SetActive(true);
                bildirimCoroutine = StartCoroutine(BildirimAcKapa());
            }
            ParaGuncelle();
            if (reklamSayaci == 12)
            {
                ShowInterstitialAd();
                reklamSayaci = 0;
            }
        }
        else
        {
            RuletBildirimText.text = "Geçersiz Bahis" ;
            KumarBildirimPaneli.SetActive(true);
            bildirimCoroutine = StartCoroutine(BildirimAcKapa());
        }
    }
    public void RuletOyna(int bahis)
    {
        int.TryParse(ParaKoy.text, out paraKoy);
        if (paraKoy > 0 && para>=paraKoy) 
        { 
            int ruletSonucu = rnd.Next(0, 37); // 0-36 arasý bir sayý döner
            string ruletRengi = renkler[ruletSonucu]; // Sonucun rengi
            reklamSayaci++;
            para -= paraKoy;

            if (bahis == 0)
            {
                if(ruletSonucu > 0 && ruletSonucu < 13)
                {
                    int a = 3* paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }

            }
            else if (bahis == 1)
            {
                if (ruletSonucu > 12 && ruletSonucu < 25)
                {
                    int a = 3 * paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
            }
            else if (bahis == 2)
            {
                if (ruletSonucu > 24 && ruletSonucu < 37)
                {
                    int a = 3 * paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
            }
            else if (bahis == 3)
            {
                int[] sayilar = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };
                if (sayilar.Contains(ruletSonucu))
                {
                    int a = 3 * paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
            }
            else if (bahis == 4)
            {
                int[] sayilar = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
                if (sayilar.Contains(ruletSonucu))
                {
                    int a = 3 * paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
            }
            else if (bahis == 5)
            {
                int[] sayilar = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
                if (sayilar.Contains(ruletSonucu))
                {   
                    int a = 3 * paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
            }
            else if (bahis == 6)
            {
                if (ruletSonucu>0 && ruletSonucu<19)
                {
                    int a = 2 * paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
            }
            else if (bahis == 7)
            {
                if(ruletSonucu % 2 == 0)
                {
                    int a = 2 * paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
            }
            else if (bahis == 8)
            {
                int[] kirmiziSayilar = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 21, 23, 25, 27, 28, 30, 32, 34, 36 };
                if (kirmiziSayilar.Contains(ruletSonucu))
                {
                    int a = 2 * paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
            }
            else if (bahis == 9)
            {
                int[] kirmiziSayilar = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 19, 20, 22, 24, 26, 29, 31, 33, 35 };
                if (kirmiziSayilar.Contains(ruletSonucu))
                {
                    int a = 2 * paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
            }
            else if (bahis == 10)
            {
                if (ruletSonucu % 2 != 0)
                {
                    int a = 2 * paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
            }
            else if (bahis == 11)
            {
                if (ruletSonucu > 18 && ruletSonucu < 37)
                {
                    int a = 2 * paraKoy;
                    para += a;
                    toplampara += a;
                    RuletBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi + "\n" + "+" + a + "$";
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
                else
                {
                    RuletBildirimText.text = "<color=red>KAYBETTÝN</color>\n" + "\n" + ruletSonucu.ToString() + " " + ruletRengi;
                    KumarBildirimPaneli.SetActive(true);
                    bildirimCoroutine = StartCoroutine(BildirimAcKapa());
                }
            }
            ParaGuncelle();
            if (reklamSayaci == 12)
            {
                ShowInterstitialAd();
                reklamSayaci = 0;
            }
        }
        else
        {
            RuletBildirimText.text = "Geçersiz Bahis";
            KumarBildirimPaneli.SetActive(true);
            bildirimCoroutine = StartCoroutine(BildirimAcKapa());
        }

    }
    #endregion

    #region Black Jack
    public void BJOyna()
    {
        reklamSayaci++;
        hitCount = 0;
        kart3 = 0;
        int.TryParse(ParaKoy21.text, out paraKoy21);

        if (para >= paraKoy21 && paraKoy21 >= 100)
        {
            para -= paraKoy21;
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
                para += 3 * paraKoy21;
                toplampara += 3 * paraKoy21;
                Hit.interactable = false;
                Stand.interactable = false;
                BJBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>" + "\n" + "+" + paraKoy21*3 + "$";
                BJBildirimPaneli.SetActive(true);
            }
            ParaGuncelle();
        }
        else
        {
            RuletBildirimText.text = "Geçersiz Bahis\n"+"Minimum Bahis 100$" ;
            KumarBildirimPaneli.SetActive(true);
            bildirimCoroutine = StartCoroutine(BildirimAcKapa());
        }
        if (reklamSayaci == 12)
        {
            reklamSayaci = 0;
            ShowInterstitialAd();
        }
    }
    public void HitBas()
    {
        if (deste.Count > 0 && hitCount < 5) 
        { // Sadece 3 kart eklemek için kontrol        
            int rastgeleKart = Random.Range(1, deste.Count);
            int kart=deste[rastgeleKart];
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
                    BJBildirimText.text = "<color=red>KAYBETTÝNÝZ</color>";
                    BJBildirimPaneli.SetActive(true);
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
                para += 3 * paraKoy21;
                toplampara += 3 * paraKoy21;
                BJBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>" + "\n" + "+" + paraKoy21 * 3 + "$";
                BJBildirimPaneli.SetActive(true);
                ParaGuncelle();
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
        K2.sprite= secilenKart;
        kurpierPuan = kartDegerleri[kart3] + kartDegerleri[kart4];
        Debug.Log("kart3:" + kartDegerleri[kart3] + " kart4:" + kartDegerleri[kart4]+","+asSayisiKurpiyer);
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
            K3.sprite= secilenKart5;
            kurpierPuan += kartDegerleri[kart5];
            K3.color = new Color(O1.color.r, O1.color.g, O1.color.b, 1f);
            if (kartDegerleri[kart5] == 11) asSayisiKurpiyer++;
            Debug.Log("kart5:"+kartDegerleri[kart5] + "," + asSayisiKurpiyer);
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
            
            Debug.Log("Kurpiyer puaný: "+kurpierPuan);
        }
        
        if (kurpierPuan >= 17)
        {
            if (oyuncuPuan > kurpierPuan)
            {
                para += 2 * paraKoy21;
                toplampara += 2 * paraKoy21;
                BJBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>" + "\n" + "+" + paraKoy21 * 2 + "$";
                BJBildirimPaneli.SetActive(true);
                ParaGuncelle();
            }
            else if (oyuncuPuan < kurpierPuan) 
            {
                if (kurpierPuan > 21)
                {
                    para += 2 * paraKoy21;
                    toplampara += 2 * paraKoy21;
                    BJBildirimText.text = "<color=green>TEBRÝKLER KAZANDINIZ</color>" + "\n" + "+" + paraKoy21 * 2 + "$";
                    BJBildirimPaneli.SetActive(true);
                    ParaGuncelle();
                }
                else
                {
                    BJBildirimText.text = "<color=red>KAYBETTÝNÝZ</color>";
                    BJBildirimPaneli.SetActive(true);
                }
            }
            else if (oyuncuPuan == kurpierPuan)
            {
                BJBildirimText.text = "<color=white>BERABERE</color>";
                BJBildirimPaneli.SetActive(true);
                para += paraKoy21;
                toplampara += paraKoy21;
                ParaGuncelle() ;
            }
            Debug.Log(kart3+ "," +kart4 + "Kurpiyer kart çekmeyecek"+kurpierPuan);
        }
        hitCount = 0;
        kart3= 0;
    }
    #endregion

    #region Zar Oyunu
    public void BarbutOyna()
    {
        reklamSayaci++;
        int.TryParse(ParaKoyBarbut.text, out paraKoyBarbut);
        BarbutBildirim.text = "";

        if (para >= paraKoyBarbut && paraKoyBarbut >= 50)
        {
            para -= paraKoyBarbut;
            dice1Result = Random.Range(1, 7); // 1-6 arasý bir sayý döner.
            dice2Result = Random.Range(1, 7);

            dice1Image.sprite = zarGorselleri[dice1Result-1];        // Zar yüzeylerinin güncellenmesi
            dice2Image.sprite = zarGorselleri[dice2Result-1];
            int toplam = dice1Result + dice2Result;
            if (toplam == 7 || toplam == 11)
            {
                BarbutBildirim.text = "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "\n" + "TEBRÝKLER KAZANDINIZ" + "\n" + "+" + paraKoyBarbut * 2 + "$";
                para += paraKoyBarbut * 2;
                toplampara += paraKoyBarbut * 2;
                YeniOyun.gameObject.SetActive(true);
                BarbutButton.interactable = false;
            }
            else if (toplam == 2 || toplam == 3 || toplam == 12)
            {
                BarbutBildirim.text = "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "\n" + "KAYBETTÝNÝZ";
                YeniOyun.gameObject.SetActive(true);
                BarbutButton.interactable = false;
            }
            else
            {
                TekrarAt.gameObject.SetActive(true);
                BarbutButton.interactable = false;
                BarbutPuan = toplam;
                BarbutBildirim.text = "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "Puanýnýz: " + BarbutPuan.ToString() + "\n" + "TEKRAR ZAR ATIN";
            }
            ParaGuncelle();
        }
        else
        {
            RuletBildirimText.text = "Geçersiz Bahis\n" + "Minimum Bahis 50$";
            KumarBildirimPaneli.SetActive(true);
            bildirimCoroutine = StartCoroutine(BildirimAcKapa());
        }
        if (reklamSayaci == 12)
        {
            reklamSayaci = 0;
            ShowInterstitialAd();
        }
    }
    public void BarbutTekrarAt()
    {
        dice1Result = Random.Range(1, 7); // 1-6 arasý bir sayý döner.
        dice2Result = Random.Range(1, 7);

        dice1Image.sprite = zarGorselleri[dice1Result - 1];        // Zar yüzeylerinin güncellenmesi
        dice2Image.sprite = zarGorselleri[dice2Result - 1];
        int toplam = dice1Result + dice2Result;
        if (toplam==BarbutPuan)
        {
            BarbutBildirim.text = "Puanýnýz: " + BarbutPuan.ToString() + "\n" + "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "\n" + "TEBRÝKLER KAZANDINIZ" + "\n" + "+" + paraKoyBarbut * 3 + "$";
            BarbutPuan = 0;
            para += paraKoyBarbut * 3;
            toplampara += paraKoyBarbut * 3;
            TekrarAt.gameObject.SetActive(false);
            YeniOyun.gameObject.SetActive(true);
        }
        else if (toplam == 7)
        {
            BarbutBildirim.text = "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "\n" + "KAYBETTÝNÝZ";
            BarbutPuan = 0;
            TekrarAt.gameObject.SetActive(false);
            YeniOyun.gameObject.SetActive(true);
            BarbutButton.interactable = false;
        }
        else
        {
            BarbutBildirim.text = "Puanýnýz: " + BarbutPuan.ToString() + "\n" + "Zarlarýn Toplamý: " + toplam.ToString() + "\n" + "TEKRAR ZAR ATIN";
        }
        ParaGuncelle();
    }
    #endregion

    #region Tefeci
    public void TefeciButon()
    {
        int.TryParse(Tefeci.text, out tefeci);
        if (toplampara > 50000)
        {
            if (tefeci >=5000 && tefeci<=25000 && !TefecidenAldýMi)
            {
                TefeciBildirim.text = tefeci.ToString() + " dolar...\n" + "Umarým bu parayý kullanmayý biliyorsundur. Geri ödemezsen bacaklarýný da faize eklerim. Al þimdi ve 30 gün içinde 2 katý olarak geri öde.";
                para += tefeci;
                toplampara += tefeci;
                tefeciOdemeGunu = sayac;
                ParaGuncelle();
                Tefeci.text = "";
                borc = tefeci * 2;
                BorcMiktari.text = borc.ToString();
                PlayerPrefs.SetString("BorçMiktarý", BorcMiktari.text);
                TefecidenAldýMi = true;
                PlayerPrefs.SetInt("TefecidenAldýMý", 1);
                Odemegunu = 30;
                OdemeGunu.text = "30 Gün";
            }
            else if (tefeci >= 5000 && tefeci < 25000 && TefecidenAldýMi)
            {
                TefeciBildirim.text = "Yeni baþlangýçlar için eski defterleri kapatmalýsýn.";
            }
            else
            {
                TefeciBildirim.text = "Bu meblað için baþýný derde sokmana deðmez. En az 5000$ en fazla 25000$ veririm sana. ";
            }
        }
        else if (toplampara >= 5000 && toplampara<=50000)
        {
            if (tefeci >=500 && tefeci<=5000 && !TefecidenAldýMi)
            {
                TefeciBildirim.text = tefeci.ToString() + " dolar...\n" + "Umarým bu parayý kullanmayý biliyorsundur. Geri ödemezsen bacaklarýný da faize eklerim. Al þimdi ve 30 gün içinde 2 katý olarak geri öde.";
                para += tefeci;
                toplampara += tefeci;
                tefeciOdemeGunu = sayac;
                ParaGuncelle();
                Tefeci.text = "";
                borc = tefeci * 2;
                BorcMiktari.text=borc.ToString();
                PlayerPrefs.SetString("BorçMiktarý", BorcMiktari.text);
                TefecidenAldýMi = true;
                PlayerPrefs.SetInt("TefecidenAldýMý", 1);
                Odemegunu = 30;
                OdemeGunu.text = "30 Gün";
            }
            else if(tefeci >= 500 && tefeci <= 5000 && TefecidenAldýMi)
            {
                TefeciBildirim.text = "Yeni baþlangýçlar için eski defterleri kapatmalýsýn.";
            }
            else
            {
                TefeciBildirim.text = "Bu meblað için baþýný derde sokmana deðmez. En az 500$ en fazla 5000$ veririm sana. ";
            }
        }
        else if (toplampara < 5000)
        {
            if (tefeci == 500 && !TefecidenAldýMi)
            {
                TefeciBildirim.text = tefeci.ToString() + " dolar...\n" + "Umarým bu parayý kullanmayý biliyorsundur. Geri ödemezsen bacaklarýný da faize eklerim. Al þimdi ve 30 gün içinde 2 katý olarak geri öde.";
                para += tefeci;
                toplampara += tefeci;
                tefeciOdemeGunu = sayac;
                ParaGuncelle();
                Tefeci.text = "";
                borc = tefeci * 2;
                BorcMiktari.text = borc.ToString();
                PlayerPrefs.SetString("BorçMiktarý", BorcMiktari.text);
                TefecidenAldýMi = true;
                PlayerPrefs.SetInt("TefecidenAldýMý", 1);
                Odemegunu = 30;
                OdemeGunu.text = "30 Gün";
            }
            else if (tefeci ==500 && TefecidenAldýMi)
            {
                TefeciBildirim.text = "Yeni baþlangýçlar için eski defterleri kapatmalýsýn.";
            }
            else
            {
                TefeciBildirim.text = "Bu meblað için baþýný derde sokmana deðmez. Henüz buralarda yeni olduðun için 500$ veririm sana. ";
            }
        }
        
    }
    public void BorcOde()
    {
        if (borc > 0 && para >= borc)
        {
            TefeciBildirim.text = "Ýyi iþ çýkardýn. Borcunu zamanýnda ödedin, bu hoþuma gitti. Tekrar ihtiyacýn olursa bilirsin, buralardayým.";
            para -= borc;
            borc = 0;
            BorcMiktari.text=borc.ToString();
            PlayerPrefs.SetString("BorçMiktarý", BorcMiktari.text);
            tefeciOdemeGunu = -1;
            Odemegunu = 0;
            OdemeGunu.text = Odemegunu.ToString();
            PlayerPrefs.SetInt("ÖdemeGünü", Odemegunu);
            PlayerPrefs.SetInt("ÖdemeGünü", -1);
            tefeciPanelAcildi = false;
            PlayerPrefs.SetInt("TefeciPanelAçýldý", 0);
            ParaGuncelle();
            TefecidenAldýMi = false;
            PlayerPrefs.SetInt("TefecidenAldýMý", 0);
            PlayerPrefs.Save();
        }
        else if (borc > 0 && para < borc) 
        {
            TefeciBildirim.text = "Bu kadarý yetmez. Borçlarýn bu kadar küçük deðil. Bir dahaki sefere tam getir, yoksa bu son görüþmemiz olmaz.";
        }
    }
    #endregion

    #region save-load-ads
    public void BaslaButonunaBasildi()
    {
        OyunuYukle();
        //ShowInterstitialAd();  //reklamý gösterecek olan fonksiyon
    }
    public void OyunuYenidenBaslat()
    {
        Time.timeScale = 1f; // Oyunu normal hýza döndür
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahneyi yeniden yükle
        PlayerPrefs.DeleteAll();
        Start();
    }
    public void OyunuKaydet()
    {
        PlayerPrefs.SetInt("Gün", gun);
        PlayerPrefs.SetInt("Sayac", sayac);
        PlayerPrefs.SetInt("GeceKonduGün", gecekonduAlindigiGun);
        PlayerPrefs.SetInt("DaireGün", evAlindigiGun);
        PlayerPrefs.SetInt("TefeciGünü", tefeciOdemeGunu);
        PlayerPrefs.SetInt("Yas", yas);
        PlayerPrefs.SetInt("Borç", borc);
        PlayerPrefs.SetInt("ToplamPara", toplampara);
        PlayerPrefs.SetInt("KötülükSayacý", kotulukSayac);
        PlayerPrefs.SetInt("ÝyilikSayacý", iyilikSayac);

        for (int i = 0; i < sonParaGunu.Length; i++)
        {
            PlayerPrefs.SetInt("sonParaGunu_" + i, sonParaGunu[i]);
        }

        PlayerPrefs.Save();
    }
    public void OyunuYukle()
    {
        for (int i = 0; i < esyaAlindiMi.Length; i++)
        {
            // Kaydedilmiþ eþya durumunu yükle (varsayýlan 0 yani alýnmamýþ)
            esyaAlindiMi[i] = PlayerPrefs.GetInt("esya_" + i, 0) == 1;
        }
        for (int j = 0; j < mulkAlindiMi.Length; j++)
        {
            mulkAlindiMi[j] = PlayerPrefs.GetInt("esya__" + j, 0) == 1;
        }
        for (int i = 0; i < sonParaGunu.Length; i++)
        {
            sonParaGunu[i] = PlayerPrefs.GetInt("sonParaGunu_" + i, 0);
        }
        for(int j = 0; j<TutulduMu.Length; j++)
        {
            if (PlayerPrefs.HasKey("TutulduMu_" + j)) // Eðer anahtar varsa
            {
                TutulduMu[j].text = PlayerPrefs.GetString("TutulduMu_" + j); // Metni geri yükle
            }
        }
        for (int i = 0; i < hasilat.Length; i++)
        {
            hasilat[i] = PlayerPrefs.GetInt("hasilat_" + i, hasilatDegeri); // Eðer PlayerPrefs'te yoksa 30'la baþlat
        }
        string kayitlibarinma = PlayerPrefs.GetString("barinmasave", "Park");
        barinmaText.text = kayitlibarinma;
        string kayitliarac = PlayerPrefs.GetString("aracsave", "Yalýnayak");
        aracText.text = kayitliarac;
        string kayitliegitim = PlayerPrefs.GetString("egitimsave", "Yok");
        egitimText.text = kayitliegitim;

        ilkokul = PlayerPrefs.GetInt("ilkokul", 0) == 1;
        lise = PlayerPrefs.GetInt("lise", 0) == 1;
        universite = PlayerPrefs.GetInt("universite", 0) == 1;
        master = PlayerPrefs.GetInt("master", 0) == 1;
        yankesicilik = PlayerPrefs.GetInt("yankesicilik", 0) == 1;
        hirsizlik = PlayerPrefs.GetInt("hirsizlik", 0) == 1;
        soygun = PlayerPrefs.GetInt("soygun", 0) == 1;
        acemi = PlayerPrefs.GetInt("acemi", 0) == 1;
        usta = PlayerPrefs.GetInt("usta", 0) == 1;
        tetikci = PlayerPrefs.GetInt("tetikci", 0) == 1;
        ehliyet = PlayerPrefs.GetInt("ehliyet", 0) == 1;
        ustalik = PlayerPrefs.GetInt("ustalik", 0) == 1;
        ekonomi = PlayerPrefs.GetInt("ekonomi", 0) == 1;
        isletme = PlayerPrefs.GetInt("isletme", 0) == 1;
        hukuk = PlayerPrefs.GetInt("hukuk", 0) == 1;
        gecekondu = PlayerPrefs.GetInt("gecekondu", 0) == 1;
        daire = PlayerPrefs.GetInt("daire", 0) == 1;
        ev = PlayerPrefs.GetInt("ev", 0) == 1;
        villa = PlayerPrefs.GetInt("villa", 0) == 1;
        otel = PlayerPrefs.GetInt("otel", 0) == 1;
        ayakkabi = PlayerPrefs.GetInt("ayakkabi", 0) == 1;
        bisiklet = PlayerPrefs.GetInt("bisiklet", 0) == 1;
        araba = PlayerPrefs.GetInt("araba", 0) == 1;
        kamyon = PlayerPrefs.GetInt("kamyon", 0) == 1;
        tir = PlayerPrefs.GetInt("tir", 0) == 1;
        gemi = PlayerPrefs.GetInt("gemi", 0) == 1;
        ucak = PlayerPrefs.GetInt("ucak", 0) == 1;
        bicak = PlayerPrefs.GetInt("bicak", 0) == 1;
        tabanca = PlayerPrefs.GetInt("tabanca", 0) == 1;
        pompali = PlayerPrefs.GetInt("pompali", 0) == 1;
        makineli = PlayerPrefs.GetInt("makineli", 0) == 1;
        celikyelek = PlayerPrefs.GetInt("celikyelek", 0) == 1;
        elbombasi = PlayerPrefs.GetInt("elbombasi", 0) == 1;
        roketatar = PlayerPrefs.GetInt("roketatar", 0) == 1;
        para = PlayerPrefs.GetInt("parasave", 0); // Varsayýlan deðeri 0
        toplampara = PlayerPrefs.GetInt("ToplamPara", 0);
        aclik = PlayerPrefs.GetInt("acliksave", 200); // Varsayýlan olarak 200 verelim
        enerji = PlayerPrefs.GetInt("enerjisave", 200);
        iyilik = PlayerPrefs.GetInt("iyiliksave", 0);
        iyilikSayac = PlayerPrefs.GetInt("ÝyilikSayacý", 0);
        kotuluk = PlayerPrefs.GetInt("kotuluksave", 0);
        kotulukSayac = PlayerPrefs.GetInt("KötülükSayacý", 0);
        yas = PlayerPrefs.GetInt("Yas", 18);
        sayac = PlayerPrefs.GetInt("Sayac", 1);
        gun = PlayerPrefs.GetInt("Gün", 1);
        borc = PlayerPrefs.GetInt("Borç", 0);
        Odemegunu = PlayerPrefs.GetInt("ÖdemeGünü", 0);
        gecekonduAlindigiGun = PlayerPrefs.GetInt("GeceKonduGün", -1);
        evAlindigiGun = PlayerPrefs.GetInt("DaireGün", -1);
        tefeciOdemeGunu = PlayerPrefs.GetInt("TefeciGünü", -1);
        tefeciPanelAcildi = PlayerPrefs.GetInt("TefeciPanelAçýldý", 0) == 1;
        TefecidenAldýMi = PlayerPrefs.GetInt("TefecidenAldýMý", 0) == 1;
        EnerjiBarGuncelle();
        AclikBarGuncelle();
        Debug.Log("Oyun yüklendi.");
    }
    void OnApplicationQuit()
    {
        OyunuKaydet(); // Oyun kapatýlýrken kaydet
    }
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // Uygulama arka plana alýndýðýnda oyunu kaydet
            OyunuKaydet();
        }
    }
    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            // Uygulama odak dýþýna çýktýðýnda oyunu kaydet
            OyunuKaydet();
        }
    }

    public void LoadLoadInterstitialAd()    //Reklamý oluþturan fonksiyon reklam izlendikten sonra bu fonksiyonun tekrar çaðrýlmasý lazým bir sonraki video oluþsun diye
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }
        //Debug.Log("Geçiþ reklamý Yüklendi");

        var adRequest = new AdRequest();
        InterstitialAd.Load(adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {

                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad" + " With error " + error);
                    return;
                }
                //Debug.Log("Geçiþ reklam response: " + ad.GetResponseInfo());
                interstitialAd = ad;
            });

    }
    public void ShowInterstitialAd()  //Reklamý ekrana yansýtan fonksiyon
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            //Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
        }
        else
        {
            //Debug.LogError("Interstitial ad is not ready yet.");
        }
        LoadLoadInterstitialAd();
        Time.timeScale = 1f;
    }
    public void RequestBanner()
    {
        bannerReklam = new BannerView(adUnitIdBanner, AdSize.Banner, AdPosition.Top);   // Banner'ý oluþturalým
        AdRequest request = new AdRequest();    // Reklam isteðini yapalým.
        bannerReklam.LoadAd(request);
    }
    public void LoadOdulluReklam()
    {
        BirSans.gameObject.SetActive(true);
        if (odulluReklam != null)
        {
            odulluReklam.Destroy();
            odulluReklam = null;
        }
       // Debug.Log("Ödüllü reklam yüklendi");
        var adRequest = new AdRequest();
        RewardedAd.Load(adUnitIdOdul, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    //Debug.LogError("Rewarded ad failer" + error);
                    return;
                }
                //Debug.Log("Ödüllü reklam response: " + ad.GetResponseInfo());
                odulluReklam = ad;
            });
    }
    public void ShowRewardAd()
    {
        if (odulluReklam != null && odulluReklam.CanShowAd())
        {
            odulluReklam.Show((Reward reward) =>
            {
                if (enerji == 0 || aclik == 0)
                {
                    enerji = 20;
                    aclik = 20;
                    AclikGuncelle();
                    AclikBarGuncelle();
                    EnerjiGuncelle();
                    EnerjiBarGuncelle();
                    PanelleriAc(KarakterPaneli);
                }
                else
                {
                    if (toplampara <= 1000)
                    {
                        para += 10;
                        toplampara += 10;
                        ParaGuncelle();
                    }
                    else if (toplampara >= 20000)
                    {
                        para += 1000;
                        toplampara += 1000;
                        ParaGuncelle();
                    }
                    else
                    {
                        para += (toplampara / 100) * 5;
                        toplampara += (toplampara / 100) * 5;
                        ParaGuncelle();
                    }
                    LoadOdulluReklam();
                }
            });
        }
        
    }

    #endregion

}

