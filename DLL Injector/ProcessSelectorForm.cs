using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLL_Injector
{
    public partial class ProcessSelectorForm : Form
    {
        public int SelectPID = 0;
        public ProcessSelectorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                SelectPID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PID"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please, enter a process from the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ProcessSelectorForm_Load_1(object sender, EventArgs e)
        {
            var processes = Process.GetProcesses();

            foreach (var proc in processes.OrderBy(p => p.ProcessName))
            {
                dataGridView1.Rows.Add(proc.ProcessName, proc.Id);
            }
        }
    }
}
