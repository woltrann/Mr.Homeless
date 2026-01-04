using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobButtonUI : MonoBehaviour
{
    public TMP_Text jobNameText;
    public TMP_Text energyReqText;
    public TMP_Text hungerReqText;
    public TMP_Text rewardMoneyText;

    private JobData jobData;
    private JobManager jobManager;

    public void Setup(JobData data, JobManager manager)
    {
        jobData = data;
        jobManager = manager;

        jobNameText.text = data.jobName;
        energyReqText.text = "<color=#278C2D>Enerji: " + data.requiredEnergy + "</color>";
        hungerReqText.text = "<color=#8C6827>Açlýk: " + data.requiredHunger + "</color>";
        rewardMoneyText.text = data.rewardMoney + "$";

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        jobManager.TryDoJob(jobData);

        if (jobData.passesTime)
        {
            CharacterStats.Instance.Time();
        }
    }
}
