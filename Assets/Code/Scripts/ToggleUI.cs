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
    public InputActionReference UIToggle;
   

    void Update()
    {
        UIToggle.action.performed +=
            ctx =>
            {
                toDo.SetActive(true);
                MissionsUI.SetActive(true);
                Postit.SetActive(true);
                ponto.SetActive(false);
            };

        UIToggle.action.canceled +=
            ctx =>
            {
                toDo.SetActive(false);
                MissionsUI.SetActive(false);
                Postit.SetActive(false);
                ponto.SetActive(true);
            };
    }
}
