using System;
using Player;
using TMPro;
using UnityEngine;

namespace Manager
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;

        #region Variables

        [SerializeField] private TMP_Text redText;
        [SerializeField] private TMP_Text blueText;
        [SerializeField] private TMP_Text winText;

        [SerializeField] private int redValue=0;
        [SerializeField] private int blueValue = 0;

        #endregion

        #region Monobehaviour Events

        private void Awake()
        {
            if (instance==null)
            {
                instance = this;
            }
            SetText();
        }

        #endregion

        #region Functions

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
            if (redValue>=5)
            {
                //Debug.Log("Red is Winner");
                winText.text = "Red Win!";
                winText.color=Color.red;
                Time.timeScale = 0f;
            }else if (blueValue>=5)
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

        #endregion
    }
}