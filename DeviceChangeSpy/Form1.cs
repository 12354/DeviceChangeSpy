using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapplo.Windows.Messages;
using Dapplo.Windows.Devices;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Dapplo.Windows.Devices.Structs;

namespace DeviceChangeSpy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DeviceNotification
                .OnDeviceArrival()
                .Subscribe(d => Log("OnDeviceArrival", d.Device));
            DeviceNotification
                .OnDeviceRemoved()
                .Subscribe(d => Log("OnDeviceRemoved", d.Device));
        }

        private void Log(string method, DevBroadcastDeviceInterface d)
        {
            var log = $"[{DateTime.Now.ToShortTimeString()}] {method}:{d.DisplayName} {d.FriendlyDeviceName} {d.DeviceId} {d.DeviceType} {d.DeviceClass}";
            listBox1.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                listBox1.Items.Add(log);
            });
        }
    }
}
