using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharStat))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharStat myStats;

    void Start() {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharStat>();
    }

    public override void Interact() {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null) playerCombat.Attack(myStats);
        
    }

}
