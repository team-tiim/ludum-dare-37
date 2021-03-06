﻿using System.Collections;
using UnityEngine;


public abstract class Weapon : MonoBehaviour
{

    private const float MIN_SPEED_MULT = 0.1f;
    private const float MAX_SPEED_MULT = 1.0f;

    public Transform handlePoint;

    public int damage = 1;
    public float attackCooldown = 1;
    public float knockback;

    private float lastAttack = -1;
    private TimedWeaponBehaviour timedBehaviour;

    public virtual void Awake()
    {
        handlePoint = transform.Find("handle");
        //this.gameObject.GetComponent<Animator>().Play();
    }

    public virtual void DoAttack(WeaponAttackParams parameters)
    {
        //Debug.Log("weapon attack");
        lastAttack = Time.time;
        PlayAnimation();
    }    

    public bool CanAttack()
    {
        return lastAttack == -1 || (Time.time - lastAttack) > attackCooldown;
    }

    private void PlayAnimation()
    {
        Animator animator = this.gameObject.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
    }

    public void ResetRotation(Quaternion q)
    {
        StopAllCoroutines();
        StartCoroutine(DoResetRotation(q));
    }

    protected void Rotate(float angle)
    {
        //Debug.Log(angle);
        transform.RotateAround(handlePoint.position, Vector3.forward, angle);
    }

    private IEnumerator DoResetRotation(Quaternion q)
    {
        yield return new WaitForSeconds(attackCooldown * 2/3);
        float angle = Quaternion.Angle(q, transform.rotation);
        Debug.Log(angle);
        transform.RotateAround(handlePoint.position, Vector3.forward, angle);
    }

    private IEnumerator DoRotation(float angle)
    {
        yield return new WaitForSeconds(attackCooldown / 2);

    }

    public int Damage
    {
        get { return damage; }
    }

    public abstract WeaponType GetWeaponType();

}

