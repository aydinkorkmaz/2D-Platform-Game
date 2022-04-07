using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{  
[SerializeField]float coinRotateSpeed;

 void Update(){
     transform.Rotate(new Vector3(0f,coinRotateSpeed,0f));
 }

   private void OnTriggerEnter2D(Collider2D collision){
       if(collision.gameObject.CompareTag("Player")){
           GameObject.Find("SceneManager").GetComponent<SceneControl>().AddScore(50);
           Destroy(gameObject);
           
       }
   }
}
