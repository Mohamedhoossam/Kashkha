using Kashkha.DAL;
using System;

public class ShopOwnerDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ShopName { get; set; }
    public Address Address { get; set; }
    public string ProfilePicture { get; set; }
   
}