using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject prefabCross;
    public GameObject prefabCircle;

    public bool canBePlayed = true;
    public enum Type
    {
        None,
        X,
        O
    }

    public Type type;

    private void OnMouseDown()
    {
        if (GameManager.instance.playerWin==false)
        {
            if (canBePlayed)
            {
                if (GameManager.instance.counterTurn % 2 == 0)
                {
                    Instantiate(prefabCircle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,-1), Quaternion.identity);
                    type = Type.O;
                    canBePlayed = false;
                    GameManager.instance.counterTurn++;
                }
                //else
                //{
                //    Instantiate(prefabCross, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);
                //    type = Type.X;
                //    GameManager.instance.counterTurn++;
                //    canBePlayed = false;
                //}
            }
        }
        
        
    }

    public void CompleteArrayForAI(Vector3 TilePosition)
    {
        Instantiate(prefabCross, TilePosition, Quaternion.identity);
        type = Type.X;
        GameManager.instance.counterTurn++;
        canBePlayed = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
