using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JobList", menuName = "Jobs/Job List")]
public class JobList : ScriptableObject
{
    public List<JobData> jobs = new List<JobData>();
}
