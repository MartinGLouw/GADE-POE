using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other) //checks when entering a collider
    {
        if (other.gameObject.CompareTag("Score")) //if collider is Score it will raise the onScoreTriggerEnter event
        {
            GameEvents2.current.ScoreTriggerEnter();
        }

        if (other.gameObject.CompareTag("Double")) //if collider is Double it will raise the onDoubleTriggerEnter event
        {
            GameEvents2.current.DoubleTriggerEnter();
        }

        if (other.gameObject.CompareTag("DPPoints")) //if collider is DPPoints it will raise the onDPPointsTriggerEnter event
        {
            GameEvents2.current.DPPointsTriggerEnter();
        }
    }
}