using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace WindowsFormsExam
{
    public partial class Form1 : Form
    {
        public Child child;
        int flafColor = 0;
        int flagLeng = 0;
        string[] Words = { "public ", "class ", "partial ", "string ", "int ", "boole ", "get ", "set ", "new ", "object ", "namespace ",
                            "private ", "void ", "double ", "true;", "false;", "for ", "if ", "foreach ", "in ", "var ", "as ", "is ", "else", "this ", "this;"};
        public string path { get; set; } = "";
        public Form1()
        {
            InitializeComponent();
            child = new Child();
            MdiChildActivate += Form1_MdiChildActivate;

            openToolStripMenuItem.Click += OpenFileToolStripMenuItem_Click;
            openToolStripButton.Click += OpenFileToolStripMenuItem_Click;
            openToolStripMenuItemEn.Click += OpenFileToolStripMenuItem_Click;
            openToolStripButtonEn.Click += OpenFileToolStripMenuItem_Click;

            newToolStripMenuItem.Click += NewFileToolStripMenuItem_Click;
            newToolStripButton.Click += NewFileToolStripMenuItem_Click;

            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            saveToolStripButton.Click += SaveToolStripMenuItem_Click;
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;

            cutToolStripItem.Click += CutToolStripItem_Click;
            cutToolStripMenuItem.Click += CutToolStripItem_Click;
            cutToolStripButton.Click += CutToolStripItem_Click;

            undoToolStripItem.Click += UndoToolStripItem_Click;
            undoToolStripMenuItem.Click += UndoToolStripItem_Click;
            undoToolStripButton.Click += UndoToolStripItem_Click;


            redoToolStripButton.Click += RedoToolStripItem_Click;

            pasteToolStripItem.Click += PastToolStripItem_Click;
            pasteToolStripMenuItem.Click += PastToolStripItem_Click;
            pasteToolStripButton.Click += PastToolStripItem_Click;

            copyToolStripItem.Click += CopyToolStripItem_Click;
            copyToolStripMenuItem.Click += CopyToolStripItem_Click;
            copyToolStripButton.Click += CopyToolStripItem_Click;

            delToolStripItem.Click += DeliteToolStripItem_Click;
            delToolStripMenuItem.Click += DeliteToolStripItem_Click;
            closeToolStripButton.Click += DeliteToolStripItem_Click;

            selectAllToolStripMenuItem.Click += SelectAllToolStripItem_Click;
            selectAllToolStripItem.Click += SelectAllToolStripItem_Click;

            fontToolStripMenuItem.Click += FontToolStripMenuItem_Click;
            colorToolStripButton.Click += FontToolStripMenuItem_Click;
            backToolStripMenuItem.Click += BackColorToolStripMenuItem_Click;
            backColorToolStripButton.Click += BackColorToolStripMenuItem_Click;

            statusBarToolStripMenuItem.CheckedChanged += StatusBarToolStripMenuItem_CheckedChanged;

            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            timeToolStripMenuItem.Click += TimeToolStripMenuItem_Click;
            dateToolStripButton.Click += TimeToolStripMenuItem_Click;

            aboutProgramToolStripMenuItem.Click += AboutProgramToolStripMenuItem_Click;

            maxToolStripMenuItem.Click += maximizeToolStripMenuItem_Click;
            minToolStripMenuItem.Click += minimizeToolStripMenuItem_Click;
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;

            maxAllToolStripMenuItem.Click += maximizeAllToolStripMenuItem_Click;
            minAllToolStripMenuItem.Click += minimizeAllToolStripMenuItem_Click;
            closeAllToolStripMenuItem.Click += closeAllToolStripMenuItem_Click;

            cascadeToolStripMenuItem.Click += cascadeToolStripMenuItem_Click;
            horizontalToolStripMenuItem.Click += horizontalToolStripMenuItem_Click;
            verticalToolStripMenuItem.Click += verticalToolStripMenuItem_Click;

            textBoxSearch.Enter += TextBoxSearch_Enter;
            textBoxSearch.Leave += TextBoxSearch_Leave;
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;

            textBoxReplace.Enter += TextBoxSearch_Enter;
            textBoxReplace.Leave += TextBoxSearch_Leave;
            textBoxReplace.TextChanged += TextBoxSearch_TextChanged;
            //ru
            buttonSerch.Click += ButtonSerch_Click;
            buttonReplace.Click += ButtonReplace_Click;
            //en
            btnFindSerchGroopEn.Click += ButtonSerchEn_Click;
            btnReplSerchGroopEn.Click += ButtonReplaceEn_Click;

            labelserchGroopEn.Click += LabelreplaceEn_Click;
            labelreplace.Click += Labelreplace_Click;

            //цвет интерфейса
            blackToolStripMenuItem.Click += BlackToolStripMenuItem_Click;
            whiteToolStripMenuItem.Click += WhiteToolStripMenuItem_Click;

            //подсветка кода c#
            lengCToolStripMenuItem.Click += LengCToolStripMenuItem_Click;

            //коментарий
            comentToolStripButton.Click += ComentToolStripButton_Click;
            unCommentToolStripButton.Click += UnCommentToolStripButton_Click;

            //язык
            enToolStripMenuItem.Click += UsToolStripMenuItem_Click;
            rusToolStripMenuItem.Click += RusToolStripMenuItem_Click;
            enToolStripMenuItemEn.Click += UsToolStripMenuItem_Click;
            rusToolStripMenuItemEn.Click += RusToolStripMenuItem_Click;
        }
        private void RusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip.Visible = true;
            menuStripEn.Visible = false;
            toolStripEn.Visible = false;
            toolStripTop.Visible = true;
            serchGroopEn.Visible = false;
            Text = $"Блокнот  {path}";
            flagLeng = 0;
        }
        private void UsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip.Visible = false;
            menuStripEn.Visible = true;
            //menuStripEn.Dock = DockStyle.Top;
            toolStripEn.Visible = true;
            //menuStripEn.Top = toolStripEn.Bottom+20;
            toolStripEn.Location = new Point(menuStripEn.Left, menuStripEn.Bottom);
            toolStripTop.Visible = false;
            //toolStripEn.Dock = DockStyle.Top;
            Text = $"Notebook  {path}";
            serchGroopEn.Visible = true;
            flagLeng = 1;


        }

        private void UnCommentToolStripButton_Click(object sender, EventArgs e)
        {
            string str = "";
            if (child.ChildRichTextBox.SelectedText != "")
            {
                int a = child.ChildRichTextBox.SelectionStart;
                str = child.ChildRichTextBox.SelectedText;
                str = myTrim(str);
                child.ChildRichTextBox.SelectionColor = (flafColor == 0) ? Color.Black : Color.White;
              
                child.ChildRichTextBox.SelectedText = str;
                child.ChildRichTextBox.Select(a, str.Length);
            }
            if (path.EndsWith("cs"))
            {
                ColorSelector(child.ChildRichTextBox, Words, Color.Blue);
            }
        }
        public string myTrim(string str)
        {
            string str2 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] == '/' && str[i + 1] == '*') || (str[i] == '*') || (str[i] == '/') || (str[i] == '*' && str[i + 1] == '/'))
                {
                    i++; continue;
                }
                str2 += str[i];
            }
            return str2;
        }
        private void ComentToolStripButton_Click(object sender, EventArgs e)
        {
            string str = "";
            if (child.ChildRichTextBox.SelectedText != "")
            {
                int a = child.ChildRichTextBox.SelectionStart;
                str = $"/*{child.ChildRichTextBox.SelectedText}*/";
                child.ChildRichTextBox.SelectedText = str;
                child.ChildRichTextBox.Select(a, str.Length);
                child.ChildRichTextBox.SelectionColor = Color.Green;
            }
        }

        private void LengCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorSelector(child.ChildRichTextBox, Words, Color.Blue);
        }
        public static void ColorSelector(RichTextBox ChildRichTextBox, string[] mystring, Color c)
        {

            foreach (string str in mystring)
            {
                if (str.Length > 0)
                {
                    int i = 0;
                    while (i <= ChildRichTextBox.Text.Length - str.Length)
                    {
                        i = ChildRichTextBox.Text.IndexOf(str, i);
                        if (i < 0) break;
                        ChildRichTextBox.SelectionStart = i;
                        ChildRichTextBox.SelectionLength = str.Length;
                        ChildRichTextBox.SelectionColor = c;
                        i += str.Length;
                    }
                }
            }
            ChildRichTextBox.SelectionStart = 0;
            ChildRichTextBox.SelectionLength = 0;
        }

        private void WhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flafColor = 0;
            foreach (var item in MdiChildren)
            {
                (item as Child).ChildRichTextBox.BackColor = Color.White;
                (item as Child).ChildRichTextBox.ForeColor = Color.Black;
                if ((item as Child).childPath.EndsWith("cs"))
                {
                    ColorSelector((item as Child).ChildRichTextBox, Words, Color.Blue);
                }
            }
        }

        private void BlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flafColor = 1;
            foreach (var item in MdiChildren)
            {
                (item as Child).ChildRichTextBox.BackColor = Color.Black;
                (item as Child).ChildRichTextBox.ForeColor = Color.White;
                if ((item as Child).childPath.EndsWith("cs"))
                {
                    ColorSelector((item as Child).ChildRichTextBox, Words, Color.Blue);
                }
            }
        }
        private void ColorIntrfese()
        {
            if (flafColor == 0)
            {
                child.ChildRichTextBox.BackColor = Color.White;
                child.ChildRichTextBox.ForeColor = Color.Black;
            }
            else
            {
                child.ChildRichTextBox.BackColor = Color.Black;
                child.ChildRichTextBox.ForeColor = Color.White;
            }
            if (path.EndsWith("cs"))
            {
                ColorSelector(child.ChildRichTextBox, Words, Color.Blue);
            }
        }
        private void ButtonReplace_Click(object sender, EventArgs e)
        {
            if (!child.ChildRichTextBox.Text.Contains(textBoxSearch.Text)) {
                MessageBox.Show($"Не удается найти {textBoxSearch.Text}", "", MessageBoxButtons.OK);
                return;
            }
            child.ChildRichTextBox.Text = child.ChildRichTextBox.Text.Replace(textBoxSearch.Text, $"{textBoxReplace.Text} ");
            if (child.childPath.EndsWith("cs"))
            {
                ColorSelector(child.ChildRichTextBox, Words, Color.Blue);
            }
            child.ChildRichTextBox.ForeColor = (flafColor == 0) ? Color.Black : Color.White;
        }
        private void ButtonReplaceEn_Click(object sender, EventArgs e)
        {
            if (!child.ChildRichTextBox.Text.Contains(searchSerchGroopEn.Text))
            {
                MessageBox.Show($"Не удается найти {searchSerchGroopEn.Text}", "", MessageBoxButtons.OK);
                return;
            }
            child.ChildRichTextBox.Text = child.ChildRichTextBox.Text.Replace(searchSerchGroopEn.Text, $"{ReplSerchGroopEn.Text} ");
            if (child.childPath.EndsWith("cs"))
            {
                ColorSelector(child.ChildRichTextBox, Words, Color.Blue);
            }
            child.ChildRichTextBox.ForeColor = (flafColor == 0) ? Color.Black : Color.White;
        }
        private void ButtonSerch_Click(object sender, EventArgs e)
        {

                int start = (child.ChildRichTextBox.Text.Length > child.ChildRichTextBox.SelectionStart ? child.ChildRichTextBox.SelectionStart + 1 : 0);
                if (textBoxSearch.Text.Length > 0 && start >= 0)
                {
                    child.ChildRichTextBox.Find(textBoxSearch.Text, start, RichTextBoxFinds.None);
                    child.ChildRichTextBox.Focus();
                }
            if ((child.ChildRichTextBox.Find(textBoxSearch.Text, start, RichTextBoxFinds.None)) == -1)
            {
                MessageBox.Show($"Не удается найти {textBoxSearch.Text}", "", MessageBoxButtons.OK);
            }
        }
        private void ButtonSerchEn_Click(object sender, EventArgs e)
        {
            int start = (child.ChildRichTextBox.Text.Length > child.ChildRichTextBox.SelectionStart ? child.ChildRichTextBox.SelectionStart + 1 : 0);
            if (searchSerchGroopEn.Text.Length > 0 && start >= 0)
            {
                child.ChildRichTextBox.Find(searchSerchGroopEn.Text, start, RichTextBoxFinds.None);
                child.ChildRichTextBox.Focus();
            }
            if ((child.ChildRichTextBox.Find(searchSerchGroopEn.Text, start, RichTextBoxFinds.None)) == -1)
            {
                MessageBox.Show($"Can not find {searchSerchGroopEn.Text}", "", MessageBoxButtons.OK);
            }
        }
        private void Labelreplace_Click(object sender, EventArgs e)
        {
            if (buttonReplace.Visible == false)
            {
                buttonReplace.Visible = true;
                textBoxReplace.Visible = true;
                labelreplace.Text = "-";
            }
            else
            {
                buttonReplace.Visible = false;
                textBoxReplace.Visible = false;
                labelreplace.Text = "+";
            }
        }
        private void LabelreplaceEn_Click(object sender, EventArgs e)
        {
            if (btnReplSerchGroopEn.Visible == false)
            {
                btnReplSerchGroopEn.Visible = true;
                ReplSerchGroopEn.Visible = true;
                labelserchGroopEn.Text = "-";
            }
            else
            {
                btnReplSerchGroopEn.Visible = false;
                ReplSerchGroopEn.Visible = false;
                labelserchGroopEn.Text = "+";
            }
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            text.ForeColor = Color.Black;
            text.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        }

        private void TextBoxSearch_Leave(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text == "" & text.Name != textBoxReplace.Name)
            {
                textBoxSearch.Text = "Поиск";
                textBoxSearch.ForeColor = Color.Silver;
                text.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            }
            else if (text.Text == "" & text.Name != textBoxSearch.Name)
            {
                textBoxReplace.Text = "Заменить на";
                textBoxReplace.ForeColor = Color.Silver;
                text.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Italic);
            }
        }

        private void TextBoxSearch_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text.Text == "Поиск")
            {
                textBoxSearch.Text = "";
            }
            else if (text.Text == "Заменить на")
            {
                textBoxReplace.Text = "";
            }
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void maximizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                (item as Child).WindowState = FormWindowState.Maximized;
            }
        }

        private void minimizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in MdiChildren)
            {
                (item as Child).WindowState = FormWindowState.Minimized;
            }
        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.WindowState = FormWindowState.Maximized;
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.WindowState = FormWindowState.Minimized;
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in this.MdiChildren)
            {
                (item as Child).Close();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Close();
        }

        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                statusBarToolStripMenuItem.Enabled = true;
                timeToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem.Enabled = true;
                backToolStripMenuItem.Enabled = true;
                fontToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                tabsToolStripMenuItem.Visible = true;
                textBoxSearch.Enabled = true;
                textBoxReplace.Enabled = true;
                labelreplace.Enabled = true;
                buttonReplace.Enabled = true;
                buttonSerch.Enabled = true;
                saveToolStripButton.Enabled = true;
                undoToolStripButton.Enabled = true;
                redoToolStripButton.Enabled = true;
                cutToolStripButton.Enabled = true;
                pasteToolStripButton.Enabled = true;
                dateToolStripButton.Enabled = true;
                copyToolStripButton.Enabled = true;
                closeToolStripButton.Enabled = true;
                colorToolStripButton.Enabled = true;
                backColorToolStripButton.Enabled = true;
                sintacsisToolStripMenuItem.Enabled = true;
                unCommentToolStripButton.Enabled = true;
                comentToolStripButton.Enabled = true;
                //en
                statusBarToolStripMenuItemEn.Enabled = true;
                timeToolStripMenuItemEn.Enabled = true;
                selectAllToolStripMenuItemEn.Enabled = true;
                pasteToolStripMenuItemEn.Enabled = true;
                backToolStripMenuItemEn.Enabled = true;
                fontToolStripMenuItemEn.Enabled = true;
                saveToolStripMenuItemEn.Enabled = true;
                saveAsToolStripMenuItemEn.Enabled = true;
                //tabsToolStripMenuItemEn.Visible = true;
                //textBoxSearchEn.Enabled = true;
                textBoxReplace.Enabled = true;
                labelreplace.Enabled = true;
                buttonReplace.Enabled = true;
                buttonSerch.Enabled = true;
                saveToolStripButton.Enabled = true;
                undoToolStripButton.Enabled = true;
                redoToolStripButton.Enabled = true;
                cutToolStripButton.Enabled = true;
                pasteToolStripButton.Enabled = true;
                dateToolStripButton.Enabled = true;
                copyToolStripButton.Enabled = true;
                closeToolStripButton.Enabled = true;
                colorToolStripButton.Enabled = true;
                backColorToolStripButton.Enabled = true;
                sintacsisToolStripMenuItem.Enabled = true;
                unCommentToolStripButton.Enabled = true;
                comentToolStripButton.Enabled = true;
                child = ActiveMdiChild as Child;
                path = child.Text;
                Text = (flagLeng == 0)?$"Блокнот  {path}": $"Notebook  {path}";
                child.ChildRichTextBox.TextChanged += RichTextBox_TextChanged;//событие на изменение текста в активной форме
                child.ChildRichTextBox.SelectionChanged += RichTextBox_SelectionChanged;//событие на выделение текста в активной форме
                child.ChildRichTextBox.ContextMenuStrip = contextMenuStrip;//подключаем контекстное меню из первой формы к второй форме
            }
            else
            {
                Text = (flagLeng == 0) ? $"Блокнот  {path}" : $"Notebook  {path}";
                path = "";
                statusBarToolStripMenuItem.Enabled = false;
                timeToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem.Enabled = false;
                backToolStripMenuItem.Enabled = false;
                fontToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                tabsToolStripMenuItem.Visible = false;
                textBoxSearch.Enabled = false;
                textBoxReplace.Enabled = false;
                labelreplace.Enabled = false;
                buttonReplace.Enabled = false;
                buttonSerch.Enabled = false;
                saveToolStripButton.Enabled = false;
                undoToolStripButton.Enabled = false;
                redoToolStripButton.Enabled = false;
                cutToolStripButton.Enabled = false;
                pasteToolStripButton.Enabled = false;
                dateToolStripButton.Enabled = false;
                copyToolStripButton.Enabled = false;
                closeToolStripButton.Enabled = false;
                colorToolStripButton.Enabled = false;
                backColorToolStripButton.Enabled = false;
                sintacsisToolStripMenuItem.Enabled = false;
                unCommentToolStripButton.Enabled = false;
                comentToolStripButton.Enabled = false;
            }
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutProgram AboutProgram = new aboutProgram();
            AboutProgram.ShowDialog();
        }

        private void TimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            child.ChildRichTextBox.SelectedText = date.ToString();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void RichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            // Получить строку.
            int index = child.ChildRichTextBox.SelectionStart;
            int line = child.ChildRichTextBox.GetLineFromCharIndex(index);

            // Получить столбец.
            int firstChar = child.ChildRichTextBox.GetFirstCharIndexFromLine(line);
            int column = index - firstChar;

            statusBarText.Text = $"Cтр:{line+1}, стлб:{column+1}";//строка состояия

            if (child.ChildRichTextBox.SelectedText == "")
            {
                cutToolStripItem.Enabled = false;
                copyToolStripItem.Enabled = false;
                delToolStripItem.Enabled = false;

                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                delToolStripMenuItem.Enabled = false;
            }
            else
            {
                cutToolStripItem.Enabled = true;
                copyToolStripItem.Enabled = true;
                delToolStripItem.Enabled = true;

                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                delToolStripMenuItem.Enabled = true;
            }
        }
        
        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            undoToolStripItem.Enabled = child.ChildRichTextBox.CanUndo;
            undoToolStripMenuItem.Enabled = child.ChildRichTextBox.CanUndo;

        }

        private void StatusBarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked == true) toolStripBottom.Visible = true;
            else toolStripBottom.Visible = false;
        }

        private void BackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = child.ChildRichTextBox.SelectionBackColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                child.ChildRichTextBox.SelectionBackColor = dialog.Color;
            }
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = child.ChildRichTextBox.SelectionColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                child.ChildRichTextBox.SelectionColor = dialog.Color;
            }
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = child.ChildRichTextBox.SelectionFont;
            dialog.Color = child.ChildRichTextBox.SelectionColor;
            dialog.ShowColor = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                child.ChildRichTextBox.SelectionFont = dialog.Font;
                child.ChildRichTextBox.SelectionColor = dialog.Color;
            }
        }
        private void SelectAllToolStripItem_Click(object sender, EventArgs e)
        {
            child.ChildRichTextBox.SelectAll();
        }
        private void DeliteToolStripItem_Click(object sender, EventArgs e)
        {
            child.ChildRichTextBox.SelectedText = "";
        }

        private void CopyToolStripItem_Click(object sender, EventArgs e)
        {
            child.ChildRichTextBox.Copy();
        }

        private void PastToolStripItem_Click(object sender, EventArgs e)
        {
            child.ChildRichTextBox.Paste();
        }
        private void RedoToolStripItem_Click(object sender, EventArgs e)
        {
            child.ChildRichTextBox.Redo();
        }
        private void UndoToolStripItem_Click(object sender, EventArgs e)
        {
            
            child.ChildRichTextBox.Undo();
        }

        private void CutToolStripItem_Click(object sender, EventArgs e)
        {
            child.ChildRichTextBox.Cut();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "All file(*.*)|*.*|Unit Test file (*.cs)|*.cs|TXT file (*.txt)|*.txt|RTF file(*.rtf)|*.rtf";
            saveFile.FilterIndex = 2;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (saveFile.FileName.EndsWith("rtf"))
                    {
                        child.ChildRichTextBox.SaveFile(saveFile.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        child.ChildRichTextBox.SaveFile(saveFile.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (path != "")
            {
                if (path.EndsWith("rtf"))
                {
                    child.ChildRichTextBox.SaveFile(path, RichTextBoxStreamType.RichText);
                }
                else
                {
                    child.ChildRichTextBox.SaveFile(path, RichTextBoxStreamType.PlainText);
                }
            }
        }
        private void NewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "All file(*.*)|*.*|Unit Test file (*.cs)|*.cs|TXT file (*.txt)|*.txt|RTF file(*.rtf)|*.rtf";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                child = new Child();
                child.MdiParent = this;
                child.Show();
                child.childPath = path = dialog.FileName;
                Text = $"Блокнот  {path}";
                ColorIntrfese();
            }
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All file(*.*)|*.*|Unit Test file (*.cs)|*.cs|TXT file (*.txt)|*.txt|RTF file(*.rtf)|*.rtf";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                child = new Child();
                child.MdiParent = this;
                child.Show();
                child.childPath = path = dialog.FileName;
                child.Text = path;
                Text = $"Блокнот  {path}";
                if (path.EndsWith("rtf"))
                {
                    child.ChildRichTextBox.LoadFile(path, RichTextBoxStreamType.RichText);
                }
                else
                {
                    using (StreamReader reader = new StreamReader(path, Encoding.Default))
                    {
                        child.ChildRichTextBox.Text = reader.ReadToEnd();
                    }
                }
                if (path.EndsWith("cs"))
                {
                    ColorSelector(child.ChildRichTextBox, Words, Color.Blue);

                }
                ColorIntrfese();

            }
        }
    }
}
