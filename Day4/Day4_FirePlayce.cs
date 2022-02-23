using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day4_FirePlayce : MonoBehaviour
{
  // Start is called before the first frame update
  public string[] signboard = {"寂しげな暖炉だ。灰がたまっている。","隅に何かあるようだ。"
                                ,"火かき棒を手に入れた"};
  public string[] signboard1={"奥で何か光っている。",
                     "ボロボロの懐中時計を手に入れた。"};

    private float speakLine = 0.9f;

    public GameObject button;
    public Transform plPos;
  //  public Transform pos;
    //public GameObject gameObject;
    private int fbsf = 0;
    [SerializeField]
    private Message2 messageScript;
    private idou pos;
    internal static readonly bool TriggerFP;

    // Start is called before the first frame update
    void Start()
    {
        plPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      if(fbsf==0&&(plPos.position - transform.position).magnitude <= speakLine){
        Debug.Log("bbb");

          Message2.Instance.StartCoroutine("WriteRoutine",signboard);
      //  fbsf = 1;
    }
    /*else if(fbsf==1&&(plPos.position - transform.position).magnitude <= speakLine){
      Message.Instance.EndFours();
      Message2.Instance.message2(signboard1);
      fbsf=-1;
    }*/
}
}
