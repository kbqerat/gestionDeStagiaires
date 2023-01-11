using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Gestion_de_stagaire
{
    public partial class Attestation : Form
    {
        Functions con;
        public Attestation()
        {
            InitializeComponent();
            con = new Functions();
            afficherAttestation();
            afficherStagairesSurComboBox();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Today.AddDays(30);
        }

        public void afficherAttestation()
        {
            string query = "select * from attestation";
            dataGridView1.DataSource = con.GetData(query);
        }

        public void afficherStagairesSurComboBox()
        {
            string query = "select DISTINCT id from stagaire full join attestation on attestation.stagaire = stagaire.id";
            comboBox1.DataSource = con.GetData(query);
            comboBox1.DisplayMember = "id";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Stagaire obj = new Stagaire();
            obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Badge obj = new Badge();
            obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Log_in obj = new Log_in();
            obj.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                textBox1.Text = selectedRow.Cells[0].Value.ToString();
                dateTimePicker1.Text = selectedRow.Cells[1].Value.ToString();
                dateTimePicker2.Text = selectedRow.Cells[2].Value.ToString();
                comboBox1.Text = selectedRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == -1 || textBox1.Text == "")
                {
                    MessageBox.Show("Veuillez entrez tous les champs, s'il vous plait");
                }
                else
                {
                    string num_att = textBox1.Text;
                    int stagaireId = int.Parse(comboBox1.Text);
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    dateTimePicker1.CustomFormat = "ddd dd MMM yyyy";
                    dateTimePicker2.Format = DateTimePickerFormat.Custom;
                    dateTimePicker2.CustomFormat = "ddd dd MMM yyyy";
                    string query = "insert into attestation values('{0}','{1}','{2}','{3}')";
                    query = string.Format(query, num_att, dateTimePicker1.Value, dateTimePicker2.Value, stagaireId);
                    con.SetData(query);
                    MessageBox.Show("Une attestation a été ajouté");
                    afficherAttestation();
                    textBox1.Text = "";
                    comboBox1.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now.AddDays(30);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Veuillez entrez tous les champs, s'il vous plait");
                }
                else
                {
                    int stagaireId = int.Parse(comboBox1.Text);
                    int num_att = int.Parse(textBox1.Text);
                    string query = "update attestation set stagaire = '{0}', [Debut du stage] = '{1}', [Fin du stage] = '{2}' where [Numero d'attestation] = '{3}'";
                    query = string.Format(query, stagaireId, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, num_att);
                    con.SetData(query);
                    afficherAttestation();
                    MessageBox.Show("Un stagaire a été bien modifié");
                    textBox1.Text = "";
                    comboBox1.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now.AddDays(30);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult resultat = MessageBox.Show("Est-ce que vous voulez supprimer cette attestation?", "Supprimer une attestation", buttons);
            if (resultat == DialogResult.Yes)
            {
                try
                {
                    string query = "delete from attestation where [Numero d'attestation] = '{0}'";
                    query = string.Format(query, id);
                    con.SetData(query);
                    afficherAttestation();
                    MessageBox.Show("Une attestation a ete bien supprime");
                    textBox1.Text = "";
                    comboBox1.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now.AddDays(30);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                return;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                reportDocument.Load(Application.StartupPath + "\\attestationReport.rpt");
                reportDocument.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                reportDocument.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            }


        }



    }
}