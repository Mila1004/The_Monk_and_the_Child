using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

	public float detectRange = 0.2f;
	public LayerMask enemyLayers;

	public float enemyAtkRate = 2f;
	float nextAttackTime = 0f;


	public GameObject GameOverText;
	// Start is called before the first frame update
	void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	// Update is called once per frame
	void Update()
	{
		//detecting enemy
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, detectRange, enemyLayers);
		//counting enemies
		int howMany = hitEnemies.Length;


		if (howMany >= 1 )
		{
			if (Time.time >= nextAttackTime)
			{

				foreach (Collider2D enemy in hitEnemies)
				{  //damaging
					nextAttackTime = Time.time + 1f / enemyAtkRate;
					TakeDamage(20);
				}
			}
		}


		if (currentHealth <= 0)
		{

			GameOverText.SetActive(true);

			Time.timeScale = 0;
		} else
		{
			GameOverText.SetActive(false);
			Time.timeScale = 1;
		}
	}

	

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}
