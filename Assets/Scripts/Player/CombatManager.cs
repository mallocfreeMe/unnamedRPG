using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    public bool canReceiveInput;
    public bool inputReceived;

    public Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            //play an attack animation
            animate.SetTrigger("isAtt");


            //detect enemies in range of attack
            //damage them
            
        }

    }













}
