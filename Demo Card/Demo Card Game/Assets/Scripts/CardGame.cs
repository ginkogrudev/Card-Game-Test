using UnityEngine;
using System.Collections;

public class CardGame : MonoBehaviour
{

    public int HandSize = 6;
    public GameObject CardBack;

    private GameObject[] Hand;
    private GameObject[] EnemyHand;

    public GameObject[] FiaryDeck = new GameObject[6];
    public GameObject[] WitchDeck = new GameObject[6];

    private int[] MyCards = new int[6];
    private int[] EnemyCards = new int[6];

    public int CardType;
    public string CardName;

    // Use this for initialization
    void Start()
    {

        Hand = new GameObject[HandSize];
        for (int i = 0; i < HandSize; i++)
        {
            CardType = Random.Range(0,5);
            GameObject go = GameObject.Instantiate(FiaryDeck[CardType]) as GameObject;
            Vector3 positionCard = new Vector3((i * 4)+ 1,1,0);
            go.transform.position = positionCard;
            Hand[i] = go;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
