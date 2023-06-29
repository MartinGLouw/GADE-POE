using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : DataBase
{
    [SerializeField] private string nextSceneName;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DataBase.SavePlayerData();
            SceneManager.LoadScene(nextSceneName);

        }
    }
}