using System.Collections;
using UnityEngine;

public class Boss2Spawn : MonoBehaviour
{
    public GameObject prefab;
    public Transform player;
    public float riseSpeed = 1f;
    public float maxHeight = 5f;

    private float timeSinceStart = 0f;
    private bool hasSpawned = false;

    private IEnumerator SpawnBoss()
    {
        Vector3 spawnPosition = player.position + player.forward;
        GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.identity);
        Destroy(instance, 50f); // destroy the boss after 50 seconds

        while (instance.transform.position.y < maxHeight)
        {
            instance.transform.position += Vector3.up * riseSpeed * Time.deltaTime;
            instance.transform.position = new Vector3(0, instance.transform.position.y, player.position.z + 60);
            yield return null;
        }

        while (instance != null)
        {
            instance.transform.position = new Vector3(0, instance.transform.position.y, player.position.z + 60);
            yield return null;
        }
    }

    void Update()
    {
        timeSinceStart += Time.deltaTime;

        if (timeSinceStart >= 230f && !hasSpawned)
        {
            GameEvents2.current.Boss2Spawn();
            hasSpawned = true;
        }

        if (timeSinceStart >= 280f)
        {
            timeSinceStart = 0f;
            hasSpawned = false;
        }
    }

    private void OnEnable()
    {
        GameEvents2.current.onBoss2Spawn += OnBoss2Spawn;
    }

    private void OnDisable()
    {
        GameEvents2.current.onBoss2Spawn -= OnBoss2Spawn;
    }

    private void OnBoss2Spawn()
    {
        StartCoroutine(SpawnBoss());
    }
}