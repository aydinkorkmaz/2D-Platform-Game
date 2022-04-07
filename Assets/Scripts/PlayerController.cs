using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float SpeedX;
    private Vector3 defaultlocalscale;
    private Rigidbody2D body;
    public bool onGround;
    private bool candoublejump;
    [SerializeField]float speed;
    [SerializeField]float jumppower;
    [SerializeField]GameObject arrow;
    [SerializeField] bool attacked;
    private float currenattacktimer=1;
    private float defaultattacktimer=1;
    private Animator myAnimator;
    [SerializeField]int MaxArrow;
    [SerializeField]Text arrownumber;
    [SerializeField]AudioClip dieMusic;
    [SerializeField] GameObject winPanel,losePanel;
    void Start()
    {   attacked=false;
        body=GetComponent<Rigidbody2D>();
        defaultlocalscale=transform.localScale;
        myAnimator=GetComponent<Animator>();
        arrownumber.text=MaxArrow.ToString();
    }

  
    void Update()
    {   
        SpeedX=Input.GetAxis("Horizontal");
        body.velocity= new Vector2(speed*SpeedX,body.velocity.y);
        myAnimator.SetFloat("Speed",Mathf.Abs(SpeedX));

        if(SpeedX>0){
            transform.localScale= new Vector3(defaultlocalscale.x,defaultlocalscale.y,defaultlocalscale.z);
        }
        else if(SpeedX<0){
            transform.localScale= new Vector3(-defaultlocalscale.x,defaultlocalscale.y,defaultlocalscale.z);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){ 
            if(onGround==true){
            body.velocity= new Vector2(body.velocity.x,jumppower);
            candoublejump=true;
            myAnimator.SetTrigger("Jump");
        }
            else{
              if(candoublejump==true){
                 body.velocity= new Vector2(body.velocity.x,jumppower);
                 candoublejump=false;
                 myAnimator.SetTrigger("Jump");

            }
        }
        
        }
        if(Input.GetKeyDown(KeyCode.Space)&&MaxArrow>0){
          if (attacked==false){
             
              myAnimator.SetTrigger("Attack");
              Invoke("Fire",0.5f);
              attacked=true;}
          
              

          }
        FireTime();
          
         
       
        
        
}
void Fire(){
             GameObject myarrow= Instantiate(arrow,transform.position,Quaternion.identity);
           if(transform.localScale.x>0){
                    myarrow.GetComponent<Rigidbody2D>().velocity=new Vector2(10f,0f);
           }
           else{Vector3 myarrowScale = myarrow.transform.localScale;
                myarrow.transform.localScale= new Vector3(-myarrowScale.x,myarrowScale.y,myarrowScale.z);
               myarrow.GetComponent<Rigidbody2D>().velocity=new Vector2(-10f,0f);}
               MaxArrow-=1;
               arrownumber.text=MaxArrow.ToString();
        }
void FireTime(){
 if(attacked==true){
            currenattacktimer-=Time.deltaTime;
        }
        else{
            currenattacktimer=defaultattacktimer;
        }
        if(currenattacktimer<=0){
            attacked=false;
        }

}
 private void OnCollisionEnter2D(Collision2D collision){
     if(collision.gameObject.tag=="Enemy"){
          GetComponent<TimeControl>().enabled=false;
          Die();
          
     }}
     private void OnTriggerEnter2D(Collider2D collision){
   if(collision.gameObject.name=="Finish"){
        
         StartCoroutine(Wait(true));
     }
            
        }
 public void Die(){
     GameObject.Find("SoundController").GetComponent<AudioSource>().clip=null;
     GameObject.Find("SoundController").GetComponent<AudioSource>().PlayOneShot(dieMusic);
     myAnimator.SetFloat("Speed",0f);
     myAnimator.SetTrigger("Die");
     body.constraints=RigidbodyConstraints2D.FreezeAll;
     enabled=false;
     StartCoroutine(Wait(false));
   
      
  
 }
 IEnumerator Wait(bool win){
     yield return new WaitForSecondsRealtime(1f);
     Time.timeScale=0;
     if(win==true){
          winPanel.SetActive(true);
     }
     else{
         losePanel.SetActive(true);
     }

 }
}
