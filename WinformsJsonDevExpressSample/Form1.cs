using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformsJsonDevExpressSample.Models;

namespace WinformsJsonDevExpressSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            using (var cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync("https://jsonplaceholder.typicode.com/todos");

                var contenido = await respuesta.Content.ReadAsStringAsync();

                var datos = JsonConvert.DeserializeObject<IEnumerable<JsonPlaceholderModel>>(contenido);

                gridControl1.DataSource = datos;
            }
        }
    }
}
