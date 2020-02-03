using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraSetup : MonoBehaviour
{
    //public Camera cam1;
    //public Camera cam2;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    cam1.enabled = true;
    //    cam2.enabled = false;
    //}

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Camera.main.transform.position = new Vector3(13.15f, 2.405f, 9.89f);
        Camera.main.transform.localEulerAngles = new Vector3(36.7f, -155.8f, 0f);
    }

    void OnTriggerExit(Collider other)
    {
        Camera.main.transform.position = new Vector3(-2.417f, 2.405f, 9.89f);
        Camera.main.transform.localEulerAngles = new Vector3(22.442f, -229.815f, 0f);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == ("Player"))
    //    {
    //        cam1.enabled = !cam1.enabled;
    //        cam2.enabled = !cam2.enabled;
    //        Debug.Log("Camere has switch");
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == ("Player"))
    //    {
    //        cam1.enabled = !cam1.enabled;
    //        cam2.enabled = !cam2.enabled;
    //        Debug.Log("Camere has switched back");
    //    }
}
