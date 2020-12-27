using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{


    public GameObject myPlayer;
    private Camera _viewCamera;

    private void Start()
    {
        _viewCamera = Camera.main;
    }



    private void FixedUpdate()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition - transform.position);
        difference.Normalize();

        var rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg - 180f;

        //transform.rotation = Quaternion.Euler(0f, 0f, rotationZ*5);

        if(myPlayer.transform.eulerAngles.y == 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, rotationZ * 5);
           // print("facing left");


        }
        else if (myPlayer.transform.eulerAngles.y == 180)
        {
            transform.localRotation = Quaternion.Euler(180, 180, rotationZ * 5 +180);
            //print("facing right");
        }




    }

}
