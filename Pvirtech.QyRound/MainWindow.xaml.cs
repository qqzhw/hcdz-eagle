using Pvirtech.QyRound.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NModbus;
namespace Pvirtech.QyRound.Views
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow 
	{
		public MainWindow()
		{
			InitializeComponent();
            var bit = 0x01;
            
        }
        public static void ModbusTcpMasterReadInputs()

        {

            using (TcpClient client = new TcpClient("127.0.0.1", 502))

            {

                var factory = new ModbusFactory();



                IModbusMaster master = factory.CreateMaster(client);

                

                // read five input values

                ushort startAddress = 100;

                ushort numInputs = 5;

                bool[] inputs = master.ReadInputs(0, startAddress, numInputs);

                

                for (int i = 0; i < numInputs; i++)

                {

                    Console.WriteLine($"Input {(startAddress + i)}={(inputs[i] ? 1 : 0)}");

                }

            }



            // output: 

            // Input 100=0

            // Input 101=0

            // Input 102=0

            // Input 103=0

            // Input 104=0

        }
    }
	 
}
