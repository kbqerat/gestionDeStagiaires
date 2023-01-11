using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_stagaire
{
    public partial class Badge : Form
    {
        Functions con;
        public Badge()
        {
            InitializeComponent();
            con = new Functions();
            afficherBadges();
            afficherStagairesSurComboBox();
        }

        public void afficherBadges()
        {
            string query = "select * from badge";
            dataGridView1.DataSource = con.GetData(query);
        }

        public void afficherStagairesSurComboBox()
        {
            string query = "select id from stagaire full join badge on badge.stagaire = stagaire.id";
            comboBox1.DataSource = con.GetData(query);
            comboBox1.DisplayMember = "id";
        }
        private void label9_Click(object sender, EventArgs e)
        {
            Stagaire obj = new Stagaire();
            obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Attestation obj = new Attestation();
            obj.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.ActiveControl = comboBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == -1 || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Veuillez entrez tous les champs, s'il vous plait");
                }
                else
                {
                    string id = comboBox1.Text;
                    string code = textBox1.Text;
                    string etablissement = textBox2.Text;
                    string branche = textBox3.Text;
                    string query = "insert into badge values('{0}','{1}','{2}','{3}')";
                    query = string.Format(query, code, etablissement, branche, id);
                    con.SetData(query);
                    MessageBox.Show("Un badge a été ajouté");
                    afficherBadges();
                    comboBox1.SelectedIndex = -1;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Log_in obj = new Log_in();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Veuillez entrez tous les champs, s'il vous plait");
                }
                else
                {
                    int stagaireId = int.Parse(comboBox1.Text);
                    string etablissement = textBox2.Text;
                    string branche = textBox3.Text;
                    int code = int.Parse(textBox1.Text);
                    string query = "update badge set stagaire = '{0}', etablissement = '{1}', branche = '{2}' where code = '{3}'";
                    query = string.Format(query, stagaireId, etablissement, branche, code);
                    con.SetData(query);
                    afficherBadges();
                    MessageBox.Show("Un stagaire a été bien modifié");
                    comboBox1.SelectedIndex = -1;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                textBox1.Text = selectedRow.Cells[0].Value.ToString();
                textBox2.Text = selectedRow.Cells[1].Value.ToString();
                textBox3.Text = selectedRow.Cells[2].Value.ToString();
                comboBox1.Text = selectedRow.Cells[3].Value.ToString();
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
            DialogResult resultat = MessageBox.Show("Est-ce que vous voulez supprimer ce badge?", "Supprimer un badge", buttons);
            if (resultat == DialogResult.Yes)
            {
                try
                {
                    string query = "delete from badge where code = '{0}'";
                    query = string.Format(query, id);
                    con.SetData(query);
                    afficherBadges();
                    MessageBox.Show("Un stagaire a ete bien supprime");
                    comboBox1.SelectedIndex = -1;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
