﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Graph_lines;

namespace Pravci
{
    public partial class Form1 : Form
    {
        private LineEquation qe;
        private LineEquation qe2;
        private Sjeciste sjeciste;
        public Form1()
        {
            InitializeComponent();
            qe = new LineEquation();
            qe2 = new LineEquation();
            sjeciste = new Sjeciste();
            functionPanel1.Function = new Function(qe.Y);
            functionPanel1.Function2 = new Function2(qe2.Y);
            functionPanel1.Invalidate();
            log4net.Config.XmlConfigurator.Configure();
        }

        void RacunajSjeciste()
        {

            NumberFormatInfo nfi = new NumberFormatInfo
            {
                NumberDecimalSeparator = "."
            };
            Tocka t = sjeciste.IzracunajSjeciste(qe, qe2);
            label4.Text = "Koordinate sjecišta:\n(" + t.X.ToString(nfi) + " , " + t.Y.ToString(nfi) + ")";
        }

        void FillResult()
        {
            qe.A = Double.Parse(textBox1.Text.Replace('.',','));
            qe.B = Double.Parse(textBox2.Text.Replace('.', ','));
            qe.C = Double.Parse(textBox3.Text.Replace('.', ','));

            qe2.A = Double.Parse(textBox4.Text.Replace('.', ','));
            qe2.B = Double.Parse(textBox5.Text.Replace('.', ','));
            qe2.C = Double.Parse(textBox6.Text.Replace('.', ','));

            functionPanel1.Invalidate();
        }

        private bool Validacija(string text)
        {
            Regex reg = new Regex(@"^(0|([0*-]?(((0|[1-9]\d*)[\,.]?\d+)|([1-9]\d*))))$");

            if (reg.IsMatch(text))
            {
                FillResult();
                RacunajSjeciste();
                lblWarning.Visible = false;
                return true;
            }
            else
            {
                lblWarning.Visible = true;
                return false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!Validacija(textBox1.Text))
                this.ActiveControl = textBox1;            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!Validacija(textBox2.Text))
                this.ActiveControl = textBox2;            
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!Validacija(textBox3.Text))
                this.ActiveControl = textBox3;            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (!Validacija(textBox4.Text))
                this.ActiveControl = textBox4;            
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (!Validacija(textBox5.Text))
                this.ActiveControl = textBox5;            
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (!Validacija(textBox6.Text))
                this.ActiveControl = textBox6;
        }
    }
}
