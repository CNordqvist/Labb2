
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Labb2;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

Menu Menu = new Menu();

#region Connection
var hostname = "localhost";
var port = 27017;
var databaseName = "TheShop";
var connectionString = $"mongodb://{hostname}:{port}";

var client = new MongoClient(connectionString);
var database = client.GetDatabase(databaseName);

#endregion


#region collections

var userCollection = database.GetCollection<User>("users",
    new MongoCollectionSettings() { AssignIdOnInsert = true });

var productCollection = database.GetCollection<Products>("products",
    new MongoCollectionSettings() { AssignIdOnInsert = true });

var shopCollection = database.GetCollection<Shops>("shops",
    new MongoCollectionSettings() { AssignIdOnInsert = true });


#endregion

#region FillBaseData
////// users
// Lista
var userList = new List<User>();
User knatte = new() { Name = "Knatte", Password = "123", Tier = 'G' };
userList.Add(knatte);
User fnatte = new() { Name = "Fnatte", Password = "321", Tier = 'S' };
userList.Add(fnatte);
User tjatte = new() { Name = "Tjatte", Password = "213", Tier = 'B' };
userList.Add(tjatte);

//kollar om databasen redan har användarna, annars lägger dom in dom.
var allUsers = userCollection.Find(_ => true).ToList();

var userName = new List<string>();
foreach (var User in allUsers)
{
    userName.Add(User.Name);
}
foreach (var User in userList)
{
    
    if (!userName.Contains(User.Name))
    {
        userCollection.InsertOne(User);
    }
}

//////Products
//lägger till alla basproducter i en lista
var productList = new List<Products>();
Products gurka = new() { Name = "Cucumber", Price = 40, Type = "Food" };
productList.Add(gurka);
Products tomat = new() { Name = "Tomato", Price = 30, Type = "Food" };
productList.Add(tomat);
Products sallad = new() { Name = "Lettuce", Price = 25, Type = "Food" };
productList.Add(sallad);
Products nails = new() { Name = "Box of nails", Price = 50, Type = "Hardware" };
productList.Add(nails);
Products saw = new() { Name = "Saw", Price = 75, Type = "Hardware" };
productList.Add(saw);
Products hammer = new() { Name = "Hammer", Price = 45, Type = "Hardware" };
productList.Add(hammer);
Products hat = new() { Name = "Hat", Price = 100, Type = "Clothing" };
productList.Add(hat);
Products shirt = new() { Name = "Ironic Programming T-Shirt", Price = 125, Type = "Clothing" };
productList.Add(shirt);
Products pants = new Products() { Name = "Pants", Price = 150, Type = "Clothing" };
productList.Add(pants);

//kollar om databasen redan har sakerna, annars lägger dom in dom.
var allProducts = productCollection.Find(_ => true).ToList();
var prodcutName = new List<string>();

foreach (var Products in allProducts)
{
    prodcutName.Add(Products.Name);
}
foreach (var Products in productList)
{
    if (!prodcutName.Contains(Products.Name))
    {
        productCollection.InsertOne(Products);
    }
}

//////shops
//lägger till i en lista
var shopList = new List<Shops>();
Shops grocery = new Shops() { ShopName = "Grocery", Type = "Food"};
shopList.Add(grocery);
Shops hardware = new Shops() { ShopName = "HardWare", Type = "Hardware" };
shopList.Add(hardware);
Shops clothing = new Shops() { ShopName = "Clothing", Type = "Clothing" };
shopList.Add(clothing);

var allShops = shopCollection.Find(_ => true).ToList();
var shopNames = new List<string>();

foreach (var Shops in allShops)
{
    shopNames.Add(Shops.ShopName);
}

foreach (var Shops in shopList)
{
    if (!shopNames.Contains(Shops.ShopName))
    {
        shopCollection.InsertOne(Shops);
    }
}


List<Products> foodList = new();
List<Products> hardList = new();
List<Products> clothList = new();

foreach (var product in allProducts)
{
    if (product.Type == "Food")
    {
        foodList.Add(product);
    } 
    else if (product.Type == "Hardware")
    {
        hardList.Add(product);
    } 
    else if (product.Type == "Clothing")
    {
        clothList.Add(product);
    }
}

foreach (var shops in allShops)
{
    if (shops.Type == "Food")
    {
        shops.Inventory = foodList;
    } 
    else if (shops.Type == "Hardware")
    {
        shops.Inventory = hardList;
    }
    else if (shops.Type == "Clothing")
    {
        shops.Inventory = clothList;
    }
}


#endregion


Menu.IntroScreen(allUsers, allShops);

#region records

public record User
{
    [BsonId] public ObjectId Id { get; set; }
    [BsonElement] public string Name { get; set; }
    [BsonElement] public string Password { get; set; }
    [BsonElement] public char Tier { get; set; }
    [BsonElement] public List<Products>? Cart { get; set; }
}

public record Products
{
    [BsonId] public ObjectId Id { get; set; }
    [BsonElement] public string Name { get; set; }
    [BsonElement] public double Price { get; set; }
    [BsonElement] public string Type { get; set; }
}

public record Shops
{
    [BsonId] public BsonObjectId Id { get; set; }
    [BsonElement] public string ShopName { get; set; }
    [BsonElement] public List<Products>? Inventory { get; set; }
    [BsonElement] public string Type { get; set; }
}



#endregion



