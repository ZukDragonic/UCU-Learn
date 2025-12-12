using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float spd;
    public KeyCode atkKey;
    public KeyCode blockKey;
    private Vector3 moveDir;

    public GameObject weapon1;
    private GameObject weapon1Anchor;
    public GameObject weapon2;
    private GameObject weapon2Anchor;

    private void Start()
    {
        weapon1Anchor = gameObject.transform.Find("HumanF_Model/Rig/B-root/B-hips/B-spine/B-chest/B-shoulder.R/B-upperArm.R/B-forearm.R/B-hand.R/B-handProp.R").gameObject;
        Instantiate(weapon1, weapon1Anchor.transform);
        weapon2Anchor = gameObject.transform.Find("HumanF_Model/Rig/B-root/B-hips/B-spine/B-chest/B-shoulder.L/B-upperArm.L/B-forearm.L/B-hand.L/B-handProp.L").gameObject;
        Instantiate(weapon2, weapon2Anchor.transform);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDir = x * transform.right + z * transform.forward;

        transform.position += moveDir * spd * Time.deltaTime;
    }
}
