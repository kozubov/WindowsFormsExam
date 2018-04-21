using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExam
{
    public partial class Child : Form
    {
        public RichTextBox ChildRichTextBox { get; set; }
        public string childPath { get; set; } = "";
        public Child()
        {
            InitializeComponent();
            ChildRichTextBox = richTextBox1;
        }
    }
}
