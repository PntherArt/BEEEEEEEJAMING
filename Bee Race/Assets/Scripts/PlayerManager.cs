using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerConfiguration> PlayerConfigs;

    [SerializeField] private int MaxPlayers = 2;


    [SerializeField] private List<PlayerInput> players = new List<PlayerInput> ();


    public AudioSource snd;
    public AudioClip[] themes;

    public static PlayerManager Instance { get; private set; }
    public GameObject levelPrefab;

    private void Awake()
    {


        if(Instance != null)
        {
            print("SINGLETON - ERRRRROR");

        } else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            DontDestroyOnLoad(levelPrefab);
            PlayerConfigs = new List<PlayerConfiguration> ();
        }
    }


    public void Theme()
    {
        snd.clip = themes[1];
        snd.Play();
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return PlayerConfigs;
    }

    public void SetPlayerColour(int index, Material colour)
    {
        PlayerConfigs[index].PlayerMat = colour;
    }

    public void ReadyPlayer(int index)
    {
        PlayerConfigs[index].IsReady = true;

        if(PlayerConfigs.Count == MaxPlayers && PlayerConfigs.All(p => p.IsReady == true))
        {
            SceneManager.LoadScene("MainGame");
            StartCoroutine(Intro());
        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        print("Player Joined" + pi.playerIndex);
        if (!PlayerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            pi.transform.SetParent(transform);
            PlayerConfigs.Add(new PlayerConfiguration(pi));
        }
    }

    IEnumerator Intro()
    {
        snd.clip = themes[0];
        snd.Play();
        yield return new WaitForSeconds(9);
        Theme();
    }

}

public class PlayerConfiguration
{
    
    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool IsReady { get; set; }
    public Material PlayerMat { get; set; }

    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }
}

