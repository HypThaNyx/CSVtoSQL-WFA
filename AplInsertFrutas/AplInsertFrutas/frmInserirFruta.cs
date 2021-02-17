using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Xml;
using System.Xml.Linq;
using System.Data.OleDb;
using Microsoft.VisualBasic.FileIO;


namespace AplInsertFrutas
{ 
    public partial class frmInserirFruta : Form
    {
        int idatual = 0;

        string Nome, Categoria, PesoM, CalKcal, CalKJ, Protein, Lipid, Carbo, Fibra, Calcium, Magnesio, Manganes, Fosforo, Ferro, Sodium, Potassio, Cobre, Zinc, VitB1, VitB2, VitB6, VitB3, VitC;

        private void TeclaApertada(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Left)
            {
                Anterior(sender, e);
            } else if ((Keys)e.KeyChar == Keys.Right)
            {
                Proximo(sender, e);
            }
            txt1.Text = "";
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() != "")
            {
                idatual = int.Parse(txtID.Text) - 1;
                setTexto(idatual);
            }
        }

        public void Proximo(object sender, EventArgs e)
        {
            idatual += 1;
            setTexto(idatual);
        }

        public void Anterior(object sender, EventArgs e)
        {
            idatual -= 1;
            setTexto(idatual);
        }

        public void setTexto(int idfruta)
        {
            DataTable Tabela = LoadFruta();
            txtID.Text = (idfruta + 1).ToString();
            txtNome.Text = Tabela.Rows[idfruta]["nomefruta"].ToString();
            txtKcal.Text = Tabela.Rows[idfruta]["kcal"].ToString();
            txtKJ.Text = Tabela.Rows[idfruta]["kJ"].ToString();
            txtCarbo.Text = Tabela.Rows[idfruta]["carboidratos"].ToString();
            txtFibra.Text = Tabela.Rows[idfruta]["fibra"].ToString();
            txtLipid.Text = Tabela.Rows[idfruta]["lipideos"].ToString();
            txtProtein.Text = Tabela.Rows[idfruta]["proteina"].ToString();
            txtVitB1.Text = Tabela.Rows[idfruta]["tiamina"].ToString();
            txtVitB2.Text = Tabela.Rows[idfruta]["riboflavina"].ToString();
            txtVitB6.Text = Tabela.Rows[idfruta]["piridoxina"].ToString();
            txtVitB12.Text = Tabela.Rows[idfruta]["niacina"].ToString();
            txtVitC.Text = Tabela.Rows[idfruta]["vitaminaC"].ToString();
            txtCalcio.Text = Tabela.Rows[idfruta]["calcio"].ToString();
            txtSodio.Text = Tabela.Rows[idfruta]["sodio"].ToString();
            txtCobre.Text = Tabela.Rows[idfruta]["cobre"].ToString();
            txtManganes.Text = Tabela.Rows[idfruta]["manganes"].ToString();
            txtZinco.Text = Tabela.Rows[idfruta]["zinco"].ToString();
            txtFosforo.Text = Tabela.Rows[idfruta]["fosforo"].ToString();
            txtFerro.Text = Tabela.Rows[idfruta]["ferro"].ToString();
            txtPotassio.Text = Tabela.Rows[idfruta]["potassio"].ToString();
            txtMagnesio.Text = Tabela.Rows[idfruta]["magnesio"].ToString();
            txtNome.Focus();
        }

        private void frmInserirFruta_Load(object sender, EventArgs e)
        {
            try
            {
                objConexao.ConnectionString = "Server=localhost;Database=suchemia;User=" + User + ";Pwd=" + Pass + "";
                objConexao.Open();
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "Suchemia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvFrutas.DataSource = LoadFruta();
            setTexto(idatual);
        }

        private MySqlConnection objConexao = new MySqlConnection();
        private MySqlCommand objComando = new MySqlCommand();
        private MySqlDataReader objDados;
        private string user;
        private string pass;

        public string User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {
                pass = value;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPesoM.Text = "";
            cbbCategoria.SelectedIndex = -1;
        }

        public frmInserirFruta(string Usuario, string Password)
        {
            InitializeComponent();
            Inicio(Usuario, Password);
        }

        public void Inicio(string Usuario, string Password)
        {
            User = Usuario;
            Pass = Password;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdicionarFruta(object sender, EventArgs e)
        {
            Nome = txtNome.Text.Trim();
            Categoria = cbbCategoria.SelectedIndex.ToString().Trim();
            PesoM = txtPesoM.Text.Trim();
            CalKcal = txtKcal.Text.Trim();
            CalKJ = txtKcal.Text.Trim();
            Carbo = txtCarbo.Text.Trim();
            Fibra = txtFibra.Text.Trim();
            Lipid = txtLipid.Text.Trim();
            Protein = txtProtein.Text.Trim();
            VitB1 = txtVitB1.Text.Trim();
            VitB2 = txtVitB2.Text.Trim();
            VitB6 = txtVitB6.Text.Trim();
            VitB3 = txtVitB12.Text.Trim();
            VitC = txtVitC.Text.Trim();
            Calcium = txtCalcio.Text.Trim();
            Sodium = txtSodio.Text.Trim();
            Cobre = txtCobre.Text.Trim();
            Manganes = txtManganes.Text.Trim();
            Zinc = txtZinco.Text.Trim();
            Fosforo = txtFosforo.Text.Trim();
            Ferro = txtFerro.Text.Trim();
            Potassio = txtPotassio.Text.Trim();
            Magnesio = txtMagnesio.Text.Trim();

            if ((Categoria != "-1") && (PesoM != "") && (Nome != "0") && (CalKcal != "0") && (CalKJ != "0"))
            {
                try
                {
                    string strSql = "Select * from fruta Where nome_fruta = '" + Nome + "'";
                    objComando.Connection = objConexao;
                    objComando.CommandText = strSql;
                    objDados = objComando.ExecuteReader();
                    if (objDados.HasRows)
                    {
                        MessageBox.Show("Essa fruta já existe!!!", "Suchemia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNome.Focus();
                    }
                    else
                    {
                        if (!objDados.IsClosed) { objDados.Close(); }
                        strSql = "Insert into fruta (nome_fruta, caloriasfruta_kcal, caloriasfruta_kj, categoria_fruta, pesomedio_fruta) values (";
                        strSql += "'" + Nome + "',";
                        strSql += "'" + CalKcal + "',";
                        strSql += "'" + CalKJ + "',";
                        strSql += "'" + Categoria + "',";
                        strSql += "'" + PesoM + "')";

                        objComando.Connection = objConexao;
                        objComando.CommandText = strSql;
                        objComando.ExecuteNonQuery();
                    }
                    if (!objDados.IsClosed) { objDados.Close(); }

                    if ((Protein != "") && (Protein != "0"))
                    {
                        NutrienteFruta(double.Parse(Protein), "Proteína");
                    }
                    if ((Lipid != "") && (Lipid != "0"))
                    {
                        NutrienteFruta(double.Parse(Lipid), "Lipídeos");
                    }
                    if ((Carbo != "") && (Carbo != "0"))
                    {
                        NutrienteFruta(double.Parse(Carbo), "Carboidratos");
                    }
                    if ((Fibra != "") && (Fibra != "0"))
                    {
                        NutrienteFruta(double.Parse(Fibra), "Fibras");
                    }
                    if ((Calcium != "") && (Calcium != "0"))
                    {
                        NutrienteFruta(double.Parse(Calcium), "Cálcio");
                    }
                    if ((Magnesio != "") && (Magnesio != "0"))
                    {
                        NutrienteFruta(double.Parse(Magnesio), "Magnésio");
                    }
                    if ((Manganes != "") && (Manganes != "0"))
                    {
                        NutrienteFruta(double.Parse(Manganes), "Manganês");
                    }
                    if ((Fosforo != "") && (Fosforo != "0"))
                    {
                        NutrienteFruta(double.Parse(Fosforo), "Fósforo");
                    }
                    if ((Ferro != "") && (Ferro != "0"))
                    {
                        NutrienteFruta(double.Parse(Ferro), "Ferro");
                    }
                    if ((Sodium != "") && (Sodium != "0"))
                    {
                        NutrienteFruta(double.Parse(Sodium), "Sódio");
                    }
                    if ((Potassio != "") && (Potassio != "0"))
                    {
                        NutrienteFruta(double.Parse(Potassio), "Potássio");
                    }
                    if ((Cobre != "") && (Cobre != "0"))
                    {
                        NutrienteFruta(double.Parse(Cobre), "Cobre");
                    }
                    if ((Zinc != "") && (Zinc != "0"))
                    {
                        NutrienteFruta(double.Parse(Zinc), "Zinco");
                    }
                    if ((VitB1 != "") && (VitB1 != "0"))
                    {
                        NutrienteFruta(double.Parse(VitB1), "Vitamina B1");
                    }
                    if ((VitB2 != "") && (VitB2 != "0"))
                    {
                        NutrienteFruta(double.Parse(VitB2), "Vitamina B2");
                    }
                    if ((VitB6 != "") && (VitB6 != "0"))
                    {
                        NutrienteFruta(double.Parse(VitB6), "Vitamina B6");
                    }
                    if ((VitB3 != "") && (VitB3 != "0"))
                    {
                        NutrienteFruta(double.Parse(VitB3), "Vitamina B3");
                    }
                    if ((VitC != "") && (VitC != "0"))
                    {
                        NutrienteFruta(double.Parse(VitC), "Vitamina C");
                    }

                    MessageBox.Show("A fruta foi adicionada com sucesso!", "Suchemia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnLimpar_Click(sender, e);
                }
                catch (Exception Erro)
                {
                    MessageBox.Show("Erro ==> " + Erro.Message, "Suchemia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (Categoria == "-1")
            {
                MessageBox.Show("Selecione uma categoria!", "Suchemia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PesoM == "")
            {
                MessageBox.Show("Preencha o Peso Médio!", "Suchemia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        public void NutrienteFruta(double qtdNutri, string nomeNutri)
        {
            try
            {
                if (!objDados.IsClosed) { objDados.Close(); }
                string strSql = "Insert into Nutriente_Fruta (id_nutrientes, id_fruta, qtdnutriente_fruta) values (";
                strSql += "" + getIdNutriente(nomeNutri) + ",";
                strSql += "" + getIdFruta() + ",";
                strSql += "" + qtdNutri + ")";

                objComando.Connection = objConexao;
                objComando.CommandText = strSql;
                objComando.ExecuteNonQuery();
                if (!objDados.IsClosed) { objDados.Close(); }
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "Suchemia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public double getIdFruta()
        {
            double retorno = 0;
            try
            {
                string strSql = "select * from fruta where nome_fruta = '" + txtNome.Text + "';";
                objComando.Connection = objConexao;
                objComando.CommandText = strSql;
                objDados = objComando.ExecuteReader();
                if (!objDados.Read())
                {
                    MessageBox.Show("Essa fruta não existe!!!", "Suchemia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    objDados.Read();
                    retorno = double.Parse(objDados["id_fruta"].ToString());
                }
                if (!objDados.IsClosed) { objDados.Close(); }
                return retorno;
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (retorno);
            }
        }

        public double getIdNutriente(string NomeNutri)
        {
            double retorno = 0;
            try
            {
                string strSql = "select * from nutrientes where nome_nutriente = '" + NomeNutri + "';";
                objComando.Connection = objConexao;
                objComando.CommandText = strSql;
                objDados = objComando.ExecuteReader();
                if (!objDados.Read())
                {
                    MessageBox.Show("Esse nutriente não existe!!!", "Suchemia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    objDados.Read();
                    retorno = double.Parse(objDados["id_nutrientes"].ToString());
                }
                if (!objDados.IsClosed) { objDados.Close(); }
                return retorno;
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "Suchemia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (retorno);
            }
        }

        private void TeclaEnter(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                AdicionarFruta(sender, e);
            }
        }
        
        public DataTable LoadFruta()
        {
            string tableDelim = ";";
            DataTable csvData = new DataTable("Fruta");
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser("E://CSV//Taco.csv"))
                {
                    csvReader.SetDelimiters(new string[]
                    {
                    tableDelim
                    });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == string.Empty)
                            {
                                fieldData[i] = string.Empty; //fieldData[i] = null
                            }
                            //Skip rows that have any csv header information or blank rows in them
                            if (fieldData[0].Contains("Disclaimer") || string.IsNullOrEmpty(fieldData[0]))
                            {
                                continue;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ==>" + ex.Message);
            }
            return csvData;
        }
    }
}

