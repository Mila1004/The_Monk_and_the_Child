using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
	public Animator animator;

	public int maxHealth = 100;
	int currentHealth;


	public GameObject ScoreNumber;
	

	// Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;


    }


	public void TakeDamage(int damage)
    {
		currentHealth -= damage;

		animator.SetTrigger("Hurt");

		if (currentHealth <= 0)
		{
			// ScoreNumber.GetComponent<Score>().addToscore(5);
			StartCoroutine(afterDie());
		}
    }

	void Die()
	{
		//die anim
		animator.SetBool("IsDead", true);

		//disable the enemy
		GetComponent<Collider2D>().enabled = false;



		
		
		


		//GetComponent<AIDestinationSetter>().enabled = false;
		//GetComponent<AIPath>().enabled = false;

		
	}

	

	IEnumerator afterDie()
	{
		Die();

		yield return new WaitForSeconds(1.5F);

		GetComponentInChildren<SpriteRenderer>().enabled = false;


		Debug.Log("Gone");

		gameObject.SetActive(false);
	}
}

