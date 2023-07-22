
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
        ProductTypeId = 1,

    },
     new Product()
    {
        Name = "Baseball",
        Price = 3.99m,
        ProductTypeId = 2,

    },
     new Product()
    {
        Name = "Dumbbell",
        Price = 2.99m,
        ProductTypeId = 1,

    },

};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productype = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Brass",
        ID = 1,
    },
    new ProductType()
    {
        Title = "Poem",
        ID = 2,
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
        choice = Console.ReadLine();
        if (choice == "1")
        {
            DisplayAllProducts(products, productype);
        }
        else if (choice == "2")
        {
            DeleteProduct(products, productype);

        }
        else if (choice == "3")
        {
            AddProduct(products, productype);
        }
        else if (choice == "4")
        {
            UpdateProduct(products, productype);
        }
        else if (choice == "5")
        {
            Console.WriteLine("GoodBye!");
        }
        else if (choice != "1" || choice != "2" || choice != "3" || choice != "4" || choice != "5")
        {
            Console.WriteLine("Please choose any menu item!");
        }
    }
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("List of Products: ");



    for (int i = 0; i < products.Count; i++)
    {
       var query = from pt in productTypes
                    where products[i].ProductTypeId == pt.ID
                    select new { pt.Title };
        // var ProductType = productTypes.Where(x => x.ID == products[i].ProductTypeId).FirstOrDefault();
        var productType = query.FirstOrDefault();
       
        Console.WriteLine($"{i + 1} . {products[i].Name} that cost {products[i].Price} that is a type {productType.Title}");

    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("Select a product you wat to delete");

    int removeProduct = Convert.ToInt32(Console.ReadLine());

    if (removeProduct == 0)
    { Console.WriteLine("Please select any product between 1-5"); }
    else
    {
        products.RemoveAt(removeProduct - 1);
    }

}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter a products name ");
    string Name = Console.ReadLine();
    Console.WriteLine("Enter the product's price");
    decimal Price = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Select a product's type");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }
    int ProductTypeid = int.Parse(Console.ReadLine());
    Product newProduct = new Product
    {
        Name = Name,
        Price = Price,
        ProductTypeId = ProductTypeid
    };
    products.Add(newProduct);
    Console.WriteLine("Thank you for adding a product.Product has been added");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        var query = from pt in productTypes
                    where products[i].ProductTypeId == pt.ID
                    select new { pt.Title };
        var productType = query.First();
        //var Value= productTypes.First(p=> p.Id == products[i].ProductTypeId);
        Console.WriteLine($"{i + 1} . {products[i].Name}");

    }
    Console.WriteLine("Select the product you want to update :");
    int updateProduct = int.Parse(Console.ReadLine());
    Product selectedProduct = products[updateProduct - 1];
    Console.WriteLine($"You Selected {selectedProduct.Name} that costs {selectedProduct.Price} and it's Product type id is {selectedProduct.ProductTypeId}");
    Console.WriteLine("Update the product's name ");
    string Name = Console.ReadLine();
    if (string.IsNullOrEmpty(Name))
    {
        products[updateProduct - 1].Name = products[updateProduct - 1].Name;
    }
    else
    {
        products[updateProduct - 1].Name = Name;
    }
    Console.WriteLine("Update the product's price");
    try
    {
        decimal Price = decimal.Parse(Console.ReadLine());
        products[updateProduct - 1].Price = Price;
    }
    catch (FormatException)
    {
        products[updateProduct - 1].Price = products[updateProduct - 1].Price;
    }
    Console.WriteLine("Update the product's type");
    try
    {
        int ProductTypeId = int.Parse(Console.ReadLine());
        products[updateProduct - 1].ProductTypeId = ProductTypeId;
    }
    catch (FormatException)
    {
        products[updateProduct - 1].ProductTypeId = products[updateProduct - 1].ProductTypeId;
    }


    Console.WriteLine("Here is your updated list");
    DisplayAllProducts(products, productTypes);


}