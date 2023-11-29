using System;
using System.Linq;
using System.Windows;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for SemiMain.xaml
    /// </summary>
    public partial class SemiMain : Window
    {
        private bool isAdmin;
        private bool isProductAdded = false;
        DbzDataContext DataB = new DbzDataContext();
        public SemiMain(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;

            DataB = new DbzDataContext(Properties.Settings.Default.Database_InventoryConnectionString);

            var products = DataB.Table_Products
                .Select(p => new
                {
                    p.Product_ID,
                    p.Product_Name,
                    p.Product_Details,
                    p.Product_SellingPrice,
                    p.Product_Cost
                    

                })
                .ToList();
            listprod.ItemsSource = products;

            
            var transaction = DataB.Table_Transactions
               .Select(c => new
               {
                   c.Transaction_ID,
                   c.Product_ID,
                   c.Product_Quantity,
                   c.User_ID,
                   c.Product_SellingPrice,
                   c.DateTime

               })
               .ToList();

            listtransaction.ItemsSource = transaction;


        }
        public void DisableEmployeeAccess()
        {
            if (!isAdmin)
            {
                // Disable functionality for employees here
                btn_UpdateProduct.IsEnabled = false;
                updateTransac.IsEnabled = false;
                btn_productAdd.IsEnabled = false;
                btn_transacAdd.IsEnabled = false;
                btn_clear1.IsEnabled = false;
                btn_clear2.IsEnabled = false;   
                
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text.Trim(); 

            // Search in products based on Product_Name
            var products = DataB.Table_Products
                .Where(p => p.Product_Name.Contains(searchText))
                .Select(p => new
                {
                    p.Product_ID,
                    p.Product_Name,
                    p.Product_Details,
                    p.Product_SellingPrice,
                    p.Product_Cost
                })
                .ToList();

            listprod.ItemsSource = products;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch2.Text.Trim(); 

            // Search in products based on User_ID
            var products = DataB.Table_Transactions
                .Where(c => c.User_ID.Contains(searchText))
                .Select(c => new
                {
                    c.Transaction_ID,
                    c.Product_ID,
                    c.Product_Quantity,
                    c.User_ID,
                    c.Product_SellingPrice,
                    c.DateTime
                })
                .ToList();

            listprod.ItemsSource = products;

            // Parse the searchText to check if it's convertible to a numeric value (like Product_ID or User_ID)
            bool isNumeric = int.TryParse(searchText, out int searchNumber);

            // Search in transactions based on Product_ID or other relevant fields containing the search text
            var transactions = DataB.Table_Transactions
                .Where(c =>
                    (isNumeric && c.Product_ID == searchNumber) || // Search by Product_ID (if it's a number)
                    c.User_ID.Contains(searchText) ||            // Search by User_ID (as string)
                    c.DateTime.ToString().Contains(searchText))  // Search by DateTime (as string)
                
                .Select(c => new
                {
                    c.Transaction_ID,
                    c.Product_ID,
                    c.Product_Quantity,
                    c.User_ID,
                    c.Product_SellingPrice,
                    c.DateTime
                })
                .ToList();

            listtransaction.ItemsSource = transactions;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(tbx_ID.Text.Trim());
            string productName = tbx_Name.Text.Trim();
            string productDetails = tbx_Details.Text.Trim();
            int sellingPrice = int.Parse(tbx_Cost.Text.Trim()); 
            int cost = int.Parse(tbx_Price.Text.Trim()); 

         
            Table_Product newProduct = new Table_Product
            {
                Product_ID = id,
                Product_Name = productName,
                Product_Details = productDetails,
                Product_SellingPrice = sellingPrice,
                Product_Cost = cost
                
            };

            // Add the new product to the database
            DataB.Table_Products.InsertOnSubmit(newProduct);
            DataB.SubmitChanges();

            // update the displayed products list after adding the new product
            var products = DataB.Table_Products
                .Select(p => new
                {
                    p.Product_ID,
                    p.Product_Name,
                    p.Product_Details,
                    p.Product_SellingPrice,
                    p.Product_Cost
                })
                .ToList();

            listprod.ItemsSource = products;
            isProductAdded = true;

            MessageBox.Show("Product added successfully!");


        }

        private void btn_transacAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!isProductAdded)
            {
                MessageBox.Show("Please add a product first!");
                return; // Prevent adding transactions until a product is added
            }

            isProductAdded = false; // Reset the flag after adding the transaction

            // Retrieve input values from TextBoxes or other UI elements
            int transactId = int.Parse(tbx_TransID.Text.Trim());
            int productId = int.Parse(tbx_TransProdID.Text.Trim()); 
            int quantity = int.Parse(tbx_TransQuantity.Text.Trim()); 
            string userId = tbx_TransUser.Text.Trim(); 
            int sellingPrice = int.Parse(tbx_TransSellPrice.Text.Trim());
            DateTime dateTime = DateTime.Now;

            Table_Transactions newTransaction = new Table_Transactions
            {
                Transaction_ID = transactId,
                Product_ID = productId,
                Product_Quantity = quantity,
                User_ID = userId,
                Product_SellingPrice = sellingPrice,
                DateTime = dateTime
             
            };

            // Add the new transaction to the database
            DataB.Table_Transactions.InsertOnSubmit(newTransaction);
            DataB.SubmitChanges();


            // update the displayed transactions list after adding the new transaction
            var transactions = DataB.Table_Transactions
                .Select(c => new
                {
                    c.Transaction_ID,
                    c.Product_ID,
                    c.Product_Quantity,
                    c.User_ID,
                    c.Product_SellingPrice,
                    c.DateTime
                })
                .ToList();

            listtransaction.ItemsSource = transactions;

            MessageBox.Show("Transaction added successfully!");
        }

        private void btn_UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            
            if (listprod.SelectedItem != null)
            {
                var selectedProduct = (dynamic)listprod.SelectedItem;


                int productId = selectedProduct.Product_ID;
                string productName = tbx_Name.Text.Trim();
                string productDetails = tbx_Details.Text.Trim();
                int sellingPrice = int.Parse(tbx_Cost.Text.Trim()); 
                int cost = int.Parse(tbx_Price.Text.Trim()); 

                var productToUpdate = DataB.Table_Products.FirstOrDefault(p => p.Product_ID == productId);

                if (productToUpdate != null)
                {
                    productToUpdate.Product_Name = productName;
                    productToUpdate.Product_Details = productDetails;
                    productToUpdate.Product_SellingPrice = sellingPrice;
                    productToUpdate.Product_Cost = cost;

                    DataB.SubmitChanges();

              
                    var products = DataB.Table_Products
                        .Select(p => new
                        {
                            p.Product_ID,
                            p.Product_Name,
                            p.Product_Details,
                            p.Product_SellingPrice,
                            p.Product_Cost
                        })
                        .ToList();

                    listprod.ItemsSource = products;

                    MessageBox.Show("Product updated successfully!");
                }
                else
                {
                    MessageBox.Show("Product not found!");
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.");
            }

        }

        private void btn_UpdateTransaction(object sender, RoutedEventArgs e)
        {
            if (listtransaction.SelectedItem != null)
            {
                var selectedTransaction = (dynamic)listtransaction.SelectedItem;

                int transactionId = selectedTransaction.Transaction_ID;
                int productId = int.Parse(tbx_TransProdID.Text.Trim());
                int quantity = int.Parse(tbx_TransQuantity.Text.Trim());
                string userId = tbx_TransUser.Text.Trim();
                int sellingPrice = int.Parse(tbx_TransSellPrice.Text.Trim()); 

                var transactionToUpdate = DataB.Table_Transactions.FirstOrDefault(c => c.Transaction_ID == transactionId);

                if (transactionToUpdate != null)
                {
                    transactionToUpdate.Product_ID = productId;
                    transactionToUpdate.Product_Quantity = quantity;
                    transactionToUpdate.User_ID = userId;
                    transactionToUpdate.Product_SellingPrice = sellingPrice;

                    DataB.SubmitChanges();

  
                    var transactions = DataB.Table_Transactions
                        .Select(c => new
                        {
                            c.Transaction_ID,
                            c.Product_ID,
                            c.Product_Quantity,
                            c.User_ID,
                            c.Product_SellingPrice,
                            c.DateTime
                        })
                        .ToList();

                    listtransaction.ItemsSource = transactions;

                    MessageBox.Show("Transaction updated successfully!");
                }
                else
                {
                    MessageBox.Show("Transaction not found!");
                }
            }
            else
            {
                MessageBox.Show("Please select a transaction to update.");
            }
        }

        private void listprod_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listprod.SelectedItem != null)
            {
                var selectedProduct = (dynamic)listprod.SelectedItem;
                int productId = selectedProduct.Product_ID;

                // Retrieve product details based on the selected product
                var selectedProductDetails = DataB.Table_Products
                    .FirstOrDefault(p => p.Product_ID == productId);

                if (selectedProductDetails != null)
                {
                    // Display product details in the product TextBoxes
                    tbx_ID.Text = selectedProductDetails.Product_ID.ToString();
                    tbx_Name.Text = selectedProductDetails.Product_Name;
                    tbx_Details.Text = selectedProductDetails.Product_Details;
                    tbx_Cost.Text = selectedProductDetails.Product_SellingPrice.ToString();
                    tbx_Price.Text = selectedProductDetails.Product_Cost.ToString();
                }

                // Retrieve transaction details related to the selected product
                var transactionsRelatedToProduct = DataB.Table_Transactions
                    .Where(t => t.Product_ID == productId)
                    .Select(t => new
                    {
                        t.Transaction_ID,
                        t.Product_ID,
                        t.Product_Quantity,
                        t.User_ID,
                        t.Product_SellingPrice,
                        t.DateTime
                    })
                    .ToList();

                // Update the transaction ListView with the details related to the selected product
                listtransaction.ItemsSource = transactionsRelatedToProduct;

                // Display the details of the first transaction related to the product in the transaction TextBoxes
                if (transactionsRelatedToProduct.Any())
                {
                    var firstTransaction = transactionsRelatedToProduct.First();
                    tbx_TransID.Text = firstTransaction.Transaction_ID.ToString();
                    tbx_TransProdID.Text = firstTransaction.Product_ID.ToString();
                    tbx_TransQuantity.Text = firstTransaction.Product_Quantity.ToString();
                    tbx_TransUser.Text = firstTransaction.User_ID;
                    tbx_TransSellPrice.Text = firstTransaction.Product_SellingPrice.ToString();
                }
                else
                {
                    // If there are no transactions related to the selected product, clear the transaction TextBoxes
                    tbx_TransID.Text = string.Empty;
                    tbx_TransProdID.Text = string.Empty;
                    tbx_TransQuantity.Text = string.Empty;
                    tbx_TransUser.Text = string.Empty;
                    tbx_TransSellPrice.Text = string.Empty;
                }
            }
        }
        private void listtransaction_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listtransaction.SelectedItem != null)
            {
                var selectedTransaction = (dynamic)listtransaction.SelectedItem;

                // Display transaction details in the transaction TextBoxes
                tbx_TransID.Text = selectedTransaction.Transaction_ID.ToString();
                tbx_TransProdID.Text = selectedTransaction.Product_ID.ToString();
                tbx_TransQuantity.Text = selectedTransaction.Product_Quantity.ToString();
                tbx_TransUser.Text = selectedTransaction.User_ID;
                tbx_TransSellPrice.Text = selectedTransaction.Product_SellingPrice.ToString();
            }
            else
            {
                // If no transaction is selected, clear the transaction TextBoxes
                tbx_TransID.Text = string.Empty;
                tbx_TransProdID.Text = string.Empty;
                tbx_TransQuantity.Text = string.Empty;
                tbx_TransUser.Text = string.Empty;
                tbx_TransSellPrice.Text = string.Empty;
            }
        }

        private void txtSearch2_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            tbx_ID.Text = string.Empty;
            tbx_Name.Text = string.Empty;
            tbx_Details.Text = string.Empty;
            tbx_Cost.Text = string.Empty;
            tbx_Price.Text = string.Empty;
              
            }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            tbx_TransID.Text = string.Empty;
            tbx_TransProdID.Text = string.Empty;
            tbx_TransQuantity.Text = string.Empty;
            tbx_TransUser.Text = string.Empty;
            tbx_TransSellPrice.Text = string.Empty;
        }
    }
}
   
