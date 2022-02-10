using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem
{
    public partial class EnterData : Form
    {
        private List<TextBox> Inputs = new List<TextBox>();

        public EnterData()
        {
            InitializeComponent();

            var propInfo = typeof(Patient).GetProperties();
            for(int i = 0;i< propInfo.Length; i++)
            {
                var property = propInfo[i];
                var textbox = CreateTextBox(i, property);
                Controls.Add(textbox);
                Inputs.Add(textbox);
            }
        }

        public bool? ShowForm()
        {
            var form = new EnterData();
            if(form.ShowDialog()== DialogResult.OK)
            {
                var patient = new Patient();

                foreach(var textbox in form.Inputs)
                {
                    patient.GetType().InvokeMember(textbox.Tag.ToString(),
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty, 
                        Type.DefaultBinder, 
                        patient, new object[] { textbox.Text });
                }

                var result = Program.Controller.DataNetwork.Predict().Output;
                return result == 1.0; 
            }
            return null;
        }

        private TextBox CreateTextBox(int number, PropertyInfo property)
        {
            var y = number * 50 + 12;
            var textbox = new TextBox()
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right),
                Location = new Point(12, y),
                Name = $"textBox{number}",
                Size = new Size(353, 20),
                TabIndex = number,
                Text = property.Name,
                Tag = property.Name,
                ForeColor = Color.Gray,
                Font = new Font("Times New Roman", 14F)
            };

            textbox.GotFocus += Textbox_GotFocus;
            textbox.LostFocus += Textbox_LostFocus;
            return textbox;
        }

        private void Textbox_LostFocus(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "")
            {
                textBox.Text = textBox.Tag.ToString();
                textBox.ForeColor = Color.Gray;
            }
        }

        private void Textbox_GotFocus(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if(textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
