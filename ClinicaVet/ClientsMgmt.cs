using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ClinicaVet
{
    public partial class ClientsMgmt : Form
    {
        DataSet ds = new DataSet();
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-LT5EGJU;Initial Catalog=db_5119;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();

        BindingSource tblDataBS = new BindingSource();
        public ClientsMgmt()
        {
            InitializeComponent();
            
        }

        private void ClientsMgmt_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            da.SelectCommand = new SqlCommand("SELECT * FROM Clientes", sqlcon);
            ds.Clear();
            da.Fill(ds);

            tblDataBS.DataSource = ds.Tables[0];

            txtFirstName.DataBindings.Add(new Binding("Text", tblDataBS, "nome"));
            txtLastName.DataBindings.Add(new Binding("Text", tblDataBS, "apelido"));
            txtFiscalNr.DataBindings.Add(new Binding("Text", tblDataBS, "contribuinte"));
            txtPhoneNr.DataBindings.Add(new Binding("Text", tblDataBS, "contato"));
            txtAddress.DataBindings.Add(new Binding("Text", tblDataBS, "morada"));
            txtPostal.DataBindings.Add(new Binding("Text", tblDataBS, "cod_postal"));
            txtCity.DataBindings.Add(new Binding("Text", tblDataBS, "cidade"));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            tblDataBS.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tblDataBS.MoveNext();
        }
    }
}
