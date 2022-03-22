using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Premier joueur joue les O
    // IA joue les X

    public GameObject[] tab = new GameObject[9];
    public GameObject[,] grid = new GameObject[3, 3];

    public int counterTurn=0;
    
    public bool playerWin=false;
    

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        grid[0, 0] = tab[0];
        grid[1, 0] = tab[1];
        grid[2, 0] = tab[2];
        grid[0, 1] = tab[3];
        grid[1, 1] = tab[4];
        grid[2, 1] = tab[5];
        grid[0, 2] = tab[6];
        grid[1, 2] = tab[7];
        grid[2, 2] = tab[8];
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWin == false)
        {
            checkGame();

        }
    }
    void checkGame()
    {
        for (int i = 0; i < 3; i++)
        {
            if (grid[i, 0].GetComponent<Tile>().type == grid[i, 1].GetComponent<Tile>().type && grid[i, 1].GetComponent<Tile>().type == grid[i, 2].GetComponent<Tile>().type && grid[i, 2].GetComponent<Tile>().type != Tile.Type.None)
            {
                playerWin = true;
                endGame(grid[i, 0], grid[i, 1], grid[i, 2]);
                Debug.Log("win");
            }
            if (grid[0, i].GetComponent<Tile>().type == grid[1, i].GetComponent<Tile>().type && grid[1, i].GetComponent<Tile>().type == grid[2, i].GetComponent<Tile>().type && grid[2, i].GetComponent<Tile>().type != Tile.Type.None)
            {
                playerWin = true;
                endGame(grid[0, i], grid[1, i], grid[2, i]);
                Debug.Log("win");
            }
        }
        if (grid[0, 0].GetComponent<Tile>().type == grid[1, 1].GetComponent<Tile>().type && grid[1, 1].GetComponent<Tile>().type == grid[2, 2].GetComponent<Tile>().type && grid[1, 1].GetComponent<Tile>().type != Tile.Type.None)
        {
            playerWin = true;
            endGame(grid[0, 0], grid[1, 1], grid[2, 2]);
            Debug.Log("win");

        }
        if (grid[2, 0].GetComponent<Tile>().type == grid[1, 1].GetComponent<Tile>().type && grid[1, 1].GetComponent<Tile>().type == grid[0, 2].GetComponent<Tile>().type && grid[1, 1].GetComponent<Tile>().type != Tile.Type.None)
        {
            playerWin = true;
            endGame(grid[2, 0], grid[1, 1], grid[0, 2]);
            Debug.Log("win");

        }
    }

    public bool checkGameIA(Tile.Type typeToCheck, GameObject[,] newGrid)
    {
        bool found = false;
        for (int i = 0; i < 3; i++)
        {
            if (newGrid[i, 0].GetComponent<Tile>().type == newGrid[i, 1].GetComponent<Tile>().type && newGrid[i, 1].GetComponent<Tile>().type == newGrid[i, 2].GetComponent<Tile>().type && newGrid[i, 2].GetComponent<Tile>().type == typeToCheck)
            {
                found = true;
                break;
            }
            if (newGrid[0, i].GetComponent<Tile>().type == newGrid[1, i].GetComponent<Tile>().type && newGrid[1, i].GetComponent<Tile>().type == newGrid[2, i].GetComponent<Tile>().type && newGrid[2, i].GetComponent<Tile>().type == typeToCheck)
            {
                found = true;
                break;
            }
        }
        if (newGrid[0, 0].GetComponent<Tile>().type == newGrid[1, 1].GetComponent<Tile>().type && newGrid[1, 1].GetComponent<Tile>().type == newGrid[2, 2].GetComponent<Tile>().type && newGrid[1, 1].GetComponent<Tile>().type == typeToCheck && !found)
        {
            found = true;
            

        }
        if (newGrid[2, 0].GetComponent<Tile>().type == newGrid[1, 1].GetComponent<Tile>().type && newGrid[1, 1].GetComponent<Tile>().type == newGrid[0, 2].GetComponent<Tile>().type && newGrid[1, 1].GetComponent<Tile>().type == typeToCheck && !found)
        {
            found = true;
            

        }
        Debug.Log("found" + found);
        return found; 
    }

    public void endGame(GameObject tile1, GameObject tile2, GameObject tile3)
    {
        
        tile1.GetComponent<SpriteRenderer>().color = Color.red;
        tile2.GetComponent<SpriteRenderer>().color = Color.red;
        tile3.GetComponent<SpriteRenderer>().color = Color.red;

    }
}

