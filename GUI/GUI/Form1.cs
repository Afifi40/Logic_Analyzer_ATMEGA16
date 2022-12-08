using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace GUI
{
    public partial class C6 : Form
    {
        SerialPort port = null;
        string data = "";
        string data_rx = "";
        int s0 = 0;
        int s1 = 0;
        int s2 = 0;
        int s3 = 0;
        int s4 = 0;
        int s5 = 0;
        int s6 = 0;
        int s7 = 0;
        public C6()
        {
            InitializeComponent();
            refresh();
        }

        ///////////////////////Methods//////////////////////////
        private void refresh()
        {
            comComboBox.DataSource = SerialPort.GetPortNames();
        }
        private void connect()
        {
            port = new SerialPort(comComboBox.SelectedItem.ToString());
            port.DataReceived += new SerialDataReceivedEventHandler(data_rx_handler); // To Receive

            port.BaudRate = 2400; //9600;
            port.DataBits = 8;
            port.StopBits = StopBits.One;

            try
            {
                if (!port.IsOpen)
                {
                    port.Open();
                    statusLabel.Text = "Connected";
                    statusLabel.ForeColor = Color.Green;
                }
            }
            catch (Exception ex) { }
        }
        private void disconnect()
        {
            try
            {
                if (port.IsOpen)
                {
                    port.Close();
                    statusLabel.Text = "Disconnected";
                    statusLabel.ForeColor = Color.Red;
                }
            }
            catch (Exception ex) { }
        }
        private void D2_FormClosed(object sender, FormClosedEventArgs e)
        {
            disconnect();
        }
        private void data_rx_handler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string tmp = "";

            try
            {
                tmp = sp.ReadExisting();
                //data_rx += tmp;
            }
            catch (Exception ex) { }

            data_rx += tmp;
        }

        ///////////////////////Buttons//////////////////////////
        private void refreshButton_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void connectButton_Click(object sender, EventArgs e)
        {
            connect();
        }
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            disconnect();
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "sss";
                Console.Write("{0}", s);
            }
            catch (Exception ex) { System.Console.WriteLine("Erroooooooooooooor"); }
        }
        private void drawButton_Click(object sender, EventArgs e)
        {
            string s = sComboBox.SelectedItem.ToString();

            Timer timer1 = new Timer
            {
                Interval = 5000
            };
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(drawButton_Click);

            data = "";
            //data = "01010101";
            string tmp = data_rx;
            //10101010_
            string tmp2 = "";

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            try
            {
                for (int i = tmp.Length - 2; i > tmp.Length - 10; i--)
                {
                    tmp2 += tmp[i];
                }
                for (int i = tmp2.Length - 1; i >= 0; i--)
                {
                    data += tmp2[i];
                }
                Console.WriteLine(data);

                if (data[0] == '0')
                {
                    chart1.Series["0"].Points.AddY("1");
                    s0 = 0;
                }
                else
                {
                    chart1.Series["0"].Points.AddY("2");
                    s0 += 1;
                }

                if (data[1] == '0')
                {
                    chart1.Series["1"].Points.AddY("3");
                    s1 = 0;
                }
                else
                {
                    chart1.Series["1"].Points.AddY("4");
                    s1 += 1;
                }

                if (data[2] == '0')
                {
                    chart1.Series["2"].Points.AddY("5");
                    s2 = 0;
                }
                else
                {
                    chart1.Series["2"].Points.AddY("6");
                    s2 += 1;
                }

                if (data[3] == '0')
                {
                    chart1.Series["3"].Points.AddY("7");
                    s3 = 0;
                }
                else
                {
                    chart1.Series["3"].Points.AddY("8");
                    s3 += 1;
                }

                if (data[4] == '0')
                {
                    chart1.Series["4"].Points.AddY("9");
                    s4 = 0;
                }
                else
                {
                    chart1.Series["4"].Points.AddY("10");
                    s4 += 1;
                }

                if (data[5] == '0')
                {
                    chart1.Series["5"].Points.AddY("11");
                    s5 = 0;
                }
                else
                {
                    chart1.Series["5"].Points.AddY("12");
                    s5 += 1;
                }

                if (data[6] == '0')
                {
                    chart1.Series["6"].Points.AddY("13");
                    s6 = 0;
                }
                else
                {
                    chart1.Series["6"].Points.AddY("14");
                    s6 += 1;
                }

                if (data[7] == '0')
                {
                    chart1.Series["7"].Points.AddY("15");
                    s7 = 0;
                }
                else
                {
                    chart1.Series["7"].Points.AddY("16");
                    s7 += 1;
                }

                if (s == "s0")
                {
                    sLabel.Text = s0.ToString();
                }
                if (s == "s1")
                {
                    sLabel.Text = s1.ToString();
                }
                if (s == "s2")
                {
                    sLabel.Text = s2.ToString();
                }
                if (s == "s3")
                {
                    sLabel.Text = s3.ToString();
                }
                if (s == "s4")
                {
                    sLabel.Text = s4.ToString();
                }                
                if (s == "s5")
                {
                    sLabel.Text = s5.ToString();
                }
                if (s == "s6")
                {
                    sLabel.Text = s6.ToString();
                }
                if (s == "s7")
                {
                    sLabel.Text = s7.ToString();
                }

            }
            catch (Exception ex) { System.Console.WriteLine("Erroooooooooooooor"); }

        }
    }
}
