using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
		public int startingHealth = 100; 
		public int currentHealth;                
		public float sinkSpeed = 2.5f;             
		public int scoreValue = 10;                 
		public AudioClip deathClip;                 

		Animator anim;                             
		AudioSource enemyAudio;                     
		ParticleSystem hitParticles;               
		BoxCollider boxCollider;   
		SphereCollider sphereCollider; 
		bool isDead;                                
		bool isSinking;                            

		void Awake ()
		{
			
			anim = GetComponent <Animator> ();
			enemyAudio = GetComponent <AudioSource> ();
			hitParticles = GetComponentInChildren <ParticleSystem> ();
			boxCollider = GetComponent <BoxCollider> ();
			sphereCollider = GetComponent <SphereCollider> ();
			
			currentHealth = startingHealth;
		}

		void Update ()
		{
			
			if(isSinking)
			{
				transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
			}
		}


		public void TakeDamage (int amount, Vector3 hitPoint)
		{
			
			if(isDead)return;
			enemyAudio.Play ();

			
			currentHealth -= amount;

			
			hitParticles.transform.position = hitPoint;

			
			hitParticles.Play();

			
			if(currentHealth <= 0)
			{
			
				Death ();
				ScoreManager.score += scoreValue;
			}
		}


		void Death ()
		{
			
		isDead = true;

		boxCollider.isTrigger = true;
		sphereCollider.isTrigger = true;
	
		}


		public void StartSinking ()
		{
			
			GetComponent <NavMeshAgent> ().enabled = false;

			GetComponent <Rigidbody> ().isKinematic = true;

			isSinking = true;
			
			ScoreManager.score += scoreValue;

			Destroy (gameObject, 2f);
		}
	}

