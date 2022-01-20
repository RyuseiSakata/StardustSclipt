using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class idou : MonoBehaviour
{
    [SerializeField] public GameObject menuUI;
  //public double walkForce ;
  //public double maxWalkSpeed;

    public float walkForce = 1000.0f;
    public float maxWalkSpeed = 30.0f;

    Rigidbody2D rigid2D;

    public Animator animator;
    public Transform player;
    public GameObject cocoa;
    [SerializeField]
    public ItemData itemData;

     //this.rigid2D = GetComponent<Rigidbody2D>();
    // Start is called before the first frame update
    void Start()
    {
      cocoa = GameObject.Find("Cocoa");
      this.rigid2D = GetComponent<Rigidbody2D>();
      animator = GetComponent<Animator>();

    }

    public Vector3 getPos(){

      Transform myTransform = this.transform;
      // 座標を取得
      Vector3 pos = myTransform.position;
      return pos;
    }

    // Update is called once per frame
    void Update()
    {
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        float speedy = Mathf.Abs(this.rigid2D.velocity.y);

          if(itemData.item[6].Flag&&!itemData.item[3].Flag){
          cocoa.SetActive(true);
        }

        if (!Message.Instance.getSpeakFlag() && !Message2.Instance.GetStartFlag() && !menuUI.activeSelf/* && !TestMessage.Instance.getSpeakFlag()*/)
        {

            if (Input.GetKey(KeyCode.LeftArrow) && speedx < this.maxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.right * -1 * this.walkForce * Time.deltaTime);
                animator.SetBool("Left", true);
            }
            if (Input.GetKey(KeyCode.RightArrow) && speedx < this.maxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.right * this.walkForce * Time.deltaTime);
                animator.SetBool("Right", true);
            }
            if (Input.GetKey(KeyCode.UpArrow) && speedy < this.maxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.up * this.walkForce * Time.deltaTime);
                animator.SetBool("Back", true);
            }
            if (Input.GetKey(KeyCode.DownArrow) && speedy < this.maxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.up * -1 * this.walkForce * Time.deltaTime);
                animator.SetBool("Front", true);
            }

            //ここからダッシュ
            //if(!Message.Instance.getSpeakFlag()){
            if (Input.GetKey("left shift") || Input.GetKey("right shift"))
            {
                if (Input.GetKey(KeyCode.LeftArrow) && speedx < this.maxWalkSpeed)
                {
                    this.rigid2D.AddForce(transform.right * -2 * this.walkForce * Time.deltaTime);
                    animator.SetBool("Left", true);
                }
                if (Input.GetKey(KeyCode.RightArrow) && speedx < this.maxWalkSpeed)
                {
                    this.rigid2D.AddForce(transform.right * 2 * this.walkForce * Time.deltaTime);
                    animator.SetBool("Right", true);
                }
                if (Input.GetKey(KeyCode.UpArrow) && speedy < this.maxWalkSpeed)
                {
                    this.rigid2D.AddForce(transform.up * 2 * this.walkForce * Time.deltaTime);
                    animator.SetBool("Back", true);
                }
                if (Input.GetKey(KeyCode.DownArrow) && speedy < this.maxWalkSpeed)
                {
                    this.rigid2D.AddForce(transform.up * -2 * this.walkForce * Time.deltaTime);
                    animator.SetBool("Front", true);
                }
            }
            /* */
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                animator.SetBool("Front", false);
                animator.SetBool("Left", false);
                animator.SetBool("Right", false);
                animator.SetBool("Back", false);

            }
        }
        //Debug.Log(getPos().z);
        //Debug.Log(getPos().y);
    }
}
