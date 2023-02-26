using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject MenuCanvas;
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject Fish;
    [SerializeField] GameObject CreditsCanvas;

    void Start()
    {
        
    }

    public void Credits()
    {
        CreditsCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
        Boss.SetActive(false);
        Fish.SetActive(false);
    }

    public void Menu()
    {
        CreditsCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        Boss.SetActive(true);
        Fish.SetActive(true);
    }
}
