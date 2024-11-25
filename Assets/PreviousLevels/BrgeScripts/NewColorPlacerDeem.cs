using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class NewColorPlacerDeem : MonoBehaviour
{
    int totalPlayers;
    private void Awake()
    {
        //totalPlayers = cameramovr_Bridge.Instance.allplayers.Count;
        totalPlayers = NewCameraDeemBridge.Instance.allplayers.Count;
    }
    private void Start()
    {
        //totalPlayers= cameramovr_Bridge.Instance.allplayers.Count;
        totalPlayers = NewCameraDeemBridge.Instance.allplayers.Count;
        Debug.Log("Hello " + totalPlayers);
    }
    public void assigncolor(GameObject player, string name)
    {
        Material temp = player.transform.GetChild(0).transform.GetComponent<SkinnedMeshRenderer>().material;
        int perPlayerTiles = 120 / totalPlayers;
        for (int j = 0; j < perPlayerTiles; j++)
        {
            int k = Random.Range(0, transform.childCount);
            MeshRenderer m1 = transform.GetChild(k).transform.GetComponent<MeshRenderer>();
            m1.material = temp;
            m1.enabled = true;
            if (name == "bot")
            {
                //player.GetComponent<AIcontroler_Bridge>().MyTargets.Add(transform.GetChild(k).transform.gameObject);
                player.GetComponent<NewAiControllerDeem>().MyTargets.Add(transform.GetChild(k).transform.gameObject);
            }
            else if (name == "player")
            {
                //player.GetComponent<BridgeControllerr_Bridge>().MyTargets.Add(transform.GetChild(k).transform.gameObject);
                player.GetComponent<NewBridgePlayerController>().MyTargets.Add(transform.GetChild(k).transform.gameObject);
            }
            transform.GetChild(k).parent = null;
        }
    }
}
