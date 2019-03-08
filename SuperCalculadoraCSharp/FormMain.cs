using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCalculadoraCSharp
{
    public partial class FormMain : Form
    {
        //Definiendo las variables globales de mi aplicacion
        decimal _Operador;

        string _OperadorTxt;
        string _OperadorAct;

        //Definiendo una funcion privada para agregar en valor en cada boton
        private void SetOperadorTxt(string value)
        {
            //If value is numeric
            if (value == "1" || value == "2" || value == "3" || value == "4" || value == "5" ||
                value == "6" || value == "7" || value == "8" || value == "9" || value == "0")
            {
                if (_OperadorTxt == "0")
                    _OperadorTxt = "";

                _OperadorTxt = _OperadorTxt + value;
                txtResultado.Text = _OperadorTxt;
            }
            //If value is operator
            else if (value == "+" || value == "-" || value == "*" || value == "/")
            {
                if (_OperadorAct != "" && _OperadorTxt != "")
                {
                    DoOperation();
                }

                _OperadorAct = value;

                if (_OperadorTxt != "")
                {
                    _Operador = decimal.Parse(_OperadorTxt);
                    _OperadorTxt = "";
                }
            }
            //If value is = Equals
            else if (value == "=")
            {
                if (_OperadorAct != "" && _OperadorTxt != "")
                {
                    DoOperation();
                }
            }
            //If value is deleted
            else if (value == "\b") {
                Delete();
            }
            //If value is reset ESC
            else if (value == "\u001b")
            {
                Reset();
            }
            //If value is decimal
            else if (value == "," || value == ".")
            {
                if (_OperadorTxt.IndexOf(",") < 0)
                {
                    _OperadorTxt = _OperadorTxt + ",";
                    txtResultado.Text = _OperadorTxt;
                }
            }
        }

        private void DoOperation()
        {
            decimal result = 0;

            if (_OperadorAct == "+")
            {
                result = _Operador + decimal.Parse(_OperadorTxt);
            } else if (_OperadorAct == "-")
            {
                result = _Operador - decimal.Parse(_OperadorTxt);
            }
            else if (_OperadorAct == "*")
            {
                result = _Operador * decimal.Parse(_OperadorTxt);
            }
            else if (_OperadorAct == "/")
            {
                result = _Operador / decimal.Parse(_OperadorTxt);
            }

            _OperadorAct = "";
            _OperadorTxt = result.ToString();
            txtResultado.Text = _OperadorTxt;
        }

        private void Delete()
        {
            if(_OperadorTxt.Length > 1)
            {
                _OperadorTxt = _OperadorTxt.Substring(0, _OperadorTxt.Length - 1);
            } else
            {
                _OperadorTxt = "0";
            }
            txtResultado.Text = _OperadorTxt;
        }

        private void Reset()
        {
            _OperadorTxt = "0";
            _Operador = 0;
            _OperadorAct = "";
            txtResultado.Text = "0";
        }

        public FormMain()
        {
            InitializeComponent();
            Reset();
        }

        private void btnNumber9_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("9");
        }

        private void btnNumber0_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("0");
        }

        private void btnNumber1_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("1");
        }

        private void btnNumber2_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("2");
        }

        private void btnNumber3_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("3");
        }

        private void btnNumber6_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("6");
        }

        private void btnNumber5_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("5");
        }

        private void btnNumber4_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("4");
        }

        private void btnNumber7_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("7");
        }

        private void btnNumber8_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("8");
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("=");
        }

        private void btnmas_Click(object sender, EventArgs e)
        {

        }

        private void btnmenos_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            SetOperadorTxt(Convert.ToString(e.KeyChar)); 
        }

        private void btnmas_Click_1(object sender, EventArgs e)
        {
            SetOperadorTxt("+");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            SetOperadorTxt(",");
        }

        private void btnmenos_Click_1(object sender, EventArgs e)
        {
            SetOperadorTxt("-");
        }

        private void btnmulti_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("*");
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            SetOperadorTxt("/");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
