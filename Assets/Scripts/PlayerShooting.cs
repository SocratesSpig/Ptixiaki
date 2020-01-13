using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject impactEffect;

    public int damagePerShot = 20;
    public float timeBetweenBullets = 3f;
    public float range = 10f;

    float timer;
    Ray shootRay; 
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    //Ammo
    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    public bool isReloading = false;

    private void Start()

    {   
        
    }

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        //gunAudio=GetComponent<AudioSource> ();
        gunLight = GetComponent<Light>();
        currentAmmo = maxAmmo;


    }
    void Update()
    {
       

        if(currentAmmo<=0)
        {
            StartCoroutine(Reload());
            return;
        }

        timer += Time.deltaTime;
        
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            
                Shoot();
            
        }
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }
        public void DisableEffects()
        {
            gunLine.enabled = false;
            gunLight.enabled = false;
        }

    void Shoot()
    {
        currentAmmo--;

        timer = 0f;
        //gunAudio.Play();
        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);

            Instantiate(impactEffect, shootHit.point, Quaternion.LookRotation(shootHit.normal));

        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

    IEnumerator Reload()
    {
        
        DisableEffects();
        isReloading = true;


        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
