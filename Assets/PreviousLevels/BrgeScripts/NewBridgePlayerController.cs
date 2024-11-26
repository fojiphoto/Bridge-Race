using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class NewBridgePlayerController : MonoBehaviour
{
    public Animator animator;
    public bool alive;
    public Material MyMaterial;
    public GameObject Bag;
    public GameObject blockinbag;
    public GameObject mytiles;
    public List<GameObject> mytargetparents;
    public List<GameObject> MyTargets;
    public int stage;
    public int exits;
    public bool move;
    private bool isBrickMoving;
    public float moveDuration = 0.3f;
    public Ease moveEase = Ease.OutQuad;

    public AudioClip Pick_up;
    public AudioSource audio_source;

    void Start()
    {
        Time.timeScale = 1;
        MyMaterial = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material;
        Bag = transform.GetChild(2).gameObject;
        animator = GetComponent<Animator>();
        alive = true;
        exits = 0;
        stage = 0;
        keepBrgR_bricks();
        move = true;

    }
    void Update()
    {
        if (move)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Run");
            }
            if (Input.GetMouseButtonUp(0))
            {
                animator.SetTrigger("Idle");
            }

        }
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && move)
        {
            if (alive)
            {
                Vector3 direction = Vector3.forward * Input.GetAxis("Mouse Y") + Vector3.right * Input.GetAxis("Mouse X");
                transform.Translate(Vector3.forward * 5 * Time.deltaTime);
                if (direction != Vector3.zero)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 8.5f * Time.deltaTime);
                }
            }
        }
    }
    public void sendallBrgR_brikesback()
    {
        int tempsize = Bag.transform.childCount;
        for (int i = 0; i < tempsize; i++)
        {
           // Bag.transform.GetChild(0).GetComponent<Materialsaddr_Bridge>().BackBrgR_ToFirstPosition();
            Bag.transform.GetChild(0).GetComponent<NewMaterialsAddBridge>().BackBrgR_ToFirstPosition();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "gate")
        {
            other.gameObject.tag = "Untagged";
            other.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = false;
            stage++;
            if (stage <= 2)
            {
                keepBrgR_bricks();
            }
        }
        if (other.gameObject.tag == "nth")
        {
           // other.transform.root.GetComponent<Enemyr_Bridge>().thisBridggingRacechar(gameObject);
            other.transform.root.GetComponent<NewEnemyBridge>().thisBridggingRacechar(gameObject);
        }
        if (other.gameObject.tag == "0th")
        {
            exits++;
            if (exits == 2)
            {
                exits = 0;
                // transform.GetChild(3).GetComponent<stepsr_Bridge>().buildBrgR_again();
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cude"))
        {
            if (move)
            {
                if (collision.gameObject.GetComponent<MeshRenderer>().material.color == MyMaterial.color)
                {
                    audio_source.PlayOneShot(Pick_up);
                    GameObject a = collision.gameObject;
                    a.transform.parent = Bag.transform;
                    StartCoroutine(SmoothMoveToBag(a));
                   
                    //a.transform.localPosition = new Vector3(Bag.transform.localPosition.x, (Bag.transform.childCount * 0.25f), Bag.transform.localPosition.z);
                    //a.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }
            Invoke(nameof(isMoving), .5f);
        }
        if (collision.gameObject.CompareTag("Bot"))
        {
            if (Bag.transform.childCount != 0 && exits == 0 && !isBrickMoving)
            {
                //if (collision.gameObject.transform.GetComponent<AIcontroler_Bridge>().Bag.transform.childCount > Bag.transform.childCount)
                //{
                //    StartCoroutine(BrgR_stand());
                //}
                if (collision.gameObject.transform.GetComponent<NewAiControllerDeem>().Bag.transform.childCount > Bag.transform.childCount)
                {
                    StartCoroutine(BrgR_stand());
                }
            }
        }
    }

    private IEnumerator SmoothMoveToBag(GameObject brick)
    {
        isBrickMoving = true;
        Vector3 targetPosition = new Vector3(0, Bag.transform.childCount * 0.25f, 0);

        brick.transform.DOLocalJump(targetPosition, 2.5f, 1, 0.4f)
            .SetEase(moveEase)
            .OnComplete(() =>
            {
                AttachToBag(brick);

            });

        while (brick.transform.localPosition != targetPosition)
        {
            brick.transform.localPosition = Vector3.Lerp(brick.transform.localPosition, targetPosition, Time.deltaTime * 5);

            yield return null;
        }
    }

    private void AttachToBag(GameObject brick)
    {
        brick.transform.localPosition = new Vector3(0, Bag.transform.childCount * 0.25f, 0);
        brick.transform.localRotation = Quaternion.identity;
       
    }
    private void isMoving()
    {
        isBrickMoving = false;
    }

    public void keepBrgR_bricks()
    {
        mytiles = mytargetparents[stage].gameObject;
        //mytargetparents[stage].GetComponent<ColorPlacer_Bridge>().assigncolor(gameObject, "player");
        mytargetparents[stage].GetComponent<NewColorPlacerDeem>().assigncolor(gameObject, "player");
    }
    IEnumerator BrgR_stand()
    {
        animator.SetTrigger("knock");
        move = false;
        GetComponent<Collider>().isTrigger = true;
        sendallBrgR_brikesback();
        yield return new WaitForSeconds(1.2f);
        GetComponent<Collider>().isTrigger = false;
        move = true;
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
}