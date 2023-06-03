using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelSpawnner : MonoBehaviour
{

    [SerializeField] private Transform[] playerSpawns;

    [SerializeField] private GameObject playerPrefab;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        var playerConfigs = PlayerManager.Instance.GetPlayerConfigs().ToArray();
        for(int i = 0; i < playerConfigs.Length; i++)
        {
            var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            player.GetComponentInChildren<PlayerInputHandler>().IniPlayer(playerConfigs[i]);
        }
    }


}
