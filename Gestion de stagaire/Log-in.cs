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
    public partial class Log_in : Form
    {
        public Log_in()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Veuillez entrez tous les champs");
            }
            else if(username.Text == "colaimo" && password.Text == "colaimo")
            {
                Stagaire obj = new Stagaire();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Données non valides, Veuillez ressayez s'il vous plaît");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Log_in_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
