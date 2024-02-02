using System.Security.Claims;
using Api.Data;
using Api.Models;
using AutoMapper;

namespace Api.Classes;

public class CustomerUser
{
    public required string UserName { get; set; }
    public required CustomerDto Customer { get; set; }
}
