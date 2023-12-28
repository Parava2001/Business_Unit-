using businessUnit.component.EfCore;
using businessUnit.EFCore;
using businessUnit.Model;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessUnitTests.Controller
{
    public class businessUnitTest
    {

 [Fact]
        public void businessUnitController_Get_ReturnOk()
        {
            //Arrange 
            var dbContextOptions = new DbContextOptionsBuilder<EF_DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())    // using of InMemory package
                .Options;

            var context = new EF_DataContext(dbContextOptions);
            var db = new DbHelper(context);

            // So Addding Test-Data in the testing in-Memory DataBase

            context.businessUnits.Add(new businessUnits

            {
                id = 1,
                CustomerName = "Alby",
                BusinessUnit = "AJ",
                BusinessUnitName = "AJ1",
                Vertical = "FFC",
                Channel = "KKKK",
                SynapseCustomer = "Joseph",
                Status = false,
                InactiveDate = "0909"
            });

            context.SaveChanges();
            //Act 
            var result = db.GetBusinessUnits();

            //Assert
            var businessUnitModel = result.First();
            Assert.NotNull(businessUnitModel);
            Assert.Equal(1, businessUnitModel.id);
            Assert.Equal("Alby", businessUnitModel.CustomerName);
            Assert.False(businessUnitModel.Status);
            // Ensure that other fields are checked .

        }

        [Fact]

        public void businessUnitController_Post_ReturnsPost()
        {
            // Arrange 

            var dbContextOptions = new DbContextOptionsBuilder<EF_DataContext>()
                 .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                 .Options;

            var context = new EF_DataContext(dbContextOptions);
            var db = new DbHelper(context);
            // So Addding Test-Data in the testing in-Memory DataBase

            var details = new businessUnitModel
            {
                id = 2,
                CustomerName = "Alby",
                BusinessUnit = "AJ",
                BusinessUnitName = "AJ1",
                Vertical = "FFC",
                Channel = "KKKK",
                SynapseCustomer = "Joseph",
                Status = false,
                InactiveDate = "0909"
            };

            //Act 
            db.SaveOrder(details);
            var result = db.GetBusinessUnits();
            Console.WriteLine(result);

            //Assert 
            var postData = result.First();
            Assert.NotNull(postData);
            Assert.Equal(details.CustomerName, postData.CustomerName);
            Assert.Equal(details.Vertical, postData.Vertical);
            Assert.Equal("AJ", postData.BusinessUnit);
            Assert.False(postData.Status);
        }


        [Fact]
        public void businessUnitController_Patch_ReturnsPatch()
        {

            //Arrange
          var dbContenxtOptions = new DbContextOptionsBuilder<EF_DataContext>()
             .UseInMemoryDatabase (databaseName: Guid.NewGuid().ToString())
             .Options;

            var context = new EF_DataContext (dbContenxtOptions);
            var db = new DbHelper(context);


            context.businessUnits.Add(new businessUnits
            {
                id = 3,
                CustomerName = "Alby",
                BusinessUnit = "AJ",
                BusinessUnitName = "AJ1",
                Vertical = "FFC",
                Channel = "KKKK",
                SynapseCustomer = "Joseph",
                Status = false,
                InactiveDate = "0909"
            });
            context.SaveChanges();

            var patchDetails = new businessUnitModel
            {
                id = 3,
                CustomerName = "Alby",
                BusinessUnit = "AJ",
                BusinessUnitName = "AJ1",
                Vertical = "FFFFF",
                Channel = "KKKK",
                SynapseCustomer = "Joseph",
                Status = true,
                InactiveDate = "0909"
            };

            //Act
            db.EditLocation(3, patchDetails);
            var result = db.GetBusinessUnits();

            //Assert
            var EditedData = result.First();
            Assert.Equal("Alby" , EditedData.CustomerName);
            Assert.Equal("KKKK" , EditedData.Channel);
            Assert.NotEqual("FFC", EditedData.Vertical);
            Assert.True(result.Any());  

        }

        
    }

}
