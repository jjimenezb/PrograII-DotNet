﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesarrolloWindows.CSharp
{
    public partial class FormularioEmpleados : Form
    {
        public FormularioEmpleados()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var empleados = NominaWeb.ObtenerEmpleados();

            MessageBox.Show($"Se encontraron: {empleados.Length} empleados");
        }
    }
}