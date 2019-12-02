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
using CSGO;

namespace GunGame
{
    public partial class Form1 : Form
    {      

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Assembly asm = Assembly.GetExecutingAssembly();

            Type[] types = asm.GetTypes();

            foreach (Type type in types) {

                if (type.BaseType == typeof(Silah)) {

                    Silah silah = (Silah)Activator.CreateInstance(type);
                    silah.doesHaveAttributeHandler += Silah_doesHaveAttributeHandler;
                   
                    cb1.Items.Add(silah);
                }
            }            
        }

        private void Silah_doesHaveAttributeHandler(Silah silah)
        {
            MessageBox.Show(silah.GetType().Name + " class has no attribute!");
                
        }

        private void btnFier_Click(object sender, EventArgs e)
        {
            string text;
            
            if (cb1.SelectedItem.GetType().GetMethod("AtesEt") != null)
            {

                 text = cb1.SelectedItem.GetType().GetMethod("AtesEt").Invoke(cb1.SelectedItem, null).ToString();
            }
            else {

                 text = cb1.SelectedItem.GetType().GetMethod("Savur").Invoke(cb1.SelectedItem, null).ToString();
            }

           

            txtTitle.Text = text;
            
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
