using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private GameManager gm;
    public static Game instance;
    [SerializeField] int numFishToProgress;
    [SerializeField] GameObject player;
    [Header("All the attibutes to do with the zoom out feature")]
    [SerializeField] GameObject bottomRidge;
    [SerializeField] GameObject topRidge;    
    [Header("All the attributes to do with the game over screen")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Text myScore;
    [SerializeField] Text highScore;

    private int currentScore = 0;
    private int numOfFishEaten = 0;
    private int level = 0;

    private Size playerSize = 0;

    // Use this for initialization
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }
    void Start ()
    {
        gm = GameManager.instance;
        gm.GameState += SetupScene;
        gm.SetState(State.GAME);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(numOfFishEaten >= numFishToProgress)
        {
            playerSize++;
            numOfFishEaten = 0;
            if(playerSize == Size.SIZE_4)
            {
                bottomRidge.transform.position = new Vector3(bottomRidge.transform.position.x, bottomRidge.transform.position.y, bottomRidge.transform.position.z + 1);
                topRidge.transform.position = new Vector3(topRidge.transform.position.x, topRidge.transform.position.y, topRidge.transform.position.z - 1);
                level++;
                playerSize = 0;
            }
            player.GetComponent<Player>().SetSize(playerSize);
        }
	}

    void SetupScene()
    {

    }

    public void AddScore(int a_score)
    {
        currentScore += a_score;
    }
    public void EatenFish()
    {
        numOfFishEaten++;
    }

    public void PlayerKilled()
    {
        Time.timeScale = 0.0f;
        gameOverScreen.SetActive(true);
        myScore.text = currentScore.ToString();
        highScore.text = gm.GetTopScore().ToString();
    }
}
