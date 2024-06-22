using Fungus;
using UnityEngine;

public class NpcEntity : MonoBehaviour
{
    [Header("npc名字，需与Block名字一致")]
    public string npcName;
    private Flowchart flowchart;
    private bool canSay;


    void Start()
    {
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canSay)
            {
                if (flowchart.HasBlock(npcName))
                {
                    flowchart.ExecuteBlock(npcName);
                    print(npcName);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canSay = true;
            print(canSay);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canSay = false;
            print(canSay);
        }
    }
}
