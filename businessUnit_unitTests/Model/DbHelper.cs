using businessUnit.component.EfCore;
using businessUnit.EFCore;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;

namespace businessUnit.Model
{
    public class DbHelper
    {
        private EF_DataContext context;
        public DbHelper(EF_DataContext context) // constructor
        {
            this.context = context;
        }


        // Get Process
        public List<businessUnitModel> GetBusinessUnits()
        {
            List<businessUnitModel> response = new List<businessUnitModel>(); // assiging the response businessUnitModel 
            var dataList = context.businessUnits.ToList();
            dataList.ForEach(row => response.Add(new businessUnitModel()
            {
                id = row.id,
                CustomerName = row.CustomerName,
                BusinessUnit = row.BusinessUnit,
                BusinessUnitName = row.BusinessUnitName,
                Vertical = row.Vertical,
                Channel = row.Channel,
                SynapseCustomer = row.SynapseCustomer,
                Status = row.Status,
                InactiveDate = row.InactiveDate


            }));
            return response;
        }


        public businessUnitModel GetBusinessUnitsById(int id)
        {
            businessUnitModel response = new businessUnitModel();
            var row = context.businessUnits.Where(d => d.id.Equals(id)).FirstOrDefault(); // .Where is LINQ query
            return new businessUnitModel()
            {
                id = row.id,
                CustomerName = row.CustomerName,
                BusinessUnit = row.BusinessUnit,
                BusinessUnitName = row.BusinessUnitName,
                Vertical = row.Vertical,
                Channel = row.Channel,
                SynapseCustomer = row.SynapseCustomer,
                Status = row.Status,
                InactiveDate = row.InactiveDate



            };
        }
        //POST
        public void SaveOrder(businessUnitModel details)
        {
            businessUnits dbTable = new businessUnits();

            dbTable.id = details.id;
            dbTable.CustomerName = details.CustomerName;
            dbTable.BusinessUnit = details.BusinessUnit;
            dbTable.BusinessUnitName = details.BusinessUnitName;
            dbTable.Vertical = details.Vertical;
            dbTable.Channel = details.Channel;
            dbTable.SynapseCustomer = details.SynapseCustomer;
            dbTable.Status = details.Status;
            dbTable.InactiveDate = details.InactiveDate;

            context.businessUnits.Add(dbTable);   // .Add is LINQ query
            context.SaveChanges();
        }

        //PATCH

        public void EditLocation(int id,businessUnitModel details)
        {
            businessUnits edit = new businessUnits();

            edit = context.businessUnits.Where(d => d.id.Equals(id)).FirstOrDefault();

            if (edit != null)
            {
                edit.CustomerName = details.CustomerName;

                edit.BusinessUnit = details.BusinessUnit;

                edit.BusinessUnitName = details.BusinessUnitName;

                edit.Vertical = details.Vertical;

                edit.Channel = details.Channel;

                edit.SynapseCustomer = details.SynapseCustomer;
                
                edit.Status = details.Status;
                
                edit.InactiveDate = details.InactiveDate;

                context.SaveChanges(); // SaveChanges() is one of two techniques for saving changes to the database with EF.
                                       // With this method, you perform one or more tracked changes (add, update, delete), and then apply those changes by calling the SaveChanges method
            }
            else
            {
                Console.WriteLine("null");
            }
        
        }




        public void DeleteUnits(int id)
        {
            var row = context.businessUnits.Where(d => d.id.Equals(id)).FirstOrDefault();  // .Where , .Equals , .FirstOrDefault are all LINQ querys
            if (row != null)
            {
                context.businessUnits.Remove(row);
                context.SaveChanges();
            }
        }
    }
}