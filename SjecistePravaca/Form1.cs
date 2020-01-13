using System;
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
            Tocka t = new Tocka();
            t = sjeciste.IzracunajSjeciste(qe, qe2);
            label4.Text= "Intersection coordinates:\n(" + t.X + " , " + t.Y + ")";
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

        private void Validacija(string text)
        {
            Regex reg = new Regex("^[+-]?([0-9]*\\.?[0-9]+|[0-9]+\\.?[0-9]*)([eE][+-]?[0-9]+)?$");

            if (reg.IsMatch(text))
            {
            }
            else
            {
                MessageBox.Show("Invalid value");
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Validacija(textBox1.Text);
            FillResult();
            RacunajSjeciste();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Validacija(textBox2.Text);
            FillResult();
            RacunajSjeciste();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Validacija(textBox3.Text);
            FillResult();
            RacunajSjeciste();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Validacija(textBox4.Text);
            FillResult();
            RacunajSjeciste();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Validacija(textBox5.Text);
            FillResult();
            RacunajSjeciste();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Validacija(textBox6.Text);
            FillResult();
            RacunajSjeciste();
        }
    }
}
