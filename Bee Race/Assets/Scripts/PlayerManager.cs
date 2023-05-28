using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameObject startCam;
   [SerializeField] private List<PlayerInput> players = new List<PlayerInput> ();
    [SerializeField] private List<Transform> startingPoints;

    public AudioSource snd;
    public AudioClip[] themes;

    //public TextMeshProUGUI playerTag;

    private PlayerInputManager playerInputManager;

    private void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager> ();
        RandomTheme();
    }

    private void OnEnable()
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
    }

    public void RandomTheme()
    {
        snd.clip = themes[Random.Range(0, themes.Length)];
        snd.Play();
    }

}
