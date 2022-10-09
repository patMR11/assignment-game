using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    
    public enum FSMState{
        None,
        Patrol,
        Attack,
    }

    public FSMState curState;
    protected Transform PlayerTransform;

    //attacks
    public bool attack=true;
    public float attackRange= 50.0f;
    public GameObject bullet;
    //bullet shooting rate
    public float shootRate= 0.3f;
    protected float elapsedTime;
    public float power= 3000.0f;
    public float moveSpeed= 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime=0.0f;
        curState= FSMState.Patrol;
        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = objPlayer.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(curState){
            case FSMState.Patrol: UpdatePatrolState(); break;
            case FSMState.Attack: UpdateAttackState(); break;
        }
        elapsedTime += Time.deltaTime;
    }

    protected void UpdatePatrolState(){
        if ((PlayerTransform) & (attack)){
            float distance= Vector3.Distance(transform.position, PlayerTransform.transform.position);

            if((distance <= attackRange)){
                curState= FSMState.Attack;
            }
        }
    }
    protected void UpdateAttackState(){

        //shoot the bullets
        //turn gun to player
        
        Quaternion gunRotation = Quaternion.LookRotation(PlayerTransform.position - transform.position);
        transform.rotation= Quaternion.Slerp(transform.rotation, gunRotation, Time.deltaTime * moveSpeed);
        
        shooting();
        //check player distance and return to patrol
        float distance= Vector3.Distance(transform.position, PlayerTransform.transform.position);
        
        if ((distance >= attackRange)){
                curState= FSMState.Patrol;
            }
    }

    private void shooting(){

        if(elapsedTime >= shootRate){
            if(bullet){
                GameObject instance= Instantiate (bullet, transform.position, transform.rotation) as GameObject;
                Vector3 fwd= transform.TransformDirection (Vector3.forward);
                instance.GetComponent<Rigidbody> () .AddForce (fwd*power);
            }
            elapsedTime = 0.0f;
        }
        
    }



}
