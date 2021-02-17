using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace clsFrutas
{
    public class Fruta
    {
        private int id;
        private string nome;
        private string categoria;

        private string carbo;
        private string lipid;
        private string protein;

        private string vitA;
        private string vitB1;
        private string vitB2;
        private string vitB6;
        private string vitB12;
        private string vitC;
        private string vitD;
        private string vitE;
        private string vitF;

        private string calcium;
        private string sodium;
        private string cobre;
        private string manganes;
        private string zinc;
        private string iodo;
        private string fluor;
        private string fosforo;
        private string ferro;
        private string potassio;
        private string magnesio;


        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }


        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public string Carbo
        {
            get { return carbo; }
            set { carbo = value; }
        }

        public string Lipid
        {
            get { return lipid; }
            set { lipid = value; }
        }

        public string Protein
        {
            get { return protein; }
            set { protein = value; }
        }

        public string VitA
        {
            get { return vitA; }
            set { vitA = value; }
        }

        public string VitB1
        {
            get { return vitB1; }
            set { vitB1 = value; }
        }

        public string VitB2
        {
            get { return vitB2; }
            set { vitB2 = value; }
        }

        public string VitB6
        {
            get { return vitB6; }
            set { vitB6 = value; }
        }

        public string VitB12
        {
            get { return vitB12; }
            set { vitB12 = value; }
        }

        public string VitC
        {
            get { return vitC; }
            set { vitC = value; }
        }

        public string VitD
        {
            get { return vitD; }
            set { vitD = value; }
        }

        public string VitE
        {
            get { return vitE; }
            set { vitE = value; }
        }

        public string VitF
        {
            get { return vitF; }
            set { vitF = value; }
        }

        public string Calcium
        {
            get { return calcium; }
            set { calcium = value; }
        }

        public string Sodium
        {
            get { return sodium; }
            set { sodium = value; }
        }

        public string Cobre
        {
            get { return cobre; }
            set { cobre = value; }
        }

        public string Manganes
        {
            get { return manganes; }
            set { manganes = value; }
        }

        public string Zinc
        {
            get { return zinc; }
            set { zinc = value; }
        }

        public string Iodo
        {
            get { return iodo; }
            set { iodo = value; }
        }

        public string Fluor
        {
            get { return fluor; }
            set { fluor = value; }
        }

        public string Fosforo
        {
            get { return fosforo; }
            set { fosforo = value; }
        }

        public string Ferro
        {
            get { return ferro; }
            set { ferro = value; }
        }

        public string Potassio
        {
            get { return potassio; }
            set { potassio = value; }
        }

        public string Magnesio
        {
            get { return magnesio; }
            set { magnesio = value; }
        }



        //Aqui ficarão os métodos

        public static void AdicionarFruta(Fruta fruta)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter("Frutas.xml", null);
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement("frutas");
                writer.WriteStartElement("fruta");
                writer.WriteElementString("id", fruta.ID.ToString());
                writer.WriteElementString("nome", fruta.Nome);
                writer.WriteElementString("categoria", fruta.Categoria);
                writer.WriteElementString("carboidratos", fruta.Carbo);
                writer.WriteElementString("lipideos", fruta.Lipid);
                writer.WriteElementString("proteinas", fruta.Protein);
                writer.WriteElementString("vitamina_A", fruta.VitA);
                writer.WriteElementString("vitamina_B1", fruta.VitB1);
                writer.WriteElementString("vitamina_B2", fruta.VitB2);
                writer.WriteElementString("vitamina_B6", fruta.VitB6);
                writer.WriteElementString("vitamina_B12", fruta.VitB12);
                writer.WriteElementString("vitamina_C", fruta.VitC);
                writer.WriteElementString("vitamina_D", fruta.VitD);
                writer.WriteElementString("vitamina_E", fruta.VitE);
                writer.WriteElementString("vitamina_F", fruta.VitF);
                writer.WriteElementString("calcio", fruta.Calcium);
                writer.WriteElementString("sodio", fruta.Sodium);
                writer.WriteElementString("cobre", fruta.Cobre);
                writer.WriteElementString("manganes", fruta.Manganes);
                writer.WriteElementString("zinco", fruta.Zinc);
                writer.WriteElementString("iodo", fruta.Iodo);
                writer.WriteElementString("fluor", fruta.Fluor);
                writer.WriteElementString("fosforo", fruta.Fosforo);
                writer.WriteElementString("ferro", fruta.Ferro);
                writer.WriteElementString("potassio", fruta.Potassio);
                writer.WriteElementString("magnesio", fruta.Magnesio);
                writer.WriteEndElement();
                writer.WriteFullEndElement();
                writer.Close();
            }
            catch (Exception Erro)
            {
                
            }            
        }        
    }
}
