using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sem05
{
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=LAB1504-25\\SQLEXPRESS;Initial Catalog=Neptuno; User Id=userTaipe;Password=12345";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InsertarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("USP_InsertarEmpleados", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Asignar valores de los campos de texto a los parámetros del procedimiento almacenado
                    command.Parameters.AddWithValue("@IdEmpleado", int.Parse(txtIdEmpleado.Text));
                    command.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                    command.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    command.Parameters.AddWithValue("@Cargo", txtCargo.Text);
                    command.Parameters.AddWithValue("@Tratamiento", txtTratamiento.Text);
                    command.Parameters.AddWithValue("@FechaNacimiento", dpFechaNacimiento.SelectedDate);
                    command.Parameters.AddWithValue("@FechaContratacion", dpFechaContratacion.SelectedDate);
                    command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    command.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                    command.Parameters.AddWithValue("@Region", txtRegion.Text);
                    command.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                    command.Parameters.AddWithValue("@Pais", txtPais.Text);
                    command.Parameters.AddWithValue("@TelDomicilio", txtTelDomicilio.Text);
                    command.Parameters.AddWithValue("@Extension", txtExtension.Text);
                    command.Parameters.AddWithValue("@Notas", txtNotas.Text);
                    command.Parameters.AddWithValue("@Jefe", int.Parse(txtJefe.Text));
                    command.Parameters.AddWithValue("@SueldoBasico", decimal.Parse(txtSueldoBasico.Text));

                    command.ExecuteNonQuery();

                    MessageBox.Show("Empleado insertado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar empleado: " + ex.Message);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)


        {


            List<Empleado> empleados = new List<Empleado>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("USP_ListEmpleados", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("IdEmpleado"));
                        string apellidos = reader.GetString(reader.GetOrdinal("Apellidos"));
                        string nombre = reader.GetString(reader.GetOrdinal("Nombre"));
                        string cargo = reader.GetString(reader.GetOrdinal("Cargo"));
                        string tratamiento = reader.GetString(reader.GetOrdinal("Tratamiento"));

                        empleados.Add(new Empleado(id, apellidos, nombre, cargo, tratamiento));
                    }

                    reader.Close();
                }

                resultGrid.ItemsSource = empleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los empleados: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

  