using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour
{
    public CharacterStats stats;
    public PurchaseManager purchaseManager;
    public MissingRequirementsPanel missingPanel;

    public void TryDoJob(JobData job)
    {
        List<string> missingItems = new List<string>();

        if (stats.energy < -job.requiredEnergy)
            missingItems.Add("Yetersiz Enerji");

        if (stats.hunger < -job.requiredHunger)
            missingItems.Add("Yetersiz Açlýk");

        if(stats.power < job.requiredPower)
            missingItems.Add("Yetersiz Güç (" + job.requiredPower + ")");

        if (stats.intellegent < job.requiredIntellegent)
            missingItems.Add("Yetersiz Zeka (" + job.requiredIntellegent + ")");

        foreach (var itemID in job.requiredItemIDs)        // Item gereksinimleri
        {
            if (!purchaseManager.HasItem(itemID))
                missingItems.Add(purchaseManager.GetItemName(itemID));
        }

        if (missingItems.Count > 0)        // Eksik varsa iþi yapma
        {
            missingPanel.Show(missingItems);
            return;
        }

        // Ýþ baþarýlý
        stats.ChangeEnergy(job.requiredEnergy);
        stats.ChangeHunger(job.requiredHunger);
        stats.AddMoney(job.rewardMoney);

        Debug.Log(job.jobName + " tamamlandý.");
    }
}
