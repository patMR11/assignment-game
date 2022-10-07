using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distract : MonoBehaviour
{
    public enum FSMState{
        None,
        Patrol,
        Attack,
    }

    
    public FSMState curState;
    protected Transform PlayerTransform;
    public bool attack=true;
    public float attackRange= 30.0f;
    //bullets
    public GameObject bullet;
    //public GameObject bulletCreate;
    public float shootingRate=3.0f;
    protected float elapsedTime;

    //gun
    public GameObject gun;
    public float gunSpeed=3.0f;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime=0.0f;
        curState= FSMState.Patrol;
        //get player
        GameObject objPlayer= GameObject.FindGameObjectWithTag("Player");
        PlayerTransform= objPlayer.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(curState){
            case FSMState.Patrol: UpdatePatrolState(); break;
            case FSMState.Attack: UpdateAttackState(); break;
        }
        elapsedTime += Time.deltaTime;
        //Debug.Log(elapsedTime);
    }

    protected void UpdatePatrolState(){
        if ((PlayerTransform) & (attack)){
            float distance= Vector3.Distance(transform.position, PlayerTransform.transform.position);

            if((distance <= attackRange)){
                curState= FSMState.Attack;
            }else if ((distance >= attackRange)){
                curState= FSMState.Patrol;
            }
        }
    }

    protected void UpdateAttackState(){

        //shoot the bullets
        //turn gun to player
        /**if(gun){
            Quaternion gunRotation = Quaternion.LookRotation(PlayerTransform.position - transform.position);
            gun.transform.rotation= Quaternion.Slerp(gun.transform.rotation, gunRotation, Time.deltaTime * gunSpeed);
        }**/
        shooting();
    }


    private void shooting(){
        
        if (elapsedTime >= shootingRate){
            if (bullet){
                Instantiate(bullet, transform.position, transform.rotation);
                //Debug.Log("Hi");
            }
            elapsedTime= 0.0f;
        }
        
    }
}
