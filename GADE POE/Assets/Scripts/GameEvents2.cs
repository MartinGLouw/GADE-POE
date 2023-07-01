using System;
using UnityEngine;

public class GameEvents2 : MonoBehaviour
{
    public static GameEvents2 current;

    private void Awake()
    {
        current = this;
    }

    public event Action onScoreTriggerEnter;
    public void ScoreTriggerEnter()
    {
        if (onScoreTriggerEnter != null)
        {
            onScoreTriggerEnter();
        }
    }

    public event Action onDoubleTriggerEnter;
    public void DoubleTriggerEnter()
    {
        if (onDoubleTriggerEnter != null)
        {
            onDoubleTriggerEnter();
        }
    }

    public event Action onDPPointsTriggerEnter;
    public void DPPointsTriggerEnter()
    {
        if (onDPPointsTriggerEnter != null)
        {
            onDPPointsTriggerEnter();
        }
    }

    public event Action onBossSpawn;
    public void BossSpawn()
    {
        if (onBossSpawn != null)
        {
            onBossSpawn();
        }
    }

    public event Action onBoss2Spawn;
    public void Boss2Spawn()
    {
        if (onBoss2Spawn != null)
        {
            onBoss2Spawn();
        }
    }
}