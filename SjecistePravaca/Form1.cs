using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Graph_lines;
using log4net;

namespace Pravci
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Form1));
        LineEquation qe;
        LineEquation qe2;
        Sjeciste sjeciste;
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

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            Tocka t = new Tocka();
            t = sjeciste.IzracunajSjeciste(qe, qe2);
            label4.Text = "Koordinate sjecišta:\n(" + t.X.ToString(nfi) + " , " + t.Y.ToString(nfi) + ")";
        }

        void FillResult()
        {
            qe.A = Double.Parse(textBox1.Text);
            qe.B = Double.Parse(textBox2.Text);
            qe.C = Double.Parse(textBox3.Text);

            qe2.A = Double.Parse(textBox4.Text);
            qe2.B = Double.Parse(textBox5.Text);
            qe2.C = Double.Parse(textBox6.Text);

            functionPanel1.Invalidate();
        }

        private bool Validacija(string text)
        {
            Regex reg = new Regex(@"-?\d+(?:\.\d+)?");

            if (reg.IsMatch(text))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (Validacija(textBox1.Text))
            {
                FillResult();
                RacunajSjeciste();
            }
            else
            {
                this.ActiveControl = textBox1;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (Validacija(textBox2.Text))
            {
                FillResult();
                RacunajSjeciste();
            }
            else
            {
                this.ActiveControl = textBox2;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (Validacija(textBox3.Text))
            {
                FillResult();
                RacunajSjeciste();
            }
            else
            {
                this.ActiveControl = textBox3;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (Validacija(textBox4.Text))
            {
                FillResult();
                RacunajSjeciste();
            }
            else
            {
                this.ActiveControl = textBox4;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (Validacija(textBox5.Text))
            {
                FillResult();
                RacunajSjeciste();
            }
            else
            {
                this.ActiveControl = textBox5;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (Validacija(textBox6.Text))
            {
                FillResult();
                RacunajSjeciste();
            }
            else
            {
                this.ActiveControl = textBox6;
            }
        }
    }
}
