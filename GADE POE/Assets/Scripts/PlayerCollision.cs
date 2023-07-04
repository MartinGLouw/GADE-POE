using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool touched;
    void OnTriggerEnter(Collider other) //checks when entering a collider
    {
        if (other.gameObject.CompareTag("Score")&& !touched) //if collider is Score it will raise the onScoreTriggerEnter event
        {
            GameEvents2.current.ScoreTriggerEnter();
            touched = true;
        }

        if (other.gameObject.CompareTag("Double")&&!touched) //if collider is Double it will raise the onDoubleTriggerEnter event
        {
            GameEvents2.current.DoubleTriggerEnter();
            touched = true;
        }

        if (other.gameObject.CompareTag("DPPoints")&&!touched) //if collider is DPPoints it will raise the onDPPointsTriggerEnter event
        {
            GameEvents2.current.DPPointsTriggerEnter();
            touched = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        touched = false;
    }
}