using UnityEngine;

public class PurchaseUIBuilder : MonoBehaviour
{
    public PurchaseItemList itemList;
    public PurchaseManager purchaseManager;

    public Transform content;
    public GameObject purchaseButtonPrefab;

    private void Start()
    {
        BuildUI();
    }

    public void BuildUI()
    {
        foreach (var item in itemList.items)
        {
            GameObject obj = Instantiate(purchaseButtonPrefab, content);
            obj.GetComponent<PurchaseButtonUI>().Setup(item, purchaseManager);
        }
    }
}
