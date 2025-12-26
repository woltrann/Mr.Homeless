using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissingRequirementsPanel : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text requirementsText;

    private Coroutine closeRoutine;

    public void Show(List<string> missingItems)
    {
        panel.SetActive(true);

        requirementsText.text = "Ýhtiyaç Listesi:\n";

        foreach (var item in missingItems)
        {
            requirementsText.text += "- " + item + "\n";
        }

        // Eðer daha önce kapanma coroutine'i varsa durdur
        if (closeRoutine != null)
            StopCoroutine(closeRoutine);

        closeRoutine = StartCoroutine(AutoClose());
    }

    private IEnumerator AutoClose()
    {
        yield return new WaitForSeconds(2f);
        Close();
    }

    public void Close()
    {
        panel.SetActive(false);
    }
}
