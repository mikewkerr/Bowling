using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bowling
{
    public partial class Bowling : Form
    {
        private int _totalScore;
        private int ballCounter;
        private int _highScore;
        private int _frameOneScore;
        private int _frameTwoScore;
        private int _frameThreeScore;
        private int _frameFourScore;
        private int _frameFiveScore;
        private int _frameSixScore;
        private int _frameSevenScore;
        private int _frameEightScore;
        private int _frameNineScore;
        private int _frameTenScore;

        private List<string> printedScores = Enumerable.Repeat<string>(null, 30).ToList();
        private List<int> numericScores = Enumerable.Repeat<int>(0, 30).ToList();
        
        public Bowling()
        {
            this.InitializeComponent();
            this.EnableButtons();
        }

        private void RollBall_Click(object sender, EventArgs e)
        {
            if (this.ballCounter > 20)
                return;

            int currentBallScore = this.ballCounter % 2 == 0 ? Bowling.ScoreBall() : Bowling.ScoreBall(this.numericScores[this.ballCounter - 1]);
            if(currentBallScore > 10)
                throw new ArgumentOutOfRangeException();

            if (this.ballCounter < 18)
            {
                if (this.ballCounter % 2 == 0 && currentBallScore == 10)
                {
                    this.numericScores[this.ballCounter] = 10;
                    this.printedScores[this.ballCounter] = "X";
                    this.printedScores[this.ballCounter + 1] = "-";
                    this.ballCounter += 2;
                    this.DisplayScores();
                    return;
                }

                if (this.ballCounter % 2 != 0 && (this.numericScores[this.ballCounter - 1] + currentBallScore) == 10)
                {
                    this.numericScores[this.ballCounter] = currentBallScore;
                    this.printedScores[this.ballCounter] = "/";
                    this.ballCounter++;
                    this.DisplayScores();
                    return;
                }

                this.numericScores[this.ballCounter] = currentBallScore;
                this.printedScores[this.ballCounter] = currentBallScore.ToString();
                this.DisplayScores();
                this.ballCounter++;

                return;
            }

            if (this.ballCounter >= 18 && this.ballCounter < 20)
            {
                if (this.ballCounter != 18 || currentBallScore != 10)
                {
                    if (this.ballCounter == 19 && (this.numericScores[18] + currentBallScore) == 10 && this.numericScores[18] != 10)
                    {
                        this.numericScores[this.ballCounter] = currentBallScore;
                        this.printedScores[this.ballCounter] = "/";
                        this.ballCounter++;
                        this.DisplayScores();
                        return;
                    }

                    this.numericScores[this.ballCounter] = currentBallScore;
                    this.printedScores[this.ballCounter] = currentBallScore.ToString();
                    this.DisplayScores();
                    this.ballCounter++;
                }
                else
                {
                    this.numericScores[this.ballCounter] = 10;
                    this.printedScores[this.ballCounter] = "X";
                    this.ballCounter++;
                    this.DisplayScores();
                    return;
                }
            }

            if (this.ballCounter == 20 && (this.numericScores[18] + this.numericScores[19] >= 10))
            {
                this.numericScores[this.ballCounter] = currentBallScore;
                this.printedScores[this.ballCounter] = currentBallScore.ToString();
                this.DisplayScores();
                this.ballCounter++;
            }

            if (this.ballCounter == 20 && (this.numericScores[18] + this.numericScores[19] < 10))
            {
                this.Frame10Ball3.Text = @"-";
                this.ballCounter++;
                this.DisableButtons();
            }
                
            if (this.ballCounter > 20)
                this.DisableButtons();
        }

        private void Cheater_Click(object sender, EventArgs e)
        {
            if ((this.ballCounter % 2 != 0 && this.ballCounter < 18) || this.ballCounter > 20)
                return;

            if (this.ballCounter < 18)
            {
                this.numericScores[this.ballCounter] = 10;
                this.printedScores[this.ballCounter] = "X";
                this.printedScores[this.ballCounter + 1] = "-";
                this.ballCounter += 2;
                this.DisplayScores();
                return;
            }

            this.numericScores[this.ballCounter] = 10;
            this.printedScores[this.ballCounter] = "X";
            this.DisplayScores();
            this.ballCounter++;

            if (this.ballCounter > 20)
                this.DisableButtons();
        }

        private void Loser_Click(object sender, EventArgs e)
        {
            if (this.ballCounter > 19)
                return;

            this.numericScores[this.ballCounter] = 0;
            this.printedScores[this.ballCounter] = "-";
            this.DisplayScores();
            this.ballCounter++;

            if (this.ballCounter > 19)
                this.DisableButtons();
        }

        private static int ScoreBall(int? offSet = 0)
        {
            Random randomScore = new Random();
            int score = randomScore.Next(0, 11 - offSet ?? 0);

            return score;
        }

        private void DisplayScores()
        {
            this.DisplayBallScores();
            this.DisplayFrameScore();
        }

        private void DisplayBallScores()
        {
            this.Frame1Ball1.Text = this.printedScores[0];
            this.Frame1Ball2.Text = this.printedScores[1];
            this.Frame2Ball1.Text = this.printedScores[2];
            this.Frame2Ball2.Text = this.printedScores[3];
            this.Frame3Ball1.Text = this.printedScores[4];
            this.Frame3Ball2.Text = this.printedScores[5];
            this.Frame4Ball1.Text = this.printedScores[6];
            this.Frame4Ball2.Text = this.printedScores[7];
            this.Frame5Ball1.Text = this.printedScores[8];
            this.Frame5Ball2.Text = this.printedScores[9];
            this.Frame6Ball1.Text = this.printedScores[10];
            this.Frame6Ball2.Text = this.printedScores[11];
            this.Frame7Ball1.Text = this.printedScores[12];
            this.Frame7Ball2.Text = this.printedScores[13];
            this.Frame8Ball1.Text = this.printedScores[14];
            this.Frame8Ball2.Text = this.printedScores[15];
            this.Frame9Ball1.Text = this.printedScores[16];
            this.Frame9Ball2.Text = this.printedScores[17];
            this.Frame10Ball1.Text = this.printedScores[18];
            this.Frame10Ball2.Text = this.printedScores[19];
            this.Frame10Ball3.Text = this.printedScores[20];
        }

        private void DisplayFrameScore()
        {
            this._frameOneScore = this.CalculateFrameScore(0, 1);
            this._frameTwoScore = this.CalculateFrameScore(2, 3, this._frameOneScore);
            this._frameThreeScore = this.CalculateFrameScore(4, 5, this._frameTwoScore);
            this._frameFourScore = this.CalculateFrameScore(6, 7, this._frameThreeScore);
            this._frameFiveScore = this.CalculateFrameScore(8, 9, this._frameFourScore);
            this._frameSixScore = this.CalculateFrameScore(10, 11, this._frameFiveScore);
            this._frameSevenScore = this.CalculateFrameScore(12, 13, this._frameSixScore);
            this._frameEightScore = this.CalculateFrameScore(14, 15, this._frameSevenScore);
            this._frameNineScore = this.CalculateFrameScore(16, 17, this._frameEightScore);
            this._frameTenScore = this.CalculateFrameScore(18, 19, this._frameNineScore);
            this._totalScore = this._frameTenScore;

            this.Frame1Total.Text = this.ballCounter >= 1 ? this._frameOneScore.ToString() : null;
            this.Frame2Total.Text = this.ballCounter >= 3 ? this._frameTwoScore.ToString() : null;
            this.Frame3Total.Text = this.ballCounter >= 5 ? this._frameThreeScore.ToString() : null;
            this.Frame4Total.Text = this.ballCounter >= 7 ? this._frameFourScore.ToString() : null;
            this.Frame5Total.Text = this.ballCounter >= 9 ? this._frameFiveScore.ToString() : null;
            this.Frame6Total.Text = this.ballCounter >= 11 ? this._frameSixScore.ToString() : null;
            this.Frame7Total.Text = this.ballCounter >= 13 ? this._frameSevenScore.ToString() : null;
            this.Frame8Total.Text = this.ballCounter >= 15 ? this._frameEightScore.ToString() : null;
            this.Frame9Total.Text = this.ballCounter >= 17 ? this._frameNineScore.ToString() : null;
            this.Frame10Total.Text = this.ballCounter >= 19 ? this._frameTenScore.ToString() : null;

            this.TotalScore.Text = this._totalScore.ToString();
            this.CurrentHighScore.Text = this._highScore.ToString();
        }

        private int CalculateFrameScore(int ballOne, int ballTwo, int previousFrameScore = 0)
        {
            int frameScore;
            int value = this.numericScores[ballOne] + this.numericScores[ballTwo];

            if (this.numericScores[ballOne] == 10)
            {
                value += this.numericScores[ballTwo + 1];
                if (value == 20)
                    value += this.numericScores[ballTwo + 3];
                else
                    value += this.numericScores[ballTwo + 2];

                frameScore = previousFrameScore + value;
                return frameScore;
            }

            if (value == 10)
            {
                value += this.numericScores[ballTwo + 1];
                frameScore = previousFrameScore + value;
                return frameScore;
            }

            frameScore = previousFrameScore + value;
            return frameScore;
        }

        private void EnableButtons()
        {
            this.RollBall.Enabled = true;
            this.Cheater.Enabled = true;
            this.Loser.Enabled = true;
        }
        private void DisableButtons()
        {
            this.RollBall.Enabled = false;
            this.Cheater.Enabled = false;
            this.Loser.Enabled = false;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            this.ResetGame();
        }

        private void ResetHighScore_Click(object sender, EventArgs e)
        {
            this._highScore = 0;
            this.ResetGame();
        }

        private void ResetGame()
        {
            if (this._totalScore > this._highScore)
                this._highScore = this._totalScore;

            this.EnableButtons();
            this.printedScores = Enumerable.Repeat<string>(null, 30).ToList();
            this.numericScores = Enumerable.Repeat<int>(0, 30).ToList();
            this.ballCounter = 0;
            this._totalScore = 0;
            this.DisplayScores();
        }
    }
}
