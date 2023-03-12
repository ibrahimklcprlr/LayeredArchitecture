// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete;
ProductTest();

//CategoryTest();

static void ProductTest()
{
    ProductManager pro = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));
    //foreach (var item in pro.GetProductDetails())
    //{
    //    Console.WriteLine(item.ProductName + "/"+ item.CategoryName);
    //}
}

static void CategoryTest()
{
    CategoryManager cat = new CategoryManager(new EfCategoryDal());
    foreach (var item in cat.GetAll().Data)
    {
        Console.WriteLine(item.CategoryName);
    }
}