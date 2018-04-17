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
    [SerializeField] Spawner spawner;
    [SerializeField] Text liveScoreCounter;
    [Header("All the attibutes to do with the zoom out feature")]
    [SerializeField] GameObject bottomRidge;
    [SerializeField] GameObject topRidge;    
    [Header("All the attributes to do with the game over screen")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Text myScore;
    [SerializeField] Text highScore;
    [Header("The 3 platforms to simulate depth")]
    [SerializeField] GameObject[] platforms;

    private int currentScore = 0;
    private int numOfFishEaten = 0;
    private int level = 0;
    private int platformNum = 0;

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
        Time.timeScale = 1.0f;
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
            if (playerSize == Size.SIZE_4 && level != 3)
            {
                bottomRidge.transform.position = new Vector3(bottomRidge.transform.position.x, bottomRidge.transform.position.y, bottomRidge.transform.position.z + 1);
                topRidge.transform.position = new Vector3(topRidge.transform.position.x, topRidge.transform.position.y, topRidge.transform.position.z - 1);
                level++;
                playerSize = 0;
                spawner.PlayerGrew();
                player.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                platforms[platformNum].SetActive(true);
                platformNum++;

            }
            else
            {
                playerSize++;
                player.transform.localScale = new Vector3(player.transform.localScale.x + 0.1f, player.transform.localScale.y + 0.1f, player.transform.localScale.z + 0.1f);
                numOfFishEaten = 0;
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
        liveScoreCounter.text = currentScore.ToString();
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
        gm.SaveScore(currentScore);
    }
}
