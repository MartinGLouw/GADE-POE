using System.Collections;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject prefab;
    public Transform player;
    public float spawnDelay = 90f;
    public float riseSpeed = 1f;
    public float maxHeight = 5f;

    // set the initial spawn delay to 90 seconds

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            Vector3 spawnPosition = player.position + player.forward;
            GameObject instance = Instantiate(prefab, spawnPosition, Quaternion.identity);
            Destroy(instance, 50f); // destroy the boss after 50 seconds

            while (instance.transform.position.y < maxHeight)
            {
                instance.transform.position += Vector3.up * riseSpeed * Time.deltaTime;
                instance.transform.position = new Vector3(0, instance.transform.position.y, player.position.z + 70);
                yield return null;
            }

            while (instance != null)
            {
                instance.transform.position = new Vector3(0, instance.transform.position.y, player.position.z + 70);
                yield return null;
            }

            spawnDelay = 140f; // set the spawn delay to 140 seconds for subsequent spawns
        }
    }


}