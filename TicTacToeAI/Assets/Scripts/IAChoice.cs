using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAChoice : MonoBehaviour
{
    

    public GameObject prefabCross;
    bool find;
    List<GameObject> listTileFree = new List<GameObject>();
    GameObject[,] IAGrid = new GameObject[3, 3];

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.playerWin == false)
        {
            if(GameManager.instance.counterTurn == 1)
            {
                Debug.Log("premier tour");
                FirstTurn();
            }
            else  
            {
                Debug.Log("autre tour");

                if (GameManager.instance.counterTurn % 2 != 0 )
                {
                    choiceInArray();

                }
            }
        }
    }

    public void FirstTurn()
    {
        GameObject[,] IAGrid = GameManager.instance.grid;

        if (IAGrid[0, 0].GetComponent<Tile>().type != Tile.Type.None || IAGrid[0, 2].GetComponent<Tile>().type != Tile.Type.None || IAGrid[2, 2].GetComponent<Tile>().type != Tile.Type.None || IAGrid[2, 0].GetComponent<Tile>().type != Tile.Type.None)
        {
            
            GameObject newTile = GameManager.instance.grid[1, 1];
            newTile.GetComponent<Tile>().type = Tile.Type.X;
            Instantiate(prefabCross, new Vector3(newTile.transform.position.x, newTile.transform.position.y, -1), Quaternion.identity);
            //Instantiate(prefabCross, newTile.transform.position, Quaternion.identity);
            newTile.GetComponent<Tile>().canBePlayed = false;
            GameManager.instance.counterTurn++;
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GameManager.instance.grid[i, j].GetComponent<Tile>().type == Tile.Type.None)
                    {
                        listTileFree.Add(GameManager.instance.grid[i, j]);
                        

                    }
                }
            }
            int rand = Random.Range(0, listTileFree.Count);
            GameObject newTile = listTileFree[rand];
            newTile.GetComponent<Tile>().type = Tile.Type.X;
            Instantiate(prefabCross, new Vector3(newTile.transform.position.x, newTile.transform.position.y, -1), Quaternion.identity);
            //Instantiate(prefabCross, newTile.transform.position, Quaternion.identity);
            newTile.GetComponent<Tile>().canBePlayed = false;
            GameManager.instance.counterTurn++;

        }
    }
    public void choiceInArray()
    {
        GameObject[,] IAGrid = GameManager.instance.grid;

        Debug.Log("autour de l ia");

        //listTileFree.Clear();
        int bestScore = -10;
        
        int xCoord=0;
        int yCoord=0;
        bool winnerFound = false;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int score = 10;
                if (IAGrid[i, j].GetComponent<Tile>().type == Tile.Type.None)
                {
                    IAGrid[i, j].GetComponent<Tile>().type = Tile.Type.X;
                    //listTileFree.Add(GameManager.instance.grid[i, j]);
                    if (GameManager.instance.checkGameIA(Tile.Type.X,IAGrid))
                    {
                        bestScore = 1000;
                        xCoord = i;
                        yCoord = j;
                        winnerFound = true;
                        break;
                    }
                    else
                    {
                        Debug.Log("dans le else");
                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                if (IAGrid[k, l].GetComponent<Tile>().type == Tile.Type.None)
                                {
                                    IAGrid[k, l].GetComponent<Tile>().type = Tile.Type.O;
                                    if (GameManager.instance.checkGameIA(Tile.Type.O, IAGrid))
                                    {
                                        score -= 1;
                                    }
                                    IAGrid[k, l].GetComponent<Tile>().type = Tile.Type.None;
                                }
                            }
                        }
                        if (score > bestScore)
                        {
                            bestScore = score;
                            xCoord = i;
                            yCoord = j;
                        }
                    }
                    IAGrid[i, j].GetComponent<Tile>().type=Tile.Type.None;
                }


            }
            if (winnerFound) break;

            
        }
        
        
        GameObject newTile = GameManager.instance.grid[xCoord, yCoord];
        newTile.GetComponent<Tile>().type = Tile.Type.X;
        Instantiate(prefabCross, new Vector3(newTile.transform.position.x, newTile.transform.position.y, -1), Quaternion.identity);
        //Instantiate(prefabCross, newTile.transform.position, Quaternion.identity);
        newTile.GetComponent<Tile>().canBePlayed = false;
        GameManager.instance.counterTurn++;

        //Tile tile =listTileFree[0].GetComponent<Tile>();
        //tile.type = Tile.Type.X;
    }
}
