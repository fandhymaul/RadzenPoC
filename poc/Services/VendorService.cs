using poc.Models;
using System.Collections.Generic;
using System.Linq;

namespace poc.Services
{
    public class VendorService
    {
        private readonly List<Vendor> _vendors = new();
        private int _nextId = 1;

        public VendorService()
        {
            SeedData();
        }

        public IList<Vendor> GetVendors()
        {
            return _vendors;
        }

        public Vendor? GetVendor(int id) => _vendors.FirstOrDefault(v => v.Id == id);

        public void AddVendor(Vendor vendor)
        {
            vendor.Id = _nextId++;
            vendor.VendorCode = string.IsNullOrWhiteSpace(vendor.VendorCode)
                ? $"VND-{DateTime.UtcNow.Year}-{vendor.Id:000}"
                : vendor.VendorCode;
            vendor.Status = string.IsNullOrWhiteSpace(vendor.Status) ? "Pending" : vendor.Status;
            _vendors.Add(vendor);
        }

        public void UpdateVendor(Vendor vendor)
        {
            var existingVendor = _vendors.FirstOrDefault(v => v.Id == vendor.Id);
            if (existingVendor != null)
            {
                existingVendor.VendorCode = vendor.VendorCode;
                existingVendor.Status = vendor.Status;
                existingVendor.Name = vendor.Name;
                existingVendor.BusinessType = vendor.BusinessType;
                existingVendor.TaxId = vendor.TaxId;
                existingVendor.RegistrationDate = vendor.RegistrationDate;
                existingVendor.Address = vendor.Address;
                existingVendor.City = vendor.City;
                existingVendor.Country = vendor.Country;
                existingVendor.PostalCode = vendor.PostalCode;
                existingVendor.PhoneNumber = vendor.PhoneNumber;
                existingVendor.Email = vendor.Email;
                existingVendor.BankName = vendor.BankName;
                existingVendor.AccountName = vendor.AccountName;
                existingVendor.AccountNumber = vendor.AccountNumber;
                existingVendor.Currency = vendor.Currency;
                existingVendor.PaymentTerms = vendor.PaymentTerms;
                existingVendor.Comments = vendor.Comments;
            }
        }

        public void DeleteVendor(int id)
        {
            var vendor = _vendors.FirstOrDefault(v => v.Id == id);
            if (vendor != null)
            {
                _vendors.Remove(vendor);
            }
        }

        public IEnumerable<Vendor> Search(string? query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return _vendors;
            }

            query = query.Trim().ToLowerInvariant();
            return _vendors.Where(v =>
                (v.VendorCode ?? string.Empty).ToLowerInvariant().Contains(query) ||
                (v.Name ?? string.Empty).ToLowerInvariant().Contains(query) ||
                (v.BusinessType ?? string.Empty).ToLowerInvariant().Contains(query) ||
                (v.Country ?? string.Empty).ToLowerInvariant().Contains(query));
        }

        private void SeedData()
        {
            AddVendor(new Vendor
            {
                VendorCode = "VND-2024-001",
                Status = "Active",
                Name = "Tech Solutions Inc.",
                BusinessType = "IT Services",
                TaxId = "TAX123456789",
                RegistrationDate = new DateTime(2024, 1, 15),
                Email = "contact@techsolutions.com",
                PhoneNumber = "+1-555-0101",
                Address = "123 Tech Street, San Francisco, USA 94102",
                City = "San Francisco",
                Country = "USA",
                PostalCode = "94102",
                BankName = "Chase Bank",
                AccountName = "Tech Solutions Inc.",
                AccountNumber = "9876543210",
                Currency = "USD - US Dollar",
                PaymentTerms = "Net 30"
            });

            AddVendor(new Vendor
            {
                VendorCode = "VND-2024-002",
                Status = "Active",
                Name = "Global Supplies Ltd.",
                BusinessType = "Office Supplies",
                TaxId = "TAX998877665",
                RegistrationDate = new DateTime(2024, 2, 5),
                Email = "hello@globalsupplies.com",
                PhoneNumber = "+1-555-0102",
                Address = "56 Warehouse Ave, Austin, USA 78701",
                City = "Austin",
                Country = "USA",
                PostalCode = "78701",
                BankName = "Wells Fargo",
                AccountName = "Global Supplies Ltd.",
                AccountNumber = "5678901234",
                Currency = "USD - US Dollar",
                PaymentTerms = "Net 30"
            });

            AddVendor(new Vendor
            {
                VendorCode = "VND-2024-003",
                Status = "Active",
                Name = "Manufacturing Pro",
                BusinessType = "Manufacturing",
                TaxId = "TAX555444333",
                RegistrationDate = new DateTime(2024, 3, 22),
                Email = "info@manufacturingpro.com",
                PhoneNumber = "+1-555-0103",
                Address = "88 Industrial Park, Chicago, USA 60601",
                City = "Chicago",
                Country = "USA",
                PostalCode = "60601",
                BankName = "Bank of America",
                AccountName = "Manufacturing Pro",
                AccountNumber = "1234509876",
                Currency = "USD - US Dollar",
                PaymentTerms = "Net 45"
            });

            AddVendor(new Vendor
            {
                VendorCode = "VND-2024-004",
                Status = "Inactive",
                Name = "Logistics Express",
                BusinessType = "Logistics",
                TaxId = "TAX222333444",
                RegistrationDate = new DateTime(2024, 4, 12),
                Email = "contact@logisticsexpress.com",
                PhoneNumber = "+1-555-0104",
                Address = "5 Harbor Road, Seattle, USA 98101",
                City = "Seattle",
                Country = "USA",
                PostalCode = "98101",
                BankName = "Citi Bank",
                AccountName = "Logistics Express",
                AccountNumber = "4567801239",
                Currency = "USD - US Dollar",
                PaymentTerms = "Net 60"
            });

            AddVendor(new Vendor
            {
                VendorCode = "VND-2024-005",
                Status = "Pending",
                Name = "Consulting Partners",
                BusinessType = "Consulting",
                TaxId = "TAX111222333",
                RegistrationDate = new DateTime(2024, 5, 2),
                Email = "hello@consultingpartners.com",
                PhoneNumber = "+1-555-0105",
                Address = "77 Market Street, New York, USA 10005",
                City = "New York",
                Country = "USA",
                PostalCode = "10005",
                BankName = "Capital One",
                AccountName = "Consulting Partners",
                AccountNumber = "8901234567",
                Currency = "USD - US Dollar",
                PaymentTerms = "Net 30"
            });
        }
    }
}
