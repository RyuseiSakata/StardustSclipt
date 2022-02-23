using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public static bool cameraBool=false;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

        cameraMove();

    }
    void cameraMove()
    {
        if (cameraBool==true)
        {
            Vector3 playerPos = player.transform.position;
            //カメラとプレイヤーの位置を同じにする
            transform.position = new Vector3(playerPos.x, playerPos.y, -10);
        }


    }
}
