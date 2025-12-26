using UnityEngine;

public class JobUIBuilder : MonoBehaviour
{
    public JobList jobList;              // Legal veya Illegal job list
    public JobManager jobManager;        // Referans

    public Transform content;            // ScrollView Content
    public GameObject jobButtonPrefab;   // Buton prefabý

    private void Start()
    {
        BuildUI();
    }

    public void BuildUI()
    {
        foreach (var job in jobList.jobs)
        {
            GameObject obj = Instantiate(jobButtonPrefab, content);
            obj.GetComponent<JobButtonUI>().Setup(job, jobManager);
        }
    }
}
