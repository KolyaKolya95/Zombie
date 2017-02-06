using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                           
	public int currentHealth; 

	public Slider healthSlider;                               
	public Image damageImage;                                                                
	public float flashSpeed = 5f;                              
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     
	                                                                              
	PlayerGo playerGo;                              
	PlayerShooting playerShooting;                             
	bool isDead;                                               
	bool damaged;                                               

	void Awake ()
	{
		playerGo = GetComponent <PlayerGo> ();
		playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
	}
		
	void Update ()
	{
		if(damaged)
		{
			damageImage.color = flashColour;
		}

		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}


	public void TakeDamage (int amount)
	{
		
		damaged = true;

		currentHealth -= amount;

		healthSlider.value = currentHealth;

		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}
		
	void Death ()
	{
		isDead = true;
		Application.LoadLevel ("GameOver");

		playerGo.enabled = false;
		playerShooting.enabled = false;
	}       
}
