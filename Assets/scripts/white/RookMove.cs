using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class RookMove : MonoBehaviour
{
    public float timer;
    public Vector3 movement;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private GameObject Effect;
    [SerializeField] private GameObject CooldownBuffadd;
    [SerializeField] private GameObject HPadd;
    [SerializeField] private GameObject Lightningadd;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if(timer>0.5f){
            movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z);
        
         if(movement.x>15){
                Destroy(gameObject);
            
            }
            transform.position=movement;
            timer=0;
            }else{
            timer+=Time.deltaTime;
        }*/
        if(timer>0.5f){
            
                movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z);

            
            if(movement.x>15){
                Destroy(gameObject);
            
            }
            Vector3 direction = (movement - transform.position).normalized;
        if(GameObject.Find("King W Variant").GetComponent<PlayerMovement>().lighting){
            rb.velocity = direction*2.3f;
           }else{
        rb.velocity = direction * 1.8f;
           }
        timer=0;
        }else{
            timer+=Time.deltaTime;
        }


    }
    void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.tag=="black"){
            Debug.Log("rook hit");
            Destroy(other.gameObject);
            GameObject cloneW = Instantiate(Effect, transform.position, transform.rotation);
            Destroy(cloneW,1f);
            
            int check = Random.Range(0,10);
            if(check<2){
                Instantiate(CooldownBuffadd, new Vector3((float)Math.Round((double)transform.position.x,0),0.91f,(float)Math.Round((double)transform.position.z,0)), transform.rotation);
            }else if(check<4){
                Instantiate(HPadd, new Vector3((float)Math.Round((double)transform.position.x,0),0.91f,(float)Math.Round((double)transform.position.z,0)), transform.rotation);
            }else if(check<6){
                Instantiate(Lightningadd, new Vector3((float)Math.Round((double)transform.position.x,0),0.91f,(float)Math.Round((double)transform.position.z,0)), transform.rotation);
            }
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "hourglass"){
            Debug.Log("hourglass cd buff");
        GameObject.Find("King W Variant").GetComponent<PlayerMovement>().CooldownUpgrade();
        Destroy(other.gameObject);
    }
    if(other.gameObject.tag == "HP"){
        Debug.Log("addhp");
        GameObject.Find("King W Variant").GetComponent<PlayerMovement>().AddHP(1);
        Destroy(other.gameObject);
    }
    if(other.gameObject.tag == "Lightning"){
        Debug.Log("lightning");
        GameObject.Find("King W Variant").GetComponent<PlayerMovement>().LightingOn();
        Destroy(other.gameObject);
    }
        


}
}
