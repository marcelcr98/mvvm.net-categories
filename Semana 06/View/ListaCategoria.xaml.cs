using Semana_06.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Business;
using Entity;
namespace Semana_06.View
{
    /// <summary>
    /// Lógica de interacción para ListaCategoria.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        ListaCategoriaViewModel viewModel;
        public ListaCategoria()
        {
            InitializeComponent();
            viewModel = new ListaCategoriaViewModel();
            this.DataContext = viewModel;

        }

        public void Cargar()
        {
            BCategoria BCategoria = null;
            try
            {
                BCategoria = new BCategoria();
                dgvCategoria.ItemsSource = BCategoria.Listar(0);

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error. Debe comunicarse con el Administrador");
            }
            finally
            {
                BCategoria = null;
            }
        }

        private void dgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ID;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (item == null) return;
            ID = Convert.ToInt32(item.IdCategoria);
            View.ManCategoria window =  new View.ManCategoria();
            window.ShowDialog();

        }
    }
}
