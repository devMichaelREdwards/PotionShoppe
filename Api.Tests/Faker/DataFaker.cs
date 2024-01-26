using Api.Models;

namespace Faker;

public static class DataFaker
{
    public static List<EmployeeStatus> FakeEmployeeStatuses()
    {
        List<EmployeeStatus> statuses = [];
        for (int i = 1; i <= 10; i++)
        {
            statuses.Add(new()
            {
                EmployeeStatusId = i,
                Title = $"Status {i}"
            });
        }
        return statuses;
    }

    public static List<EmployeePosition> FakeEmployeePositions()
    {
        List<EmployeePosition> positions = [];
        for (int i = 1; i <= 10; i++)
        {
            positions.Add(new()
            {
                EmployeePositionId = i,
                Title = $"Position {i}"
            });
        }
        return positions;
    }

    public static List<Employee> FakeEmployees()
    {
        EmployeePosition fakePosition = new() { EmployeePositionId = 1, Title = "FAKE" };
        EmployeeStatus fakeStatus = new() { EmployeeStatusId = 1, Title = "Fake" };
        List<Employee> employees = [];
        for (int i = 1; i <= 10; i++)
        {
            employees.Add(
                new()
                {
                    EmployeeId = i,
                    Username = $"Username{i}",
                    Password = $"Password{i}",
                    Name = $"Name{i}",
                    DateHired = DateOnly.FromDateTime(DateTime.Now),
                    DateTerminated = DateOnly.FromDateTime(DateTime.Now),
                    EmployeeStatus = fakeStatus,
                    EmployeePosition = fakePosition
                }
            );
        }

        return employees;
    }

    public static List<Customer> FakeCustomers()
    {
        CustomerStatus fakeStatus = new() { CustomerStatusId = 1, Title = "Fake" };
        List<Customer> customers = [];
        for (int i = 1; i <= 10; i++)
        {
            customers.Add(
                new()
                {
                    CustomerId = i,
                    Username = $"Username{i}",
                    Password = $"Password{i}",
                    Name = $"Name{i}",
                    CustomerStatus = fakeStatus
                }
            );
        }

        return customers;
    }

    public static List<Effect> FakeEffects()
    {
        List<Effect> effects = [];
        for (int i = 1; i <= 10; i++)
        {
            effects.Add(new()
            {
                EffectId = i,
                Duration = i * 10,
                Description = $"Effect {i}"
            });
        }
        return effects;
    }

    public static List<OrderStatus> FakeOrderStatuses()
    {
        List<OrderStatus> effects = [];
        for (int i = 1; i <= 10; i++)
        {
            effects.Add(new()
            {
                OrderStatusId = i,
                Title = $"OrderS Status {i}"
            });
        }
        return effects;
    }

    public static List<CustomerStatus> FakeCustomerStatuses()
    {
        List<CustomerStatus> statuses = [];
        for (int i = 1; i <= 10; i++)
        {
            statuses.Add(new()
            {
                CustomerStatusId = i,
                Title = $"Status {i}"
            });
        }
        return statuses;
    }

    public static List<Ingredient> FakeIngredients()
    {
        Effect fakeEffect = new() { EffectId = 1, Description = "Fake", Duration = 60, Value = 40 };
        List<Ingredient> ingredients = [];
        for (int i = 1; i <= 10; i++)
        {
            ingredients.Add(
                new()
                {
                    IngredientId = i,
                    Name = $"Ingredient {i}",
                    Description = $"Ingredient {i}",
                    Price = i * 10,
                    Cost = i * 5,
                    CurrentStock = i,
                    Image = $"Image-{i}",
                    Effect = fakeEffect
                }
            );
        }

        return ingredients;
    }

    public static List<Potion> FakePotions()
    {
        List<Potion> potions = [];
        for (int i = 1; i <= 10; i++)
        {
            potions.Add(
                new()
                {
                    PotionId = i,
                    Name = $"Ingredient {i}",
                    Description = $"Ingredient {i}",
                    Price = i * 10,
                    Cost = i * 5,
                    CurrentStock = i,
                    Image = $"Image-{i}"
                }
            );
        }

        return potions;
    }

    public static List<Order> FakeOrders()
    {
        CustomerStatus fakeStatus = new() { CustomerStatusId = 1, Title = "Fake" };
        Customer fakeCustomer = new()
        {
            CustomerId = 1,
            Username = $"Username{1}",
            Password = $"Password{1}",
            Name = $"Name{1}",
            CustomerStatus = fakeStatus
        };
        List<Order> orders = [];
        for (int i = 1; i <= 10; i++)
        {
            orders.Add(
                new()
                {
                    OrderId = i,
                    OrderNumber = $"Order {i}",
                    CustomerId = fakeCustomer.CustomerId,
                    OrderStatusId = 1,
                    Total = i * 10,
                    Customer = fakeCustomer
                }
            );
        }

        return orders;
    }

    public static List<Receipt> FakeReceipts()
    {
        EmployeePosition fakePosition = new() { EmployeePositionId = 1, Title = "FAKE" };
        EmployeeStatus fakeStatus = new() { EmployeeStatusId = 1, Title = "Fake" };
        Employee fakeEmployee = new()
        {
            EmployeeId = 1,
            Username = $"Username{1}",
            Password = $"Password{1}",
            Name = $"Name{1}",
            DateHired = DateOnly.FromDateTime(DateTime.Now),
            DateTerminated = DateOnly.FromDateTime(DateTime.Now),
            EmployeeStatus = fakeStatus,
            EmployeePosition = fakePosition
        };
        Order fakeOrder = new()
        {
            OrderId = 1,
            OrderNumber = $"Order {1}",
            CustomerId = 1,
            OrderStatusId = 1,
            Total = 10
        };
        List<Receipt> receipts = [];
        for (int i = 1; i <= 10; i++)
        {
            receipts.Add(
                new()
                {
                    ReceiptId = i,
                    ReceiptNumber = $"Receipt {i}",
                    EmployeeId = 1,
                    OrderId = fakeOrder.OrderId,
                    Order = fakeOrder,
                    Employee = fakeEmployee
                }
            );
        }

        return receipts;
    }

    public static List<PotionEffect> FakePotionEffects()
    {
        List<PotionEffect> potionEffects = new();
        Potion fakePotion = new()
        {
            PotionId = 1,
            Name = $"Ingredient {1}",
            Description = $"Ingredient {1}",
            Price = 1 * 10,
            Cost = 1 * 5,
            CurrentStock = 1,
            Image = $"Image-{1}"
        };
        Effect[] fakeEffects = [
            new(){ EffectId = 1, Description = "Fake", Duration = 60, Value = 40 },
            new(){ EffectId = 2, Description = "Fake2", Duration = 60, Value = 40 },
            new(){ EffectId = 3, Description = "Fake3", Duration = 60, Value = 40 }
        ];

        for (int i = 0; i < 3; i++)
        {
            potionEffects.Add(
                new()
                {
                    PotionEffectId = i,
                    PotionId = fakePotion.PotionId,
                    EffectId = fakeEffects[i].EffectId,
                    Potion = fakePotion,
                    Effect = fakeEffects[i]
                }
            );
        }

        return potionEffects;
    }

    public static List<OrderIngredient> FakeOrderIngredients()
    {
        Effect fakeEffect = new() { EffectId = 1, Description = "Fake", Duration = 60, Value = 40 };
        Ingredient fakeIngredient = new()
        {
            IngredientId = 1,
            Name = $"Ingredient {1}",
            Description = $"Ingredient {1}",
            Price = 10,
            Cost = 5,
            CurrentStock = 1,
            Image = $"Image-{1}",
            Effect = fakeEffect
        };

        CustomerStatus fakeStatus = new() { CustomerStatusId = 1, Title = "Fake" };
        Customer fakeCustomer = new()
        {
            CustomerId = 1,
            Username = $"Username{1}",
            Password = $"Password{1}",
            Name = $"Name{1}",
            CustomerStatus = fakeStatus
        };
        Order fakeOrder = new()
        {
            OrderId = 1,
            OrderNumber = $"Order {1}",
            CustomerId = fakeCustomer.CustomerId,
            OrderStatusId = 1,
            Total = 10,
            Customer = fakeCustomer
        };

        List<OrderIngredient> orderIngredients = [];
        for (int i = 1; i <= 10; i++)
        {
            orderIngredients.Add(
                new()
                {
                    OrderIngredientId = i,
                    OrderId = fakeOrder.OrderId,
                    IngredientId = fakeIngredient.IngredientId,
                    Order = fakeOrder,
                    Ingredient = fakeIngredient
                }
            );
        }

        return orderIngredients;
    }

    public static List<OrderPotion> FakeOrderPotions()
    {
        Potion fakePotion = new()
        {
            PotionId = 1,
            Name = $"Ingredient {1}",
            Description = $"Ingredient {1}",
            Price = 1 * 10,
            Cost = 1 * 5,
            CurrentStock = 1,
            Image = $"Image-{1}"
        };

        CustomerStatus fakeStatus = new() { CustomerStatusId = 1, Title = "Fake" };
        Customer fakeCustomer = new()
        {
            CustomerId = 1,
            Username = $"Username{1}",
            Password = $"Password{1}",
            Name = $"Name{1}",
            CustomerStatus = fakeStatus
        };
        Order fakeOrder = new()
        {
            OrderId = 1,
            OrderNumber = $"Order {1}",
            CustomerId = fakeCustomer.CustomerId,
            OrderStatusId = 1,
            Total = 10,
            Customer = fakeCustomer
        };

        List<OrderPotion> orderPotions = [];
        for (int i = 1; i <= 10; i++)
        {
            orderPotions.Add(
                new()
                {
                    OrderPotionId = i,
                    OrderId = fakeOrder.OrderId,
                    PotionId = fakePotion.PotionId,
                    Order = fakeOrder,
                    Potion = fakePotion
                }
            );
        }

        return orderPotions;
    }
}
