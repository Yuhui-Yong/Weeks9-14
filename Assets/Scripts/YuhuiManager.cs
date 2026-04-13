using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class YuhuiManager : MonoBehaviour
{

    public List<Sprite> possiblePlayerVisuals;
    public List<PlayerInput> existingPlayers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayerJoined(PlayerInput newPlayer)
    {

        //ASSIGN VISUALS TO THIS NEW PLAYER
        SpriteRenderer newPlayerRenderer = newPlayer.GetComponent<SpriteRenderer>();
        newPlayerRenderer.sprite = possiblePlayerVisuals[existingPlayers.Count];

        existingPlayers.Add(newPlayer);

        YuhuiPlayer playerScript = newPlayer.GetComponent<YuhuiPlayer>();
        playerScript.manager = this;
        playerScript.manager = gameObject.GetComponent<YuhuiManager>();
    }

    public void TryAttack(PlayerInput attackingPlayer)
    {

        for (int i = 0; i < existingPlayers.Count; i++)
        {
            if (attackingPlayer == existingPlayers[i])
            {
                //GO TO THE NEXT ITERATION OF LOO{
                continue;
            }

            Vector3 attackingPlayerPosition = attackingPlayer.transform.position;
            Vector3 existingPlayerPosition = existingPlayers[i].transform.position;
            float distanceToPlayer = Vector3.Distance(attackingPlayerPosition, existingPlayerPosition);

            if (distanceToPlayer < 1.5f)
            {
                Debug.Log("attacking this player: " + existingPlayers[i].playerIndex);
            }
        }


    }
}