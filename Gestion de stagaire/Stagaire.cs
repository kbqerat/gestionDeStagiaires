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
    public partial class Stagaire : Form
    {
        Functions con;
        public Stagaire()
        {
            InitializeComponent();
            con = new Functions();
            afficherStagaires();
        }
        private void afficherStagaires()
        {
            string query = "select * from stagaire";
            stagaireDataGridView.DataSource = con.GetData(query);
        }
        private void ajouterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (nomStagaire.Text == "" || prenomStagaire.Text == "" || ageStagaire.Text == "" || emailStagaire.Text == "" || sexeStagaire.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez entrez tous les champs, s'il vous plait");
                }
                else
                {
                    string nom = nomStagaire.Text;
                    string prenom = prenomStagaire.Text;
                    string age = ageStagaire.Text;
                    string email = emailStagaire.Text;
                    string sexe = sexeStagaire.SelectedItem.ToString();
                    string query = "insert into stagaire values('{0}','{1}','{2}','{3}','{4}')";
                    query = string.Format(query, nom, prenom, age, email, sexe);
                    con.SetData(query);
                    MessageBox.Show("Un stagaire est ajoute");
                    afficherStagaires();
                    idStagaire.Text = "";
                    nomStagaire.Text = "";
                    prenomStagaire.Text = "";
                    ageStagaire.Text = "";
                    emailStagaire.Text = "";
                    sexeStagaire.SelectedIndex = -1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void stagaireDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = stagaireDataGridView.Rows[index];
                idStagaire.Text = selectedRow.Cells[0].Value.ToString();
                nomStagaire.Text = selectedRow.Cells[1].Value.ToString();
                prenomStagaire.Text = selectedRow.Cells[2].Value.ToString();
                ageStagaire.Text = selectedRow.Cells[3].Value.ToString();
                emailStagaire.Text = selectedRow.Cells[4].Value.ToString();
                sexeStagaire.Text = selectedRow.Cells[5].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void supprimerBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idStagaire.Text);
            
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult resultat = MessageBox.Show("Est-ce que vous voulez supprimer ce stagaire", "Supprimer un stagaire",buttons);
                if(resultat == DialogResult.Yes)
                {
                    try
                    {
                        string query = "delete from stagaire where id = '{0}'";
                        query = string.Format(query, id);
                        con.SetData(query);
                        afficherStagaires();
                        MessageBox.Show("Un stagaire a ete bien supprime");
                        idStagaire.Text = "";
                        nomStagaire.Text = "";
                        prenomStagaire.Text = "";
                        ageStagaire.Text = "";
                        emailStagaire.Text = "";
                        sexeStagaire.SelectedIndex = -1;
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

        private void modifierBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (nomStagaire.Text == "" || prenomStagaire.Text == "" || ageStagaire.Text == "" || emailStagaire.Text == "" || sexeStagaire.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez entrez tous les champs, s'il vous plait");
                }
                else
                {
                    int id = int.Parse(idStagaire.Text);
                    string nom = nomStagaire.Text;
                    string prenom = prenomStagaire.Text;
                    string age = ageStagaire.Text;
                    string email = emailStagaire.Text;
                    string sexe = sexeStagaire.SelectedItem.ToString();
                    string query = "update stagaire set nom = '{0}', prenom = '{1}', age = '{2}', email = '{3}', sexe = '{4}' where id = '{5}'";
                    query = string.Format(query, nom, prenom, age, email, sexe, id);
                    con.SetData(query);
                    afficherStagaires();
                    MessageBox.Show("Un stagaire a été bien modifie");
                    idStagaire.Text = "";
                    nomStagaire.Text = "";
                    prenomStagaire.Text = "";
                    ageStagaire.Text = "";
                    emailStagaire.Text = "";
                    sexeStagaire.SelectedIndex = -1;
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

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Attestation obj = new Attestation();
            obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Badge obj = new Badge();
            obj.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.ActiveControl = nomStagaire;
        }

        private void nomStagaire_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sexeStagaire_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}