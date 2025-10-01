using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionEscritorio
{
    public static class dataGridView
    {
        public static void formatoDgv(DataGridView pData)
        {
            // ===============================================
            // 1. Configuración de Filas y Celdas
            // ===============================================

            // Font para las filas (Celda por defecto)
            pData.RowsDefaultCellStyle.Font = new Font("Open Sans", 10f, FontStyle.Regular);

            // Color de fondo para las filas impares (Alternando el color)
            pData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Gris claro

            // Color de fondo para cuando se selecciona una fila
            pData.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            pData.DefaultCellStyle.SelectionForeColor = Color.White;

            // Ajuste automático de la altura de las filas
            // Esto es lo que se ve incompleto en la imagen.
            pData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // ===============================================
            // 2. Configuración de Columnas (Headers)
            // ===============================================

            // Font para las columnas (Headers)
            pData.ColumnHeadersDefaultCellStyle.Font = new Font("Lato", 12f, FontStyle.Bold);

            // Alineación del texto en los encabezados
            pData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Color de fondo y de texto del Header
            pData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 120, 215); // Azul Microsoft
            pData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Propiedades de la Cabecera
            pData.EnableHeadersVisualStyles = false; // Importante para poder aplicar los colores personalizados
            pData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; // Para que no se mueva
            pData.ColumnHeadersHeight = 40; // Altura fija de la cabecera

            // Ajuste automático del ancho de las columnas
            pData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ===============================================
            // 3. Comportamiento General del DGV
            // ===============================================

            // Quitar la columna extra (Header de fila izquierda)
            pData.RowHeadersVisible = false;

            // Quitar el borde feo
            pData.BorderStyle = BorderStyle.None;
            pData.BackgroundColor = pData.Parent.BackColor;

            // Solo permitir selección de filas completas
            pData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Las filas no se pueden agregar ni eliminar directamente por el usuario
            pData.AllowUserToAddRows = false;
            pData.AllowUserToDeleteRows = false;
            pData.ReadOnly = true; // Hacer que el DGV sea de solo lectura
        }
    }
}
