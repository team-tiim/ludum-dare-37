﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class ProjectileWeapon : Weapon
{
    public float gravityScale;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    // Use this for initialization
    void Start()
    {
        if (projectilePrefab == null)
        {
            GameController gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            projectilePrefab = gc.basicBulletPrefab;
        }
        projectileSpawnPoint = transform.Find("projectileSpawnPoint");
        if(projectileSpawnPoint == null)
        {
            projectileSpawnPoint = this.transform;
        }
    }


    protected override void DoAttack(GameObject parent, Vector3 attackDirection)
    {
        //Debug.Log("Projectile weapon attack");
        SpawnPojectile(attackDirection);
        DoKnockback(attackDirection);
    }

    private void SpawnPojectile(Vector3 attackDirection)
    {
        //Debug.Log("Spawning projectile " );
        Projectile p = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
        p.SetVariables(this, attackDirection);
    }

    private void DoKnockback(Vector3 attackDirection)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerBehaviour pc = player.GetComponent<PlayerBehaviour>();
        //player.GetComponent<Rigidbody2D>().AddForce(-attackDirection.normalized * knockback, ForceMode2D.Impulse);
        pc.DoKnockback(-attackDirection.normalized * knockback);
    }

}
