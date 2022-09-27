namespace WisdomPetMedicine.Models;

public record Sale(int ClientId, 
    int ProductId, 
    string ProductName, 
    decimal ProductPrice, 
    int Quantity, decimal Amount);