using System;
using Player;
using TMPro;
using UnityEngine;

namespace Manager
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;

        [SerializeField] private TMP_Text redText;
        [SerializeField] private TMP_Text blueText;
        [SerializeField] private TMP_Text winText;

        [SerializeField] private int redValue=0;
        [SerializeField] private int blueValue = 0;
        

        private void Awake()
        {
            if (instance==null)
            {
                instance = this;
            }
            SetText();
        }

        public void Goal(PlayerType type)
        {
            switch (type)
            {
                case PlayerType.Player:
                    blueValue++;
                    break;
                case PlayerType.PC:
                    redValue++;
                    break;
                case PlayerType.Grey:
                    break;
            }
            SetText();
            CheckWinner();
        }

        private void CheckWinner()
        {
            if (redValue>=1)
            {
                //Debug.Log("Red is Winner");
                winText.text = "Red Win!";
                winText.color=Color.red;
                Time.timeScale = 0f;
            }else if (blueValue>=1)
            {
                //Debug.Log("Blue is Winner");
                winText.text = "Blue Win!";
                winText.color=Color.blue;
                Time.timeScale = 0f;
            }
        }

        private void SetText()
        {
            redText.text = "Red: " + redValue;
            blueText.text = "Blue: " + blueValue;
        }
    }
}