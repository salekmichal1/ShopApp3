using Microsoft.EntityFrameworkCore;

namespace ShopApp3.Models
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Invoice>().HasData(
            new Invoice() { Id = 1, InvoiceName = "1", DateOfInvoice = DateTime.Now }
            );
            modelBuilder.Entity<Employee>().HasData(
            new Employee() { Id = 1, EmployeeName = "Michal", EmployeeSurname = "Salek", Mail = "abc@abc.com", Login ="micsal", Password = "zaq1@WSX" }
            );

        }
    }
}
