using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalShot : MonoBehaviour
{
   public float speed = 100f;
   public int damage;
   public Rigidbody2D rigidBody;
   public GameObject impactEffect;

   // Start is called before the first frame update
   void Start()
   {
      rigidBody.velocity = transform.right * speed;
      Destroy(gameObject, 2); // despawns after 2 secs in case it takes too long
   }

   void OnTriggerEnter2D(Collider2D hitInfo)
   {
      Enemy enemy = hitInfo.GetComponent<Enemy>();
      if(enemy != null){
        if (enemy.currentHealth > 0)
        {
           enemy.TakeDamage(damage);
        }

      Debug.Log(enemy.name + " " + damage + " " + enemy.currentHealth);


      var impact = Instantiate(impactEffect, transform.position, transform.rotation);

      Destroy(gameObject);
      Destroy(impact, 1); // the impact is still there even after ending
      }
   }
}
