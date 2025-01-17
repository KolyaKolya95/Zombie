﻿using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{

	public int damagePerShot = 20;                  
	public float timeBetweenBullets = 0.15f;       
	public float range = 100f;                     


	float timer;                                    
	Ray shootRay;                                 
	RaycastHit shootHit;                           
	int shootableMask;                              
	ParticleSystem gunParticles;                   
	LineRenderer gunLine;                          
	AudioSource gunAudio;                           
	Light gunLight;                                 
	public Light faceLight;								
	float effectsDisplayTime = 0.2f;              


	void Awake ()
	{
		shootableMask = -LayerMask.GetMask ("Shootable");
		gunParticles = GetComponentInChildren<ParticleSystem> ();
		gunLine = GetComponentInChildren <LineRenderer> ();
		gunAudio = GetComponentInChildren<AudioSource> ();
		gunLight = GetComponentInChildren<Light> ();
		faceLight = GetComponentInChildren<Light> ();
	}


	void Update ()
	{
		
		timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
		{
			Shoot ();
		}
		
		if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			
			DisableEffects ();
		}
	}


	public void DisableEffects ()
	{
		
		gunLine.enabled = false;
		faceLight.enabled = false;
		gunLight.enabled = false;
	}


	void Shoot ()
	{
		
		timer = 0f;

		gunLight.enabled = true;
		faceLight.enabled = true;

		gunParticles.Stop ();
		gunParticles.Play ();

		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		gunAudio.Play ();

		if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
		{
			
			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
	
			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (damagePerShot, shootHit.point);
			}
				
			gunLine.SetPosition (1, shootHit.point);
		}
		else
		{
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}
}

