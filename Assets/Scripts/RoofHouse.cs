using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofHouse : MonoBehaviour
{
    public GameObject Roof = null;


    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" )
        {
            Roof.SetActive(false);

        }

    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {

            Roof.SetActive(true);
        }

    }







}