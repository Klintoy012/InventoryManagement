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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isAdmin = false;

        DbzDataContext DataB = new DbzDataContext();


        public MainWindow()
        {
            InitializeComponent();


            DataB = new DbzDataContext(Properties.Settings.Default.Database_InventoryConnectionString);

        }

        void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            bool isValidUser = false;

            do
            {
                bool isValidEmployee = IsValidEmployee(username, password);
                bool isValidAdmin = IsValidAdmin(username, password);

                if (isValidEmployee)
                {
                    MessageBox.Show("Employee login successful!");
                    this.Hide();
                    SemiMain secondWindow = new SemiMain(isAdmin);
                    secondWindow.DisableEmployeeAccess(); // Disable employee access in SemiMain
                    secondWindow.Show(); // Show the SecondWindow for employees
                    isValidUser = true;
                }
                else if (isValidAdmin)
                {
                    MessageBox.Show("Admin login successful!");
                    this.Hide();
                    SemiMain secondWindow = new SemiMain(isAdmin);
                    secondWindow.Show(); // Show the SecondWindow
                    isValidUser = true;
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                    // Clear the text fields for retrying username and password
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    isValidUser = false;

                    // Show the login window again
                    this.Show();
                    this.Activate();
                    return;
                }
            } while (!isValidUser);
        }

        bool IsValidEmployee(string username, string password)
        {
            using (var context = new DbzDataContext(Properties.Settings.Default.Database_InventoryConnectionString))
            {
                var employeeUser = context.Table_Users.FirstOrDefault(u => u.User_ID == username && u.Password == password && u.Role != "Admin");
                return employeeUser != null;
            }
        }

        bool IsValidAdmin(string username, string password)
        {
            using (var context = new DbzDataContext(Properties.Settings.Default.Database_InventoryConnectionString))
            {
                var adminUser = context.Table_Users.FirstOrDefault(u => u.User_ID == username && u.Password == password && u.Role == "Admin");
                return adminUser != null;
            }
        }
    }
}
