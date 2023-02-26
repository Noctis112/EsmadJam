using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleUI : MonoBehaviour
{
    [SerializeField] GameObject MissionsUI;
    [SerializeField] GameObject Postit;
    [SerializeField] GameObject ponto;
    [SerializeField] GameObject toDo;

    [SerializeField] GameObject[] Lines;

    bool[] LinesOn;

    public InputActionReference UIToggle;

    private void Start()
    {
        LinesOn = new bool[Lines.Length];
    }

    void Update()
    {
        UIToggle.action.performed +=
            ctx =>
            {
                toDo.SetActive(true);
                MissionsUI.SetActive(true);
                Postit.SetActive(true);
                ponto.SetActive(false);

                EnableLines();
            };

        UIToggle.action.canceled +=
            ctx =>
            {
                toDo.SetActive(false);
                MissionsUI.SetActive(false);
                Postit.SetActive(false);
                ponto.SetActive(true);

                DisableLines();
            };


        CheckMissionComplete();
    }


    private void EnableLines()
    {
        for (int i = 0; i < GameManager.missions.Length; i++)
        {
            if (LinesOn[i] == true)
            {
                Lines[i].SetActive(true);
            }
        }
    }

    private void DisableLines()
    {
        for (int i = 0; i < GameManager.missions.Length; i++)
        {
            if (LinesOn[i] == true)
            {
                Lines[i].SetActive(false);
            }
        }
    }

    private void CheckMissionComplete()
    {
        for (int i = 0; i < GameManager.missions.Length; i++)
        {
            if (GameManager.missions[i].currentCount == GameManager.missions[i].requiredCount)
            {
                LinesOn[i] = true;
            }
        }
    }
}
