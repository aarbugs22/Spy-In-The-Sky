using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] float distancePosition = 1f;

    public Vector3 InteractPosition()
    {
        return transform.position + transform.forward * distancePosition;
    }

    public void Interact(PlayerScript player)
    {
        Debug.Log(gameObject.name + " clicked by player");

        StartCoroutine(WaitforPlayerArriving(player));
    }

    IEnumerator WaitforPlayerArriving(PlayerScript player)
    {
        while (!player.CheckIfArrived()) //If the player has not arrived yet
        {
            yield return null; //Delay the Coroutine
        }

        //Will run code below when the player arrives
        Debug.Log("Player arrived");

        player.SetDirection(transform.position);
    }
}
