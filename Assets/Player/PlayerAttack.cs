using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject projectile;
    public float fireDelta = 0.5F;

    private BoxCollider2D swordCollider;
    private Animator animator;
    private float nextFire = 0.5F;
    //private GameObject newProjectile;
    private float myTime = 0.0F;
    void Start()
    {
        swordCollider = this.GetComponent<BoxCollider2D>();
        animator = this.GetComponentInParent<Animator>();
        swordCollider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;
        if(Input.GetButton("Fire1") && myTime > nextFire)
        {
            //newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            animator.SetTrigger("PlayerAttack");
            swordCollider.enabled = true;
            Invoke("DisableWeapon", 0.3f);
            // create code here that animates the newProjectile

            nextFire = 0.7F;
            myTime = 0.0F;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision");
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
    private void DisableWeapon()
    {
        swordCollider.enabled = false;
    }
}
