using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class Bot : MonoBehaviour
{
    public Button[] ButtonsEnter = new Button[9];
    public Button[,] Buttons = new Button[3, 3];
    public bool Botplay=false;
    public string[] values =  new string[2];
    List<int> Historique = new List<int>();
    public int NombreRecursion ; //dans unity

    public int Choice = 100;
    public Color green;
    public Color red;
     
    void Start()
    {
        Buttons[0, 0] = ButtonsEnter[0];
        Buttons[1, 0] = ButtonsEnter[1];
        Buttons[2, 0] = ButtonsEnter[2];
        Buttons[0, 1] = ButtonsEnter[3];
        Buttons[1, 1] = ButtonsEnter[4];
        Buttons[2, 1] = ButtonsEnter[5];
        Buttons[0, 2] = ButtonsEnter[6];
        Buttons[1, 2] = ButtonsEnter[7];
        Buttons[2, 2] = ButtonsEnter[8];

        values[0] = "X";
        values[1] = "O";
    }

    void Update()
    {
        if (Botplay)//au bot de jouer
        {
            CompleteArray(Buttons, NombreRecursion, Botplay, Historique);

            Buttons[Choice % 3, Choice / 3].GetComponentInChildren<Text>().text = values[1];
            Buttons[Choice % 3, Choice / 3].GetComponentInChildren<Text>().color = red;

            Botplay = !Botplay;
        }
        //Debug.LogError(IsGameFinish());
       // Debug.LogError(Buttons[0, 0].GetComponentInChildren<Text>().text);
    }

    public void OnDifficultyChange(GameObject dropdown)
    {
        int difficulty = dropdown.GetComponent<Dropdown>().value;
        //NombreRecursion = (int)Math.Pow(difficulty, 3) + 1;
        
        if (difficulty == 0)
        {
            NombreRecursion = 1;
        }
        if (difficulty == 1)
        {
            NombreRecursion = 2;
        }
        if (difficulty == 2)
        {
            NombreRecursion = 8;
        }

    }

    IEnumerator WaitForOneSeconde(bool doublle)
    {
        yield return new WaitForSeconds(0.1f);
        if (doublle)
        {
            OnButtonClickedRestart(false);
        }
    }


    public void OnButtonClickedRestart(bool doublle)
    {
        for (int i = 0; i < 9; i++)
        {
            Buttons[i % 3, i / 3].GetComponentInChildren<Text>().text = "";
        }
        for (int i = 0; i < 9; i++)
        {
            Buttons[i % 3, i / 3].GetComponentInChildren<Text>().text = "";
        }
        StartCoroutine(WaitForOneSeconde(doublle));
        
    }

    public void OnButtonClicked(GameObject but)
    {
        Text textt = but.GetComponentInChildren<Text>();
        textt.text = "X";
        textt.color = green;
        Botplay = true;
    }

    public void OnButtonClickedForDebugg(GameObject but)
    {
        Botplay = true;
    }

    public bool GameFinish(Button[,] Buttons)
    {
        int compteur = 0;
        for (int i = 0; i < 9; i++)
        {
            if (Buttons[i % 3, i / 3].GetComponentInChildren<Text>().text != "")
            {
                compteur++;
            }
        }
        if (compteur==9)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }


    public int ScoreGame(Button[,] Buttons)
    {
        for (int i = 0; i < values.Length; i++)
        {
            //ligne
            if (Buttons[0, 0].GetComponentInChildren<Text>().text == values[i] && Buttons[1, 0].GetComponentInChildren<Text>().text == values[i] && Buttons[2, 0].GetComponentInChildren<Text>().text == values[i])
            {
                if (values[i]=="O")
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            if (Buttons[0, 1].GetComponentInChildren<Text>().text == values[i] && Buttons[1, 1].GetComponentInChildren<Text>().text == values[i] && Buttons[2, 1].GetComponentInChildren<Text>().text == values[i])
            {
                if (values[i] == "O")
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            if (Buttons[0, 2].GetComponentInChildren<Text>().text == values[i] && Buttons[1, 2].GetComponentInChildren<Text>().text == values[i] && Buttons[2, 2].GetComponentInChildren<Text>().text == values[i])
            {
                if (values[i] == "O")
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            //colonne
            if (Buttons[0, 0].GetComponentInChildren<Text>().text == values[i] && Buttons[0, 1].GetComponentInChildren<Text>().text == values[i] && Buttons[0, 2].GetComponentInChildren<Text>().text == values[i])
            {
                if (values[i] == "O")
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            if (Buttons[1, 0].GetComponentInChildren<Text>().text == values[i] && Buttons[1, 1].GetComponentInChildren<Text>().text == values[i] && Buttons[1, 2].GetComponentInChildren<Text>().text == values[i])
            {
                if (values[i] == "O")
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            if (Buttons[2, 0].GetComponentInChildren<Text>().text == values[i] && Buttons[2, 1].GetComponentInChildren<Text>().text == values[i] && Buttons[2, 2].GetComponentInChildren<Text>().text == values[i])
            {
                if (values[i] == "O")
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            //diag
            if (Buttons[0, 0].GetComponentInChildren<Text>().text == values[i] && Buttons[1, 1].GetComponentInChildren<Text>().text == values[i] && Buttons[2, 2].GetComponentInChildren<Text>().text == values[i])
            {
                if (values[i] == "O")
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            if (Buttons[0, 2].GetComponentInChildren<Text>().text == values[i] && Buttons[1, 1].GetComponentInChildren<Text>().text == values[i] && Buttons[2, 0].GetComponentInChildren<Text>().text == values[i])
            {
                if (values[i] == "O")
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

        }


        return 0;
    }

    public List<int> CompleteArray(Button[,] Array, int recursionNb, bool botplay, List<int> historique)
    {
        //Debug.Log("StartCompleteArray" + " recursion=" + recursionNb);
        List<int> Scores = new List<int>();
        List<int> ScoresTempo = new List<int>();

        string symbol;
        if (botplay)
        {
            symbol = "O";
        }
        else
        {
            symbol = "X";  // X   here 
        }

        if (recursionNb==0 || ScoreGame(Array)!=0 || GameFinish(Array))
        {
            //Debug.Log("Score "+ScoreGame(Array));
            return new List<int>() { ScoreGame(Array), historique[historique.Count - 1] };
 
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                if (Array[i % 3, i / 3].GetComponentInChildren<Text>().text == "")//si c'est libre 
                {

                    Array[i % 3, i / 3].GetComponentInChildren<Text>().text = symbol; // je joue
                                                                              //Debug.Log("Play on  0 0" + " by bot? " + botplay + " recursion="+recursionNb);
                    historique.Add(i);

                    ScoresTempo = CompleteArray(Array, recursionNb - 1, !botplay, historique);
                    for (int ii = 0; ii < ScoresTempo.Count; ii++)
                    {
                        Scores.Add(ScoresTempo[ii]);
                    }
                    ScoresTempo = new List<int>();
                    Array[i % 3, i / 3].GetComponentInChildren<Text>().text = "";

                    if (historique.Count > 0 && historique != null)
                    {
                        historique.RemoveAt(historique.Count - 1);
                    }
                }
            }
        }


        //Debug.Log("ScoreMaxStart");
        List<int> RealScore = new List<int>();
        List<int> RealPosition = new List<int>();
        for (int i = 0; i < Scores.Count/2; i++)
        {
            //Debug.Log("ScoreMax "+ Scores[i*2] + " " + Scores[i * 2 +1]);
            RealScore.Add(Scores[i * 2]);
            RealPosition.Add(Scores[i * 2 + 1]);
        }

        int scoremax;
        if (botplay)//botplay
        {
            scoremax = RealScore.Max();
        }
        else
        {
            scoremax = RealScore.Min();
        }
        int pos = RealPosition[ RealScore.IndexOf(scoremax) ];
        //Debug.Log("ScoreMax "+scoremax + "   Taille " + Scores.Count + "   bestposition "+ pos + " recursion=" + recursionNb);

        if (recursionNb == NombreRecursion)
        {
            //Debug.LogError("TEs");
            Choice = pos;
        }


        if (historique.Count>0)
        {
            return new List<int>() { scoremax, historique[historique.Count - 1] };
        }
        return new List<int>() { scoremax, -2 };
    }
}
