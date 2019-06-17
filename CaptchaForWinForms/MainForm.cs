﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptchaForWinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //Setting checked change events of the check boxes.
            CBoxNumeric.CheckedChanged += CBoxs_CheckedChanged;
            CBoxLowCaseChar.CheckedChanged += CBoxs_CheckedChanged;
            CBoxUpCaseChar.CheckedChanged += CBoxs_CheckedChanged;
            CBoxSymbol.CheckedChanged += CBoxs_CheckedChanged;

            CBoxLine.CheckedChanged += CBoxs_CheckedChanged;
            CBoxNoise.CheckedChanged += CBoxs_CheckedChanged;
        }

        /// <summary>
        /// Global objects and variables.
        /// </summary>
        #region Global objects and variables.
        WinFormCaptcha cp;
        #endregion

        /// <summary>
        /// Form load event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            /*New instance was created from WinFormCaptcha and
             * was set necessary parameters.*/
            cp = new WinFormCaptcha(5, PanelCaptcha.Width, PanelCaptcha.Height,
            true, true, true, true, true, true);
            cp.IsIncludeSymbol = false;

            //Captcha image was created and was set as background image of the panel's.
            PanelCaptcha.BackgroundImage = cp.DrawCaptcha();
        }

        /// <summary>
        /// This method is run when click refresh button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            //Captcha image was created and was set as background image of the panel's.
            PanelCaptcha.BackgroundImage = cp.DrawCaptcha();
        }

        /// <summary>
        /// This method is run when click listen button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnListen_Click(object sender, EventArgs e)
        {
            //Text on captcha was voiced by computer.
            cp.ListenCaptcha();
        }

        /// <summary>
        /// This method is run when click check button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCheck_Click(object sender, EventArgs e)
        {
            //Control was made according to the match status of the texts.
            if (cp.CheckCorrect(TxtCheckText.Text))
            {
                LblStatus.ForeColor = Color.Green;
                LblStatus.Text = "Correct!";
            }
            else if (TxtCheckText.Text == string.Empty)
            {
                LblStatus.ForeColor = Color.Red;
                LblStatus.Text = "Please enter text!";
            }
            else
            {
                LblStatus.ForeColor = Color.Red;
                LblStatus.Text = "Wrong!";
            }
        }

        /// <summary>
        /// This method is run when click save button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            cp.SaveCaptcha(Application.StartupPath,
                System.Drawing.Imaging.ImageFormat.Png);
        }

        /// <summary>
        /// This method is change captcha setting when changed captcha preferences.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBoxs_CheckedChanged(object sender, EventArgs e)
        {
            cp.ChangeCaptchaSettings(CBoxNumeric.Checked, CBoxLowCaseChar.Checked,
                CBoxUpCaseChar.Checked, CBoxSymbol.Checked, CBoxLine.Checked,
                CBoxNoise.Checked);
        }

        /// <summary>
        /// This method is open about form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            using (AboutForm aboutFrm=new AboutForm())
            {
                aboutFrm.ShowDialog();
            }
        }
    }
}