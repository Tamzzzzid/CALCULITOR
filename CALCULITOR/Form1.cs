using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CALCULITOR
{
    
    public partial class Form1 : Form
    {
        int Precedence(char op)
        {
            if (op == '+' || op == '-') return 1;
            if (op == '*' || op == '/') return 2;
            return 0;
        }

        // Convert infix to postfix
        string InfixToPostfix(string infix)
        {
            Stack<char> operators = new Stack<char>();
            StringBuilder postfix = new StringBuilder();

            for (int i = 0; i < infix.Length; i++)
            {
                char ch = infix[i];

                if (ch == ' ')
                    continue;

                // Number (multi-digit)
                if (char.IsDigit(ch))
                {
                    while (i < infix.Length && char.IsDigit(infix[i]))
                    {
                        postfix.Append(infix[i]);
                        i++;
                    }
                    postfix.Append(' ');
                    i--;
                }
                else if (ch == '(')
                {
                    operators.Push(ch);
                }
                else if (ch == ')')
                {
                    while (operators.Peek() != '(')
                        postfix.Append(operators.Pop()).Append(' ');
                    operators.Pop();
                }
                else // operator
                {
                    while (operators.Count > 0 &&
                           Precedence(operators.Peek()) >= Precedence(ch))
                    {
                        postfix.Append(operators.Pop()).Append(' ');
                    }
                    operators.Push(ch);
                }
            }

            while (operators.Count > 0)
                postfix.Append(operators.Pop()).Append(' ');

            return postfix.ToString().Trim();
        }

        // Evaluate postfix
        int EvaluatePostfix(string postfix)
        {
            Stack<int> stack = new Stack<int>();
            string[] tokens = postfix.Split(' ');

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int num))
                {
                    stack.Push(num);
                }
                else
                {
                    int b = stack.Pop();
                    int a = stack.Pop();

                    switch (token)
                    {
                        case "+": stack.Push(a + b); break;
                        case "-": stack.Push(a - b); break;
                        case "*": stack.Push(a * b); break;
                        case "/": stack.Push(a / b); break;
                    }
                }
            }

            return stack.Pop();
        }
        string str = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            str += "2";
            lbl1.Text = str;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            str += "5";
            lbl1.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            str += "1";
            lbl1.Text = str;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            str += "3";
            lbl1.Text = str;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            str += "4";
            lbl1.Text = str;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            str += "6";
            lbl1.Text = str;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            str += "7";
            lbl1.Text = str;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            str += "8";
            lbl1.Text = str;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            str += "9";
            lbl1.Text = str;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            str += "0";
            lbl1.Text = str;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            str += "+";
            lbl1.Text = str;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            str += "/";
            lbl1.Text = str;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            str += "-";
            lbl1.Text = str;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            str += "*";
            lbl1.Text = str;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            string postfix = InfixToPostfix(str);
            int result = EvaluatePostfix(postfix);

            lbl1.Text = result.ToString();
            str= result.ToString();

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            str = "";
            lbl1.Text = str;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
