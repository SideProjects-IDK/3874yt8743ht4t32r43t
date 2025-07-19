using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgePay
{
    public partial class MainPanel : Form
    {
        // Sidebar animation
        private System.Windows.Forms.Timer panelSlideTimer;
        private bool isPanelExpanded = true;
        private int panelTargetWidth;
        private const int panelCollapsedWidth = 57;
        private const int panelExpandedWidth = 344;
        private const int panelSlideStep = 20;

        public MainPanel()
        {
            InitializeComponent();

            // Initialize the sidebar animation timer
            panelSlideTimer = new System.Windows.Forms.Timer();
            panelSlideTimer.Interval = 10;
            panelSlideTimer.Tick += PanelSlideTimer_Tick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set target width and start animation
            if (isPanelExpanded)
            {
                panelTargetWidth = panelCollapsedWidth;
                groupBox1.Visible = false;
                panel3.Dock = DockStyle.None;
            }
            else
            {
                panelTargetWidth = panelExpandedWidth;
            }

            panelSlideTimer.Start();
        }

        private void PanelSlideTimer_Tick(object sender, EventArgs e)
        {
            if (isPanelExpanded)
            {
                // Collapse animation
                if (panel2.Width > panelTargetWidth)
                {
                    panel2.Width -= panelSlideStep;
                    if (panel2.Width <= panelTargetWidth)
                    {
                        panel2.Width = panelTargetWidth;
                        panelSlideTimer.Stop();
                        isPanelExpanded = false;
                    }
                }
            }
            else
            {
                // Expand animation
                if (panel2.Width < panelTargetWidth)
                {
                    panel2.Width += panelSlideStep;
                    if (panel2.Width >= panelTargetWidth)
                    {
                        panel2.Width = panelTargetWidth;
                        panelSlideTimer.Stop();
                        groupBox1.Visible = true;
                        panel3.Dock = DockStyle.Top;
                        isPanelExpanded = true;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create and configure the form
            frmEmployeeProfile employeeForm = new frmEmployeeProfile();
            employeeForm.FormClosed += (s, args) => this.Show(); // Show MainPanel when employeeForm closes
            this.Hide(); // Hide the current form
            employeeForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Create and configure the form
            frmEditTimeRegister timeRegisterForm = new frmEditTimeRegister();
            timeRegisterForm.FormClosed += (s, args) => this.Show(); // Show MainPanel when timeRegisterForm closes
            this.Hide(); // Hide the current form
            timeRegisterForm.Show();
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {
            // Optional: run logic on form load
        }
    }
}