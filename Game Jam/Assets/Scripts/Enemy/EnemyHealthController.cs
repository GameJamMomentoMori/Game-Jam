using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : CharStat
{
    EnemyManager enemyManager;
    CharStat myStats;

    void Start() {
        enemyManager = EnemyManager.instance;
        myStats = gameObject.GetComponent<CharStat>();
    }

    public override void Die() {
        base.Die();
        enemyManager.KillEnemy();
    }
}
