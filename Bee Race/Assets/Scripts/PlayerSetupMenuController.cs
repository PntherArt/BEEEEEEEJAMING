using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerSetupMenuController : MonoBehaviour
{
    private int PlayerIndex;

    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField] private GameObject readyPanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Button readyBtn;

    private float ignoreInputTime = 1.5f;
    private bool inputEnabled;

    public void SetPlayerIndex(int pi)
    {
        PlayerIndex = pi;
        titleText.SetText("Player " + (pi + 1).ToString());
        ignoreInputTime = Time.time + ignoreInputTime;

    }


    // Update is called once per frame
    void Update()
    {
        if(Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }

    public void SetPlayer(Material colour)
    {
        if(!inputEnabled) 
        {
            return;        
        }

        PlayerManager.Instance.SetPlayerColour(PlayerIndex, colour);
        readyPanel.SetActive(true);
        readyBtn.Select();
        menuPanel.SetActive(false);
    }

    public void ReadyPlayer()
    {
        if (!inputEnabled)
        {
            return;
        }

        PlayerManager.Instance.ReadyPlayer(PlayerIndex);
        readyBtn.gameObject.SetActive(false);
    }

}
