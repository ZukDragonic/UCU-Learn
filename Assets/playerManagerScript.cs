using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManagerScript : MonoBehaviour
{
    public float spd;
    private Vector3 moveDir;

    public KeyCode atkKey;
    public Animator anim;
    public GameObject weapon1;
    public GameObject attackAnchor;
    private GameObject weapon1Anchor;
    public GameObject weapon2;
    private GameObject weapon2Anchor;
    public float atkGracePeriod;
    private float atkGraceTimer;

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

        if (moveDir != Vector3.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKey(atkKey))
        {
            if(anim.GetCurrentAnimatorStateInfo(1).IsName("Empty"))
            {
                anim.Play("Attack1", 1);
            }
            atkGraceTimer = 0f;
            attackAnchor.SetActive(true);
            anim.SetBool("isAttacking", true);
        }
        if (atkGraceTimer > atkGracePeriod)
        {
            attackAnchor.SetActive(false);
            anim.SetBool("isAttacking", false);
        }
        else
        {
            atkGraceTimer += Time.deltaTime;
        }
    }
}
