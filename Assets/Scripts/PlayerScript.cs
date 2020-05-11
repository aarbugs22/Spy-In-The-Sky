﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    private NavMeshAgent agent; //Grabs NavMeshAgent from component
    private Camera mainCamera; //Reference to main camera

    private bool turning; //Default to false
    private Quaternion targerRot;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; //Stores main camera

        agent = GetComponent<NavMeshAgent>();

        CameraManager.Instance.OnCameraSwitch += CameraSwitched;
    }

    private void OnDestroy()
    {
        CameraManager.Instance.OnCameraSwitch -= CameraSwitched;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Extensions.IsMouseOverUI()) //If left mouse button is clicked, execute "OnClick"
            OnClick();

        if (turning && transform.rotation != targerRot) //If turning is true and if the transform.rotation isn't the same as the targetRot
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targerRot, 15f * Time.deltaTime); //Rotate the player to face the target
        }
    }

    void OnClick()
    {
        Debug.Log("LeftMouseButton Clicked!");

        RaycastHit hit; 
        Ray camToScreen = mainCamera.ScreenPointToRay(Input.mousePosition); //From screen position shoots a ray to the scene

        if (Physics.Raycast(camToScreen, out hit, Mathf.Infinity))
        {
            if (hit.collider != null) //if it hits something
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>(); //Check if interactable class is attached 

                if (interactable != null)
                {
                    MovePlayer(interactable.InteractPosition()); //Will move player to the interactable position
                    interactable.Interact(this); //Run interact function
                }
                else
                {
                    MovePlayer(hit.point); 
                }
            }
        }
    }

    public bool CheckIfArrived() //Check if the player has arrived at its destination
    {
        return (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance); //Will return whether the condition is true or false
    }

    void MovePlayer(Vector3 targetPosition) 
    {
        turning = false;

        agent.SetDestination(targetPosition);

        DialogueSystem.Instance.HideDialogue();
    }

    public void SetDirection(Vector3 targetDirection)
    {
        turning = true;
        targerRot = Quaternion.LookRotation(targetDirection - transform.position);
    }

    void CameraSwitched(Camera cam)
    {
        mainCamera = cam;
    }
}
