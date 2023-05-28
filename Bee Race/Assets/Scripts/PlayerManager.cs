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

    public GameObject startCam;
    [SerializeField] private List<PlayerInput> players = new List<PlayerInput> ();
    [SerializeField] private List<Transform> startingPoints;

    public AudioSource snd;
    public AudioClip[] themes;

    public static PlayerManager Instance { get; private set; }

    //public TextMeshProUGUI playerTag;

    private PlayerInputManager PlayerInputManager;

    private void Awake()
    {
        //playerInputManager = FindObjectOfType<PlayerInputManager> ();


        if(Instance != null)
        {
            print("SINGLETON - ERRRRROR");

        } else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            PlayerConfigs = new List<PlayerConfiguration> ();
        }
    }

    /*private void OnEnable()
    {
        playerInputManager.onPlayerJoined += AddPlayer;
        startCam.SetActive (false);
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= AddPlayer;
    }

    public void AddPlayer(PlayerInput player)
    {
        players.Add(player);
        player.transform.position = startingPoints[players.Count - 1].position;
        //playerTag.text = player.name;
    }*/

    public void RandomTheme()
    {
        snd.clip = themes[Random.Range(0, themes.Length)];
        snd.Play();
    }

    public void SetPlayerColour(int index, Material colour)
    {
        colour = PlayerConfigs[index].PlayerMat;
    }

    public void ReadyPlayer(int index)
    {
        PlayerConfigs[index].IsReady = true;

        if(PlayerConfigs.Count == MaxPlayers && PlayerConfigs.All(p => p.IsReady == true))
        {
            SceneManager.LoadScene("MainGame");
            RandomTheme();
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