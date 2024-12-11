using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
public class PLayerController : MonoBehaviour
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
    bool move;
    //Rigidbody rb;
    public float moveDuration = 0.3f;
    public Ease moveEase = Ease.OutQuad;

    public AudioClip Pick_up;
    public AudioSource audio_source;
    bool isBrickMoving;

    //public EnableColiider EC;
   
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        MyMaterial = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material;
        Bag = transform.GetChild(2).gameObject;
        animator = GetComponent<Animator>();
        alive = true;
        exits = 0;
        stage = 0;
        keepbricks();
        move = true;
        //EC.enabled = false;
    }
    void Update()
    {
        if (move)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
                animator.SetTrigger("Run");
            }
            if (Input.GetMouseButtonUp(0))
            {
                //rb.constraints |= ~RigidbodyConstraints.FreezePositionZ;
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
                transform.Translate(Vector3.forward * 6 * Time.deltaTime);
                //rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
                if (direction != Vector3.zero)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 8.5f * Time.deltaTime);
                }
            }
        }
    }
    public void sendallBrgR_brikesbackMinus(int bricksToSendBack)
    {
        int tempsize = Bag.transform.childCount;

        // Process only the smaller of tempsize or bricksToSendBack
        int bricksToProcess = Mathf.Min(tempsize, bricksToSendBack);

        for (int i = 0; i < bricksToProcess; i++)
        {
            Bag.transform.GetChild(Bag.transform.childCount - 1).GetComponent<AddMaterials>().BackToFirstPosition();
        }
    }
    public void sendallbrikesback()
    {
        int tempsize = Bag.transform.childCount;
        for (int i = 0; i < tempsize; i++)
        {
            Bag.transform.GetChild(0).GetComponent<AddMaterials>().BackToFirstPosition();
        }
    }
    public void OnTriggerExit(Collider other)
    {
    
        if (other.gameObject.tag == "gate")
        {
            other.gameObject.tag = "Untagged";
            //trail.Assign_color();
            other.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = false;
            stage++;
            if (stage <= 2)
            {
                keepbricks();
            }
        }
        if (other.gameObject.tag == "0th")
        {
            exits++;
            if (exits == 2)
            {
                exits = 0;
                //transform.GetChild(3).GetComponent<stepmaker>().buildagain();
            }
        }

        //if (other.gameObject.CompareTag("Stairs"))
        //{
        //    EC.enabled = false;
        //}
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TenX"))
        {
            //Nadeem Ads
            //CASAds.instance.ShowRewarded(() => {
            //    GameObject[] allCudes = GameObject.FindGameObjectsWithTag("cude");
            //    Debug.Log("All cudes" + allCudes.Length);
            //    StartCoroutine(MoveBricksToBagSequentially(allCudes, 10));
            //   // collision.gameObject.tag = "Untagged";

            //});
            // Get all "cude" bricks in the scene
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
        if (collision.gameObject.CompareTag("Twox"))
        {
            //Nadeem Ads
            //CASAds.instance.ShowRewarded(() => {
            //    GameObject[] allCudes = GameObject.FindGameObjectsWithTag("cude");
            //    Debug.Log("All cudes" + allCudes.Length);
            //    int bricksToMove = Bag.transform.childCount * 2;
            //    StartCoroutine(MoveBricksToBagSequentially(allCudes, bricksToMove));
            //    //collision.gameObject.tag = "Untagged";

            //});
            // Get all "cude" bricks in the scene
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
        if (collision.gameObject.CompareTag("MinusNine"))
        {
            sendallBrgR_brikesbackMinus(9);
            collision.gameObject.tag = "Untagged";
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
        if (collision.gameObject.CompareTag("Bot"))
        {
            if (Bag.transform.childCount != 0 && exits == 0 && !isBrickMoving)
            {
                if (collision.gameObject.transform.GetComponent<AIcontroller>().Bag.transform.childCount > Bag.transform.childCount)
                {
                    StartCoroutine(stand());
                    Vibration.Vibrate(100);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cude"))
        {
            if (move)
            { 
                //if (collision.gameObject.GetComponent<MeshRenderer>().material == MyMaterial)
                if (other.gameObject.GetComponent<MeshRenderer>().material.color == MyMaterial.color && other.gameObject.name == "player")
                {
                    GameObject a = other.gameObject;
                    audio_source.PlayOneShot(Pick_up);
                    a.transform.SetParent(Bag.transform);
                    StartCoroutine(SmoothMoveToBag(a));
                    //a.transform.parent = Bag.transform;
                    //a.transform.localPosition = new Vector3(Bag.transform.localPosition.x, (Bag.transform.childCount * 0.25f), Bag.transform.localPosition.z);
                    //a.transform.localRotation = Quaternion.Euler(0, 0, 0);

                    //this is ComMemberType by nadeem
                    //a.transform.DOMove(Bag.transform.position, moveDuration).SetEase(moveEase).OnComplete(() =>
                    //{
                    //    // Once the item has reached the bag, make it a child of the bag
                    //    a.transform.SetParent(Bag.transform);
                    //    a.transform.localPosition = new Vector3(Bag.transform.localPosition.x, (Bag.transform.childCount * 0.25f), Bag.transform.localPosition.z);
                    //    a.transform.localRotation = Quaternion.identity;
                    //    //a.GetComponent<ParticleSystem>().Stop();
                    //});
                } 
            }
        }
        //if (other.gameObject.CompareTag("Stairs"))
        //{
        //    EC.enabled = true;
        //}
        if (other.gameObject.tag == "nth")
        {
            other.transform.root.GetComponent<Eliminater>().thischar(gameObject);
        }
    }
    private IEnumerator MoveBricksToBagSequentially(GameObject[] allCudes, int bricksToMove)
    {
        int movedBricks = 0;
        List<GameObject> bagChildren = new List<GameObject>();
        for (int i = 0; i < Bag.transform.childCount; i++)
        {
            bagChildren.Add(Bag.transform.GetChild(i).gameObject);
        }
        foreach (GameObject cude in allCudes)
        {
            if (bagChildren.Contains(cude))
            {
                continue;
            }
            // Check if brick color matches the player's material color
            if (cude.GetComponent<MeshRenderer>().material.color == MyMaterial.color)
            {
                cude.transform.parent = Bag.transform;
               
                StartCoroutine(SmoothMoveToBag(cude)); // Smoothly move to bag
                movedBricks++;

                if (movedBricks >= bricksToMove)
                    break; // Stop after moving the desired number of bricks

                yield return new WaitForSeconds(.1f); // Wait for 1 second before moving the next brick
                audio_source.PlayOneShot(Pick_up);
            }
        }
    }
    private IEnumerator SmoothMoveToBag(GameObject brick)
    {
        isBrickMoving = true;
        Vector3 targetPosition = new Vector3(0, Bag.transform.childCount * 0.25f, 0);

        brick.transform.DOLocalJump(targetPosition, 2.5f, 1, 0.2f)
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
        Invoke(nameof(isMoving), 1f);
    }
    private void isMoving()
    {
        isBrickMoving = false;
    }
    public void keepbricks()
    {
        mytiles = mytargetparents[stage].gameObject;
        mytargetparents[stage].GetComponent<ColorPlacer>().assigncolor(gameObject, "player");
    }
    IEnumerator stand()
    {
        animator.SetTrigger("knock");
        move = false;
        GetComponent<Collider>().isTrigger = true;
        sendallbrikesback();
        yield return new WaitForSeconds(0.6f);
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