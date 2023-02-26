using UnityEngine;
using TMPro;

public class MissionUI : MonoBehaviour
{
    public TextMeshProUGUI missionText;

    private void Update()
    {
        UpdateMissionUI();
    }

    private void UpdateMissionUI()
    {
        string missionTextString = "";
        for (int i = 0; i < GameManager.missions.Length; i++)
        {
            if (!GameManager.missionComplete[i]) // exclude completed missions
            {
                missionTextString += GameManager.missions[i].description +  "\n";
            }
        }
        missionText.text = missionTextString;
    }
}