using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {

        static string chaine = @"Data Source=DESKTOP-3GUL0VT;Initial Catalog=DOSSIER;;User ID=sa;Password=Mohammed123";
        static SqlConnection cnx = new SqlConnection(chaine);
        static SqlCommand cmd = new SqlCommand();
        static SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        public Form1()
        {
            InitializeComponent();
            btnSupprimer.Enabled = false;
            btnModifier.Enabled = false;
            btnEnregistrer.Enabled = false;
            btnAnnuler.Enabled = false;
            textId.Enabled = false;
            textNom.Enabled = false;
            textPrenom.Enabled = false;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            btnEnregistrer.Enabled = true;
            btnAnnuler.Enabled = true;
            btnSelectionner.Enabled = false;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            textNom.Enabled = true;
            textNom.Focus();
            textPrenom.Enabled = true;
            dataGridView1.DataSource = null;
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            btnSupprimer.Enabled = true;
            btnModifier.Enabled = true;
            cnx.Open();
            cmd.CommandText = "select * from dataform";
            cmd.Connection = cnx;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            cnx.Close();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            btnAjouter.Enabled = false;
            btnSupprimer.Enabled = false;
            btnEnregistrer.Enabled = true;
            btnSelectionner.Enabled = false;
            btnAnnuler.Enabled = true;
            textId.Enabled = true;
            textId.Focus();
            textNom.Enabled = true;
            textPrenom.Enabled = true;
        }

        private void textId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            if (btnAjouter.Enabled) {
                cmd.CommandText = "insert into dataform (nom, prenom) values('" + textNom.Text + "','" + textPrenom.Text + "') ";
                textNom.Text = "";
                textPrenom.Text = "";
                textNom.Enabled = false;
                textPrenom.Enabled = false; 
                btnAnnuler.Enabled = false;
            }
            if (btnModifier.Enabled) {
                if(textId.Text != "")
                    cmd.CommandText = "update dataform set nom='" + textNom.Text + "' ,prenom='" + textPrenom.Text + "' where id = " + textId.Text + ";";
                btnAjouter.Enabled = true;
                textId.Text = "";
                textNom.Text = "";
                textPrenom.Text = "";
                textId.Enabled = false; 
                textNom.Enabled = false;
                textPrenom.Enabled = false; 
            }
            if (btnSupprimer.Enabled)
            {
                if (textId.Text != "")
                    cmd.CommandText = "delete from dataform where id = " + textId.Text + ";";
                textId.Text = "";
                textId.Enabled = false;
                btnAjouter.Enabled = true;
            }
            cmd.ExecuteNonQuery();
            cnx.Close();
            btnEnregistrer.Enabled = false;
            btnAnnuler.Enabled = false;
            btnSelectionner.Enabled = true;
            btnSupprimer.Enabled = false;
            btnModifier.Enabled = false;
            dataGridView1.DataSource = null;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (btnAjouter.Enabled)
            {
                textNom.Text = "";
                textPrenom.Text = "";
                textNom.Enabled = false;
                textPrenom.Enabled = false;
            }
            if (btnModifier.Enabled)
            {
                textId.Text = "";
                textNom.Text = "";
                textPrenom.Text = "";
                textId.Enabled = false;
                textNom.Enabled = false;
                textPrenom.Enabled = false;
                btnAjouter.Enabled = true;
            }
            if (btnSupprimer.Enabled)
            {
                textId.Text = "";
                textId.Enabled = false;
                btnAjouter.Enabled = true;
            }
            if(dataGridView1.DataSource != null)
            {
                btnSupprimer.Enabled = false;
                btnModifier.Enabled = false;
                dataGridView1.DataSource = null;
            }
            btnEnregistrer.Enabled = false;
            btnAnnuler.Enabled = false;
            btnSelectionner.Enabled = true;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            textId.Enabled = true;
            btnEnregistrer.Enabled = true;
            btnAnnuler.Enabled = true;
            btnAjouter.Enabled = false;
            btnModifier.Enabled = false;
            btnSelectionner.Enabled = false;
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
