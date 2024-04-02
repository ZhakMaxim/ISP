using static System.Net.Mime.MediaTypeNames;

namespace ISP_253504_Zhak
{
    public partial class MainPage : ContentPage
    {
        float buff;

        bool isCalculated = false , ok;

        string operation = "";
        public MainPage()
        {
            InitializeComponent();
        }

        private void Calculation(object sender)
        {
            ok = float.TryParse(CalculatingSpace.Text, out buff);
            if (ok)
            {
                CalculatingSpace.Text += ((Button)sender).Text;
                operation = ((Button)sender).Text;
            }
            else
            {
                CalculatingSpace.Text = "Error";
                isCalculated = true;
            }
        }
        private void OnButtonClicked(object sender, EventArgs e)
        {
            if(((Button)sender).Text == "+")
            {
                Calculation(sender);
            }
            else if (((Button)sender).Text == "-")
            {
                Calculation(sender);
            }
            else if (((Button)sender).Text == "x")
            {
                Calculation(sender);
            }
            else if (((Button)sender).Text == "/")
            {
                Calculation(sender);
            }
            else if (((Button)sender).Text == "2^x")
            {
                ok = float.TryParse(CalculatingSpace.Text, out buff);
                if (ok) 
                {
                    CalculatingSpace.Text = Math.Pow(2, buff).ToString();
                }
                else
                {
                    CalculatingSpace.Text = "Error";
                }
                isCalculated = true;
            }
            else if (((Button)sender).Text == "CE")
            {
                CalculatingSpace.Text = "";
            }
            else if (((Button)sender).Text == "=")
            {
                isCalculated = true;
                if(operation == "+")
                {
                    CalculatingSpace.Text = (buff + float.Parse(CalculatingSpace.Text.Substring(CalculatingSpace.Text.IndexOf("+") + 1))).ToString();
                }
                if (operation == "-")
                {
                    CalculatingSpace.Text = (buff - float.Parse(CalculatingSpace.Text.Substring(CalculatingSpace.Text.IndexOf("-") + 1))).ToString();
                }
                if (operation == "x")
                {
                    CalculatingSpace.Text = (buff * float.Parse(CalculatingSpace.Text.Substring(CalculatingSpace.Text.IndexOf("x") + 1))).ToString();
                }
                if (operation == "/")
                {
                    if (float.Parse(CalculatingSpace.Text.Substring(CalculatingSpace.Text.IndexOf("/") + 1)) == 0)
                    {
                        CalculatingSpace.Text = "Error";
                        isCalculated = true;
                    }
                    else
                    {
                        CalculatingSpace.Text = (buff / float.Parse(CalculatingSpace.Text.Substring(CalculatingSpace.Text.IndexOf("/") + 1))).ToString();
                    }
                }
            }
            else
            {
                if (isCalculated)
                {
                    CalculatingSpace.Text = "";
                    isCalculated = false;
                }
                CalculatingSpace.Text += ((Button)sender).Text;
            }

        }
    }

}
