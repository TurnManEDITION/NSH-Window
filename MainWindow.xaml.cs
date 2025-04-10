using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Hashed
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FromNS.Text = "Dec";
            InNS.Text = "Bin";
            ChoiceH.Text = "SHA256";
        }
        private void EnterNS(object sender, RoutedEventArgs e)
        {
            {
                OutErrorNS.Visibility = Visibility.Hidden;
                try
                {
                    long temp;
                    if (FromNS.Text == InNS.Text)
                    {
                        OutNS.Text = InputNS.Text;
                    }
                    else if (FromNS.Text == "Bin" && InNS.Text == "Oct")
                    {
                        temp = Convert.ToInt64(InputNS.Text, 2);
                        OutNS.Text = Convert.ToString(temp, 8);
                    }
                    else if (FromNS.Text == "Bin" && InNS.Text == "Dec")
                    {
                        temp = Convert.ToInt64(InputNS.Text, 2);
                        OutNS.Text = Convert.ToString(temp, 10);
                    }
                    else if (FromNS.Text == "Bin" && InNS.Text == "Hex")
                    {
                        temp = Convert.ToInt64(InputNS.Text, 2);
                        OutNS.Text = Convert.ToString(temp, 16);
                    }
                    else if (FromNS.Text == "Oct" && InNS.Text == "Bin")
                    {
                        temp = Convert.ToInt64(InputNS.Text, 8);
                        OutNS.Text = Convert.ToString(temp, 2);
                    }
                    else if (FromNS.Text == "Oct" && InNS.Text == "Dec")
                    {
                        temp = Convert.ToInt64(InputNS.Text, 8);
                        OutNS.Text = Convert.ToString(temp, 10);
                    }
                    else if (FromNS.Text == "Oct" && InNS.Text == "Hex")
                    {
                        temp = Convert.ToInt64(InputNS.Text, 8);
                        OutNS.Text = Convert.ToString(temp, 16);
                    }
                    else if (FromNS.Text == "Hex" && InNS.Text == "Bin")
                    {
                        temp = Convert.ToInt64(InputNS.Text, 16);
                        OutNS.Text = Convert.ToString(temp, 2);
                    }
                    else if (FromNS.Text == "Hex" && InNS.Text == "Oct")
                    {
                        temp = Convert.ToInt64(InputNS.Text, 16);
                        OutNS.Text = Convert.ToString(temp, 8);
                    }
                    else if (FromNS.Text == "Hex" && InNS.Text == "Dec")
                    {
                        temp = Convert.ToInt64(InputNS.Text, 16);
                        OutNS.Text = Convert.ToString(temp, 10);
                    }
                }
                catch (Exception ex)
                {
                    OutErrorNS.Visibility = Visibility.Visible;
                    OutErrorNS.Text = ex.Message;
                }
            }
        }
        private void ChangeNS(object sender, RoutedEventArgs e)
        {
            EnterNS(sender, e);
            string first = FromNS.Text;
            string second = InNS.Text;
            FromNS.Text = second;
            InNS.Text = first;
            first = InputNS.Text;
            second = OutNS.Text;
            InputNS.Text = second;
            OutNS.Text = first;
        }
        private void EnterH(object sender, RoutedEventArgs e) 
        {
            OutErrorH.Visibility = Visibility.Hidden;
            try
            {
                if (ChoiceH.Text == "MD5")
                {
                    MD5 MD5Hash = MD5.Create();
                    byte[] inputBytes = Encoding.ASCII.GetBytes(InputH.Text);
                    byte[] hash = MD5Hash.ComputeHash(inputBytes);
                    OutH.Text = Convert.ToHexString(hash);
                } else if (ChoiceH.Text == "SHA256")
                {
                    using SHA256 hash = SHA256.Create();
                    OutH.Text = Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(InputH.Text)));
                } else if (ChoiceH.Text == "SHA512")
                {
                    using SHA512 hash = SHA512.Create();
                    OutH.Text = Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(InputH.Text)));
                } else if (ChoiceH.Text == "SHA384")
                {
                    using SHA384 hash = SHA384.Create();
                    OutH.Text = Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(InputH.Text)));
                }
            } catch (Exception ex)
            {
                OutErrorH.Visibility = Visibility.Visible;
                OutErrorH.Text = ex.Message;
            }
        }
    }
}