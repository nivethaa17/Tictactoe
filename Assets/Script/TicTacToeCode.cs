/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeCode : MonoBehaviour
{
    bool checker;
    int plusone;
    bool gameOver;

    public Text btnText1 = null;
    public Text btnText2 = null;
    public Text btnText3 = null;
    public Text btnText4 = null;
    public Text btnText5 = null;
    public Text btnText6 = null;
    public Text btnText7 = null;
    public Text btnText8 = null;
    public Text btnText9 = null;

    public Button btn1 = null;
    public Button btn2 = null;
    public Button btn3 = null;
    public Button btn4 = null;
    public Button btn5 = null;
    public Button btn6 = null;
    public Button btn7 = null;
    public Button btn8 = null;
    public Button btn9 = null;

    public Button btnResetGame = null;
    public Button btnNewGame = null;
    public Text msgFeedback = null;

    public Text txtPlayerX;
    public Text txtPlayerO;

    private bool hasWinner;

    void Start()
    {
        btn1.onClick.AddListener(() => btnText_Click(btnText1));
        btn2.onClick.AddListener(() => btnText_Click(btnText2));
        btn3.onClick.AddListener(() => btnText_Click(btnText3));
        btn4.onClick.AddListener(() => btnText_Click(btnText4));
        btn5.onClick.AddListener(() => btnText_Click(btnText5));
        btn6.onClick.AddListener(() => btnText_Click(btnText6));
        btn7.onClick.AddListener(() => btnText_Click(btnText7));
        btn8.onClick.AddListener(() => btnText_Click(btnText8));
        btn9.onClick.AddListener(() => btnText_Click(btnText9));

        btnResetGame.onClick.AddListener(btnResetGame_Click);
        btnNewGame.onClick.AddListener(btnNewGame_Click);
    }

    public void score()
    {
        hasWinner = false;

        if (CheckWinCondition(btnText1, btnText2, btnText3) || CheckWinCondition(btnText1, btnText4, btnText7) ||
            CheckWinCondition(btnText1, btnText5, btnText9) || CheckWinCondition(btnText3, btnText5, btnText7) ||
            CheckWinCondition(btnText2, btnText5, btnText8) || CheckWinCondition(btnText3, btnText6, btnText9) ||
            CheckWinCondition(btnText4, btnText5, btnText6) || CheckWinCondition(btnText7, btnText8, btnText9))
        {
            hasWinner = true;
            gameOver = true;
            SetButtonsInteractable(false);
        }
        else if (IsBoardFull())
        {
            msgFeedback.text = "It's a Tie!";
            gameOver = true;
        }
    }

    private bool CheckWinCondition(Text btn1, Text btn2, Text btn3)
    {
        if (btn1.text != "" && btn1.text == btn2.text && btn2.text == btn3.text)
        {
            if (btn1.text == "X")
            {
                btn1.color = Color.red;
                btn2.color = Color.red;
                btn3.color = Color.red;
                msgFeedback.text = "The Winner is Player X";
                plusone = int.Parse(txtPlayerX.text);
                txtPlayerX.text = (plusone + 1).ToString();
            }
            else if (btn1.text == "O")
            {
                btn1.color = Color.blue;
                btn2.color = Color.blue;
                btn3.color = Color.blue;
                msgFeedback.text = "The Winner is Player O";
                plusone = int.Parse(txtPlayerO.text);
                txtPlayerO.text = (plusone + 1).ToString();
            }
            return true;
        }
        return false;
    }

    private bool IsBoardFull()
    {
        return btnText1.text != "" && btnText2.text != "" && btnText3.text != "" &&
               btnText4.text != "" && btnText5.text != "" && btnText6.text != "" &&
               btnText7.text != "" && btnText8.text != "" && btnText9.text != "";
    }

    private void SetButtonsInteractable(bool interactable)
    {
        btn1.interactable = interactable;
        btn2.interactable = interactable;
        btn3.interactable = interactable;
        btn4.interactable = interactable;
        btn5.interactable = interactable;
        btn6.interactable = interactable;
        btn7.interactable = interactable;
        btn8.interactable = interactable;
        btn9.interactable = interactable;
    }

    public void btnText_Click(Text btnText)
    {
        if (!gameOver && btnText.text == "")
        {
            if (checker == false)
            {
                btnText.text = "X";
                checker = true;
            }
            else
            {
                btnText.text = "O";
                checker = false;
            }
            score();
        }
    }

    public void btnResetGame_Click()
    {
        btnText1.text = "";
        btnText2.text = "";
        btnText3.text = "";
        btnText4.text = "";
        btnText5.text = "";
        btnText6.text = "";
        btnText7.text = "";
        btnText8.text = "";
        btnText9.text = "";

        btnText1.color = Color.white;
        btnText2.color = Color.white;
        btnText3.color = Color.white;
        btnText4.color = Color.white;
        btnText5.color = Color.white;
        btnText6.color = Color.white;
        btnText7.color = Color.white;
        btnText8.color = Color.white;
        btnText9.color = Color.white;

        msgFeedback.text = "";

        checker = false;
        gameOver = false;

        SetButtonsInteractable(true);
    }

    public void btnNewGame_Click()
    {
        btnResetGame_Click();
        txtPlayerX.text = "0";
        txtPlayerO.text = "0";
    }
}*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeCode : MonoBehaviour
{
    private bool isPlayerXTurn;
    private bool isGameOver;
    private bool hasWinner;

    public Text[] buttonTexts = new Text[9];
    public Button[] buttons = new Button[9];
    public Button resetButton;
    public Button newGameButton;
    public Text feedbackText;
    public Text playerXScoreText;
    public Text playerOScoreText;

    private void Start()
    {
        isPlayerXTurn = true;
        isGameOver = false;
        SetButtonListeners();
        resetButton.onClick.AddListener(ResetGame);
        newGameButton.onClick.AddListener(NewGame);
    }

    private void SetButtonListeners()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // capture the current index in a local variable
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    private void OnButtonClick(int index)
    {
        if (!isGameOver && buttonTexts[index].text == "")
        {
            buttonTexts[index].text = isPlayerXTurn ? "X" : "O";
            isPlayerXTurn = !isPlayerXTurn;
            CheckGameState();
        }
    }

    private void CheckGameState()
    {
        if (CheckWinConditions())
        {
            isGameOver = true;
            feedbackText.text = isPlayerXTurn ? "O Wins!" : "X Wins!";
            UpdateScore(isPlayerXTurn ? playerOScoreText : playerXScoreText);
        }
        else if (IsBoardFull())
        {
            isGameOver = true;
            feedbackText.text = "It's a Tie!";
        }
    }

    private bool CheckWinConditions()
    {
        int[,] winConditions = new int[,]
        {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Rows
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Columns
            {0, 4, 8}, {2, 4, 6}             // Diagonals
        };

        for (int i = 0; i < winConditions.GetLength(0); i++)
        {
            if (buttonTexts[winConditions[i, 0]].text == buttonTexts[winConditions[i, 1]].text &&
                buttonTexts[winConditions[i, 1]].text == buttonTexts[winConditions[i, 2]].text &&
                buttonTexts[winConditions[i, 0]].text != "")
            {
                HighlightWinningButtons(winConditions[i, 0], winConditions[i, 1], winConditions[i, 2]);
                return true;
            }
        }
        return false;
    }

    private void HighlightWinningButtons(int index1, int index2, int index3)
    {
        Color winColor = isPlayerXTurn ? Color.blue : Color.red;
        buttonTexts[index1].color = winColor;
        buttonTexts[index2].color = winColor;
        buttonTexts[index3].color = winColor;
    }

    private bool IsBoardFull()
    {
        foreach (Text btnText in buttonTexts)
        {
            if (btnText.text == "")
                return false;
        }
        return true;
    }

    private void UpdateScore(Text playerScoreText)
    {
        int score = int.Parse(playerScoreText.text);
        playerScoreText.text = (score + 1).ToString();
    }

    private void ResetGame()
    {
        foreach (Text btnText in buttonTexts)
        {
            btnText.text = "";
            btnText.color = Color.white;
        }
        feedbackText.text = "";
        isPlayerXTurn = true;
        isGameOver = false;
    }

    private void NewGame()
    {
        ResetGame();
        playerXScoreText.text = "0";
        playerOScoreText.text = "0";
    }
}
