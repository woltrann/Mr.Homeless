using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JobData", menuName = "Jobs/Job")]
public class JobData : ScriptableObject
{
    public string jobName;
    public int requiredHunger;
    public int requiredEnergy;
    public int rewardMoney;
    //public int rewardFame; // istersen kullanýrsýn
    public List<string> requiredItemIDs;

    public bool passesTime;
}
