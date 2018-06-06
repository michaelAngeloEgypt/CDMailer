using CDMailer.BLL;
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

namespace CDMailer
{
    public partial class SingleContact : Form
    {
        public String SelectedContact { get { if (cboContactNames.SelectedIndex == -1) return ""; else return cboContactNames.SelectedValue.ToString(); } }
        public String SelectedTemplate { get { if (cboTemplateNames.SelectedIndex == -1) return ""; else return cboTemplateNames.SelectedValue.ToString(); } }
        public string OutputFolder { get { return txtOutputFolder.Text; } set { txtOutputFolder.Text = value; } }
        public REF.GeneratePerContact GeneratePerContact
        {
            get
            {
                var selectedTag = Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Tag.ToString();
                return (REF.GeneratePerContact)Enum.Parse(typeof(REF.GeneratePerContact), selectedTag);
            }
        }

        public SingleContact()
        {
            InitializeComponent();
            FillControls();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(SelectedContact) || string.IsNullOrEmpty(SelectedTemplate))
                MessageBox.Show("Please make sure to select a contact and a template first");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FillControls()
        {
            var validContacts = Engine.Variables.Contacts.Where(c=>c.GetAddressContacts().Count > 0);
            var contactNames = validContacts.Select(c=> c.ContactName).Distinct().OrderBy(c=>c).ToList();
            cboContactNames.DataSource = contactNames;

            var templateNames = Directory.GetFiles(REF.templatesPath)
                    .Select(f => Path.GetFileNameWithoutExtension(f)).Where(f=>f.Contains("[") && !REF.Constants.EnvelopTemplate.ContainsString(f)).OrderBy(f=>f).ToList();
            cboTemplateNames.DataSource = templateNames;

            OutputFolder = Engine.Config.UI.OutputFolder;
        }
    }
}
