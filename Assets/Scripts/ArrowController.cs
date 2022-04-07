using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowController : MonoBehaviour
{
    [SerializeField] GameObject effect;
    
    
   private void  OnTriggerEnter2D(Collider2D collision){ 
       if(!(collision.gameObject.tag=="Player")&&(collision.gameObject.tag!="Coin")){
           Destroy(gameObject);
           if(collision.gameObject.tag=="Enemy" && collision.gameObject.name!="EnemyBlock"){
               Destroy(collision.gameObject);
               GameObject.Find("SceneManager").GetComponent<SceneControl>().AddScore(100);
               Instantiate(effect,collision.gameObject.transform.position,Quaternion.identity);
             
           }
       }

}
 private void OnBecameInvisible(){
     Destroy(gameObject);
 }
}
