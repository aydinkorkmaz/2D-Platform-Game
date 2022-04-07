using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] bool onGround;
    [SerializeField] LayerMask block;
    private float width;
    private Rigidbody2D myBody;
    
    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
        myBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
       RaycastHit2D hit = Physics2D.Raycast(transform.position+(transform.right*width/2),Vector2.down,2f,block);

     
       if(hit.collider != null){
           onGround=true;
       }
       else{
           onGround=false;
       }
      
       Flip();
    }
     private void OnDrawGizmos(){
     Gizmos.color=Color.red;
     Vector3 playerRealPosition= transform.position+(transform.right*width/2);
     Gizmos.DrawLine(playerRealPosition,playerRealPosition+new Vector3(0,-2f,0));}

     private void Flip(){
           if(!onGround){
           transform.eulerAngles+=new Vector3(0f,180f,0f);
       }
         myBody.velocity=new Vector2(transform.right.x*2f,0f);
     }
}
