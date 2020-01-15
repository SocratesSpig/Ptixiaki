using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadManager : MonoBehaviour {

    public PlayerShooting reloading;

    public float nextReload = 3f;

    Animator anim;
    float RestartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (reloading.isReloading == false)
        {
            anim.ResetTrigger("IsReloading");
            Debug.Log("NOPE...");
        }

        if (reloading.isReloading == true)
        {
            anim.SetTrigger("IsReloading");
            RestartTimer += Time.deltaTime;
            Debug.Log("Reloading...");           
        }

    }
}