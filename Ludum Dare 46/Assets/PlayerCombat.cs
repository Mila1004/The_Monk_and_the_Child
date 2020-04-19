﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	public Animator animator;

	public Transform attackPoint;
	public LayerMask enemyLayers;

	public float attackRange = 0.5f;
	public int attackDamage = 50;

	public float attackRate = 2f;
	float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
		if(Time.time >= nextAttackTime)
		{

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Attack();
				nextAttackTime = Time.time + 1f / attackRate;
			}

		}
    }


	void Attack()
	{
		animator.SetTrigger("Attack"); //attackanimation

		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); //detecting enemy

		foreach(Collider2D enemy in hitEnemies) 
		{  //damaging
			
			enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
		}

	}

	void OnDrawGizmosSelected()
	{
		if(attackPoint == null)
			return;
		

		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}