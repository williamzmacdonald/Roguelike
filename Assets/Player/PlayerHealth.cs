using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    private bool invulnerable;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        invulnerable = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {//if colliding with an enemy and not invulnerable, take damage and start invulnarability
        if (collision.gameObject.tag == "Enemy" && invulnerable == false)
        {
            Debug.Log("Ow!");
            health--;
            invulnerable = true;
            StartCoroutine(FlashSprite());
            Invoke("EndInvulnerable", 1);
        }
        if(health <= 0)//currently only reloads current scene after death 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void EndInvulnerable()
    {
        invulnerable = false;
    }
    IEnumerator FlashSprite()
    {
        for (var n = 0; n < 5; n++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(.1f);
        }
    }
}

