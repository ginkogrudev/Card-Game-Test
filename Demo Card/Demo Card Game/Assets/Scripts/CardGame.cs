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

    public int MyLife = 5;
    public int EnemyLife = 5;

    public bool playerHasWon = false;

    // Use this for initialization
    void Start()
    {

        Hand = new GameObject[HandSize];
        for (int i = 0; i < HandSize; i++)
        {
            CardType = Random.Range(0,5);
            CardName = string.Format("Fairy{0}", CardType);
            GameObject go = GameObject.Instantiate(FiaryDeck[CardType]) as GameObject;
            Vector3 positionCard = new Vector3((i * 4)+ 1,1,0);
            go.transform.position = positionCard;
            Hand[i] = go;
        }

        EnemyHand = new GameObject[HandSize];
        for (int x = 0; x < HandSize;  x++)
        {
            CardType = Random.Range(0, 5);
            CardName = string.Format("Witch {0}", CardType);
            EnemyCards[x] = CardType ;

            GameObject go = GameObject.Instantiate(CardBack) as GameObject;
            Vector3 positionEnemy = new Vector3((x * 4) + 1, 11, 0);
            go.transform.position = positionEnemy;

            EnemyHand[x] = go;
        }

    }

    // Update is called once per frame
    void Update()
    {

        // Check for the mouse left click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Card")
                {
                    Debug.Log(hit.transform.gameObject.name);
                    //TODO Make Logic 
                    GameObject CardClicked = hit.transform.gameObject;

                    string CardEnemyPlayed = EnemyTurn();
                    ResolveBattle(CardClicked.name , CardEnemyPlayed);
                    DrawNewCard(CardClicked);
                }
            }
        }

        if (MyLife <= 0)
        {
            playerHasWon = false;
            EndGame();
        }

        if (EnemyLife <= 0)
        {
            playerHasWon = true;
            EndGame();
        }
    }

    void EndGame()
    {
        if (playerHasWon = true)
        {
            Application.LoadLevel("YouWin");
        }
        else
        {
            Application.LoadLevel("GameOver");
        }
    }

    string EnemyTurn()
    {

        // Plays a random card from hand 
        int PickACardAtRandom = Random.Range(0, HandSize);
        GameObject ChosenCard = EnemyHand[PickACardAtRandom];
        string EnemyCard = ChosenCard.name;

        // Chosen card 

        int NewDraw = Random.Range(0, 5);
        EnemyHand[PickACardAtRandom] = WitchDeck[NewDraw];

        CardName = string.Format("Witch{0}", NewDraw);

        GameObject go = GameObject.Instantiate(WitchDeck[NewDraw]) as GameObject;
        go.name = CardName;
        go.transform.position = ChosenCard.transform.position;

        Destroy(ChosenCard);

        return EnemyCard;
    }

    void ResolveBattle(string CardClicked , string CardEnemyPlayed)
    {
        if (CardClicked == "Fairy0")
        {
            EnemyLife--;
        }

        if (CardClicked == "Fairy1")
        {
            EnemyLife--;
        }

        if (CardClicked == "Fairy2")
        {
            EnemyLife--;
        }

        if (CardClicked == "Fairy5")
        {
            MyLife--;
        }

        if (CardEnemyPlayed == "Witch0")
        {
            MyLife--;
        }

        if (CardEnemyPlayed == "Witch1")
        {
            MyLife--;
        }

        if (CardEnemyPlayed == "Witch2")
        {
            MyLife--;
        }

        if (CardEnemyPlayed == "Witch5")
        {
            EnemyLife++;
        }
    }

    void DrawNewCard(GameObject oldCard )
    {

    }


    void OnGUI()
    {
        GUI.Label(new Rect(10, 70, 100, 20), "Witch: " + EnemyLife);
        GUI.Label(new Rect(10, 230, 100, 20), "Fairy: " + MyLife);

    }
}
