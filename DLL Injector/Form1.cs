using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DLL_Injector
{
    public partial class Main : Form
    {
        private Dictionary<string, string> dllPaths = new Dictionary<string, string>();
        private List<DllEntry> dllEntries = new List<DllEntry>();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes,
            uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]

        private static extern bool CloseHandle(IntPtr hObject);

        private class DllEntry
        {
            public string FileName { get; set; }
            public string FullPath { get; set; }
            public bool Enabled { get; set; } = true;

            public override string ToString()
            {
                return Enabled ? FileName : $"[DISABLED] {FileName}";
            }
        }

        private bool InjectDll(int pid, string dllPath)
        {
            const int PROCESS_ALL_ACCESS = 0x1F0FFF;
            IntPtr hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, pid);

            if (hProcess == IntPtr.Zero)
            {
                MessageBox.Show("Failed to open target process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            IntPtr addrLoadLibraryA = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (addrLoadLibraryA == IntPtr.Zero)
            {
                MessageBox.Show("Could not find LoadLibraryA address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(dllPath + '\0');
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)bytes.Length, 0x1000 | 0x2000, 0x04);

            if (allocMemAddress == IntPtr.Zero)
            {
                MessageBox.Show("Memory allocation in target process failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            WriteProcessMemory(hProcess, allocMemAddress, bytes, (uint)bytes.Length, out _);

            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, addrLoadLibraryA, allocMemAddress, 0, out _);

            if (hThread == IntPtr.Zero)
            {
                int errorCode = Marshal.GetLastWin32Error();
                MessageBox.Show($"Failed to create remote thread in target process.\nError code: {errorCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            CloseHandle(hThread);
            CloseHandle(hProcess);
            return true;
        }

        public Main()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            using (var form = new ProcessSelectorForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    textBoxProccesId.Text = form.SelectPID.ToString();
                }
            }
        }

        private void buttonAddDll_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "DLL files (*.dll)|*.dll";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fullPath in openFileDialog.FileNames)
                    {
                        string fileName = Path.GetFileName(fullPath);

                        bool alreadyExists = dllEntries.Any(entry =>
                            entry.FileName.Equals(fileName, StringComparison.OrdinalIgnoreCase));

                        if (!alreadyExists)
                        {
                            var entry = new DllEntry
                            {
                                FileName = fileName,
                                FullPath = fullPath,
                                Enabled = true
                            };

                            dllEntries.Add(entry);
                            listDlls.Items.Add(entry);
                        }
                        else
                        {
                            MessageBox.Show($"File {fileName} has already been added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void buttonEnableDisable_Click(object sender, EventArgs e)
        {
            if (listDlls.SelectedItem is DllEntry selectedEntry)
            {
                selectedEntry.Enabled = !selectedEntry.Enabled;

                int index = listDlls.SelectedIndex;
                listDlls.Items.RemoveAt(index);
                listDlls.Items.Insert(index, selectedEntry);
                listDlls.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Choose a DLL from the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonRemoveDll_Click(object sender, EventArgs e)
        {
            if (listDlls.SelectedItem is DllEntry selectedEntry)
            {
                dllEntries.Remove(selectedEntry);
                listDlls.Items.Remove(selectedEntry);
            }
            else
            {
                MessageBox.Show("Choose a DLL for the removing.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonClearDlls_Click(object sender, EventArgs e)
        {
            if (dllEntries.Count == 0)
            {
                MessageBox.Show("The list is already cleaned.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Do you really want to clear the whole list?", "Aprovment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dllEntries.Clear();
                listDlls.Items.Clear();
            }
        }

        private void buttonInject_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxProccesId.Text, out int pid))
            {
                MessageBox.Show("Invalid PID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var enabledDlls = dllEntries.Where(d => d.Enabled).ToList();

            if (enabledDlls.Count == 0)
            {
                MessageBox.Show("No enabled DLLs selected for injection.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var dll in enabledDlls)
            {
                bool result = InjectDll(pid, dll.FullPath);

                if (result)
                {
                    MessageBox.Show($"DLL '{dll.FileName}' injected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Failed to inject '{dll.FileName}'.", "Injection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
