
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Soccer",
        Price = 5.99m,
        ProductTypeId = 1,

    },
     new Product()
    {
        Name = "Footbal",
        Price = 1.99m,
        ProductTypeId = 2,

    },
     new Product()
    {
        Name = "Basketball",
        Price = 4.99m,
        ProductTypeId = 3,

    },
     new Product()
    {
        Name = "Baseball",
        Price = 3.99m,
        ProductTypeId = 4,

    },
     new Product()
    {
        Name = "Dumbbell",
        Price = 2.99m,
        ProductTypeId = 5,

    },

};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productype = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Brass",
        ID = 11,
    },
    new ProductType()
    {
        Title = "Poem",
        ID = 12,
    }
};

//put your greeting here
//put your greeting here
string greeting = @"Welcome to Brass & Poem 
Nubmer 1 Shop in TN";
Console.WriteLine(greeting);
//implement your loop here
DisplayMenu();

void DisplayMenu()
{
    string choice = null;
    while (choice != "5")
    {
        Console.WriteLine(@"Choose an option:
   1. Display all products
   2. Delete a product
   3. Add a new product
   4. Update product properties
   5. Exit");
        void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Product product = products[i];
                ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
                Console.WriteLine($"{i + 1}. {product.Name}, Product type {productType.Id}");
            }
        }

        void DeleteProduct(List<Product> products, List<ProductType> productTypes)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Product product = products[i];
                ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
                Console.WriteLine($"{i + 1}. {product.Name}, Product type {productType.Id}");
            }
            int response = int.Parse(Console.ReadLine().Trim());
            if (response >= 1 && response <= products.Count)
            {
                products.RemoveAt(response - 1);
                Console.WriteLine("Product removed successfully");
            }
        }

        void AddProduct(List<Product> products, List<ProductType> productTypes)
        {
            Console.WriteLine("Enter the product name: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter the product price: ");
            decimal Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Choose a product type: 1. Brass, 2. Poem");
            int Id = int.Parse(Console.ReadLine());

            Product newProduct = new Product
            {
                Name = Name,
                Price = Price,
                ProductTypeId = Id,
            };
            products.Add(newProduct);
        }
        void UpdateProduct(List<Product> products, List<ProductType> productTypes)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Product product = products[i];
                ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
                Console.WriteLine($"{i + 1}. {product.Name}, Product type {productType.Id}");
            }
            Console.WriteLine("Which product would you like to update?");

            int userChoice = int.Parse(Console.ReadLine().Trim());
            int productToUpdate = userChoice - 1;

            Product selectedProduct = products[productToUpdate];
            Console.WriteLine($"You have chosen {selectedProduct.Name}. It costs {selectedProduct.Price} dollars and is of product type {selectedProduct.ProductTypeId}");
            Console.WriteLine("What should the new product name be? ");
            string response1 = Console.ReadLine();
            Console.WriteLine("What should the updated price be? ");
            string response2 = Console.ReadLine();
            Console.WriteLine("What is the updated product type? ");
            string response3 = Console.ReadLine();

            if (!string.IsNullOrEmpty(response1))
            {
                selectedProduct.Name = response1;
            }
            else
            {
                selectedProduct.Name = selectedProduct.Name;
            }

            if (!string.IsNullOrEmpty(response2))
            {
                selectedProduct.Price = decimal.Parse(response2);

            }
            else
            {
                selectedProduct.Price = selectedProduct.Price;
            }

            if (!string.IsNullOrEmpty(response3))
            {
                int productTypeId = int.Parse(response3);
                selectedProduct.ProductTypeId = productTypeId;

            }
            else
            {
                selectedProduct.ProductTypeId = selectedProduct.ProductTypeId;
            }

            Product updatedProduct = new Product
            {
                Name = response1,
                Price = decimal.Parse(response2),
                ProductTypeId = int.Parse(response3),
            };

            selectedProduct = updatedProduct;

            Console.WriteLine("Product updated successfully!");
        }
