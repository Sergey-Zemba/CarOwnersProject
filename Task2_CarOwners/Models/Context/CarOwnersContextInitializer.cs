using System.Data.Entity;

namespace Task2_CarOwners.Models.Context
{
    public class CarOwnersContextInitializer : CreateDatabaseIfNotExists<CarOwnersContext>
    {
    }
}